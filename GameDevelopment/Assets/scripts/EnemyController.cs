using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rb;
    public float respawnTime = 1.0f;
    public float LifeTime = 10.0f;
    public float MoveSpeed = 0.1f;
    public float EnemyStartY = 10f;
    private Vector2 screenBounds;
    Vector3 RotationAngle;
   

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = this.GetComponent<Rigidbody>();
        StartCoroutine(EnemyMover());
        StartCoroutine(EnemyLifetime());
        RotationAngle = new Vector3(0, 210, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.y > screenBounds.y * 0.9f)
        {
            rb.velocity = new Vector3(0, -2, 0);
        }

        //Rotiert den Gegner bei Bewegung
        if (rb.velocity.x > 0f)
        {
            Quaternion deltaRotation = Quaternion.Euler(rb.rotation * -RotationAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, deltaRotation, 0.05f);
        }

        if (rb.velocity.x < 0f)
        {
            Quaternion deltaRotation = Quaternion.Euler(rb.rotation * RotationAngle);   
            transform.rotation = Quaternion.Slerp(transform.rotation, deltaRotation, 0.05f);
        }
    }

    private void MoveEnemy()
    {
        MoveSpeed = Random.Range(2f, -2f);

        rb.velocity = new Vector3(MoveSpeed, 0, 0);

        if (transform.position.x < (-screenBounds.x + 1))
        {
            rb.velocity = new Vector3(+2, 0, 0);
        }

        if (transform.position.x > (screenBounds.x - 1))
        {
            rb.velocity = new Vector3(-2, 0, 0);
        }

    


    }


    IEnumerator EnemyMover()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            MoveEnemy();
        }
    }

    IEnumerator EnemyLifetime()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rb;
    public SpawnDeathAnimation AnimationSpawner;
    public float respawnTime = 1.0f;
    public float MoveSpeed = 0.1f;
    public float EnemyStartY = 10f;
    public int Health = 100;
    public bool CanBeAttacked;

    private Vector2 screenBounds;

    Vector3 RotationAngleLeft;
    Vector3 RotationAngleRight;
    Vector3 StopAngle;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = this.GetComponent<Rigidbody>();
        StartCoroutine(EnemyMover());
        CanBeAttacked = false;
        RotationAngleLeft = new Vector3(-90, 50, 0);
        RotationAngleRight = new Vector3(-90, -40, 0);
        StopAngle = new Vector3(-90, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.y >= screenBounds.y * 0.8f)
        {
            rb.velocity = new Vector3(0, -2, 0);
            
        }
        else
        {
            //Gegner kann erst angegriffen werden, wenn er eine bestimmte Position auf dem Bildschirm erreicht
            CanBeAttacked = true;
        }
        

        //Rotiert den Gegner bei Bewegung
        if (rb.velocity.x > 0.2f)
        {
            Quaternion RotationRight = Quaternion.Euler(RotationAngleRight);
            transform.rotation = Quaternion.Slerp(transform.rotation, RotationRight, 0.2f);
        }

        if (rb.velocity.x < -0.2f)
        {
            Quaternion RotationLeft = Quaternion.Euler(RotationAngleLeft);
            transform.rotation = Quaternion.Slerp(transform.rotation, RotationLeft, 0.2f);
        }

        if (rb.velocity.x > -0.2f && rb.velocity.x < 0.2f)
        {

            Quaternion StopDeltaRotation = Quaternion.Euler(StopAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, StopDeltaRotation, 0.2f);

        }

    }

    private void MoveEnemy()
    {
        MoveSpeed = Random.Range(2f, -2f);
        
        rb.velocity = new Vector3(MoveSpeed, 0, 0);

        if (transform.position.x < (-screenBounds.x + 2))
        {
            rb.velocity = new Vector3(+2, 0, 0);
        }

        if (transform.position.x > (screenBounds.x - 2))
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

    public void TakeDamage(int damage)
    {
        if (CanBeAttacked == true)
        {
            Health -= damage;

            if (Health <= 0)
            {
                
                Die();
            }
        }
    }

    public void Die()
    {
        //Hier Todesanimation abspielen
        AnimationSpawner.spawnAniamtion(transform.position); 
        Destroy(this.gameObject);
    }




}

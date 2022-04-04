using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpeed = 5f;
    public Rigidbody rb;
    private Vector2 screenBounds;
    asteroidController asteroid;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, BulletSpeed);

        //Asteroid wird zerstört wenn er außerhalb des Bildschirms ist
        if (transform.position.y > screenBounds.y * 2)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        //Spiel wird gestoppt bei Kollision mit Asteroid
        asteroidController asteroid = collision.GetComponent<asteroidController>();
        EnemyController enemy = collision.GetComponent<EnemyController>();
        //collision.gameObject.tag == "Spawnable";
        if (asteroid != null || enemy != null)
        {
            Debug.Log(collision.name);
            Destroy(gameObject);

        }

    }



}

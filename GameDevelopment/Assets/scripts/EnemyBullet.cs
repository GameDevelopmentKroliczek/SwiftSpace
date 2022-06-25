using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float BulletSpeed = -5f;
    public Rigidbody rb;
    private Vector2 screenBounds;
    asteroidController asteroid;
    public int Damage = 1;
    public GameObject ShotAnimation;
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
        if (transform.position.y < -screenBounds.y * 2)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider PlayerHit)
    {
        //Spiel wird gestoppt bei Kollision mit Asteroid
       // asteroidController asteroid = AsteroidHit.GetComponent<asteroidController>();
        PlayerMouseController player = PlayerHit.GetComponent<PlayerMouseController>();
 
        if (player != null)
        {        
            player.GetHit(Damage);
            Die();
        }
    }

    private void Die()
    {
        Instantiate(ShotAnimation, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), Quaternion.identity);
        Destroy(this.gameObject);
    }


}

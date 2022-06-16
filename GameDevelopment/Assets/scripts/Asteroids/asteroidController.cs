using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

    public PlayerMouseController player;
    public SpawnDeathAnimation AnimationSpawner;
    public float speed = 5f;
    private Rigidbody rb;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        //Asteroid wird auf zufälliger Geschwindigkeit gespawnt
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(Random.Range(-speed * 0.2f, speed * 0.2f), Random.Range(-speed, -speed * 2));
        rb.transform.localScale = transform.localScale * Random.Range(.2f, .5f);
        // Zufällige Rotation einbauen
        rb.transform.localEulerAngles = new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f));
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void OnTriggerEnter(Collider other)
    {
        //Spieler erleidet Schaden wenn er den Asteroiden berührt
        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            Die();
            player.GetHit();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Asteroid wird zerstört wenn er außerhalb des Bildschirms ist
        if (transform.position.y < screenBounds.y * -2)
        {
            Destroy(this.gameObject);
        }
    }

    private void Die()
    {
        AnimationSpawner.spawnAniamtion();
        Destroy(this.gameObject);
    }
}

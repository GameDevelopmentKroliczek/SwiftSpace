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
    public int Damage = 1;
    public int MaxHealth;
    private int CurrentHealth;
    public ScoreCounter Score;
    public GameObject BonusPoint;
    private bool CanBeHit = false;

    // Start is called before the first frame update
    void Start()
    {
        //Asteroid wird auf zuf�lliger Geschwindigkeit gespawnt
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(Random.Range(-speed * 0.2f, speed * 0.2f), Random.Range(-speed, -speed * 2));
        rb.transform.localScale = transform.localScale * Random.Range(.2f, .5f);
        // Zuf�llige Rotation einbauen
        rb.transform.localEulerAngles = new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f));
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Score = FindObjectOfType<ScoreCounter>();
        CurrentHealth = MaxHealth;
        player = FindObjectOfType<PlayerMouseController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Spieler erleidet Schaden wenn er den Asteroiden ber�hrt
        PlayerMouseController player = other.GetComponent<PlayerMouseController>();
        Shield shield = other.GetComponent<Shield>();

        if (player != null)
        {
            Die();
            player.GetHit(Damage);
        }
        if (shield != null)
        {
            Die();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Asteroid wird zerst�rt wenn er au�erhalb des Bildschirms ist
        if (transform.position.y < screenBounds.y * -2)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y < screenBounds.y )
        {
            if(!CanBeHit)
            CanBeHit = true;
        }


    }

    private void Die()
    {
        AnimationSpawner.spawnAniamtion(transform.position);
        player.OnKill(BonusPoint);
        Score.ScoreAddAsteroid();
        Destroy(this.gameObject);
    }

    public void GetHit(int Damage)
    {
        if (CanBeHit)
        {
            CurrentHealth -= Damage;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
    }
}

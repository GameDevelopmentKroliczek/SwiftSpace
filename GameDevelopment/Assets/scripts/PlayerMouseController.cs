using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    Rigidbody rb;
    asteroidController asteroid;
    public float YPosition = 0f;
    public float XPosition = 0f;
    public float ZPosition = 0f;
    public float AttackSpeed = 1f;
    Object BulletRef;
    public bool isPlaying = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //UI_EndScreen endScreen = gameObject.GetComponent<UI_EndScreen>();
        isPlaying = true;

        //L‰d den Angriff aus dem Ordner Resources und startet Coroutine zum schieﬂen
        BulletRef = Resources.Load("PlayerAttack");
        StartCoroutine(Shooting());
    }

    public void FixedUpdate()
    {
        //Playerposition wird auf Mausposition gesetzt, Z-Position bleibt 0
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        if (isPlaying == true)
        {
            rb.transform.position = mousePos;
        }

    }

    public void PlayerAttack()
    {
        //Spawnt einen Schuss an der Position des Spielers
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + 1, rb.transform.position.z);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            //aktiviert die Funktion zum spawnen des Schusses alle "AttackSpeed" Sekunden
            yield return new WaitForSeconds(AttackSpeed);
            PlayerAttack();
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        //Spiel wird gestoppt bei Kollision mit Asteroid
        asteroidController asteroid = collider.GetComponent<asteroidController>();
        //collision.gameObject.tag == "Spawnable";
        if (asteroid != null)
        {
            isPlaying = false;
            Time.timeScale = 0f;
           // TriggerEndscreen();

        }

    }
}


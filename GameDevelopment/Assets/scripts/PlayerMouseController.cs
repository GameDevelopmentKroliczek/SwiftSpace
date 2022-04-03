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
    private Vector2 screenBounds;


    Vector3 RotationAngle;
    public float  Velocity;
    public Quaternion RotatePlayer;
    public Vector3 RotaionAngle;
    public Vector3 StopAngle;
    public Vector3 lastMousePosition;
    public float MousePosX;
   

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //UI_EndScreen endScreen = gameObject.GetComponent<UI_EndScreen>();
        isPlaying = true;

        //L‰d den Angriff aus dem Ordner Resources und startet Coroutine zum schieﬂen
        BulletRef = Resources.Load("PlayerAttack");
        StartCoroutine(Shooting());

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        RotationAngle = new Vector3(0, 210, 180);
        StopAngle = new Vector3(0, 180, 180);
        MousePosX = lastMousePosition.x;

    }

    public void Update()
    {
        {
            if (Input.mousePosition != lastMousePosition)
            {
                lastMousePosition = Input.mousePosition;
                WhenMouseIsMoving();
            }
            else
                WhenMouseIsntMoving();
        }
    }

    public void WhenMouseIsMoving()
    {
    //Playerposition wird auf Mausposition gesetzt, Z-Position bleibt 0
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        if (isPlaying == true)
        {
            //Spielerposition wird mit Mausposition gleichgesetzt
            rb.transform.position = mousePos;


            //Berechnet die Entfernung des Spielers zum Mittelpunkt des Screens
            Velocity = rb.position.x;
            //Dreht den Spieler um die Entfernung in Grad
            if (Velocity  < MousePosX + 0.1f)
            {
                Quaternion deltaRotation = Quaternion.Euler(RotationAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, deltaRotation, 0.1f);  
            }

            if (Velocity  > MousePosX - 0.1f)
            {
                Quaternion deltaRotation = Quaternion.Euler( -RotationAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, deltaRotation, 0.1f);
            }
        }
        
    }

    public void WhenMouseIsntMoving()
    {
        //Dreht den Spieler um die Entfernung in Grad
       
            Quaternion StopDeltaRotation = Quaternion.Euler(StopAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, StopDeltaRotation, 0.01f);
        

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


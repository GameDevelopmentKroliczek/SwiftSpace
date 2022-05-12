using System.Collections;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    public UI_Endscreen endscreen;
    public PlayerHealth playerhealth;
    public Shield ShieldObject;
    public LaserScript Laser;

    Rigidbody rb;
    asteroidController asteroid;
    public float YPosition = 0f;
    public float XPosition = 0f;
    public float ZPosition = 0f;
    public bool isPlaying = false;
    public bool CanTakeDamage = false;
    private Vector2 screenBounds;
 

    //PlayerModels
    public GameObject PlayerNoDamage;
    public GameObject PlayerMediumDamage;
    public GameObject PlayerHighDamage;

    Vector3 RotationAngleLeft;
    Vector3 RotationAngleRight;
    Vector3 StopAngle;
    public Vector3 lastMousePosition;
    public float lastMousePosX;
    Vector3 MousePosition;

    public int MaxHealth;
    public int CurrentHealth;

    public int DamageCooldownTime = 3;

    //Weapon Variables
    public float Attackspeed;
    public bool DoubleShot = false;
    public bool SingleShot = false;
    public float DoubleShotTimer = 5f;
    public float LaserTime = 5f;
    public bool AttackspeedIsLimited = false;
    public bool PlayerCanShoot = false;


    
    public bool ActivateLaser = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //UI_EndScreen endScreen = gameObject.GetComponent<UI_EndScreen>();
        isPlaying = true;
        CanTakeDamage = true;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        RotationAngleLeft = new Vector3(0, 220, 180);
        RotationAngleRight = new Vector3(0, 140, 180);
        StopAngle = new Vector3(0, 180, 180);

        CurrentHealth = MaxHealth;
        playerhealth.SetMaxHealth(MaxHealth);

        //Single Shot mit der Angriffsgeschwindigkeit Attackspeed/Sekunde
        Attackspeed = 0.5f;
        DoubleShot = false;
        SingleShot = true;
        AttackspeedIsLimited = false;
        PlayerCanShoot = true; ;
        ActivateLaser = false;
       
    }

    public void Update()
    {

        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.y = -2f;
        MousePosition.z = 0f;
        if (isPlaying == true)
        {
            //Spielerposition wird mit Mausposition gleichgesetzt
            rb.transform.position = MousePosition;

            lastMousePosX = lastMousePosition.x;
            //Dreht den Spieler um die Entfernung in Grad
            if (Input.GetAxis("Mouse X") < -0.1)
            {
                Quaternion RotationLeft = Quaternion.Euler(RotationAngleLeft);
                transform.rotation = Quaternion.Slerp(transform.rotation, RotationLeft, 0.1f);
            }

            if (Input.GetAxis("Mouse X") > 0.1)
            {
                Quaternion RotationRight = Quaternion.Euler(RotationAngleRight);
                transform.rotation = Quaternion.Slerp(transform.rotation, RotationRight, 0.1f);
            }

            //Dreht den Spieler um wieder gerade wenn sich die Maus nicht bewegt
            if (Input.GetAxis("Mouse X") > -0.1 && Input.GetAxis("Mouse X") < 0.1)
            {
                Quaternion StopDeltaRotation = Quaternion.Euler(StopAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, StopDeltaRotation, 0.1f);
            }

        }

        //Ändert PlayerModel je nach Schadenswert
        if(CurrentHealth == MaxHealth)
        {
            PlayerNoDamage.gameObject.SetActive(true);
            PlayerMediumDamage.gameObject.SetActive(false);
            PlayerHighDamage.gameObject.SetActive(false);
        }

        if (CurrentHealth == MaxHealth -1)
        {
            PlayerMediumDamage.gameObject.SetActive(true);
            PlayerNoDamage.gameObject.SetActive(false);
            PlayerHighDamage.gameObject.SetActive(false);
        }

        if (CurrentHealth == MaxHealth - 2)
        {
            PlayerHighDamage.gameObject.SetActive(true);
            PlayerNoDamage.gameObject.SetActive(false);
            PlayerMediumDamage.gameObject.SetActive(false);
        }

        //AttackspeedLimit
        if(Attackspeed <= 0.1f && AttackspeedIsLimited == true)
        {
            Attackspeed = 0.1f;
        }

    }

    //Aktiviert den GameOver Screen
    public void TriggerEndscreen()
    {
        endscreen.ShowEndScreen();
    }

    public void GetHit()
    {
        if (CanTakeDamage == true)
        {
            CurrentHealth -= 1;
            playerhealth.SetHealth(CurrentHealth);
            CanTakeDamage = false;
            StartCoroutine(DamageCooldown());

            if (CurrentHealth <= 0)
            {
                isPlaying = false;
                Time.timeScale = 0f;
                TriggerEndscreen();
            }
        }
    }

    //Spieler kann nur alle "DamageCoolDownTime" Sekunden Schaden erleiden
    IEnumerator DamageCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(DamageCooldownTime);
            CanTakeDamage = true;
        }
    }

    //Spieler bekommt ein Leben zurück
    public void Heal()
    {

        CurrentHealth += 1;
        playerhealth.SetHealth(CurrentHealth);

        if (CurrentHealth > MaxHealth)
        {

            CurrentHealth = MaxHealth;
            playerhealth.SetHealth(CurrentHealth);
        }
        Debug.Log(CurrentHealth);
    }

    //SchildPrefab wird aktiviert
    public void ActivateShield()
    {
        ShieldObject.gameObject.SetActive(true);
    }

    //Doppelschuss hält für "DoubleShotTimer" Sekunden
    public void StartDoubleShotTimer()
    {
       
            StartCoroutine(DoubleShotTime());
        
    }

    public void RevertShots()
    {
        SingleShot = true;
        DoubleShot = false;
        StopCoroutine(DoubleShotTime());
    }

    public IEnumerator DoubleShotTime()
    {
        

        while (true)
        {
           

            yield return new WaitForSeconds(DoubleShotTimer);
            RevertShots();

            
        }
    }

    //LaserPickup


    public void ActivateLaserWeapon()
    {
       
        PlayerCanShoot = false;
        Laser.gameObject.SetActive(true);
       
            StartCoroutine(LaserTimer());
       
    }

    public void DeactivateLaser()
    {
        PlayerCanShoot = true;
        Laser.gameObject.SetActive(false);
        StopCoroutine(LaserTimer());
    }

    private IEnumerator LaserTimer()
    {
      
        while (true)
        {
            
            yield return new WaitForSeconds(LaserTime);
            DeactivateLaser();
           

        }
    }

  

}


using System.Collections;
using UnityEngine;
using EZCameraShake;

public class PlayerMouseController : MonoBehaviour
{
    public UI_Endscreen endscreen;
    public PlayerHealth playerhealth;
    public GameObject ShieldObject;
    public LaserScript Laser;
    public GameObject weapon;
    public GameObject weapon_DoubleShot;
    public GameObject Healthbar;
    public GameObject CriticalHealthOverlay;
    public GameObject PlayerModels;
    public GameObject smokeLight;
    public GameObject smokeStrong;

    Rigidbody rb;
    asteroidController asteroid;
    public float YPosition = 0f;
    public float XPosition = 0f;
    public float ZPosition = 0f;
    public bool isPlaying = false;
    public bool CanTakeDamage = false;
    private Vector2 screenBounds;
 

    //PlayerModels
   

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
    public bool PlayerCanShoot = false;
    public float DoubleShotTime = 5f;
    public bool ActivateLaser = false;

    public void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        //UI_EndScreen endScreen = gameObject.GetComponent<UI_EndScreen>();
        isPlaying = true;
        CanTakeDamage = true;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        RotationAngleLeft = new Vector3( 90, 210, 0);
        RotationAngleRight = new Vector3(90, 150, 0);
        StopAngle = new Vector3(90, 180, 0);

        CurrentHealth = MaxHealth;
        playerhealth.SetMaxHealth(MaxHealth);

        //Single Shot mit der Angriffsgeschwindigkeit Attackspeed/Sekunde
        Attackspeed = 0.5f;
        DoubleShot = false;
        SingleShot = true;
        PlayerCanShoot = true; ;
        ActivateLaser = false;

        weapon.gameObject.SetActive(true);
        weapon_DoubleShot.gameObject.SetActive(false);

        Cursor.visible = false;
        
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
            Healthbar.GetComponent<Animator>().enabled = false;
            CriticalHealthOverlay.gameObject.SetActive(false);
            smokeLight.gameObject.SetActive(false);
            smokeStrong.gameObject.SetActive(false);

        }

        if (CurrentHealth == MaxHealth -1)
        {
            Healthbar.GetComponent<Animator>().enabled = false;
            CriticalHealthOverlay.gameObject.SetActive(false);
            smokeLight.gameObject.SetActive(true);
            smokeStrong.gameObject.SetActive(false);
        }

        if (CurrentHealth == MaxHealth - 2)
        {
            Healthbar.GetComponent<Animator>().enabled = true;
            if (ShieldObject.active == true)
            {
                CriticalHealthOverlay.gameObject.SetActive(false);
            }
            CriticalHealthOverlay.gameObject.SetActive(true);
            smokeLight.gameObject.SetActive(false);
            smokeStrong.gameObject.SetActive(true);

        }


    }

    //Aktiviert den GameOver Screen
    public void TriggerEndscreen()
    {
        endscreen.ShowEndScreen();
    }

    public void GetHit( int damage)
    {
        if (CanTakeDamage == true)
        {
            CurrentHealth -= damage;
            playerhealth.SetHealth(CurrentHealth);
            CanTakeDamage = false;
            StartCoroutine(DamageCooldown());
            CameraShaker.Instance.ShakeOnce(2f, 5f, 0.1f, 1f);
            FindObjectOfType<AudioManager>().PlaySound("HitSound");
            Attackspeed = 0.5f;

            if (CurrentHealth <= 0)
            {
                isPlaying = false;
                Time.timeScale = 0f;
                TriggerEndscreen();
                FindObjectOfType<AudioManager>().PlaySound("GameOver");
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
        FindObjectOfType<AudioManager>().PlaySound("Heal");
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
        ShieldObject.SetActive(true);
    }

    //Doppelschuss hält für "DoubleShotTimer" Sekunden
    public void ActivateDoubleShot()
    {
        SingleShot = false;
        DoubleShot = true;
        weapon.gameObject.SetActive(false);
        weapon_DoubleShot.gameObject.SetActive(true);

    }

    public void RevertShots()
    {
        SingleShot = true;
        DoubleShot = false;
        weapon.gameObject.SetActive(true);
        weapon_DoubleShot.gameObject.SetActive(false);
    }


    //LaserPickup
    public void ActivateLaserWeapon()
    {   
        PlayerCanShoot = false;
        Laser.gameObject.SetActive(true);
        Laser.StartCoroutine();
        weapon.gameObject.SetActive(false);
        
    }

    public void DestroyLaser()
    {
        PlayerCanShoot = true;
        Laser.gameObject.SetActive(false);
        weapon.gameObject.SetActive(true);
    }

    public void OnKill(GameObject BonusPoint)
    {
        Instantiate(BonusPoint, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z - 0.5f), Quaternion.identity);
    }
    
}


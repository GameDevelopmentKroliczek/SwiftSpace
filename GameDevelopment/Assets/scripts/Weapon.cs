using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject BulletRef;
    public float AttackSpeed;
    public float ModifiedAS;

    public Transform firePoint;
    private Vector2 screenBounds;

    public bool singleAttack = false;
    public bool doubleAttack = false; 

    public void Awake()
    {
        singleAttack = true;
        doubleAttack = false;

        AttackSpeed = 0.5f;
        StartCoroutine(Shooting());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ModifiedAS = AttackSpeed;
    }

    public void UpdateShots()
    {
        singleAttack = false;

        doubleAttack = true;
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            //aktiviert die Funktion zum spawnen des Schusses alle "AttackSpeed" Sekunden
            yield return new WaitForSeconds(AttackSpeed);

            if(singleAttack == true)
            {
                PlayerAttackSingle();
            }

            if (doubleAttack == true)
            {
                PlayerAttackDouble();
            }

        }
    }

   

    public void PlayerAttackSingle()
    {
        //Spawnt einen Schuss an der Position des Spielers
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, 0);
    }

    public void PlayerAttackDouble()
    {
        GameObject DoubleBullet1 = (GameObject)Instantiate(BulletRef);
        DoubleBullet1.transform.position = new Vector3(firePoint.transform.position.x + 0.2f , firePoint.transform.position.y, 0);
        GameObject DoubleBullet2 = (GameObject)Instantiate(BulletRef);
        DoubleBullet2.transform.position = new Vector3(firePoint.transform.position.x - 0.2f , firePoint.transform.position.y, 0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject BulletRef;
    public float AttackSpeed = 1f;
    public Transform firePoint;
    private Vector2 screenBounds;

    public void Start()
    {
        
        StartCoroutine(Shooting());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    IEnumerator Shooting()
    {
        while (true)
        {
            //aktiviert die Funktion zum spawnen des Schusses alle "AttackSpeed" Sekunden
            yield return new WaitForSeconds(AttackSpeed);
            EnemyAttack();
            FindObjectOfType<AudioManager>().PlaySound("EnemyShot");
        }
    }


    public void EnemyAttack()
    {
        //Spawnt einen Schuss an der Position des Spielers
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, 0);
    }

}

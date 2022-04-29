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


    public void Start()
    {

        AttackSpeed = 0.5f;
        StartCoroutine(Shooting());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ModifiedAS = AttackSpeed;
    }

    public void UpdateAttackSpeed()
    {
        ModifiedAS = AttackSpeed * 0.8f;
        
    }

    public void Update()
    {
        AttackSpeed = ModifiedAS;
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


    public void PlayerAttack()
    {
        //Spawnt einen Schuss an der Position des Spielers
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, 0);
    }

}

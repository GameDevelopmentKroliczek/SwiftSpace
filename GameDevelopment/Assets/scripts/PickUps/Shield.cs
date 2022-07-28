using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldOverlay;
    public float ShieldTimer = 15f;

    public void OnEnable()
    {
        StartCoroutine(ShieldTime());
        ShieldOverlay.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().PlaySound("Shield");
    }


    private void OnTriggerEnter(Collider other)
    {
        //Schild wird Zerstört bei Kollision mit Asteroid oder gegnerischem Schuss
        asteroidController asteroid = other.GetComponent<asteroidController>();
        EnemyBullet bullet = other.GetComponent<EnemyBullet>();
        ShieldPickUp shieldnew = other.GetComponent<ShieldPickUp>();

        if (asteroid != null || bullet != null)
        {
            FindObjectOfType<AudioManager>().PlaySound("ShieldHit");
            Destroy(other.gameObject);
            DestroyShield();
        }
        if(shieldnew != null)
        {
            Destroy(other.gameObject);
            ShieldTimer += 15f;
            
        }
    }

    IEnumerator ShieldTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShieldTimer);
            DestroyShield();
            
        }
    }




 private void DestroyShield()
    {
        
        ShieldOverlay.gameObject.SetActive(false);
        gameObject.SetActive(false);
       
    }
}

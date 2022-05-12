using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject BulletRef;
    public GameObject LaserRef;
    public PlayerMouseController player;

    public Transform firePoint;
    private Vector2 screenBounds;

    

    public void Start()
    {
        //AttackSpeed = player.Attackspeed;
        StartCoroutine(Shooting());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(player.Attackspeed);

            if (player.PlayerCanShoot == true)
            {
                if (player.SingleShot == true)
                {
                    PlayerAttackSingle();
                }

                if (player.DoubleShot == true)
                {
                    PlayerAttackDouble();
                }
            }
        }
    }

    public void PlayerAttackSingle()
    {
        //Spawnt einen Schuss an der Position des Spielers
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, -0.1f);
    }

    public void PlayerAttackDouble()
    {
        GameObject DoubleBullet1 = (GameObject)Instantiate(BulletRef);
        DoubleBullet1.transform.position = new Vector3(firePoint.transform.position.x + 0.1f , firePoint.transform.position.y, -0.01f);
        GameObject DoubleBullet2 = (GameObject)Instantiate(BulletRef);
        DoubleBullet2.transform.position = new Vector3(firePoint.transform.position.x - 0.1f , firePoint.transform.position.y, -0.01f);
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_DoubleShot : MonoBehaviour
{
    public GameObject DoubleShotRef;
    public PlayerMouseController player;

    public Transform firePoint;
    private Vector2 screenBounds;

    public float DoubleShotTime = 5f;


    public void OnEnable()
    {
        
        StartCoroutine(Shooting());
        StartCoroutine(DoubleShotTimer());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(player.Attackspeed);

            if (player.PlayerCanShoot == true)
            {   

                if (player.DoubleShot == true)
                {
                    PlayerAttackDouble();
                }
            }

            
        }
    }

  

    private IEnumerator DoubleShotTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(DoubleShotTime);

            StopDoubleShots();
        }
    }

    public void StopDoubleShots()
    {   
        player.RevertShots();
        
    }



    public void PlayerAttackDouble()
    {
        GameObject DoubleBullet1 = (GameObject)Instantiate(DoubleShotRef);
        DoubleBullet1.transform.position = new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, -0.1f);

    }

}

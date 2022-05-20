using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public PlayerMouseController player;
    public float LaserTime = 5f;


    public void OnTriggerEnter(Collider EnemyHit)
    {
        //Laser zerstört Gegner mit einem hit
        EnemyController enemy = EnemyHit.GetComponent<EnemyController>();

        if (enemy != null)
        {
            if (enemy.CanBeAttacked = true)
            {
                enemy.Die();
            }
            

        }

    }

    

    public void StartCoroutine()
    {
        StartCoroutine(LaserTimer());
    }


    IEnumerator LaserTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(LaserTime);
            player.DestroyLaser();
        }
    }




   

}


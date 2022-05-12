using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public PlayerMouseController player;
    public float LaserTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserTimer());
    }


    public void OnTriggerEnter(Collider EnemyHit)
    {
        //Laser zerstört Gegner mit einem hit
        EnemyController enemy = EnemyHit.GetComponent<EnemyController>();

        if (enemy != null)
        {
            
            enemy.Die();
            //Destroy(gameObject);

        }

    }

    private IEnumerator LaserTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(LaserTime);

            DeactivateLaser();
        }
    }

    public void DeactivateLaser()
    {
        gameObject.SetActive(false);
        player.PlayerCanShoot = true;
    }
}


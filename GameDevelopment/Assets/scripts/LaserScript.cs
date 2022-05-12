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
        //Spiel wird gestoppt bei Kollision mit Asteroid
        // asteroidController asteroid = AsteroidHit.GetComponent<asteroidController>();
        EnemyController enemy = EnemyHit.GetComponent<EnemyController>();

        if (enemy != null)
        {
            //Animation hier
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


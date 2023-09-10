using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    public float respawnTime = 15.0f;
    private Vector2 screenBounds;
    public bool EnemyIsAlive = false;
    public List<GameObject> EnemyList;


    // Start is called before the first frame update
    void Start()
    {
        //Alle Objekte in dem Ordner "Resources" -> "Asteroids" werden in die Liste AsteroidList geladen
        EnemyList = new List<GameObject>(Resources.LoadAll<GameObject>("EnemiesNew"));
        //Berechnet die Größe des Bildschirmrandes
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Startet die Coroutine zum Spawnen der Asteroiden
        StartCoroutine(SpawnEnemy());
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        //Spawnt 1 zufälligen Asteroiden aus der Liste AsteroidList 
        for (int i = 0; i < 1; i++)
        {

            int n = Random.Range(0, EnemyList.Count);
            Instantiate(EnemyList[n], new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 1.5f, 0f), Quaternion.identity);
           
        }

 
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(respawnTime);
            if (!EnemyIsAlive)
            {
                spawnEnemy();
            }
           

        }
    }


}


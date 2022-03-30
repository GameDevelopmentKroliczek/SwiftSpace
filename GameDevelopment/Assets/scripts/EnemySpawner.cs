using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidPrefab1, asteroidPrefab2;
    public float respawnTime = 15.0f;
    private Vector2 screenBounds;

    public List<GameObject> AsteroidList;


    // Start is called before the first frame update
    void Start()
    {
        //Alle Objekte in dem Ordner "Resources" -> "Asteroids" werden in die Liste AsteroidList geladen
        AsteroidList = new List<GameObject>(Resources.LoadAll<GameObject>("Enemies"));
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

            int n = Random.Range(0, AsteroidList.Count);
            Instantiate(AsteroidList[n], new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 0.6f, 0f), Quaternion.Euler(0f, 180f, 0f));
           
        }

 
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }


}


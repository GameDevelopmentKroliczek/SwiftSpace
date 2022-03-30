using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{

    public GameObject asteroidPrefab1, asteroidPrefab2;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    public List<GameObject> AsteroidList;


    // Start is called before the first frame update
    void Start()
    {
        //Alle Objekte in dem Ordner "Resources" -> "Asteroids" werden in die Liste AsteroidList geladen
        AsteroidList = new List<GameObject>(Resources.LoadAll<GameObject>("Asteroids"));
        //Berechnet die Größe des Bildschirmrandes
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Startet die Coroutine zum Spawnen der Asteroiden
        StartCoroutine(asteroidWave());
    }

    private void spawnEnemy()
    {
        //Spawnt 1 zufälligen Asteroiden aus der Liste AsteroidList 
        for (int i = 0; i < 1; i++)
        {

            int n = Random.Range(0, AsteroidList.Count);
            Instantiate(AsteroidList[n], new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2, 0f), Quaternion.identity);
           
        }

        //GameObject a = Instantiate(asteroidPrefab1) as GameObject;
        //a.transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2, 0f);
        //a.transform.localScale = a.transform.localScale * Random.Range(.2f, 1.5f);

        //GameObject b = Instantiate(asteroidPrefab2) as GameObject;
        //b.transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2, 0f);
        //b.transform.localScale = b.transform.localScale * Random.Range(.2f, 1.5f);

    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }


}


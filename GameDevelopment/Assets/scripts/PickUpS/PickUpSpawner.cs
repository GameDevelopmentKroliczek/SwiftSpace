using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public EnemyController Enemy;
   
    public float respawnTime = 15.0f;
    private Vector2 screenBounds;

    public List<GameObject> PickupList;


    // Start is called before the first frame update
    void Start()
    {
        //Alle Objekte in dem Ordner "Resources" -> "Asteroids" werden in die Liste AsteroidList geladen
        PickupList = new List<GameObject>(Resources.LoadAll<GameObject>("PickUps"));
        //Berechnet die Größe des Bildschirmrandes
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Startet die Coroutine zum Spawnen der Asteroiden
        StartCoroutine(SpawnEnemy());
        //spawnPickup();
    }

    public void spawnPickup()
    {
        //Spawnt 1 zufälliges Pickup aus der Liste PickupList 
        for (int i = 0; i < 1; i++)
        {

            int n = Random.Range(0, PickupList.Count);
            Instantiate(PickupList[n], new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 1.5f, 0f), Quaternion.Euler(0f, 180f, 0f));
           
        }

 
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPickup();
        }
    }


}


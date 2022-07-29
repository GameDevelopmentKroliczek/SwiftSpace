using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeathAnimation : MonoBehaviour
{
    public List<GameObject> DeathAnimationList;

    // Start is called before the first frame update
    void Start()
    {
        //Alle Objekte in dem Ordner "Resources" -> "Explosions_Animationen" werden in die Liste DeathAnimationList geladen
        DeathAnimationList = new List<GameObject>(Resources.LoadAll<GameObject>("Explosions_Animationen"));
    }

    public void spawnAniamtion(Vector3 PositionToSpawnAt)
    {
        //Spawnt 1 zuf�lliges Pickup aus der Liste PickupList 
        for (int i = 0; i < 1; i++)
        {
            //FindObjectOfType<AudioManager>().PlayOneShotSound("Explosion");
            int n = Random.Range(0, DeathAnimationList.Count);
            Instantiate(DeathAnimationList[n], new Vector3 (PositionToSpawnAt.x, PositionToSpawnAt.y, PositionToSpawnAt.z -0.5f), Quaternion.identity);

        }


    }
}

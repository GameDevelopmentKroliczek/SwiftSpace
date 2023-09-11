using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPickUp : MonoBehaviour
{

   
    public PlayerMouseController player;

    // aktiviert den Laserangriff beim Spieler wenn das PickUp eingesammelt wird

    private void OnTriggerEnter(Collider other)
    {
        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            player.ActivateLaserWeapon();
            

            Destroy(this.gameObject);

        }
    }

 

}

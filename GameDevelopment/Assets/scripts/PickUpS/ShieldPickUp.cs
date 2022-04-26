using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public PlayerMouseController player;
    
    public float ShieldTimer = 3.0f;

    // aktiviert das Schild Prefab beim Spieler wenn das PickUp eingesammelt wird

    private void OnTriggerEnter(Collider other)
    {
        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            player.ActivateShield();
            
            Destroy(this.gameObject);
            
        }
    }
    
}

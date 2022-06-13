using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAS : MonoBehaviour
{
    public PlayerMouseController player;
    
    public float AttackSpeedMulitplier = 0.8f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            //Attackspeed wird jedes Mal 20% schneller
            player.Attackspeed *= 0.8f;
            //Attackspeed ist bei 0.1 gecapt
            if(player.Attackspeed < 0.1f)
            {
                player.Attackspeed = 0.1f;
            }
            Destroy(this.gameObject);

        }
    }
}

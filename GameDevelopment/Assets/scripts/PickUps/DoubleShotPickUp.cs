using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPickUp : MonoBehaviour
{
    public PlayerMouseController player;
 

    public void OnTriggerEnter(Collider other)
    {

        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            //deaktiviert Singleshot und aktiviert Doubleshot
            player.ActivateDoubleShot();

            Destroy(this.gameObject);
        }
    }

}

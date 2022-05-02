using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPickUp : MonoBehaviour
{
    

    public void OnTriggerEnter(Collider other)
    {

        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            //deaktiviert Singleshot und aktiviert Doubleshot
            player.SingleShot = false;
            player.DoubleShot = true;

            Destroy(this.gameObject);
        }
    }
}

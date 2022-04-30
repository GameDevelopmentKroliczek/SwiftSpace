using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPickUp : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter(Collider other)
    {

        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            weapon.UpdateShots();

            Destroy(this.gameObject);
        }
    }
}

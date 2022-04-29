using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPickUp : MonoBehaviour
{
    public Weapon weapon;
    public PlayerMouseController player;

    public void OnTriggerEnter(Collider other)
    {

        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            weapon.DoubleAttack = true;
            weapon.SingleAttack = false;
            weapon.UpdateShots();
            Destroy(this.gameObject);
        }
    }
}

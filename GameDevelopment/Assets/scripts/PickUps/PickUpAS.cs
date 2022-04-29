using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAS : MonoBehaviour
{
    public PlayerMouseController player;
    public Weapon weapon;
    public float AttackSpeedMulitplier = 0.8f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            weapon.UpdateAttackSpeed();

            Destroy(this.gameObject);

        }
    }
}

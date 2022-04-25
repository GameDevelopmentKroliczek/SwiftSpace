using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public PlayerMouseController player;
    public float ShieldTimer = 3.0f;

    //Aktueller Bug: Spieler bekommt keinen Schaden wenn er volle Leben hat, Schild endet nicht. Wenn er nicht volle Leben hat, aktiviert der Schild nicht

    private void OnTriggerEnter(Collider other)
    {
        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)
        {
            player.CanTakeDamage = false;
            StartCoroutine(ShieldCooldown());
            Destroy(this.gameObject);
            
        }
    }
    
    public void ResetShield()
    {
        player.CanTakeDamage = true;
    }

    IEnumerator ShieldCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShieldTimer);
            ResetShield();
        }
    }
}

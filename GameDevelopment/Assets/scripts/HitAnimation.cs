using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    private float DeathTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        while (true)
        {
            yield return new WaitForSeconds(DeathTime);

            Destroy(this.gameObject);
        }
    }
}

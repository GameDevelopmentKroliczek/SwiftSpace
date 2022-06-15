using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{

    private float Animationtime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBoom());
    }

    private IEnumerator DestroyBoom()
    {
        while (true)
        {
            yield return new WaitForSeconds(Animationtime);

            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Rigidbody rb;
    private Vector2 screenBounds;

    public float FallSpeed = -2f;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, FallSpeed, 0);

        if(rb.transform.position.y <= -screenBounds.y * 2)
        {
            Destroy(this.gameObject);
        }
    }
}

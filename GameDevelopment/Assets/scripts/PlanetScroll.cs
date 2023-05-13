using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScroll : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    private Vector3 StartPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.localPosition.y < -100f)
        {
            transform.localPosition = StartPosition;
        }
    }
}

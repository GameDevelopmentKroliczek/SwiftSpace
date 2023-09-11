using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrailsPlayer : MonoBehaviour
{
    public Transform TrailOrigin;
    LineRenderer TrailLine;
    Vector3 TrailEnd;
    [SerializeField]
    private float Traillength = 1f;

    public void Start()
    {
        TrailLine = GetComponent<LineRenderer>();
        StartCoroutine(TrailLength());
    }

    public void Update()
    {
        TrailEnd = new Vector3(TrailOrigin.transform.position.x, TrailOrigin.transform.position.y - Traillength, TrailOrigin.transform.position.z);

        TrailLine.SetPosition(0, TrailOrigin.position);
        TrailLine.SetPosition(1, TrailEnd);
        Ray ray = new Ray(TrailOrigin.position, TrailOrigin.up);
    }

    public IEnumerator TrailLength()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
                Traillength += Random.Range(-0.1f, 0.1f);
            if (Traillength < 0.7f) Traillength = 0.7f;
            if (Traillength > 1.3f) Traillength = 1.3f;
        }
    }
}

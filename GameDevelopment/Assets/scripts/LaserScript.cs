using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public PlayerMouseController player;
    public float LaserTime = 5f;
    public Transform Laserorigin;
    public GameObject LaserhitPoint;
    LineRenderer LaserLine;
    public float gunRange = 10f;
    RaycastHit hit;
    public LayerMask EnemyLayer;

    public void OnEnable()
    {
        LaserhitPoint.SetActive(true);
        
        LaserLine = GetComponent<LineRenderer>();
    }

    private void OnDisable()
    {
        LaserhitPoint.SetActive(false);
    }



    public void Update()
    {
        
        LaserLine.SetPosition(0, Laserorigin.position);
        LaserLine.SetPosition(1, LaserhitPoint.transform.position);
        Ray ray = new Ray(Laserorigin.position, Laserorigin.up);
        
        if(Physics.Raycast(ray, out hit, gunRange, EnemyLayer))
        {
            
            if (hit.collider != null)
            { 
                LaserhitPoint.transform.position = hit.point;
               
            }
        }
        else
        {
            LaserhitPoint.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + gunRange, player.transform.position.z);
            
           
          
        }
    }






    public void StartCoroutine()
    {
        StartCoroutine(LaserTimer());
    }


    IEnumerator LaserTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(LaserTime);
            
            player.DestroyLaser();
        }
    }
  




}


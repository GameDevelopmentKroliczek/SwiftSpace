using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermodels : MonoBehaviour
{
    public GameObject characterList;
    private void OnEnable()
    {
        characterList.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        characterList.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class modelChange : MonoBehaviour
{
    [SerializeField] private Renderer meshToChange;
    [SerializeField] private Material[] materialToChangeTo;
    public PlayerMouseController player;
    private int CurrentModel;


    public void Update()
    {
        if(player.CurrentHealth >= 3f)
        {
            CurrentModel = 0;
            meshToChange.material = materialToChangeTo[CurrentModel];
        }

        if (player.CurrentHealth <  3f)
        {
            CurrentModel = 1;
            meshToChange.material = materialToChangeTo[CurrentModel];
        }
    }

}



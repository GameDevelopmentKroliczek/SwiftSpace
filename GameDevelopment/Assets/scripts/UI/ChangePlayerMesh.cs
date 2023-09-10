using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerMesh: MonoBehaviour
{
    private GameObject[] PlayerModels;
    public ChooseModel ModelList;
    private int Modelindex;

    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerModels = new GameObject[transform.childCount];
        Modelindex = PlayerPrefs.GetInt("CharacterSelected");

        //Models werden in die Liste geladen
        for (int i = 0; i < transform.childCount; i++)
        {
            PlayerModels[i] = transform.GetChild(i).gameObject;
        }
        //Modelle werden im renderer deaktiviert
        foreach (GameObject go in PlayerModels)
        {
            go.SetActive(false);
        }

        //ausgewähltes Model wird aktiviert
        if (PlayerModels[Modelindex])
        {
            PlayerModels[Modelindex].SetActive(true);
        }
    }

}

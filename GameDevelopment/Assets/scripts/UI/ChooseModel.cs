using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseModel : MonoBehaviour
{
    public GameObject[] characterList;
    public GameObject ModelSelection;
    public GameObject Startscreen;
    public GameObject CharacterList;
    public int index;
    public string loadLevel;

    private void Start()
    {
        characterList = new GameObject[transform.childCount];

        index = PlayerPrefs.GetInt("CharacterSelected");

        //Models werden in die Liste geladen
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //Modelle werden im renderer deaktiviert
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //ausgew�hltes Model wird aktiviert
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    public void ScrollRight()
    {
        //altes Model deaktivieren
        characterList[index].SetActive(false);

        //Index wird hochgez�hlt
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        //neues Model wird aktiviert
        characterList[index].SetActive(true);
    }

    public void ScrollLeft()
    {
        //altes Model deaktivieren
        characterList[index].SetActive(false);

        //Index wird runtergez�hlt
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        //neues Model wird aktiviert
        characterList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt ("CharacterSelected", index);
        ModelSelection.SetActive(false);
        CharacterList.SetActive(false);
        LoadingScene.FindObjectOfType<LoadingScene>().LoadScene();
        Time.timeScale = 1f;
    }

    public void ReturnButton()
    {
        ModelSelection.SetActive(false);
        Startscreen.SetActive(true);
        CharacterList.SetActive(false);
    }
}

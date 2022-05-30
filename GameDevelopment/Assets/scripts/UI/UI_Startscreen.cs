using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Startscreen : MonoBehaviour
{
    public string loadLevel;
    public GameObject Playermodels;
    public GameObject Startmenu;
    public GameObject CharacterList;

  

    public void StartGame()
    {
        SceneManager.LoadScene(loadLevel, LoadSceneMode.Single);
   
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void changePlayerModels()
    {
        Playermodels.gameObject.SetActive(true);
        Startmenu.gameObject.SetActive(false);
        CharacterList.SetActive(true);
    }

}

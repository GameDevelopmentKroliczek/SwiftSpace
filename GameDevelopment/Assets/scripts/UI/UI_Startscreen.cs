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



    public static void StartGame()
    {
        
        // erstellt einen neuen Spielstand
        SceneManager.LoadSceneAsync("PlayScene");  
        //SceneManager.LoadScene(loadLevel, LoadSceneMode.Single);
        Time.timeScale = 1f;
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

    public void deactivateMusic()
    {
        if (FindObjectOfType<AudioManager>().ActivateMusic == true)
        {
            FindObjectOfType<AudioManager>().ActivateMusic = false;
            FindObjectOfType<AudioManager>().NewScene();
        }
        else
        {
            FindObjectOfType<AudioManager>().ActivateMusic = true;
            FindObjectOfType<AudioManager>().NewScene();
        }
    }

}

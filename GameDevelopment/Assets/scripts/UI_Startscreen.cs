using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Startscreen : MonoBehaviour
{
    public string loadLevel;
    public void StartGame()
    {

        SceneManager.LoadScene(loadLevel, LoadSceneMode.Single);
        
        
}

    public void QuitGame()
    {
        Application.Quit();
    }

}

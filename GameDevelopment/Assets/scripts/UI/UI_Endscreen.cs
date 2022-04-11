using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Endscreen : MonoBehaviour
{
    public PauseButton pausebutton;
    public string retryLevel;



    public void ShowEndScreen()
    {
        gameObject.SetActive(true);
        pausebutton.gameObject.SetActive(false);
    }



    public void ReloadLevel()
    {
        SceneManager.LoadScene(retryLevel, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
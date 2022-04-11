using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_PauseScreen : MonoBehaviour
{

    public string retryLevel;
    public PlayerMouseController player;
    public PauseButton pausebutton;

    public void ShowPauseScreen()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        player.isPlaying = false;
    }



    public void ReloadLevel()
    {
        
        SceneManager.LoadScene(retryLevel, LoadSceneMode.Single);
        Time.timeScale = 1f;
        player.isPlaying = true;
    }

    public void continueGame()
    {
        player.isPlaying = true;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        pausebutton.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
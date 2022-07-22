using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_PauseScreen : MonoBehaviour
{

    public string retryLevel;
    public string MenuLevel;
    public PlayerMouseController player;
    public GameObject UI_Overlay;
    public ScoreCounter Scorecounter;
    public Text PauseScore;

    public void ShowPauseScreen()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        player.isPlaying = false;
        UI_Overlay.gameObject.SetActive(false);        
        PauseScore.text = "Score: " + Scorecounter.Score.ToString("0");
    }



    public void ReloadLevel()
    {
        // erstellt einen neuen Spielstand 

        SceneManager.LoadSceneAsync("PlayScene");
        Time.timeScale = 1f;
        player.isPlaying = true;
    }

    public void continueGame()
    {
        player.isPlaying = true;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        UI_Overlay.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("StartMenu");

    }
}
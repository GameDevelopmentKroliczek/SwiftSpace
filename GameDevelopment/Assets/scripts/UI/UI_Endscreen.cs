using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Endscreen : MonoBehaviour
{
   
    public string retryLevel;
    public GameObject UI_Overlay;
    public ScoreCounter scorecounter;
    public Text EndScore;
    public string MenuLevel;



    public void ShowEndScreen()
    {
        gameObject.SetActive(true);
        UI_Overlay.gameObject.SetActive(false);
        
        EndScore.text = "Score: " + scorecounter.FinalScore.ToString();
    }



    public void ReloadLevel()
    {

        SceneManager.LoadSceneAsync("PlayScene");
        Time.timeScale = 1f;
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
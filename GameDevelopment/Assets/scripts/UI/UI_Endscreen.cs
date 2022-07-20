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
        EndScore.text = "Score: " + scorecounter.Score.ToString("0");
    }



    public void ReloadLevel()
    {
        DataPersistenceManager.instance.ResetGame();
        SceneManager.LoadScene(retryLevel, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        DataPersistenceManager.instance.ResetGame();
        Application.Quit();
    }

    public void MainMenu()
    {
        DataPersistenceManager.instance.ResetGame();
        SceneManager.LoadScene(MenuLevel, LoadSceneMode.Single);
        
    }
}
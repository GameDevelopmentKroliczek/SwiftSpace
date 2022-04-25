using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Endscreen : MonoBehaviour
{
    public PauseButton pausebutton;
    public string retryLevel;
    public Text Score;

    public ScoreCounter Scorecounter;
    public Text EndScore;

    public void ShowEndScreen()
    {
        gameObject.SetActive(true);
        pausebutton.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        EndScore.text = "Score: " + Scorecounter.Score.ToString("0");
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
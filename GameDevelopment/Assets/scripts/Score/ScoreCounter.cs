using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    public int Score = 0;
    

    public void Start()
    {
        scoreText.text = "000000";
       
        Score = 0;
    }

    public void BeginTimer()
    {
       
    }

    public void StopTimer()
    {
        
    }

    //Funktion um den Score zu Updaten
    public void  UpdateScore( int Bonus)
    {
       
            //Updated die Scorezahl
            Score = Score + Bonus;
        

    }

    public void FixedUpdate()
    {
       
            Score = Score + 1;
            scoreText.text = Score.ToString();

      
    }
}

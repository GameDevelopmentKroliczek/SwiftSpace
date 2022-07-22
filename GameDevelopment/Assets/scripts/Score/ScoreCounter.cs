using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text Highscore;

    public float Score;
    public float ScoreBonus;
    public Text ScoreDisplay;
    public float TimeMultiplier;

    public void Start()
    {
        TimeMultiplier = 2f;
        ScoreBonus = 0f;
        Highscore.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore", 0).ToString("0");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Highscorefunktion
        if (Score > PlayerPrefs.GetFloat("Highscore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", Score);
            Highscore.text = "Highscore: " + Score.ToString("0");
        }


        Score += Time.deltaTime * TimeMultiplier;
        ScoreDisplay.text = Score.ToString("0");

        if(Score <= 50 && Score >= 0)
        {
            TimeMultiplier = 2;
        }
        if (Score <= 150 && Score >= 51)
        {
            TimeMultiplier = 3f;
        }
        if (Score >= 151)
        {
            TimeMultiplier = 5f;
        }
    }
}

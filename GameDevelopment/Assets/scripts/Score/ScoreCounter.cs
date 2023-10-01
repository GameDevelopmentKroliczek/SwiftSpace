using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text Highscore;

    public int Score;
    public Text ScoreDisplay;
    public float TimeMultiplier;
    
    [SerializeField] private int ScoreAdd;
    public int FinalScore;
    public void Start()
    {
        TimeMultiplier = 2f;
        StartCoroutine(UpdateScore());
    }

    private IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/TimeMultiplier);
            Score += 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FinalScore = Score + ScoreAdd;
        //Highscorefunktion
        if (FinalScore > PlayerPrefs.GetInt("Highscore", 0))
        {     
            PlayerPrefs.SetInt("Highscore", FinalScore);
            Highscore.text = "Highscore: " + FinalScore.ToString();
        }


        ScoreDisplay.text = (Score + ScoreAdd).ToString();

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

    public void ScoreAddEnemy()
    {
        ScoreAdd += 20;
    }
    public void ScoreAddAsteroid()
    {
        ScoreAdd += 1;
    }
}

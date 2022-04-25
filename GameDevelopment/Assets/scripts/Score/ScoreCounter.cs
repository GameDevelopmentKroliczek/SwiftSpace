using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public float Score;
    public Text ScoreDisplay;
    public float TimeMultiplier;

    public void Start()
    {
        TimeMultiplier = 2f;
    }

    public void UpdateScore(int scoreBonus)
    {
        Score = Score + scoreBonus;
    }

    // Update is called once per frame
    void Update()
    {
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

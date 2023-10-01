using TMPro;
using UnityEngine.Events;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int InputScore;
    [SerializeField]
    private TMP_InputField InputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
      
            InputScore = PlayerPrefs.GetInt("Highscore", 0);
            submitScoreEvent.Invoke(InputName.text, int.Parse(InputScore.ToString()));
       
      
    }
}

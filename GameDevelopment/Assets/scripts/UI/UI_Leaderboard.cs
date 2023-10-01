using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class UI_Leaderboard : MonoBehaviour
{
    public GameObject Leaderboard;
    public GameObject Startscreen;
    public GameObject CharacterList;
    private string PublicLeaderboardKey = 
        "9f4921330240c62d44a54ab356d755943753473fc469267b8c41ed75fd85bcb8";


    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;


    public void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(PublicLeaderboardKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
        for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        if (username != null)
        {
            LeaderboardCreator.UploadNewEntry(PublicLeaderboardKey, username, score, ((msg) =>
            {
                username.Substring(0, 6);
                GetLeaderboard();
            }));
        }
        
    }

    public void ReturnButton()
    {
        Leaderboard.SetActive(false);
        Startscreen.SetActive(true);
        
    }

   
}

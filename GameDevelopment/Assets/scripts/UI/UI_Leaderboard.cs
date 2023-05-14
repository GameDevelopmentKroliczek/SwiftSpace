using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Leaderboard : MonoBehaviour
{
    public GameObject Leaderboard;
    public GameObject Startscreen;
    public GameObject CharacterList;

    // Start is called before the first frame update
   
    public void ReturnButton()
    {
        Leaderboard.SetActive(false);
        Startscreen.SetActive(true);
        
    }
}

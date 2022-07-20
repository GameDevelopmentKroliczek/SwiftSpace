using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int ScoreCount;
    public int PlayerHealth;
    public Vector3 playerPosition;
    

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        this.ScoreCount = 0;
        this.PlayerHealth = 0;
        playerPosition = Vector3.zero;
        
    }
}

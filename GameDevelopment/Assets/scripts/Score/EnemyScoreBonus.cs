using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreBonus : MonoBehaviour
{
    public int ScoreBonus = 0;
    public ScoreCounter counter;

    public void UpdateScoreBonus(int KillBonus)
    {
        ScoreBonus = ScoreBonus + KillBonus;
        counter.UpdateScore(ScoreBonus);
    }
}

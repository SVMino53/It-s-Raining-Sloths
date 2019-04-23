using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;

    int GetScore()
    {
        return score;
    }
    
    public void AddToScore(int num)
    {
        score += num;
    }
}

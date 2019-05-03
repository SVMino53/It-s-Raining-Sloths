using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0;
    [SerializeField]
    float timeMultiplier = 120;
   
    [SerializeField]
    Text pointsText;


    private void Start()
    {
        pointsText.text = "Points Placeholder";
    }

    private void Update()
    {
        pointsText.text = score.ToString();
    }

    float GetScore()
    {
        return score;
    }
    
    public void AddToScore(int num)
    {
        score += num;
    }

    public void countPoints(float resultTime)
    { 
        score += resultTime * timeMultiplier;
    }

    
}

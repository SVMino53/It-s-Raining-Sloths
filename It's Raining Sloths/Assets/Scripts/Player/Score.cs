using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0;
    [SerializeField]
    float timeMultiplier = 120;
   
    [SerializeField]
    TextMeshProUGUI pointsText;


    private void Start()
    {
        if(pointsText)
            pointsText.text = "Points Placeholder";
        score = 0;
        GlobalVars.SlothCount = 0;
    }

    private void Update()
    {
        if (pointsText)
            pointsText.text = "Sloth\nCount\n" + GlobalVars.SlothCount.ToString();
    }

    public float GetScore()
    {
        return score;
    }
    
    public void AddToScore(int num)
    {
        score += num;
    }

    public void countPoints(float resultTime)
    { 
        //score += resultTime * timeMultiplier;
    }

    
}

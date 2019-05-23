using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    int nLives = 5;
    [SerializeField]
    float dizzyTime = 5;

    float startTime;
    bool timerIsOn;
    [SerializeField]
    GameObject stars = null;
    
    float timer;
    void Start()
    {
        startTime = Time.time;
        stars.GetComponent<Stars>().Activate(false);
    }

    void Update()
    {
        Timer();
        if (nLives <= 0)
        {
            GlobalVars.PlayerScore = 2540L;

            SceneManager.LoadScene("HighScore", LoadSceneMode.Single);
        }
    }

    public void Decrease()
    {
        if(timerIsOn)
        {
            nLives = 0;
        } else
        {
            timerIsOn = true;
            startTime = Time.time;
            if(stars)
                stars.GetComponent<Stars>().Activate(true); 
        }
    }

    void Timer()
    {
        timer = Time.time - startTime;
        if (Time.time - startTime >= dizzyTime)
        {
            timerIsOn = false;
            if (stars)
                stars.GetComponent<Stars>().Activate(false);
        } 
    }

    int GetNumLives()
    {
        return nLives;
    }
}

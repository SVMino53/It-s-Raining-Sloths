using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float LevelLength = 120.0f;
    [SerializeField]
    TextMeshProUGUI TimeText;
    [SerializeField]
    GameObject ScoreTextObj = null;

    float StartTime;
    int Seconds = 0;
    int Minutes = 0;

    bool playerReachedTheTop = false;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVars.GameTime = (int)GetTimeLeft();
        if (GlobalVars.GameTime == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().SetLives(0);
        }
        Seconds = GlobalVars.GameTime % 60;
        Minutes = GlobalVars.GameTime / 60;

        //if(Time.time - StartTime>=LevelLength)
        //{
        //    GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().countPoints(GetTimeLeft());
        //}d

        if (Seconds >= 10)
        {
            TimeText.text = Minutes.ToString() + ":" + Seconds.ToString();
        }
        else
        {
            TimeText.text = Minutes.ToString() + ":0" + Seconds.ToString();
        }
    }

    public float GetTimeLeft()
    {
        if (LevelLength - (Time.time - StartTime) > 0)
            return LevelLength - (Time.time - StartTime);
        else return 0;
    }

    public void AddToTime(float sec)
    {
        LevelLength += sec;
    }
}

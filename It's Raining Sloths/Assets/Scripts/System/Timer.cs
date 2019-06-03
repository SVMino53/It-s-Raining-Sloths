using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float LevelLength = 120.0f;
    [SerializeField]
    TextMeshProUGUI TimeText;
    [SerializeField]
    GameObject ScoreTextObj = null;
    [SerializeField]
    string PlayerName = "Player";
    [SerializeField]
    string TimesUpName = "Image_Time'sUp";
    [SerializeField]
    float TimesUpDuration = 2.0f;

    float StartTime;
    int Seconds = 0;
    int Minutes = 0;

    GameObject TimesUpObj = null;

    bool playerReachedTheTop = false;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        TimesUpObj = GameObject.Find(TimesUpName);
        TimesUpObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.GameTime > 0)
        {
            GlobalVars.GameTime = (int)GetTimeLeft();
        }
        else
        {
            TimesUpObj.SetActive(true);

            TimesUpDuration -= Time.deltaTime;

            if (TimesUpDuration <= 0.0f)
            {
                GameObject.Find(PlayerName).GetComponent<Health>().SetLives(0);
                enabled = false;
            }
        }
        Seconds = GlobalVars.GameTime % 60;
        Minutes = GlobalVars.GameTime / 60;

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

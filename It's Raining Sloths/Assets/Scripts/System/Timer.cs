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
        Seconds = (int)GetTimeLeft() % 60;
        Minutes = (int)GetTimeLeft() / 60;

        if(Time.time - StartTime>=LevelLength && !playerReachedTheTop)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().countPoints(GetTimeLeft());
        }
        else if(Seconds >= 10)
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
        return LevelLength - (Time.time - StartTime);
    }

    public void AddToTime(float sec)
    {
        LevelLength += sec;
    }
}

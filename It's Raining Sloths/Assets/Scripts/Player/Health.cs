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
    [SerializeField]
    GameObject ScoreTextObj = null;
    [SerializeField]
    GameObject SystemsObj = null;
    [SerializeField]
    GameObject Canvas_EyesObj = null;
    [SerializeField]
    GameObject SliderObj = null;
    [SerializeField]
    AudioSource Music = null;

    Move_Mouse Move_MouseComp = null;
    Rotate_Analog Rotate_AnalogComp = null;
    ArmsController_Test ArmsController_TestComp = null;
    ArmAnimationController ArmAnimationControllerComp = null;

    float startTime;
    bool timerIsOn;
    [SerializeField]
    GameObject stars = null;
    
    float timer;
    void Start()
    {
        Move_MouseComp = GetComponent<Move_Mouse>();
        Rotate_AnalogComp = GetComponent<Rotate_Analog>();
        ArmsController_TestComp = GetComponent<ArmsController_Test>();
        ArmAnimationControllerComp = GetComponent<ArmAnimationController>();

        //ScoreTextObj.SetActive(false);
        //SystemsObj.SetActive(true);
        //Canvas_EyesObj.SetActive(true);
        startTime = Time.time;
        stars.GetComponent<Stars>().Activate(false);
    }

    void Update()
    {
        Timer();
        if (nLives <= 0)
        {
            //GlobalVars.PlayerScore = 2540L;

            SceneManager.LoadScene("HighScore", LoadSceneMode.Single);

            Music.Stop();

            Move_MouseComp.enabled = false;
            Rotate_AnalogComp.enabled = false;
            ArmsController_TestComp.enabled = false;
            ArmAnimationControllerComp.enabled = false;

            ScoreTextObj.SetActive(true);
            SystemsObj.SetActive(false);
            Canvas_EyesObj.SetActive(false);

            SliderObj.GetComponent<HeightBar>().enabled = false;
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

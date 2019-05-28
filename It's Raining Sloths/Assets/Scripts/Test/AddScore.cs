using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AddScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI PlayerScoreText = null;
    [SerializeField]
    TextMeshProUGUI SlothCountText = null;
    [SerializeField]
    TextMeshProUGUI TimeText = null;
    [SerializeField]
    Slider ProgressSlider = null;
    [SerializeField]
    float SlothCountMultiplier = 50.0f;
    [SerializeField]
    float TimeMultiplier = 10.0f;
    [SerializeField]
    float ProgressMultiplier = 20.0f;
    [SerializeField]
    float ProgressInterval = 0.005f;
    [SerializeField]
    float TreeTopBonus = 1000.0f;
    [SerializeField]
    float Delay = 0.01f;
    [SerializeField]
    float ExtraDelay = 1.0f;
    [SerializeField]
    string NextSceneName = "HighScore";
    [SerializeField]
    AudioSource PointsSound = null;
    [SerializeField]
    float SoundDelay = 0.08f;

    float CurrentDelay = 0.0f;
    float CurrentSoundDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScoreText.enabled = true;
        CurrentDelay = -ExtraDelay;
        CurrentSoundDelay = -ExtraDelay;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDelay += Time.deltaTime;
        CurrentSoundDelay += Time.deltaTime;

        if (CurrentSoundDelay >= SoundDelay)
        {
            PointsSound.Play();
            CurrentSoundDelay = 0.0f;
        }

        if (CurrentDelay >= Delay)
        {
            CurrentDelay = 0.0f;

            if (GlobalVars.SlothCount > 0)
            {
                GlobalVars.SlothCount--;
                GlobalVars.PlayerScore += SlothCountMultiplier;

                if (GlobalVars.SlothCount <= 0)
                {
                    CurrentDelay = -ExtraDelay;
                    CurrentSoundDelay = -ExtraDelay;
                }
            }
            else if (GlobalVars.GameTime > 0)
            {
                GlobalVars.GameTime--;
                GlobalVars.PlayerScore += TimeMultiplier;

                int Seconds = GlobalVars.GameTime % 60;
                int Minutes = GlobalVars.GameTime / 60;

                if (Seconds >= 10)
                {
                    TimeText.text = Minutes.ToString() + ":" + Seconds.ToString();
                }
                else
                {
                    TimeText.text = Minutes.ToString() + ":0" + Seconds.ToString();
                }

                if (GlobalVars.GameTime <= 0)
                {
                    CurrentDelay = -ExtraDelay;
                    CurrentSoundDelay = -ExtraDelay;
                }
            }
            else if (GlobalVars.OnTreeTop)
            {
                GlobalVars.OnTreeTop = false;
                GlobalVars.PlayerScore += TreeTopBonus;

                if (!GlobalVars.OnTreeTop)
                {
                    CurrentDelay = -ExtraDelay;
                    CurrentSoundDelay = -ExtraDelay;
                }
            }
            else if (GlobalVars.Progress > 0.0f)
            {
                if (GlobalVars.Progress >= ProgressInterval)
                {
                    GlobalVars.Progress -= ProgressInterval;
                }
                else
                {
                    GlobalVars.Progress = 0.0f;
                }

                GlobalVars.PlayerScore += ProgressMultiplier;
                ProgressSlider.value = GlobalVars.Progress;

                if (GlobalVars.Progress <= 0.0f)
                {
                    CurrentDelay = -ExtraDelay;
                    CurrentSoundDelay = -ExtraDelay;
                }
            }
            else
            {
                SceneManager.LoadScene(NextSceneName);
            }

            PlayerScoreText.text = ((long)GlobalVars.PlayerScore).ToString();
        }
    }

    
}

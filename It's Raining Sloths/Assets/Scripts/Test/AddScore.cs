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
    float Delay = 0.2f;
    [SerializeField]
    string NextSceneName = "HighScore";

    float CurrentDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScoreText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDelay += Time.deltaTime;

        if (CurrentDelay >= Delay)
        {
            CurrentDelay = 0.0f;

            if (GlobalVars.SlothCount > 0)
            {
                GlobalVars.SlothCount--;
                GlobalVars.PlayerScore += SlothCountMultiplier;
                SlothCountText.text = GlobalVars.SlothCount.ToString();
            }
            else if (GlobalVars.GameTime > 0)
            {
                GlobalVars.GameTime--;
                GlobalVars.PlayerScore += TimeMultiplier;
                TimeText.text = GlobalVars.GameTime.ToString();
            }
            else if (GlobalVars.Progress > 0.0f)
            {
                if (GlobalVars.Progress >= 0.01f)
                {
                    GlobalVars.Progress -= 0.01f;
                }
                else
                {
                    GlobalVars.Progress = 0.0f;
                }

                GlobalVars.PlayerScore += ProgressMultiplier;
                ProgressSlider.value = GlobalVars.Progress;
            }
            else
            {
                SceneManager.LoadScene(NextSceneName);
            }

            PlayerScoreText.text = ((long)GlobalVars.PlayerScore).ToString();
        }
    }

    
}

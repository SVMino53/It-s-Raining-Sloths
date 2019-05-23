using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

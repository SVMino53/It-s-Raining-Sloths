using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int Seconds = GlobalVars.GameTime % 60;
        int Minutes = GlobalVars.GameTime / 60;

        if (Seconds >= 10)
        {
            GetComponent<TextMeshProUGUI>().text = Minutes.ToString() + ":" + Seconds.ToString();
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = Minutes.ToString() + ":0" + Seconds.ToString();
        }
    }
}

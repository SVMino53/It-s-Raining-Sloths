using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlothCountText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "SLOTH COUNT " + GlobalVars.SlothCount.ToString();
    }
}

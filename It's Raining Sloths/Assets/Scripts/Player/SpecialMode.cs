using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMode : MonoBehaviour
{
    GameObject detector_l = null;
    GameObject detector_r = null;
    GameObject detector_m = null;

    [SerializeField]
    string detector_l_name = "Detector_Left";
    [SerializeField]
    string detector_r_name = "Detector_Right";
    [SerializeField]
    string detector_m_name = "Detector_Middle";

    [SerializeField]
    KeyCode rotateLeft = KeyCode.J;
    [SerializeField]
    KeyCode rotateRight = KeyCode.K;

    void Start()
    {
        detector_l = GameObject.Find(detector_l_name);
        detector_r = GameObject.Find(detector_r_name);
        detector_m = GameObject.Find(detector_m_name);

        if (GlobalVars.SpecialMode)
        {
            if (detector_l) detector_l.SetActive(false);
            if (detector_r) detector_r.SetActive(false);
            if (detector_m) detector_m.SetActive(true);

            GetComponent<ArmsController_Test>().enabled = false;

            // GetComponent<Rotate_Analog>().SetButtons(rotateLeft, rotateRight);
            GetComponent<Rotate_Analog>().enabled = false;
            GetComponent<Rotate>().enabled = true;
            GetComponent<Rotate>().SetButtons(rotateLeft, rotateRight);

        } else
        {
            if (detector_l) detector_l.SetActive(true);
            if (detector_r) detector_r.SetActive(true);
            if (detector_m) detector_m.SetActive(false);

            GetComponent<Rotate_Analog>().enabled = true;
            GetComponent<Rotate>().enabled = false;
        }
    }
}

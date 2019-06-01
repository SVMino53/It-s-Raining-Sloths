using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController_Test : MonoBehaviour
{
    [SerializeField]
    KeyCode CatchLeft = KeyCode.O;
    [SerializeField]
    KeyCode CatchRight = KeyCode.P;
    [SerializeField]
    float activePhaseLength = 5f;
    [SerializeField]
    string LeftArmName = "Detector_Left";
    [SerializeField]
    string RightArmName = "Detector_Right";

    GameObject rightArm;
    GameObject leftArm;

    bool armActive = false;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rightArm = GameObject.Find(RightArmName);
        leftArm = GameObject.Find(LeftArmName);
        timer = Time.time;

        rightArm.SetActive(false);
        leftArm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(CatchRight))
        {
            rightArm.SetActive(true);
            timer = Time.time;
        }

        if (Input.GetKey(CatchLeft))
        {
            leftArm.SetActive(true);
            timer = Time.time;
        }

        if (Time.time - timer >= activePhaseLength)
        {
            if (leftArm.activeInHierarchy)
                leftArm.SetActive(false);

            if (rightArm.activeInHierarchy)
                rightArm.SetActive(false);
            
            timer = Time.time;
        }
    }
}

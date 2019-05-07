using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    [SerializeField]
    KeyCode CatchLeft = KeyCode.O;
    [SerializeField]
    KeyCode CatchRight = KeyCode.P;
    [SerializeField]
    float activePhaseLength = 1f;
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
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(CatchLeft) && armActive == false)
        {
            GetComponent<Animator>().SetBool("Climb", false);
            GetComponent<Animator>().SetBool("Stretch", true);
        }

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stretching") && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > .99f)
        {
            GetComponent<Animator>().SetBool("Stretch", false);
            GetComponent<Animator>().SetBool("Retract", true);
        }

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Retract") && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > .99f)
        {
            GetComponent<Animator>().SetBool("Retract", false);
            GetComponent<Animator>().SetBool("Climb", true);
        }

        //if (Time.time - timer >= activePhaseLength)
        //{
        //    //GetComponent<Animator>().SetBool("Stretch", false);
        //    //GetComponent<Animator>().SetBool("Climb", true);
        //    armActive = false;
        //    timer = Time.time;
        //}
    }
}

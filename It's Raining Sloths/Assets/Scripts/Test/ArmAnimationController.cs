using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimationController : MonoBehaviour
{
    [SerializeField]
    GameObject LeftArmObj;
    [SerializeField]
    GameObject RightArmObj;
    [SerializeField]
    GameObject MainCameraObj;
    [SerializeField]
    KeyCode CatchLeft = KeyCode.O;
    [SerializeField]
    KeyCode CatchRight = KeyCode.P;
    [SerializeField]
    float AnimationSpeed = 0.005f;
    [SerializeField]
    float ReachTime = 1.5f;

    float AnimTime = 0.0f;
    Animator LeftArmAnimator;
    Animator RightArmAnimator;
    Animator MainCameraAnimator;
    float CurrentReachTime = 0.0f;
    bool LeftReach = false;
    bool RightReach = false;

    // Start is called before the first frame update
    void Start()
    {
        LeftArmAnimator = LeftArmObj.GetComponent<Animator>();
        RightArmAnimator = RightArmObj.GetComponent<Animator>();
        MainCameraAnimator = MainCameraObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse Y") < 0)
        {
            AnimTime += AnimationSpeed;
        }

        if (AnimTime >= 1.0f)
        {
            AnimTime -= 1.0f;
        }

        RightArmAnimator.SetFloat("NormalTime", AnimTime);
        LeftArmAnimator.SetFloat("NormalTime", AnimTime);

        if (Input.GetKey(CatchRight))
        {
            RightReach = true;
            LeftReach = false;
            CurrentReachTime = ReachTime;
        }
        else if (Input.GetKey(CatchLeft))
        {
            LeftReach = true;
            RightReach = false;
            CurrentReachTime = ReachTime;
        }

        if (CurrentReachTime > 0.0f)
        {
            CurrentReachTime -= Time.deltaTime;
        }

        if (RightReach && CurrentReachTime > 0.0f)
        {
            RightArmAnimator.SetBool("DoExtend", true);
            MainCameraAnimator.SetBool("DoTurnRight", true);

            if(MainCameraAnimator.GetCurrentAnimatorStateInfo(0).IsName("UntiltLeft"))
            {
                MainCameraAnimator.speed = 2.0f;
            }
            else
            {
                MainCameraAnimator.speed = 1.0f;
            }
        }
        else
        {
            RightArmAnimator.SetBool("DoExtend", false);
            MainCameraAnimator.SetBool("DoTurnRight", false);
            RightReach = false;
        }

        if (LeftReach && CurrentReachTime > 0.0f)
        {
            LeftArmAnimator.SetBool("DoExtend", true);
            MainCameraAnimator.SetBool("DoTurnLeft", true);

            if (MainCameraAnimator.GetCurrentAnimatorStateInfo(0).IsName("UntiltRight"))
            {
                MainCameraAnimator.speed = 2.0f;
            }
            else
            {
                MainCameraAnimator.speed = 1.0f;
            }
        }
        else
        {
            LeftArmAnimator.SetBool("DoExtend", false);
            MainCameraAnimator.SetBool("DoTurnLeft", false);
            LeftReach = false;
        }
    }
}

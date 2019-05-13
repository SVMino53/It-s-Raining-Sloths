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
    KeyCode CatchLeft = KeyCode.O;
    [SerializeField]
    KeyCode CatchRight = KeyCode.P;
    [SerializeField]
    float AnimationSpeed = 0.005f;

    float AnimTime = 0.0f;
    Animator LeftArmAnimator;
    Animator RightArmAnimator;

    // Start is called before the first frame update
    void Start()
    {
        LeftArmAnimator = LeftArmObj.GetComponent<Animator>();
        RightArmAnimator = RightArmObj.GetComponent<Animator>();
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
            RightArmAnimator.SetBool("DoExtend", true);
        }
        else
        {
            RightArmAnimator.SetBool("DoExtend", false);
        }

        if (Input.GetKey(CatchLeft))
        {
            LeftArmAnimator.SetBool("DoExtend", true);
        }
        else
        {
            LeftArmAnimator.SetBool("DoExtend", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmController : MonoBehaviour
{
    [SerializeField]
    KeyCode CatchLeft = KeyCode.O;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(CatchLeft))
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

    }
}

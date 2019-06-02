using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeTopScript : MonoBehaviour
{
    [SerializeField]
    GameObject ScoreTextObj = null;
    [SerializeField]
    GameObject SystemsObj = null;
    [SerializeField]
    GameObject Canvas_EyesObj = null;
    [SerializeField]
    GameObject SliderObj = null;
    [SerializeField]
    GameObject PlayerObj = null;

    Move_Mouse Move_MouseComp = null;
    Rotate_Analog Rotate_AnalogComp = null;
    ArmsController_Test ArmsController_TestComp = null;
    ArmAnimationController ArmAnimationControllerComp = null;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        Move_MouseComp = PlayerObj.GetComponent<Move_Mouse>();
        Rotate_AnalogComp = PlayerObj.GetComponent<Rotate_Analog>();
        ArmsController_TestComp = PlayerObj.GetComponent<ArmsController_Test>();
        ArmAnimationControllerComp = PlayerObj.GetComponent<ArmAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Move_MouseComp.enabled = false;
            Rotate_AnalogComp.enabled = false;
            ArmsController_TestComp.enabled = false;
            ArmAnimationControllerComp.enabled = false;

            //ScoreTextObj.SetActive(true);
            //SystemsObj.SetActive(false);
            //Canvas_EyesObj.SetActive(false);

            //SliderObj.GetComponent<HeightBar>().enabled = false;

            GlobalVars.OnTreeTop = true;

            PlayerObj.GetComponent<Health>().SetLives(0);
        }
    }
}

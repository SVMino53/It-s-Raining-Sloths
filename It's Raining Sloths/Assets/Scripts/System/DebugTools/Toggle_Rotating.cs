using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Rotating : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerObj = null;
    [SerializeField]
    KeyCode Toggle = KeyCode.B;

    Rotate Player_Rotate;
    Rotate_Analog Player_Rotate_Analog;
    Move_ScrollWheel Player_Move_ScrollWheel;
    int ActiveScript;

    // Start is called before the first frame update
    void Start()
    {
        Player_Rotate = PlayerObj.GetComponent<Rotate>();
        Player_Rotate_Analog = PlayerObj.GetComponent<Rotate_Analog>();

        ActiveScript = 0;
        Player_Rotate.enabled = true;
        Player_Rotate_Analog.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Toggle))
        {
            switch (ActiveScript)
            {
                case 0:
                    Player_Rotate.enabled = false;
                    Player_Rotate_Analog.enabled = true;
                    break;
                case 1:
                    Player_Rotate_Analog.enabled = false;
                    Player_Rotate.enabled = true;
                    ActiveScript = -1;
                    break;
                default:
                    break;
            }
            ActiveScript++;
        }
    }
}

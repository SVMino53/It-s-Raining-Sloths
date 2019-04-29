using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Climbing : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerObj = null;
    [SerializeField]
    KeyCode Toggle = KeyCode.V;

    Move Player_Move;
    Move_Mouse Player_Move_Mouse;
    Move_ScrollWheel Player_Move_ScrollWheel;
    int ActiveScript;

    // Start is called before the first frame update
    void Start()
    {
        Player_Move = PlayerObj.GetComponent<Move>();
        Player_Move_Mouse = PlayerObj.GetComponent<Move_Mouse>();
        Player_Move_ScrollWheel = PlayerObj.GetComponent<Move_ScrollWheel>();

        ActiveScript = 0;
        Player_Move.enabled = true;
        Player_Move_Mouse.enabled = false;
        Player_Move_ScrollWheel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Toggle))
        {
            switch (ActiveScript)
            {
                case 0:
                    Player_Move.enabled = false;
                    Player_Move_Mouse.enabled = true;
                    break;
                case 1:
                    Player_Move_Mouse.enabled = false;
                    Player_Move_ScrollWheel.enabled = true;
                    break;
                case 2:
                    Player_Move_ScrollWheel.enabled = false;
                    Player_Move.enabled = true;
                    ActiveScript = -1;
                    break;
                default:
                    break;
            }
            ActiveScript++;
        }
    }
}

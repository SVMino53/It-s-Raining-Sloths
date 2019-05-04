using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 2.0f)]
    public float speed = 20.05f;
    [SerializeField]
    public KeyCode MoveUp = KeyCode.W;
    [SerializeField]
    public KeyCode MoveDown = KeyCode.S;


    private void Update()
    {
        if (Input.GetKey(MoveUp))
        {
            GetComponent<GeneralMovement>().SetSpeed(speed);
            GetComponent<GeneralMovement>().Move();
        }
        else if (Input.GetKey(MoveDown))
        {
            GetComponent<GeneralMovement>().SetSpeed(-speed);
            GetComponent<GeneralMovement>().Move();
        }

    }
   
}

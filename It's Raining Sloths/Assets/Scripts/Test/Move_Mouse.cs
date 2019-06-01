using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Mouse : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 2.0f)]
    public float speed = 10f;

    void Update()
    {
        float YMovement = -Input.GetAxis("Mouse X") * speed;
            
        if (YMovement < speed * -1.5) YMovement = speed * 1.5f;
            
        GetComponent<GeneralMovement>().SetSpeed(Mathf.Abs(YMovement));
        GetComponent<GeneralMovement>().Move();
    }
}

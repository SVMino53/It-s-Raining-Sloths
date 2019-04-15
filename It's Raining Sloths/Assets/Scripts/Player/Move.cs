using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed = 0.01f;
    [SerializeField]
    public KeyCode MoveUp = KeyCode.W;
    [SerializeField]
    public KeyCode MoveDown = KeyCode.S;
    float initialXpos;

    // Start is called before the first frame update
    void Start()
    {
        initialXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(MoveUp))
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        else if (Input.GetKey(MoveDown) && transform.position.y-speed >= initialXpos)
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);

        /*if(Input.GetKey(KeyCode.A))
            transform.Rotate()*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 2.0f)]
    public float speed = 0.05f;
    [SerializeField]
    public KeyCode MoveUp = KeyCode.W;
    [SerializeField]
    public KeyCode MoveDown = KeyCode.S;

    float initialXpos;
    float treeHeight;
    [SerializeField]
    bool moving = true;

    /*...........*/
    Rigidbody rb;

    public void ChangeSpeed(float value)
    {
        speed = value;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initialXpos = transform.position.x;
        treeHeight = GameObject.Find("Trees").GetComponent<InitializeTrees>().GetTreeHeight();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (Input.GetKey(MoveUp) && transform.position.y + speed <= treeHeight)
                //rb.velocity = new Vector3(0, speed, 0);
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            else if (Input.GetKey(MoveDown) && transform.position.y - speed >= initialXpos)
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        } //else moving = true;
    }

    public float getCurPosY()
    {
        return transform.position.y;
    }
}

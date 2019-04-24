using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ScrollWheel : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 2.0f)]
    public float speed = 1.0f;
    float initialXpos;

    public void ChangeSpeed(float value)
    {
        speed = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            float YMovement = Input.GetAxis("Mouse ScrollWheel") * speed;

            transform.position = new Vector3(transform.position.x, transform.position.y - YMovement, transform.position.z);
        }
    }
}

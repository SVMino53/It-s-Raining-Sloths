using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Test : MonoBehaviour
{
    [SerializeField]
    float speed = 0.01f;
    float initialXpos;

    // Start is called before the first frame update
    void Start()
    {
        initialXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float YMovement = Input.GetAxis("Mouse Y") * speed;

        transform.position = new Vector3(transform.position.x, transform.position.y - YMovement, transform.position.z);
    }
}

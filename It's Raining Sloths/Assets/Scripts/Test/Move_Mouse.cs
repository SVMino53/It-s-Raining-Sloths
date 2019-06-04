using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Mouse : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 2.0f)]
    public float speed = 10f;
    float timer = 0;
    [SerializeField]
    float allowedStillTime = 5;

    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Mouse X")) < 0.1)
        {
            timer += Time.deltaTime;
            if (timer > allowedStillTime) GameObject.Find("Systems").GetComponent<SpawnSlothBaby>().SetSpawningStatus(false);
            return;
        } 
        float YMovement = -Input.GetAxis("Mouse X") * speed;
        if (YMovement < speed * -1.5f) YMovement = speed * 1.5f;
        if (YMovement > speed * 7.5f) YMovement = speed * 7.5f;

        if (!GameObject.Find("Systems").GetComponent<SpawnSlothBaby>().GetSpawningStatus()) { GameObject.Find("Systems").GetComponent<SpawnSlothBaby>().SetSpawningStatus(true); timer = 0; }
        GetComponent<GeneralMovement>().SetSpeed(Mathf.Abs(YMovement));
        GetComponent<GeneralMovement>().Move();
    }
}

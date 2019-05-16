using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDown : MonoBehaviour
{
    float minHeight;
    float speed;
    [SerializeField]
    float BounceDownHeight = 5f;
    [SerializeField]
    float StannedLength = 0.3f;
    bool falling = true;

    public void Bounce(float speedL, bool fall = true)
    {
        speed = speedL;
        falling = fall;
        GetComponent<GeneralMovement>().moving = false;
        GetComponent<ShakeScreen>().enabled = true;
        StartCoroutine(Falling());
    }

    IEnumerator Falling()
    {
        float curHeight = 0;
        float localSpeed = speed;
        minHeight = GameObject.FindGameObjectWithTag("Tree").GetComponent<Growing>().GetMinHeight();

        while (curHeight <= BounceDownHeight)
        {
            if (!falling) curHeight = BounceDownHeight;
            localSpeed = getSpeed(speed);
            if (transform.position.y - Mathf.Abs(localSpeed) >= 0 && transform.position.y - Mathf.Abs(localSpeed) >= minHeight)
                transform.position = new Vector3(transform.position.x, transform.position.y - Mathf.Abs(localSpeed), transform.position.z);
            else
            {
                GetComponent<GeneralMovement>().moving = true;
                yield break;
            }
            curHeight += Mathf.Abs(localSpeed);
            yield return null;
        }
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(StannedLength);
        GetComponent<GeneralMovement>().moving = true;
    }

    float getSpeed(float curSpeed)
    {
        return curSpeed *= (0.7f + Mathf.Abs(Mathf.Cos(Time.time)));
    }

}

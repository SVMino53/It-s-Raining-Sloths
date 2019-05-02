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
    [SerializeField]
    string TreesName = "Trees";

    float initialXpos;
    float initialZpos;
    float treeHeight;
    [SerializeField]
    public bool moving = true;
    [SerializeField]
    float BounceDownHeight = 10f;
    [SerializeField]
    float StannedLength = 0.3f;

    /*...........*/
    public float minHeight;

    public void ChangeSpeed(float value)
    {
        speed = value;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        initialXpos = transform.position.x;
        initialZpos = transform.position.z;
        treeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initialXpos, transform.position.y, initialZpos);
        if (GetComponent<CollisionCheck>().Colliding())
            Debug.Log("colliding");
        if(GetComponent<CollisionCheck>().Colliding() && moving)
        {
            BounceDown();
            GetComponent<CollisionCheck>().SetColliding(false);
        }
        if (moving)
        {
            if (Input.GetKey(MoveUp) && transform.position.y + speed <= treeHeight)
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            else if (Input.GetKey(MoveDown) && transform.position.y - speed >= initialXpos)
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        } 
    }

    public float GetCurPosY()
    {
        return transform.position.y;
    }

    public void BounceDown()
    {
        
        moving = false;
        StartCoroutine(Falling());
    }

    IEnumerator Falling()
    {
        float curHeight = 0;
        float localSpeed = speed;
        minHeight = GameObject.FindGameObjectWithTag("Tree").GetComponent<Growing>().GetMinHeight();

        while (curHeight <= BounceDownHeight)
        {
            localSpeed = getSpeed(speed);
            if (transform.position.y - localSpeed >= 0 && transform.position.y - localSpeed >= minHeight)
                transform.position = new Vector3(transform.position.x, transform.position.y - localSpeed, transform.position.z);
            else
            {
                moving = true;
                yield break;
            }
            curHeight += localSpeed;
            yield return null;
        }
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(StannedLength);
        moving = true;
    }

    float getSpeed(float curSpeed)
    {
        return curSpeed *= (0.7f+Mathf.Abs(Mathf.Cos(Time.time)));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : MonoBehaviour
{
    float speed = 20.05f;
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
    [SerializeField]
    AudioSource HitSound = null;
    [SerializeField]
    AudioSource MonkeyLaughSound = null;
    [SerializeField]
    ulong MLSoundDelay = 3L;

    /*...........*/
    float minHeight;

    public void SetSpeed(float value)
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


    public void Move()
    {
        transform.position = new Vector3(initialXpos, transform.position.y, initialZpos);

        if (GetComponent<CollisionCheck>().Colliding() && moving)
        {
            GetComponent<BounceDown>().Bounce(speed);
            GetComponent<CollisionCheck>().SetColliding(false);
            GetComponent<Health>().Decrease();
        }
        if (moving)
        {
            if (transform.position.y + speed <= treeHeight && transform.position.y + speed >= initialXpos)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            }
        }
    }

    public float GetCurPosY()
    {
        return transform.position.y;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Rock"))
    //    {
    //        GetComponent<BounceDown>().Bounce(speed, false);
    //        GetComponent<Health>().Decrease();
    //        other.gameObject.SetActive(false);
    //        HitSound.Play();
    //        MonkeyLaughSound.Play(MLSoundDelay * 44100L);
    //    }
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            GetComponent<BounceDown>().Bounce(speed, false);
            GetComponent<Health>().Decrease();
            other.gameObject.SetActive(false);
            HitSound.Play();
            MonkeyLaughSound.Play(MLSoundDelay * 44100L);
        }
    }
}

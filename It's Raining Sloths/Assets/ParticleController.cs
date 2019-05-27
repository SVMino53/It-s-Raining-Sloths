using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticleController : MonoBehaviour
{
    GameObject particleLeft;
    GameObject particleRight;

    float startTime;
    [SerializeField]
    float particleLength = 1f;
    // Start is called before the first frame update
    void Start()
    {
        particleLeft = GameObject.Find("particles_l");
        particleRight = GameObject.Find("particles_r");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-startTime > particleLength && (particleLeft.GetComponent<ParticleSystem>().isPlaying || particleRight.GetComponent<ParticleSystem>().isPlaying))
        {
            startTime = Time.time;
            particleLeft.GetComponent<ParticleSystem>().Stop();
            particleRight.GetComponent<ParticleSystem>().Stop();
        }
    }

    public void PlayParticle(bool left)
    {
        if(left)
        {
            particleLeft.GetComponent<ParticleSystem>().Play();
        } else
        {
            particleRight.GetComponent<ParticleSystem>().Play();
        }
    }
}

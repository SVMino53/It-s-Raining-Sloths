using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    GameObject particleLeft;
    GameObject particleRight;
    GameObject particleMiddle;

    float startTime = 0;
    [SerializeField]
    float particleLength = 3f;
    [SerializeField]
    string LeftArmName = "Detector_Left";
    [SerializeField]
    string RightArmName = "Detector_Right";
    [SerializeField]
    string HeadName = "Detector_Middle";

    void Start()
    {
        particleLeft = GameObject.Find("particles_l");
        particleRight = GameObject.Find("particles_r");
        particleMiddle = GameObject.Find("particles_m");

        particleLeft.GetComponent<ParticleSystem>().Stop();
        particleRight.GetComponent<ParticleSystem>().Stop();
        particleMiddle.GetComponent<ParticleSystem>().Stop();
    }

    void Update()
    {
        if(particleLeft.GetComponent<ParticleSystem>().isPlaying || particleRight.GetComponent<ParticleSystem>().isPlaying || particleMiddle.GetComponent<ParticleSystem>().isPlaying) 
        {
            if (Time.time - startTime > particleLength)
            {
                particleLeft.GetComponent<ParticleSystem>().Stop();
                particleRight.GetComponent<ParticleSystem>().Stop();
                particleMiddle.GetComponent<ParticleSystem>().Stop();
            }
        } else
        {
            startTime = Time.time;
        }
    }

    public void PlayParticle(string name)
    {
        if(name == LeftArmName)
        {
            if (particleLeft != null)
            {
                particleLeft.GetComponent<ParticleSystem>().Play();
                startTime = Time.time;
            }
        } else if (name == RightArmName)
        {
            if (particleRight != null)
            {
                particleRight.GetComponent<ParticleSystem>().Play();
                startTime = Time.time;
            }
        } else if (name == HeadName)
        {
            if(particleMiddle != null)
            {
                particleMiddle.GetComponent<ParticleSystem>().Play();
                startTime = Time.time;
            }
        }
    }
}

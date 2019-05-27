using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    GameObject particleLeft;
    GameObject particleRight;

    float startTime = 0;
    [SerializeField]
    float particleLength = 3f;
    [SerializeField]
    string LeftArmName = "Detector_Left";
    [SerializeField]
    string RightArmName = "Detector_Right";

    void Start()
    {
        particleLeft = GameObject.Find("particles_l");
        particleRight = GameObject.Find("particles_r");

        particleLeft.GetComponent<ParticleSystem>().Stop();
        particleRight.GetComponent<ParticleSystem>().Stop();
    }

    void Update()
    {
        if(particleLeft.GetComponent<ParticleSystem>().isPlaying || particleRight.GetComponent<ParticleSystem>().isPlaying) 
        {
            if (Time.time - startTime > particleLength)
            {
                particleLeft.GetComponent<ParticleSystem>().Stop();
                particleRight.GetComponent<ParticleSystem>().Stop();
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
            particleLeft.GetComponent<ParticleSystem>().Play();
            startTime = Time.time;
        } else if (name == RightArmName)
        {
            particleRight.GetComponent<ParticleSystem>().Play();
            startTime = Time.time;
        }
    }
}

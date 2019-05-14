using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    int nLives = 5;
    [SerializeField]
    float delayTime = 5;

    float startTime;
    bool timerIsOn;
    GameObject particle = null;

    void Start()
    {
        startTime = Time.time;
        particle = GameObject.Find("Particle_Player");
        particle.GetComponent<ParticleSystem>().Stop();
    }

    void Update()
    {
        Timer();
        if (nLives <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Decrease()
    {
        if(timerIsOn)
        {
            nLives = 0;
        } else
        {
            timerIsOn = true;
            startTime = Time.time;
            if(particle)
                particle.GetComponent<ParticleSystem>().Play(); 
        }
    }

    void Timer()
    {
        if(Time.time - startTime >= delayTime)
        {
            timerIsOn = false;
            if (particle)
                particle.GetComponent<ParticleSystem>().Stop();
        } 
    }

    int GetNumLives()
    {
        return nLives;
    }
}

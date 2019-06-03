using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchDetection : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    int nPointsForCatching = 1;
    [SerializeField]
    float TimeBonus = 10;
    [SerializeField]
    GameObject PlusTenObj = null;
    [SerializeField]
    string CanvasName = "Canvas_MainGame";
    [SerializeField]
    AudioSource SlothSound = null;

    bool isActive = false;
    GameObject player;

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {         
        if (other.gameObject.tag == "Sloth")
        {
            if (player != null)
            {
                player.GetComponent<Score>().AddToScore(nPointsForCatching);
                player.GetComponent<ParticleController>().PlayParticle(gameObject.name);
            }

            GlobalVars.SlothCount += nPointsForCatching;

            if (GameObject.Find("Systems").GetComponent<Timer>() != null)
                GameObject.Find("Systems").GetComponent<Timer>().AddToTime(TimeBonus);

            other.gameObject.GetComponent<SlothDestroyer>().Deactivate();

            Instantiate(PlusTenObj, GameObject.Find(CanvasName).transform);

            SlothSound.Play();

            //Destroy(other.gameObject);
        } 
    }
}


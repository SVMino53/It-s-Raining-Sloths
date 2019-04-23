using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchDetection : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    int nPointsForCatching = 1;

    bool isActive = false;
    GameObject player;

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sloth" && isActive)
        {
            if(player!=null)
                player.GetComponent<Score>().AddToScore(nPointsForCatching);
        }
    }

    public void SetActive(bool active)
    {
        isActive = active;
    }

    public bool GetActiveStatus()
    {
        return isActive;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField]
    GameObject starPrefab;
    [SerializeField]
    const int nStars = 10;
    [SerializeField]
    float speed = 20;
    [SerializeField]
    float radius = 5;

    GameObject[] starArray = new GameObject[nStars];
    GameObject player;
    Vector3 playerPos;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        for (int i = 0; i < nStars; i++)
        {
            float angle = i * Mathf.PI * 2 / nStars;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            starArray[i] = Instantiate<GameObject>(starPrefab, pos + transform.position, transform.rotation);
            starArray[i].transform.parent = gameObject.transform;
        }
        Activate(active);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            playerPos = player.transform.position;
            if (player != null)
            {
                transform.Rotate(0, 0, speed * Time.deltaTime);
            }
        }
    }

    public void Activate(bool act)
    {
        active = act;
      
        for(int i=0; i < nStars; i++)
        {
             if(starArray[i])
                starArray[i].GetComponent<MeshRenderer>().enabled = active;
        }
    }
}

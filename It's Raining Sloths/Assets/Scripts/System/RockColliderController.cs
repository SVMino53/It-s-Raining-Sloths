using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColliderController : MonoBehaviour
{
    [SerializeField]
    float startCollisionDistance = 35;
    [SerializeField]
    float timeBeforeDestractionOnBranches = 2;
    GameObject player = null;
    float distanceToPlayer = 0f;
    float curPos = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider>().enabled == false)
        {
            if (player)
            {
                distanceToPlayer = transform.position.y - player.GetComponent<GeneralMovement>().GetCurPosY();
            } else
            {
                Debug.Log("No player found");
            }

            if (distanceToPlayer <= startCollisionDistance)
            {
                GetComponent<Collider>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sloth"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Branch"))
        {
            StartCoroutine(Wait());
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeBeforeDestractionOnBranches);
        Destroy(gameObject);
    }
}

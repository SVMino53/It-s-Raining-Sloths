using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class TextController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI ClimbText;
    [SerializeField]
    string ClimbStr = "Move mat to climb!";
    [SerializeField]
    TextMeshProUGUI RotateText;
    [SerializeField]
    string RotateStr = "Balance to rotate and avoid branches! Don't hit them twice";
    [SerializeField]
    TextMeshProUGUI CatchText;
    [SerializeField]
    string CatchStr = "Press buttons to catch the babies!";
    [SerializeField]
    float delayTime = 2f;

    [SerializeField]
    GameObject rockPrefab;
    [SerializeField]
    GameObject rockSpawner;

    GameObject player; 
    

    bool climbFinished = false;
    bool rotateFinished = false;
    bool catchFinished = false;

    void Start()
    {
        ClimbText.text = ClimbStr;
        player = GameObject.Find("Player");
        player.GetComponent<Rotate_Analog>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ClimbText.text == ClimbStr)
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                StartCoroutine(Wait(ClimbStr));
            }
        }

        if(RotateText.text == RotateStr)
        {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
            {
                StartCoroutine(Wait(RotateStr));
            }

        }

        if(CatchText.text == CatchStr)
        {
            if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G)) && player.GetComponent<Score>().GetScore() > 0)
            {
                StartCoroutine(Wait(CatchStr));
            }
        }
    }

    IEnumerator Wait(string smth)
    {
        yield return new WaitForSeconds(delayTime);

        if (smth == ClimbStr) climbFinished = true;
        else if (smth == RotateStr) rotateFinished = true;
        else if (smth == CatchStr) catchFinished = true;
        Reset();
    }

    private void Reset()
    {
        if (catchFinished)
        {
            CatchText.text = "";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (rotateFinished)
        {
            RotateText.text = "";
            CatchText.text = CatchStr + " " + player.GetComponent<Score>().GetScore() +"/2";
            GameObject.Find("Systems").GetComponent<SpawnSlothBaby>().enabled = true;
            player.GetComponent<GeneralMovement>().moving = true;
        }
        else if (climbFinished)
        {
            ClimbText.text = "";
            RotateText.text = RotateStr;
            player.GetComponent<Rotate_Analog>().enabled = true;
            player.GetComponent<GeneralMovement>().moving = false;
            if (rockPrefab)
            {
                Instantiate<GameObject>(rockPrefab, rockSpawner.transform.position, rockSpawner.transform.rotation);
                rockPrefab = null;
            }
        }
    }
}

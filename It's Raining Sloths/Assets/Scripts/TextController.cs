using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class TextController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ClimbText;
    [SerializeField]
    string ClimbStr = "Move mat to climb!";
    [SerializeField]
    Image climbingImage;

    [SerializeField]
    TextMeshProUGUI RotateText;
    [SerializeField]
    string RotateStr = "Balance to avoid branches and rocks!";
    [SerializeField]
    Image rotateImage;

    [SerializeField]
    TextMeshProUGUI CatchText;
    [SerializeField]
    string CatchStr = "Press buttons to catch the babies!";
    [SerializeField]
    Image[] catchImage;

    [SerializeField]
    TextMeshProUGUI GoodJobText;
    [SerializeField]
    string GoodJobStr = "GOOD JOB!";

    [SerializeField]
    float delayTime = 2f;

    [SerializeField]
    GameObject rockPrefab;
    [SerializeField]
    GameObject rockSpawner;

    [SerializeField]
    string NextSceneName = "Play Test";

    GameObject player; 
    

    bool climbFinished = false;
    bool rotateFinished = false;
    bool catchFinished = false;
    bool goodjobFinished = false;

    void Start()
    {
        ClimbText.text = ClimbStr;

        rotateImage.enabled = false;
        if (catchImage.Length == 2)
        {
            catchImage[0].enabled = false;
            catchImage[1].enabled = false;
        }
        else Debug.Log("Add 2 press button images");

        player = GameObject.Find("Player");
        player.GetComponent<Rotate_Analog>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetAxis("Mouse Y") > 0)
        //    SceneManager.LoadScene(NextSceneName);

        if (ClimbText.text == ClimbStr)
        {
            if (Input.GetAxis("Mouse X") != 0)
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
            if (player.GetComponent<Score>().GetScore() > 0)
            {
                StartCoroutine(Wait(CatchStr));
            }
        }

        if(GoodJobText.text == GoodJobStr)
        {
            StartCoroutine(Wait(GoodJobStr));
        }
    }

    IEnumerator Wait(string smth)
    {
        yield return new WaitForSeconds(delayTime);

        if (smth == ClimbStr) climbFinished = true;
        else if (smth == RotateStr) rotateFinished = true;
        else if (smth == CatchStr) catchFinished = true;
        else if (smth == GoodJobStr) goodjobFinished = true;
        Reset();
    }

    private void Reset()
    {
        if(goodjobFinished)
        {
            SceneManager.LoadScene(NextSceneName);

        } else if (catchFinished)
        {
            CatchText.text = "";
            GoodJobText.text = GoodJobStr;
            player.GetComponent<Rotate_Analog>().enabled = false;
            //player.GetComponent<GeneralMovement>().moving = false;
            if (catchImage.Length == 2)
            {
                catchImage[0].enabled = false;
                catchImage[1].enabled = false;
            }
        }
        else if (rotateFinished)
        {
            RotateText.text = "";
            CatchText.text = CatchStr;
            rotateImage.enabled = false;
            if (catchImage.Length == 2)
            {
                catchImage[0].enabled = true;
                catchImage[1].enabled = true;
            }
            GameObject.Find("Systems").GetComponent<SpawnSlothBaby>().enabled = true;
            player.GetComponent<GeneralMovement>().moving = true;
        }
        else if (climbFinished)
        {
            ClimbText.text = "";
            RotateText.text = RotateStr;
            player.GetComponent<Rotate_Analog>().enabled = true;
            player.GetComponent<GeneralMovement>().moving = false;
            rotateImage.enabled = true;
            climbingImage.enabled = false;
            if (rockPrefab)
            {
                Instantiate<GameObject>(rockPrefab, rockSpawner.transform.position, rockSpawner.transform.rotation);
                rockPrefab = null;
            }
        }
    }
}

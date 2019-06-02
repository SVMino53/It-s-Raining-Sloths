using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class TextController : MonoBehaviour
{
    [SerializeField]
    KeyCode SkipButton = KeyCode.J;

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
    string RotateStrAlt = "Use buttons on sides to avoid branches and rocks!";
    [SerializeField]
    Image rotateImage;

    [SerializeField]
    TextMeshProUGUI CatchText;
    [SerializeField]
    string CatchStr = "Press buttons to catch the babies!";
    [SerializeField]
    string CatchStrAlt = "Let the babies fall into your arms";
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

    KeyCode rotateRight;
    KeyCode rotateLeft;

    bool climbFinished = false;
    bool rotateFinished = false;
    bool catchFinished = false;
    bool goodjobFinished = false;

    void Start()
    {
        //if (!GlobalVars.SpecialMode)
        //    SkipText.text = "Press 'Skip' to skip the tutorial";
        //else {
        //    //change skip button
        //    SkipText.text = "Press SMTH to skip the tutorial";
        //}

        ClimbText.text = ClimbStr;

        rotateImage.enabled = false;
        if (catchImage.Length == 2)
        {
            catchImage[0].enabled = false;
            catchImage[1].enabled = false;
        }
        else Debug.Log("Add 2 press button images");

        player = GameObject.Find("Player");

        if (GlobalVars.SpecialMode) {
            RotateStr = RotateStrAlt;
            CatchStr = CatchStrAlt;
            SkipButton = KeyCode.D;
            rotateLeft = player.GetComponent<Rotate>().GetLeft();
            rotateRight = player.GetComponent<Rotate>().GetRight();
            player.GetComponent<Rotate>().enabled = false;
            player.GetComponent<Rotate_Analog>().enabled = false;
        } else
        {
            rotateLeft = player.GetComponent<Rotate_Analog>().GetLeft();
            rotateRight = player.GetComponent<Rotate_Analog>().GetRight();
            player.GetComponent<Rotate_Analog>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(SkipButton))
            SceneManager.LoadScene(NextSceneName);

        if (ClimbText.text == ClimbStr)
        {
            if (Input.GetAxis("Mouse X") != 0)
            {
                StartCoroutine(Wait(ClimbStr));
            }
        }

        if(RotateText.text == RotateStr)
        {
            if ((Input.GetKeyDown(rotateRight) || Input.GetKeyDown(rotateLeft)))
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

            if(GlobalVars.SpecialMode)
                player.GetComponent<Rotate>().enabled = false;
            else
                player.GetComponent<Rotate_Analog>().enabled = false;

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
            if (catchImage.Length == 2 && !GlobalVars.SpecialMode)
            {
                catchImage[0].enabled = true;
                catchImage[1].enabled = true;
            }
            if(GlobalVars.SpecialMode)
            {
                catchImage[0].enabled = false;
                catchImage[1].enabled = false;
            }
            GameObject.Find("Systems").GetComponent<SpawnSlothBaby>().enabled = true;
            player.GetComponent<GeneralMovement>().moving = true;
        }
        else if (climbFinished)
        {
            ClimbText.text = "";
            RotateText.text = RotateStr;
            if(GlobalVars.SpecialMode) player.GetComponent<Rotate>().enabled = true;
            else player.GetComponent<Rotate_Analog>().enabled = true;
            player.GetComponent<GeneralMovement>().moving = false;
            if(!GlobalVars.SpecialMode)
                rotateImage.enabled = true;
            else
            {
                catchImage[0].enabled = true;
                catchImage[1].enabled = true;
            }
            climbingImage.enabled = false;
            if (rockPrefab)
            {
                Instantiate<GameObject>(rockPrefab, rockSpawner.transform.position, rockSpawner.transform.rotation);
                rockPrefab = null;
            }
        }
    }
}

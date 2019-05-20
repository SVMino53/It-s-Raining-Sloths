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
    string ClimbStr = "Move mat to climb!";
    [SerializeField]
    TextMeshProUGUI RotateText;
    string RotateStr = "Balance to rotate!";
    [SerializeField]
    TextMeshProUGUI CatchText;
    string CatchStr = "Press buttons to catch babies!";
    [SerializeField]
    float delayTime = 2f;

    bool climbFinished = false;
    bool rotateFinished = false;
    bool catchFinished = false;

    void Start()
    {
        ClimbText.text = ClimbStr;
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
            if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G)) && GameObject.Find("Player").GetComponent<Score>().GetScore() > 0)
            {
                StartCoroutine(Wait(CatchStr));
            }
        }
        
        if (catchFinished)
        {
            CatchText.text = "";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (rotateFinished)
        {
            RotateText.text = "";
            CatchText.text = CatchStr;
        }
        else if(climbFinished)
        {
            ClimbText.text = "";
            RotateText.text = RotateStr;
        } 
    }

    IEnumerator Wait(string smth)
    {
        yield return new WaitForSeconds(delayTime);

        if (smth == ClimbStr) climbFinished = true;
        else if (smth == RotateStr) rotateFinished = true;
        else if (smth == CatchStr) catchFinished = true;
    }

    IEnumerator boolLogic()
    {
        
        yield return null;
    } 
}

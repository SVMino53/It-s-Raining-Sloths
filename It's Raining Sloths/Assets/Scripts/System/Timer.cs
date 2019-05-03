using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float startTime;
    [SerializeField]
    float levelLength;
    [SerializeField]
    Text time;
    [SerializeField]
    float waitingTime = 13;

    bool playerReachedTheTop = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    { 
        if(Time.time - startTime>=levelLength && !playerReachedTheTop)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().countPoints(GetTimeLeft());
            StartCoroutine(Wait());
        } else {
            time.text = ((int)levelLength - ((int)(Time.time - startTime))).ToString();
        }
    }

    public float GetTimeLeft()
    {
        return levelLength - (Time.time - startTime);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitingTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

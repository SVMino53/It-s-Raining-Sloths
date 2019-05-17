using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField]
    string MainSceneName = "Video";

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown || Input.GetAxis("Mouse Y") < 0)
        {
            SceneManager.LoadScene(MainSceneName);
        }
    }
}

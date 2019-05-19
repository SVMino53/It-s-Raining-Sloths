using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField]
    string NextSceneName = "Video";
    [SerializeField]
    KeyCode[] allowedKeys;
    [SerializeField]
    bool useMat = false;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<allowedKeys.Length; i++)
        {
            if (Input.GetKeyDown(allowedKeys[i]))
                SceneManager.LoadScene(NextSceneName); 
        }

        if(Input.GetAxis("Mouse Y") < 0 && useMat)
             SceneManager.LoadScene(NextSceneName);
    }
}

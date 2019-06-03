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
        GlobalVars.GameTime = 60;
        GlobalVars.PlayerScore = 0L;
        GlobalVars.Progress = 0.0f;
        GlobalVars.SlothCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<allowedKeys.Length; i++)
        {
            if (Input.GetKeyDown(allowedKeys[i]))
                SceneManager.LoadScene(NextSceneName); 
        }

        if(Input.GetAxis("Mouse X") != 0 && useMat)
             SceneManager.LoadScene(NextSceneName);
    }
}

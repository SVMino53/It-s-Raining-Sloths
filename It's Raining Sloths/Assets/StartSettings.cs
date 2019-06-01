using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSettings : MonoBehaviour
{
    [SerializeField]
    string NextSceneName = "Video";
    // Start is called before the first frame update
    void Start()
    {
        GlobalVars.SpecialMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GlobalVars.SpecialMode = true;
            SceneManager.LoadScene(NextSceneName);
        }
    }
}

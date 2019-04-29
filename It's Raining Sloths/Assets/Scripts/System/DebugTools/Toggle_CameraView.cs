using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_CameraView : MonoBehaviour
{
    [SerializeField]
    GameObject[] Cameras = null;
    [SerializeField]
    KeyCode Toggle = KeyCode.C;

    int ActiveCamera;

    // Start is called before the first frame update
    void Start()
    {
        ActiveCamera = 0;
        Cameras[ActiveCamera].SetActive(true);

        for(int n = 1; n < Cameras.Length; n++)
        {
            Cameras[n].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Toggle))
        {
            Cameras[ActiveCamera].SetActive(false);
            ActiveCamera++;

            if (ActiveCamera >= Cameras.Length)
                ActiveCamera = 0;

            Cameras[ActiveCamera].SetActive(true);
        }
    }
}

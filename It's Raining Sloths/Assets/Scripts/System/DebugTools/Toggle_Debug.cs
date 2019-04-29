using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Debug : MonoBehaviour
{
    [SerializeField]
    GameObject GameCanvas = null;
    [SerializeField]
    GameObject DebugCanvas = null;
    [SerializeField]
    public KeyCode Toggle = KeyCode.H;

    bool DebugIsActive;

    // Start is called before the first frame update
    void Start()
    {
        GameCanvas.SetActive(true);
        DebugCanvas.SetActive(false);
        DebugIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Toggle))
        {
            GameCanvas.SetActive(DebugIsActive);
            DebugCanvas.SetActive(!DebugIsActive);
            DebugIsActive = !DebugIsActive;
        }
    }
}

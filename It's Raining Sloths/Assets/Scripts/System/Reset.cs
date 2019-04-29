using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField]
    KeyCode ResetKey = KeyCode.R;
    [SerializeField]
    int ThisSceneIndex = 0;
    //[SerializeField]
    //GameObject PlayerObj = null;
    //[SerializeField]
    //Vector3 PlayerResetPos = new Vector3(0.0f, 0.0f, 0.0f);
    //[SerializeField]
    //Vector3 PlayerResetRot = new Vector3(0.0f, 0.0f, 0.0f);
    //[SerializeField]
    //string BabySlothTag = "Sloth";

    Quaternion QuatPlayerResetRot;

    // Start is called before the first frame update
    //void Start()
    //{
    //    QuatPlayerResetRot = Quaternion.Euler(PlayerResetRot);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ResetKey))
        {
            //PlayerObj.transform.SetPositionAndRotation(PlayerResetPos, QuatPlayerResetRot);

            SceneManager.LoadScene(ThisSceneIndex, LoadSceneMode.Single);
        }
    }
}

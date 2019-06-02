using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class EyesClosing : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerObj = null;
    [SerializeField]
    float Delay = 5.0f;
    [SerializeField]
    float MinPlayerVelocity = 1.0f;
    [SerializeField]
    float ClosingSpeed = 1.0f;
    [SerializeField]
    float OpeningSpeed = 5.0f;
    [SerializeField]
    float OriginY = 350.0f;
    [SerializeField]
    float ClosedY = 10.0f;
    [SerializeField]
    int ThisSceneIndex = 0;
    [SerializeField]
    string MainCameraName = "Main Camera";
    [SerializeField]
    [Range(0.01f, 1.0f)]
    float BlurSpeed = 0.1f;
    [SerializeField]
    KeyCode LeftRotateKey = KeyCode.A;
    [SerializeField]
    KeyCode RightRotateKey = KeyCode.D;
    

    float PrevPosY;
    float CurPosY;
    float StartDelay = 0.0f;
    bool IsDelaying = false;
    GameObject MainCamera;

    public float CurVelocity = 0.0f;
    public float CurDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        PrevPosY = PlayerObj.transform.position.y;

        MainCamera = GameObject.Find(MainCameraName);
    }

    // Update is called once per frame
    void Update()
    {
        CurPosY = PlayerObj.transform.position.y;

        CurVelocity = CurPosY - PrevPosY;

        if (CurVelocity > MinPlayerVelocity || Input.GetKey(LeftRotateKey) || Input.GetKey(RightRotateKey))
        {
            IsDelaying = false;

            if (Mathf.Abs(transform.localPosition.y) < Mathf.Abs(OriginY))
            {
                transform.Translate(0.0f, OpeningSpeed, 0.0f);
                MainCamera.GetComponent<BlurOptimized>().blurSize += BlurSpeed * OpeningSpeed;
            }
        }
        else if (!IsDelaying)
        {
            StartDelay = Time.time;
            IsDelaying = true;
        }

        CurDelay = Time.time - StartDelay;

        if (Time.time - StartDelay >= Delay && IsDelaying)
        {
            transform.Translate(0.0f, ClosingSpeed, 0.0f);
            MainCamera.GetComponent<BlurOptimized>().blurSize += BlurSpeed * ClosingSpeed;
        }
        
        if (Mathf.Abs(transform.localPosition.y) <= Mathf.Abs(ClosedY))
        {
            Health HealthScript = PlayerObj.GetComponent<Health>();
            HealthScript.SetLives(0);
            enabled = false;
        }

        PrevPosY = PlayerObj.transform.position.y;
    }
}

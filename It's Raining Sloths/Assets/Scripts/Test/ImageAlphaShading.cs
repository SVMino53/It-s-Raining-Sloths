using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaShading : MonoBehaviour
{
    [SerializeField]
    float StartDelay = 3.0f;
    [SerializeField]
    float ShadingTime = 2.0f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float StartAlpha = 0.0f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float EndAlpha = 1.0f;

    Color NewColor = new Color();
    float NewAlpha = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        NewAlpha = StartAlpha;
        NewColor = GetComponent<Image>().color;
        NewColor.a = NewAlpha;
        GetComponent<Image>().color = NewColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= StartDelay && GetComponent<Image>().color.a < EndAlpha && EndAlpha > StartAlpha ||
            Time.timeSinceLevelLoad >= StartDelay && GetComponent<Image>().color.a > EndAlpha && EndAlpha < StartAlpha)
        {
            float AddAlpha = (EndAlpha - StartAlpha) / ShadingTime * Time.deltaTime;
            NewAlpha += AddAlpha;
            NewColor.a = NewAlpha;
            GetComponent<Image>().color = NewColor;
        }

        if (IsDone())
        {
            enabled = false;
        }
    }

    public bool IsDone()
    {
        return GetComponent<Image>().color.a >= EndAlpha && EndAlpha >= StartAlpha ||
               GetComponent<Image>().color.a <= EndAlpha && EndAlpha <= StartAlpha;
    }
}

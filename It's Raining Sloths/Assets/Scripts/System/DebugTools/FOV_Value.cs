using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOV_Value : MonoBehaviour
{
    [SerializeField]
    GameObject SliderObj = null;

    Slider ValueSlider;
    float Value;
    Text ValueText;

    // Start is called before the first frame update
    void Start()
    {
        ValueSlider = SliderObj.GetComponent<Slider>();
        ValueText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Value = ValueSlider.value;

        ValueText.text = Value.ToString();
    }
}

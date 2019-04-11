using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float transparency;
    Renderer rn;
   
    void Start()
    {
 
        rn = gameObject.GetComponent<Renderer>();
        rn.material.color = new Color(rn.material.color.r, rn.material.color.g, rn.material.color.b, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public int fps {get; private set;}
    public TextMeshPro displayFPs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float current = (int)(1f / Time.deltaTime);
        if (Time.frameCount % 50 == 0 )
        {
            displayFPs.text = current.ToString() + "FPS";
        }
    }
}

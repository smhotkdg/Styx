using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public string Name = "temp";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Name = Name + ".png";
            ScreenCapture.CaptureScreenshot(Name);
            
        }
    }
    public void Capture()
    {
        Name = Name + ".png";
        ScreenCapture.CaptureScreenshot(Name);
    }
}

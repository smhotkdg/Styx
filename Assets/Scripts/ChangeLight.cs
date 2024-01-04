using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public float speed = 1f;
    public float time = 1f;
    public Color[] colors;

    int currentID = 0;
    TimerHelper timer;
    Light2D lightSource;
    Color oriColor;
    void Start()
    {
        timer = TimerHelper.Create();

        lightSource = GetComponent<Light2D>();
        oriColor = lightSource.color;
    }
    bool bReset = false;

    void Update()
    {   
        Color color = lightSource.color;
        Color newColor = colors[currentID];
        if(bReset ==false)
        {
            color.r = Mathf.Lerp(color.r, newColor.r, Time.deltaTime * speed);
            color.g = Mathf.Lerp(color.g, newColor.g, Time.deltaTime * speed);
            color.b = Mathf.Lerp(color.b, newColor.b, Time.deltaTime * speed);

            lightSource.color = color;
        }
        else
        {
            Color newColorOri = lightSource.color;
            color.r = Mathf.Lerp(newColorOri.r, oriColor.r, Time.deltaTime * speed);
            color.g = Mathf.Lerp(newColorOri.g, oriColor.g, Time.deltaTime * speed);
            color.b = Mathf.Lerp(newColorOri.b, oriColor.b, Time.deltaTime * speed);
            lightSource.color = color;
        }

        if (timer.Get() > time)
        {
            if(bReset ==false)
            {
                currentID += 1;

                if (currentID >= colors.Length)
                {
                    currentID = 0;
                    bReset = true;
                }
                
            }
            else
            {
                bReset = false;
            }
            timer.Reset();
            
           
        }
    }
}

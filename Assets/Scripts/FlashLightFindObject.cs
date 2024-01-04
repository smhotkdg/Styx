using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
public class FlashLightFindObject : MonoBehaviour
{
    RaySensor2D raySensor;
    GameObject findObject;
    private void Start()
    {
        raySensor = GetComponent<RaySensor2D>();
        raySensor.OnDetected.AddListener(onDetect);
        raySensor.OnLostDetection.AddListener(onLost);
    }
    void onDetect(GameObject detectObejct, Sensor sensor)
    {
        detectObejct.GetComponent<SpriteRenderer>().enabled = true;
        findObject = detectObejct;
    }
    void onLost(GameObject detectObejct, Sensor sensor)
    {
        detectObejct.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void CheckDisable()
    {
        if(findObject!=null)
        {
            findObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

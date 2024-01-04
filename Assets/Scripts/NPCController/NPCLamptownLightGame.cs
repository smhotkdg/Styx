using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLamptownLightGame : MonoBehaviour
{
    public List<GameObject> lampTownLights;

    private void Start()
    {
        if(GameManager.Instance.styxData.strEnableCopperwire =="active")
        {
            StartLightOff();
        }
        else
        {
            StartLightOn();
        }
    }
    public void StartLightOff(bool flag =false)
    {
        for(int i=0; i< lampTownLights.Count; i++)
        {
            lampTownLights[i].SetActive(false);
        }        
        if(flag)
        {
            GameManager.Instance.cameraEffectController.LightEffect();
        }
    }
    public void StartLightOn(bool flag =false)
    {
        for (int i = 0; i < lampTownLights.Count; i++)
        {
            lampTownLights[i].SetActive(true);
        }
        if(flag)
        {
            GameManager.Instance.cameraEffectController.LightEffect();
        }
    }
    bool bflashlight =false;
    public void EnableFlashlight()
    {
        bflashlight = true;
    }
    public void EndConversation()
    {
        if(bflashlight)
        {
            bflashlight = false;
            UIManager.Instance.flashLightUI.SetActive(true);
        }
    }
}

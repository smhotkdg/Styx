using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChecker : MonoBehaviour
{
    bool setRain = false;
    public void CheckEffect(bool flag)
    {
        if (flag == true)
        {
            if (GameManager.Instance.cameraEffectController.isRain)
            {
                GameManager.Instance.cameraEffectController.SetRain(false);
                setRain = true;
            }
            else
            {
                setRain = false;
            }
        }
        else
        {
            if (setRain)
            {
                if (GameManager.Instance.roomPosition == GameManager.RoomPosition.ship || GameManager.Instance.roomPosition == GameManager.RoomPosition.port)
                {
                    GameManager.Instance.cameraEffectController.SetRain(true);
                    setRain = false;
                }             
            }
        }
    }
    private void OnEnable()
    {
        CheckEffect(true);
    }
}

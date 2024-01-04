using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSoundController : MonoBehaviour
{
    int drinkCount = 0;
    public void Drink()
    {
        if (drinkCount < 5)
        {
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.Drink);
            drinkCount++;
        }        
        
    }
    public void Effect_1()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.HiddenPupEffect);
    }
    public void Effect_2()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.HiddenPupEffect_2);
    }
}

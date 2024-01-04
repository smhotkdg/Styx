using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ClickSound : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClickListener);
    }
    void onClickListener()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.TOUCH);
    }    
}

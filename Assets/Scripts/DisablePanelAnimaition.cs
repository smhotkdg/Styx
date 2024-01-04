using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DisablePanelAnimaition : MonoBehaviour
{
    public bool isOnlyPanel = false;
    public delegate void EndAnimationEvent();
    public event EndAnimationEvent EndAnimationEventHandler;

    public delegate void StartAnimationEvent();
    public event StartAnimationEvent StartAnimationEventHandler;
    public GameObject panel;
    public GameObject OpenPanel;
    public void EndAniamtion()
    {
        if(isOnlyPanel==false)
        {
            this.gameObject.SetActive(false);
        }        
        if(panel!=null)
        {
            panel.SetActive(false);
        }
        EndAnimationEventHandler?.Invoke();
    }
    public void StartEndAnimation()
    {
        transform.DOScale(new Vector3(0.15f, 0.15f, 0.15f), 0.75f).SetEase(Ease.OutBack).From(true);
        StartAnimationEventHandler?.Invoke();
    }

    public void OpenClosePanel()
    {
        if(OpenPanel != null)
        {
            OpenPanel.SetActive(true);
        }
    }
}

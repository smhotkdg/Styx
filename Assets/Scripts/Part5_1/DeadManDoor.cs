using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeadManDoor : ObjectChekcer
{
    
    public GameObject uiElement;
    public delegate void OnCompleteMoveDeadMan();
    public event OnCompleteMoveDeadMan OnCompleteMoveDeadManaEventHandler;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    void Click()
    {
        if (AdManager.Instance.isShowPop == true)
        {
            if (AdManager.Instance.ShowPopAds())
            {
                return;
            }
        }
        GetComponent<BoxCollider2D>().enabled = false;
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        OnCompleteMoveDeadManaEventHandler?.Invoke();
    }
    private void FixedUpdate()
    {
        
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.ObjectType.Deaddoor, uiElement, this.gameObject, 50);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}
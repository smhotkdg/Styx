using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SewerDoorTrigger : ObjectChekcer
{
    public GameObject uiElement;
    
    public GameObject UIObject;

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
        UIObject.SetActive(true);
        
    }
 

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.ObjectType.door, uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VentMover : ObjectChekcer
{    
    public GameObject uiElement;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        isBottomSetting = false;
        //OnClickObjectEventHandler += QuestMover_OnClickObjectEventHandler;
    }

    void Click()
    {
        TestCodeManager.Instance.WareHouse();
    }
    //private void QuestMover_OnClickObjectEventHandler()
    //{
    //    TestCodeManager.Instance.WareHouse();
    //}

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110);        
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

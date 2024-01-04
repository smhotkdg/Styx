using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestMover : ObjectChekcer
{
    public bool isRoom = true;
    public GameObject uiElement;    
    private void Start()
    {
        OnEnterObjectEventHandler += QuestMover_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += QuestMover_OnExitObjectEventHandelr;
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

    private void QuestMover_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void QuestMover_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmergencyLock : ObjectChekcer
{
    public GameObject NPC;
    public GameObject uiElement;
    public DialogueSystemTrigger systemTrigger;
    public DialogueSystemTrigger SubMarinKeyStytemTrigger;
    public GameObject UIObject;
    BoxCollider2D boxCollider;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        UIObject.GetComponent<NumberRouletteGameController>().OnFindEventHandler += EmergencyLock_OnFindEventHandler;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void EmergencyLock_OnFindEventHandler()
    {
        DialogueManager.StartConversation(SubMarinKeyStytemTrigger.conversation, this.transform);
    }

    void Click()
    {
        if(GameManager.Instance.styxData.EscapeSubQuestNumber !=5)
        {
            NPC.GetComponent<EmergencyManager>().isSetLeft = true;
            DialogueManager.StartConversation(systemTrigger.conversation, this.transform);
        }
        else
        {
            GameManager.Instance.SetPlayerWork(true);
            UIObject.SetActive(true);
        }
        
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.data.SubmarinKey !=0)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
        }
    }
    public bool isSubmarinKey = false;
    public void SetSubmarinKey()
    {
        isSubmarinKey = true;
    }
    public void EndConversation()
    {
        if(isSubmarinKey)
        {
            GameManager.Instance.SetPlayerWork(false);
            isSubmarinKey = false;
            //열쇠 획득
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.submarinkey);
            TestCodeManager.Instance.GetSubmarinKey();
        }
    }
    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 90);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}
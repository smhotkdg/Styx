using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmergencyLever : ObjectChekcer
{
    public GameObject NPC;
    public GameObject uiElement;
    public DialogueSystemTrigger systemTrigger;    
    public GameObject UIObject;
    BoxCollider2D boxCollider;
    public DisablePanelAnimaition panelAnimaition;
    public GameObject EventPanel;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;        
        boxCollider = GetComponent<BoxCollider2D>();
        panelAnimaition.EndAnimationEventHandler += PanelAnimaition_EndAnimationEventHandler;
    }

    private void PanelAnimaition_EndAnimationEventHandler()
    {
        TestCodeManager.Instance.SetEmergencyLever(true);
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler()
    {
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler;
        EventPanel.SetActive(true);
        
    }

    void Click()
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber != 5)
        {
            NPC.GetComponent<EmergencyManager>().isSetLeft = false;
            DialogueManager.StartConversation(systemTrigger.conversation, this.transform);
        }
        else
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
            GameManager.Instance.SetPlayerWork(true);
            UIObject.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.styxData.isEnableEmergency ==true)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
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

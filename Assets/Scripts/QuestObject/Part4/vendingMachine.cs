using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vendingMachine : ObjectChekcer
{

    public GameObject uiElement;
    public GameObject Game;
    public DialogueSystemTrigger systemTrigger;
    bool isGame = false;

    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        Game.GetComponent<SleepingJuiceController>().OnCompleteEventHandler += VendingMachine_OnCompleteEventHandler;
        Game.GetComponent<SleepingJuiceController>().OnDisableEventHandler += VendingMachine_OnDisableEventHandler;
    }
    bool bComplete =false;
    private void VendingMachine_OnDisableEventHandler()
    {
        if(bComplete ==false)
        {
            GameStart = false;
        }
    }

    private void VendingMachine_OnCompleteEventHandler()
    {
        bComplete = true;
        GetJuice();
        GetSpeeingJuice();
    }

    void Click()
    {
        GameManager.Instance.SetPlayerWork(true);
        DialogueManager.StartConversation(systemTrigger.conversation, this.transform);
    }
    public bool GameStart = false;
    public void EndConversation()
    {
        Game.SetActive(true);
        GameStart = true;

    }
    public void GetJuiceUI()
    {
        DialogueManager.Pause();
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.EscapeSub2);

        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler()
    {
        DialogueManager.Unpause();
    }

    public void GetJuice()
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 2)
        {            
            GameManager.Instance.styxData.EscapeSubQuestNumber = 3;
            GameManager.Instance.data.Juice = 1;
            GameManager.Instance.SaveStyxData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
    }
    public void GetSpeeingJuice()
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 3)
        {
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.SleepingJuice);
            
            GameManager.Instance.styxData.EscapeSubQuestNumber = 4;
            GameManager.Instance.data.slpeepingJuice = 1;
            GameManager.Instance.data.Juice = 0;
            GameManager.Instance.data.sleepingpill = 0;
            GameManager.Instance.SaveStyxData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
            StartCoroutine(NewEventRoutine());
        }
    }
    bool isSleepingJuice = false;
    public void SetSleepingJuice()
    {
        isSleepingJuice = true;
    }
    IEnumerator NewEventRoutine()
    {
        yield return new WaitForSeconds(7f);
        UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.EscapeSub3);
    }
    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    private void FixedUpdate()
    {
        
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 2)
        {
            if (GameStart)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
            
        }
        else
        {
           
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
    private void Bed_OnEnterObjectEventHandler()
    {     
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 90);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }

}

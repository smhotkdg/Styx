using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
public class HospitalCabinet : ObjectChekcer
{
    public bool isRoom = true;
    public GameObject uiElement;
    public GameObject Target;
    public DialogueSystemTrigger systemTrigger;
    public DialogueSystemTrigger systemTrigger_success;
    bool isDoctorPos = false;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        
    }
    void Click()
    {        
        if(GameManager.Instance.data.RingerGameSuccess ==false)
        {
            DialogueManager.StartConversation(systemTrigger.conversation,transform);            
        }
        else
        {
            DialogueManager.StartConversation(systemTrigger_success.conversation, systemTrigger_success.transform);
        }
        GameManager.Instance.SetPlayerWork(true);
    }
    public void StartConversation()
    {
        GameManager.Instance.SetPlayerWork(true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.CONVERSATION;
        GameManager.Instance.SetCameraTarget(Target, 0.5f);
    }
    public void Endconversation()
    {
        
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SetPlayerWork(false);
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.styxData.EscapeSubQuestNumber <2)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void GetDrug()
    {        
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 1&& GameManager.Instance.data.RingerGameSuccess)
        {
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.EscapeSub1);
            GameManager.Instance.styxData.EscapeSubQuestNumber = 2;
            StartCoroutine(NextQuestRoutine());
            GameManager.Instance.data.sleepingpill = 1;
            GameManager.Instance.SaveData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
            GameManager.Instance.SetPlayerWork(false);
        }

    }
    IEnumerator NextQuestRoutine()
    {
        yield return new WaitForSeconds(7f);
        UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.EscapeSub2);
    }
    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}
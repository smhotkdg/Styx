using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Part5DrugQuestObject : ObjectChekcer
{
    public bool isPart5_1 = true;
    public GameObject uiElement;
    BoxCollider2D boxCollider;
    public DialogueSystemTrigger systemTrigger;
    public DialogueSystemTrigger systemTrigger_5_2;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
    }
    private void FixedUpdate()
    {
        if(isPart5_1)
        {
            if (GameManager.Instance.styxData.PartyroomQuest == "active")
            {

                boxCollider.enabled = true;
            }
            else
            {
                boxCollider.enabled = false;
            }
        }
        else
        {
            if (GameManager.Instance.styxData.PartyroomQuest5_2 == "active")
            {

                boxCollider.enabled = true;
            }
            else
            {
                boxCollider.enabled = false;
            }
        }
       
    }
    public void Click()
    {
        if (AdManager.Instance.isShowPop == true)
        {
            if (AdManager.Instance.ShowPopAds())
            {
                return;
            }
        }
        if (isPart5_1)
        {
            if(UIManager.Instance.PartyRoomDrugGame.activeSelf==false)
            {
                GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
                UIManager.Instance.PartyRoomDrugGame.SetActive(true);
                UIManager.Instance.PartyRoomDrugGame.GetComponent<PartroomDrugGame>().OnCompleteEventHander += Part5DrugQuestObject_OnCompleteEventHander;
            }
            
        }
        else
        {
            if (UIManager.Instance.PartyRoomDrugGame_sleeping.activeSelf == false)
            {
                GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
                UIManager.Instance.PartyRoomDrugGame_sleeping.SetActive(true);
                UIManager.Instance.PartyRoomDrugGame_sleeping.GetComponent<PartroomDrugGame>().OnCompleteEventHander += Part5DrugQuestObject_OnCompleteEventHander1;
            }
            
        }
        
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
    }

    private void Part5DrugQuestObject_OnCompleteEventHander1(bool flag)
    {
        Check(flag);
    }

    public void Check(bool flag)
    {
        UIManager.Instance.PartyRoomDrugGame.GetComponent<PartroomDrugGame>().OnCompleteEventHander -= Part5DrugQuestObject_OnCompleteEventHander;
        if (flag)
        {
            boxCollider.enabled = false;
            SetObject(languageController.ObjectType.bed, uiElement, this.gameObject, 500075);
            DisableObject(uiElement);
            uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
            if (isPart5_1)
            {
                GameManager.Instance.styxData.PartyroomQuest = "success";

                DialogueLua.SetQuestField("PartyroomQuest", "State", GameManager.Instance.styxData.PartyroomQuest);
                GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.PartyRoomDrug);
            }
            else
            {
                GameManager.Instance.styxData.PartyroomQuest5_2 = "success";

                DialogueLua.SetQuestField("PartyroomQuest5_2", "State", GameManager.Instance.styxData.PartyroomQuest5_2);
                GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Sleeping);
            }


        }
        else
        {
            if (isPart5_1)
            {
                DialogueManager.StartConversation(systemTrigger.conversation);
            }
            else
            {
                DialogueManager.StartConversation(systemTrigger_5_2.conversation);
            }

        }
    }
    private void Part5DrugQuestObject_OnCompleteEventHander(bool flag)
    {
        Check(flag);
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.ObjectType.bed, uiElement, this.gameObject, 75);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }

}

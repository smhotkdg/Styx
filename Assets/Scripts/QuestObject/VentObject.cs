using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using UnityEngine.UI;
public class VentObject : ObjectChekcer
{
    public Transform MovePosition;
    public GameObject uiElement;
    public Transform movePosition;
    public bool isVent = false;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    public void SetIsVent()
    {
        isVent = true;
    }
    void Click()
    {
        if (GameManager.Instance.GameIndex >= 11)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.random, movePosition, 2);
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);
            return;
        }
        if (DialogueLua.GetVariable("leverQuestItem_3").asInt == 0)
        {
            if(DialogueLua.GetQuestField("part1MainQuest", "State").asString == "active")
            {
                DialogueManager.StartConversation("brokenPart");
                DialogueManager.conversationView.SelectedResponseHandler += ConversationView_SelectedResponseHandler;
            }
            else
            {
                DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.NotSuccess), 2.5f);
            }
            
        }
      
        if (DialogueLua.GetQuestField("part1MainQuest", "State").asString == "success")
        {
            //UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.goLampTown, MovePosition, 1);
            TestCodeManager.Instance.MoveToVent(true);
        }
      
    }


    private void ConversationView_SelectedResponseHandler(object sender, SelectedResponseEventArgs e)
    {
        if(isVent ==true)
        {
            //UIManager.Instance.ScratchGamePanel.SetActive(true);
            UIManager.Instance.ScratchBrokenPartGamePanel.SetActive(true);
            UIManager.Instance.ScratchBrokenPartGamePanel.GetComponent<ScratchCardGameManager>().SetBackgroundImage(ScratchCardGameManager.CardObject.BrokenPart);
            uiElement.SetActive(false);
        }
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void FixedUpdate()
    {
        if (DialogueLua.GetQuestField("part1MainQuest", "State").asString == "success")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        if (DialogueLua.GetVariable("leverQuestItem_3").asInt == 1 && DialogueLua.GetQuestField("part1MainQuest", "State").asString != "success")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void Bed_OnEnterObjectEventHandler()
    {        
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        if (GameManager.Instance.GameIndex >= 11)
        {
            uiElement.GetComponent<Button>().onClick.AddListener(Click);            
            return;
        }
        if (DialogueLua.GetVariable("leverQuestItem_3").asInt==0)
        {            
            SetObject(languageController.Instance.GetText(languageController.ObjectType.vent), uiElement, this.gameObject, 70);
        }
        else if(DialogueLua.GetQuestField("part1MainQuest", "State").asString == "success")
        {            
            SetObject(languageController.Instance.GetText(languageController.ObjectType.vent), uiElement, this.gameObject, 70);
        }

        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

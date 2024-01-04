using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
public class Bed : ObjectChekcer
{
    public GameObject uiElement;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }

    //private void Bed_OnClickObjectEventHandler()
    //{
    //    if (DialogueLua.GetVariable("isBed").asBool == false)
    //    {
    //        DialogueManager.StartConversation("emptyConversation");
    //    }
    //    else
    //    {
    //        DialogueManager.StartConversation("checkBed");
    //        DialogueManager.conversationView.SelectedResponseHandler += ConversationView_SelectedResponseHandler;
    //    }
    //}

    bool isBedItem = false;
    public void SetBedItem()
    {
        isBedItem = true;
    }

    private void ConversationView_SelectedResponseHandler(object sender, SelectedResponseEventArgs e)
    {
        if (DialogueLua.GetVariable("isBed").asBool == false)
        {
            TestCodeManager.Instance.OneDay();
            DialogueManager.conversationView.SelectedResponseHandler -= ConversationView_SelectedResponseHandler;
        }
        if (isBedItem == true)
        {
            UIManager.Instance.ScratchGamePanel.SetActive(true);
            UIManager.Instance.ScratchGamePanel.GetComponent<ScratchCardGameManager>().SetBackgroundImage(ScratchCardGameManager.CardObject.Spoons);
        }
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    void Click()
    {
        if (DialogueLua.GetVariable("isBed").asBool == false)
        {
            DialogueManager.StartConversation("emptyConversation");
        }
        else
        {
            DialogueManager.StartConversation("checkBed");
            DialogueManager.conversationView.SelectedResponseHandler += ConversationView_SelectedResponseHandler;
        }
    }
    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 75);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

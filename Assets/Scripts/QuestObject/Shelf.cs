using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using UnityEngine.UI;
public class Shelf : ObjectChekcer
{
    public GameObject uiElement;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    void Click()
    {
        if (DialogueLua.GetVariable("isShelf").asBool == false)
        {
            DialogueManager.StartConversation("emptyConversation");
        }
        else
        {
            DialogueManager.StartConversation("checkShelf");
            DialogueManager.conversationView.SelectedResponseHandler += ConversationView_SelectedResponseHandler;
        }
    }
    //private void Bed_OnClickObjectEventHandler()
    //{
    //    if (DialogueLua.GetVariable("isShelf").asBool == false)
    //    {
    //        DialogueManager.StartConversation("emptyConversation");
    //    }
    //    else
    //    {
    //        DialogueManager.StartConversation("checkShelf");
    //        DialogueManager.conversationView.SelectedResponseHandler += ConversationView_SelectedResponseHandler; 
    //    }
    //}

    private void ConversationView_SelectedResponseHandler(object sender, SelectedResponseEventArgs e)
    {
        if (isShelfItem == true)
        {
            UIManager.Instance.SlideGeGamePanel.SetActive(true);            

        }
        DialogueManager.conversationView.SelectedResponseHandler -= ConversationView_SelectedResponseHandler;
    }

    bool isShelfItem = false;
    public void SetShelfItem()
    {
        isShelfItem = true;
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject,75);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

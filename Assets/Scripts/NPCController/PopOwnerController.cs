using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOwnerController : MonoBehaviour
{
    bool bEndDeliverly = false;
    bool bSpeacialSeaweedQuestStart = false;
    public void EndDeliverlyQuest()
    {
        bEndDeliverly = true;
    }
    public void EndConversation()
    {
        if(bEndDeliverly ==true)
        {
            TestCodeManager.Instance.DeliveryQuestComplete(true);
            bEndDeliverly = false;
        }
        if(bSpeacialSeaweedQuestStart ==true)
        {
            TestCodeManager.Instance.SetSpeacialSeaweedQuest(false);
            bSpeacialSeaweedQuestStart = false;
        }
        if(bSpeacialSeaweedQuestComplete ==true)
        {
            TestCodeManager.Instance.SetEndSpeacialSeaweedQuest(true);
            bSpeacialSeaweedQuestComplete = false;
        }
        if(bDeliverlyGame ==true)
        {
            UIManager.Instance.JuiceGamePanel.SetActive(true);
            UIManager.Instance.JuiceGamePanel.GetComponent<JuiceGameController>().OnFindJuiceHandler += PopOwnerController_OnFindJuiceHandler;
            bDeliverlyGame = false;
        }
    }

    private void PopOwnerController_OnFindJuiceHandler()
    {
        
        TestCodeManager.Instance.MakeDrinkComplete(true);        
    }


    public void SetSpeacialSeaweedQuestStart()
    {
        bSpeacialSeaweedQuestStart = true;
    }
    bool bSpeacialSeaweedQuestComplete =false;
    public void SetEndSpeacialSeaweedQuest()
    {
        bSpeacialSeaweedQuestComplete = true;
    }

    bool bDeliverlyGame = false;
    public void SetDeliverlyGame()
    {
        bDeliverlyGame = true;
    }
}

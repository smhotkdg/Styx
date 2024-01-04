using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using UnityEngine.UI;
public class SteelLeverFinder : ObjectChekcer
{
    public GameObject findGame;
    public GameObject uiElement;
    BoxCollider2D BoxCollider2;
    // Start is called before the first frame update
    void Start()
    {
        OnEnterObjectEventHandler += WarehousekeyFinder_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += WarehousekeyFinder_OnExitObjectEventHandelr;
        //findGame.GetComponent<NumberRouletteGameController>().OnFindEventHandler += SteelLeverFinder_OnFindEventHandler;
        findGame.GetComponent<RoundPlusGameController>().OnFindEventHandler += SteelLeverFinder_OnFindEventHandler;
        BoxCollider2 = GetComponent<BoxCollider2D>();
    }

    private void SteelLeverFinder_OnFindEventHandler()
    {
        TestCodeManager.Instance.GetSteellever(true);
        //findGame.SetActive(false);        
    }

    private void WarehousekeyFinder_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    bool bStart = false;
    private void WarehousekeyFinder_OnEnterObjectEventHandler()
    {
        if (bStart)
            return;
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 60);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {        
        DialogueManager.instance.StartConversation("SteelleverFindConversation");
        DialogueManager.conversationView.SelectedResponseHandler += ConversationView_SelectedResponseHandler;
    }

    private void ConversationView_SelectedResponseHandler(object sender, SelectedResponseEventArgs e)
    {
        bStart = true;
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        findGame.SetActive(true);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(findGame.activeSelf ==false)
        {
            bStart = false;
        }
        if (GameManager.Instance.styxData.AccesscardQuest == "active" && GameManager.Instance.styxData.SteelLeverCount == 0)
        {
            BoxCollider2.enabled = true;
        }
        else
        {
            BoxCollider2.enabled = false;
        }
    }
}

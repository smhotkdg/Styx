using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HospitalRinger : ObjectChekcer
{
    
    public GameObject uiElement;
    public GameObject Game;
    DialogueSystemTrigger systemTrigger;
    bool isGame = false;
    
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        systemTrigger = GetComponent<DialogueSystemTrigger>();
    }    
    void Click()
    {        
        DialogueManager.StartConversation(systemTrigger.conversation,this.transform);
    }   

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.data.RingerGameSuccess || GameManager.Instance.styxData.EscapeSubQuestNumber ==0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
            
    }
    private void Bed_OnEnterObjectEventHandler()
    {
        if (GameManager.Instance.data.RingerGameSuccess)
            return;
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 90);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void SetGame()
    {
        isGame = true;        
    }
    public void EndConversation()
    {
        if(isGame)
        {           
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
            GameManager.Instance.SetPlayerWork(true);
            Game.SetActive(true);
            isGame = false;
        }
    }
}

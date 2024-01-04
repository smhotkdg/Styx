 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using UnityEngine.UI;
public class PensObject : ObjectChekcer
{
    public GameObject uiElement;
    // Start is called before the first frame update
    void Start()
    {
        OnEnterObjectEventHandler += PensObject_OnEnterObjectEventHandler; 
        OnExitObjectEventHandelr += PensObject_OnExitObjectEventHandelr; 
        //OnClickObjectEventHandler += PensObject_OnClickObjectEventHandler; 
    }

    //private void PensObject_OnClickObjectEventHandler()
    //{
    //    UIManager.Instance.leverGamePanel.SetActive(true);
    //    uiElement.SetActive(false);
    //    GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
    //}

    void Click()
    {
        UIManager.Instance.leverGamePanel.SetActive(true);
        uiElement.SetActive(false);
        //DisableObject(uiElement);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
    }

    private void PensObject_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void PensObject_OnEnterObjectEventHandler()
    {
        if(DialogueLua.GetQuestField("part1MainQuest", "State").asString == "grantable")
        {
            uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
            SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 75);
            uiElement.GetComponent<Button>().onClick.AddListener(Click);

        }
    }  
}

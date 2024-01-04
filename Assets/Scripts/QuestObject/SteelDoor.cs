using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
public class SteelDoor : ObjectChekcer
{
    public GameObject uiElement;
    // Start is called before the first frame update
    void Start()
    {
        OnEnterObjectEventHandler += SteelDoor_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += SteelDoor_OnExitObjectEventHandelr;
    }

    private void SteelDoor_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void SteelDoor_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.steeldoor), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if(GameManager.Instance.styxData.part2_subQuest == "unassigned")
        {
            DialogueManager.StartConversation("getMatser");
            return;

        }
        if(GameManager.Instance.styxData.Part2PasswordQuest == "active" || GameManager.Instance.styxData.Part2PasswordQuest == "success")
        {
            UIManager.Instance.SteelDoorPassword.SetActive(true);
        }
        else
        {
            DialogueManager.StartConversation("DisableSteelDoor");
        }
        
        //DisableObject(uiElement);
    }

}

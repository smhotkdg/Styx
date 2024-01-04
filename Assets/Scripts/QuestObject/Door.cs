using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using UnityEngine.UI;
public class Door : ObjectChekcer
{
    public bool isRoom = true;
    public GameObject uiElement;
    public Transform movePosition;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    void Click()
    {
        if (DialogueLua.GetVariable("isRoomDoor").asBool == false)
        {
            DialogueManager.StartConversation("emptyConversation");
        }
        else
        {
            if (isRoom == true)
            {
                UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.startGame_part1, movePosition, 1);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
            }
            else
            {
                UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.startGame_part1, movePosition, 1);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
            }

        }
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.door), uiElement, this.gameObject,110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
public class ladderWater : ObjectChekcer
{
    public GameObject uiElement;
    public Transform movePosition;
    public GameObject ShipWater;
    public GameObject UnderWater;
    public Transform evnetPlayerPos;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    void Click()
    {
        if (DialogueLua.GetQuestField("Part0Quest", "State").asString == "success")
        {

            //UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.theShip, movePosition, 0);
            UIManager.Instance.SetScenesChangeViewEnable_ShipEvent(languageController.SceneTextType.shipEvent, evnetPlayerPos);
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.ship);
            StartCoroutine(ChangePlayerVerticalMove());
        }
        else
        {
            DialogueManager.StartConversation("emptyConversation_Welding");
        }
    }
    IEnumerator ChangePlayerVerticalMove()
    {
        yield return new WaitForSeconds(0.9f);
        GameManager.Instance.Player.GetComponent<PlayerController>().isHorizontal = true;
        GameManager.Instance.Player.GetComponent<PlayerController>().SetIdle();
        GameManager.Instance.cameraEffectController.SetRain(true);
        ShipWater.SetActive(true);
        UnderWater.SetActive(false);
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 0);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}
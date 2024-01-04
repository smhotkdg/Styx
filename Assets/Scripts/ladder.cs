using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ladder : ObjectChekcer
{    
    public GameObject uiElement;
    public Transform movePosition;
    public GameObject ShipWater;
    public GameObject UnderWater;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    void Click()
    {
        if (GameManager.Instance.isPart0Event)
        {

            GameManager.Instance.Player.GetComponent<PlayerController>().JumpAnimation();
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.underWater, movePosition, 0);
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.underWater);
            StartCoroutine(ChangePlayerVerticalMove());
        }
        else
        {
            DialogueManager.StartConversation("emptyConversation_No");
        }
    }
    IEnumerator ChangePlayerVerticalMove()
    {
        yield return new WaitForSeconds(0.9f);
        GameManager.Instance.Player.GetComponent<PlayerController>().isHorizontal = false;
        GameManager.Instance.Player.GetComponent<PlayerController>().Swiming();
        GameManager.Instance.cameraEffectController.SetRain(false);
        ShipWater.SetActive(false);
        UnderWater.SetActive(true);
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
        SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

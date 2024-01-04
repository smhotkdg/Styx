using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElavatorController : ObjectChekcer
{
    public Transform movePosition;
    public Transform movePositionSkyTown;
    public GameObject uiElement;    
    public GameObject ElavatorObejct;

    public Button SkyTownButton;
    public Text SkyTownText;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
    }
    
    void Click()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        ElavatorObejct.SetActive(true);

        SkyTownButton.interactable = false;
        SkyTownText.color = new Color(0.58f, 0.58f, 0.58f, 0.58f);
    }  
    public void ClickFactory()
    {
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.machineroom, movePosition, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        ElavatorObejct.SetActive(false);
    }
    public void ClickSkyTown()
    {
        ElavatorObejct.SetActive(false);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 80);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

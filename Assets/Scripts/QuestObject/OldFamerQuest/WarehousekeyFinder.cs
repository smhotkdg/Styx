using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using UnityEngine.UI;

public class WarehousekeyFinder : ObjectChekcer
{
    public GameObject FamerGame;
    public ButtonGameManger ButtonGameManger;
    public GameObject uiElement;
    BoxCollider2D BoxCollider2;
    // Start is called before the first frame update
    void Start()
    {
        OnEnterObjectEventHandler += WarehousekeyFinder_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += WarehousekeyFinder_OnExitObjectEventHandelr;
        ButtonGameManger.OnFindEventHandler += ButtonGameManger_OnFindEventHandler;
        BoxCollider2 = GetComponent<BoxCollider2D>();
    }

    private void ButtonGameManger_OnFindEventHandler()
    {
        TestCodeManager.Instance.GetWarehouseKey(true);
        FamerGame.SetActive(false);
        ButtonGameManger.gameObject.SetActive(false);
        if (GameManager.Instance != null)
            GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
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
        bStart = true;
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        FamerGame.SetActive(true);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(FamerGame.activeSelf==false)
        {
            bStart = false;
        }
        if(GameManager.Instance.styxData.AccesscardQuest =="active" && GameManager.Instance.styxData.WarehouseKeyCount ==0)
        {
            BoxCollider2.enabled = true;
        }
        else
        {
            BoxCollider2.enabled = false;
        }
        if(DialogueManager.isConversationActive)
        {
            DisableObject(uiElement);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
public class SeedController : ObjectChekcer
{

    ////씨뿌리기
    //sowing,
    //    //물주기
    //    watering,
    //    //수확하기
    //    harvest

    public enum seedType
    {
        non,
        sowing,
        watering,
        harvest
    }
    public SeedGameController gameController;

    public Sprite seed;
    public Sprite watring;
    public Sprite harvest;
    public seedType type = seedType.non;
    public GameObject uiElement;
    bool bStart = false;
    // Start is called before the first frame update

    void Start()
    {
        OnEnterObjectEventHandler += SeedController_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += SeedController_OnExitObjectEventHandelr;
        gameController.onOnEndPanelEnvetHandler += GameController_onOnEndPanelEnvetHandler;
        gameController.OnDisablePanelEvent += GameController_OnDisablePanelEvent;
        transform.DOShakeScale(0.2f, 0.2f).SetLoops(-1);
    }

    private void GameController_OnDisablePanelEvent()
    {
        bStart = false;
    }
   
    private void GameController_onOnEndPanelEnvetHandler()
    {
        bStart = false;
        if (type == seedType.sowing)
        {            
            GetComponent<SpriteRenderer>().sprite = watring;
        }
        if (type == seedType.watering)
        {
            GetComponent<SpriteRenderer>().sprite = harvest;
        }
        if (type == seedType.harvest)
        {
            gameObject.SetActive(false);
        }
    }

    private void SeedController_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void SeedController_OnEnterObjectEventHandler()
    {
        if (bStart)
            return;
        if (GameManager.Instance.Player.GetComponent<PlayerController>().isPlayWagon == true)
            return;
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.door), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        bStart = true;
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
       
        if (type == seedType.non)
        {
            UIManager.Instance.SeedGameController.SetActive(true);
            gameController.SetView(seedType.sowing, this.gameObject);
        }
        if (type == seedType.sowing)
        {
            UIManager.Instance.SeedGameController.SetActive(true);
            gameController.SetView(seedType.watering, this.gameObject);
        }
        if (type == seedType.watering)
        {
            UIManager.Instance.SeedGameController.SetActive(true);
            gameController.SetView(seedType.harvest, this.gameObject);
            GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
        }
        
    }   
}

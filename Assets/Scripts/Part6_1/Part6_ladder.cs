using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Part6_ladder : ObjectChekcer
{
    public Part6_2Hardware hardware;
    public GameObject uiElement;
    public bool isPart6_2 = false;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    void Click()
    {
        if (AdManager.Instance.isShowPop == true)
        {
            if (AdManager.Instance.ShowPopAds())
            {
                return;
            }
        }
        GameManager.Instance.playerController.LadderPlayIdle();
        GameManager.Instance.playerController.OnlyVertical = true;
        GameManager.Instance.playerController.SetFreezeY();
        GetComponent<BoxCollider2D>().enabled = false;

        Vector2 NewPos = GameManager.Instance.Player.transform.position;
        NewPos.x = transform.position.x;
        GameManager.Instance.Player.transform.position = NewPos;
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();

        if (isPart6_2)
        {
            GameManager.Instance.styxData.Part5_2EventCount = 17;
            DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);            
            hardware.StartLadderEvent();
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
        SetObject(languageController.ObjectType.door, uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GateKeeperHint : ObjectChekcer
{
    public bool isNormal =false;
    public GameObject GameUI;
    public GameObject uiElement;
    public bool isNamePlate = false;

    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
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
        if (GameUI.activeSelf ==false)
        {
            GameUI.SetActive(true);
            if(isNamePlate==false)
            {
                GameUI.transform.Find("BG/Panel/Part6_1").gameObject.SetActive(false);
                GameUI.transform.Find("BG/Panel/Part6_2").gameObject.SetActive(false);
                if (GameManager.Instance.data.isChoiceMember == 2)
                {
                    GameUI.transform.Find("BG/Panel/Part6_2").gameObject.SetActive(true);
                }
                else
                {
                    GameUI.transform.Find("BG/Panel/Part6_1").gameObject.SetActive(true);
                }
            }
          
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
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
        if(isNormal)
        {
            SetObject(languageController.ObjectType.bed, uiElement, this.gameObject, 100);
        }
        else
        {
            SetObject(languageController.ObjectType.bed, uiElement, this.gameObject, 0, 50);
        }
        
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

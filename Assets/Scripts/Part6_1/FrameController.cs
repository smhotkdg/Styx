using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FrameController : ObjectChekcer
{
    
    public GameObject uiElement;

    public SymbolGameController SymbolGameController;
    public _2dxFX_DesintegrationFX Number;
    public _2dxFX_DesintegrationFX Number_6_2;

    public SymbolGameController.SymbolType symbolType = SymbolGameController.SymbolType.Blue;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        SymbolGameController.OnCompleteEventHandler += SymbolGameController_OnCompleteEventHandler;
        SymbolGameController.OnCloseEventHandler += SymbolGameController_OnCloseEventHandler;
        Number.Desintegration = 1;
        if(Number_6_2!=null)
            Number_6_2.Desintegration = 1;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }

    private void SymbolGameController_OnCloseEventHandler()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }

    private void SymbolGameController_OnCompleteEventHandler(SymbolGameController.SymbolType type)
    {
        if(symbolType == type)
        {
            SymbolGameController.OnCompleteEventHandler -= SymbolGameController_OnCompleteEventHandler;
            StartCoroutine(NumberChangeRoutine());
        }
    }

    IEnumerator NumberChangeRoutine()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        SymbolGameController.gameObject.SetActive(false);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.WIPING);
        for (int i = 0; i < 100; i++)
        {
            if (GameManager.Instance.data.isChoiceMember == 2)
            {
                if (Number_6_2 != null)
                    Number_6_2.Desintegration -= 0.01f;
            }
            else
            {
                Number.Desintegration -= 0.01f;
            }

            yield return new WaitForSeconds(0.01f);
        }
        if (GameManager.Instance.data.isChoiceMember == 2)
        {
            if (Number_6_2 != null)
                Number_6_2.Desintegration = 0f;
        }
        else
        {
            Number.Desintegration = 0f;
        }
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
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;

        SymbolGameController.gameObject.SetActive(true);
        
        switch (symbolType)
        {
            case SymbolGameController.SymbolType.Red:
                SymbolGameController.symbolType = SymbolGameController.SymbolType.Red;
                break;
            case SymbolGameController.SymbolType.Blue:
                SymbolGameController.symbolType = SymbolGameController.SymbolType.Blue;
                break;
            case SymbolGameController.SymbolType.Yellow:
                SymbolGameController.symbolType = SymbolGameController.SymbolType.Yellow;
                break;
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
        SetObject(languageController.ObjectType.door, uiElement, this.gameObject, -100);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

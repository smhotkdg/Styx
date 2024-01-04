using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
public class HardwareStoreFindChess : ObjectChekcer
{
    public GameObject uiElement;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    public void Click()
    {
        //OnClickObjectEventHandler?.Invoke();        
        UIManager.Instance.ChessFindGame.SetActive(true);
    }
    //private void Bed_OnClickObjectEventHandler()
    //{
    //    //클릭 이벤트
    //    UIManager.Instance.ChessFindGame.SetActive(true);
    //}

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 75);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

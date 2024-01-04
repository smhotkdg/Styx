using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProfessorRoomBook : ObjectChekcer
{
    public GameObject uiElement;
    public bool isNormal = false;
    public GameObject NormalBook;
    public GameObject GetDroneBook;
    public GameObject MainDoor;
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
        if (isNormal)
        {
            if(NormalBook.activeSelf ==false)
            {
                GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
                NormalBook.SetActive(true);
            }
            
        }
        else
        {
            if(GetDroneBook.activeSelf ==false)
            {
                GetDroneBook.SetActive(true);
                GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
            }
            
        }
        
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.styxData.DroneCheck =="success")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            MainDoor.SetActive(false);
        }
        else if(GameManager.Instance.styxData.DroneCheck == "active")
        {
            GetComponent<BoxCollider2D>().enabled = true;
            MainDoor.SetActive(true);
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
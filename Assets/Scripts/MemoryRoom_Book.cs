using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MemoryRoom_Book : ObjectChekcer
{
    public GameObject uiElement;
    public GameObject bookObject;
    public enum bookType
    {
        Headmaster,
        Revolution
    }
    public BoxCollider2D boxCollider;
    public bookType m_bookType = bookType.Headmaster;
    //교주와 함께 1 , 관리자와 함께 2
    //public int isChoiceMember = -1;

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
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        bookObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.data.isChoiceMember ==1)
        {
            if(m_bookType == bookType.Headmaster)
            {
                boxCollider.enabled = true;
            }
            else
            {
                boxCollider.enabled = false;
            }
        }
        if (GameManager.Instance.data.isChoiceMember == 2)
        {
            if (m_bookType == bookType.Revolution)
            {
                boxCollider.enabled = true;
            }
            else
            {
                boxCollider.enabled = false;
            }
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
        SetObject(languageController.ObjectType.read, uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}
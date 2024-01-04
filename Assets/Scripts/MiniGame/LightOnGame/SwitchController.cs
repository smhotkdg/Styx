using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchController : MonoBehaviour
{
    public delegate void OnCommitSwitch(SwitchController switchController, int value);
    public event OnCommitSwitch OnCommitSwitchEventHandler;

    public int lightCount = 0;
    public GameObject uiElement;
    //여기 스위치 이미지로 변경
    public Sprite OnSprite;
    public Sprite OffSprite;
    SpriteRenderer SwitchImage;

    bool bStay = false;
    public bool bOn = false;
    private void OnEnable()
    {
        bOn = false;
        bStay = false;
        SetSwitchText();
    }
    private void Start()
    {
        SwitchImage = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            
            uiElement.SetActive(true);
            uiElement.GetComponent<UiTargetManager>().WorldObject = this.gameObject;

            SetSwitchText();
            uiElement.GetComponent<Button>().onClick.AddListener(SelectOnOff);

            bStay = true;
        }
    }
    void SelectOnOff()
    {
        bOn = !bOn;
        SetSwitchText();
        if (!bOn)
        {
            OnCommitSwitchEventHandler?.Invoke(this.GetComponent<SwitchController>(),-lightCount);
        }
        else
        {
            OnCommitSwitchEventHandler?.Invoke(this.GetComponent<SwitchController>(),lightCount);
        }
        
    }
    public void SetOn()
    {
        bOn = false;
        SetSwitchText();
    }
    void SetSwitchText()
    {
        if (bOn == false)
        {
            uiElement.transform.Find("Text").gameObject.GetComponent<Text>().text = "On";
            if (SwitchImage == null)
                return;
            SwitchImage.sprite = OffSprite;
            //SwitchImage.color = new Color(1, 1, 1, 1);            
        }
        else
        {
            uiElement.transform.Find("Text").gameObject.GetComponent<Text>().text = "Off";
            if (SwitchImage == null)
                return;
            SwitchImage.sprite = OnSprite;
            //SwitchImage.color = new Color(1,0,0,1);            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (uiElement != null)
            {
                uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
                uiElement.SetActive(false);
            }

            bStay = false;
        }
    }


    private void QuestObjectController_onOnEndPanelEnvetHandler()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
        //Debug.Log("hhh");
    }

    private void FixedUpdate()
    {
        if (bStay == true)
        {
            if (uiElement != null)
            {               
                if (GameManager.Instance.gameStatus == GameManager.GameStatus.NOTING)
                    uiElement.SetActive(true);
               
            }
            if (GameManager.Instance.gameStatus != GameManager.GameStatus.NOTING)
            {
                uiElement.SetActive(false);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
public class ObjectChekcer : MonoBehaviour
{
    public bool isBottomSetting = true;
    public delegate void OnClickObject();
    public event OnClickObject OnClickObjectEventHandler;

    public delegate void OnEnterObject();
    public event OnEnterObject OnEnterObjectEventHandler;

    public delegate void OnExitObject();
    public event OnExitObject OnExitObjectEventHandelr;

    public bool bStay = false;
    string strname; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {   
            bStay = true;
            OnEnterObjectEventHandler?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {          
            bStay = false;
            OnExitObjectEventHandelr?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)  
    {
        if(collision.tag =="player")
        {
            bStay = true;
            OnEnterObjectEventHandler?.Invoke();
        }      
    }
    GameObject UiElemnet;
    public void SetObject(string title,GameObject ui,GameObject pObject,int yMargin,int xMargin =0)
    {
        if(DialogueLua.GetVariable("oldManIndex").asInt ==0)
        {
            if(GameManager.Instance.roomPosition == GameManager.RoomPosition.ship || GameManager.Instance.roomPosition == GameManager.RoomPosition.underWater)
            {
                UiElemnet = ui;
                ui.SetActive(true);
                ui.transform.Find("Text").gameObject.GetComponent<Text>().text = title;
                //ui.GetComponent<Button>().onClick.AddListener(Click);
                ui.GetComponent<UiTargetManager>().WorldObject = pObject;
                ui.GetComponent<UiTargetManager>().y_Margin = yMargin;
                ui.GetComponent<UiTargetManager>().x_Margin = xMargin;
            }
            return;
        }
        
        UiElemnet = ui;
        ui.SetActive(true);        
        ui.transform.Find("Text").gameObject.GetComponent<Text>().text = title;
        //ui.GetComponent<Button>().onClick.AddListener(Click);
        ui.GetComponent<UiTargetManager>().WorldObject = pObject;
        ui.GetComponent<UiTargetManager>().y_Margin = yMargin;
        ui.GetComponent<UiTargetManager>().x_Margin = xMargin;
    }
    public void DisableObject(GameObject ui)
    {
        //ui.GetComponent<Button>().onClick.RemoveAllListeners();        
        if(UiElemnet !=null)
        {
            
            UiElemnet.SetActive(false);
        }
            
        UiElemnet = null;

        ui.SetActive(false);
        

    }
    private void Update()
    {
      
            
        if (isBottomSetting == false)
            return;


        if(UiElemnet !=null)
        {
            if (GameManager.Instance.gameStatus != GameManager.GameStatus.NOTING)
            {
                UiElemnet.SetActive(false);
                return;
            }
        }
        

        if(UiElemnet !=null)
        {
            UiElemnet.SetActive(UIManager.Instance.CheckBottomUI());
        }

        if (UiElemnet != null && UIManager.Instance.CheckBottomUI() ==true)
        {
            if (DialogueManager.isConversationActive == false)
            {                
                UiElemnet.SetActive(true);
            }
            else
            {
                
                UiElemnet.SetActive(false);
            }
        }
        
    }
    public void Click()
    {        
        //OnClickObjectEventHandler?.Invoke();        
    }

    
}

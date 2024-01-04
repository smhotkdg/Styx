using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CCTV : ObjectChekcer
{
    public bool isPart5_1 = true;
    public bool isRoom = true;
    public GameObject uiElement;    
    private void Start()
    {       
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        if(isPart5_1)
        {
            if(GameManager.Instance.styxData.CCTVQuest =="active")
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else
        {
            if (GameManager.Instance.styxData.CCTV_Part5_2 == "active")
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        
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
        if (isPart5_1)
        {
            if(UIManager.Instance.CCTVUI.activeSelf ==false)
            {
                GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
                UIManager.Instance.CCTVUI.SetActive(true);
                UIManager.Instance.CCTVUI.GetComponent<Part5CctvGame>().OnCompleteQuestEventHandler += CCTV_OnCompleteQuestEventHandler;
            }
            
        }
        else
        {
            if (UIManager.Instance.Part5_2CCTV.activeSelf == false)
            {
                GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
                UIManager.Instance.Part5_2CCTV.SetActive(true);
                UIManager.Instance.Part5_2CCTV.GetComponent<Part5CctvGame>().OnCompleteQuestEventHandler += CCTV_OnCompleteQuestEventHandler;
            }
            
        }
        
    }

    private void CCTV_OnCompleteQuestEventHandler()
    {
        if (isPart5_1)
        {
            UIManager.Instance.CCTVUI.GetComponent<Part5CctvGame>().OnCompleteQuestEventHandler -= CCTV_OnCompleteQuestEventHandler;
            
            GameManager.Instance.styxData.CCTVQuest = "success";
            DialogueLua.SetQuestField("CCTVQuest", "State", "success");
            GetComponent<BoxCollider2D>().enabled = false;
            DisableObject(uiElement);
            uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Part5_cctv);
        }
        else
        {
            UIManager.Instance.Part5_2CCTV.GetComponent<Part5CctvGame>().OnCompleteQuestEventHandler -= CCTV_OnCompleteQuestEventHandler;
            
            GameManager.Instance.styxData.CCTV_Part5_2= "success";
            DialogueLua.SetQuestField("CCTV_Part5_2", "State", "success");
            TestCodeManager.Instance.StartPart5_2StartCCTVQuestComplete(false);
            GetComponent<BoxCollider2D>().enabled = false;
            DisableObject(uiElement);
            uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Part5_cctv);
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
        SetObject(languageController.ObjectType.cctv, uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

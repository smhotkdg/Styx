using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
public class SelectWordNumberGame : MonoBehaviour
{
    public ChapelMasterController masterController;

    public delegate void OnFind(string number);
    public event OnFind OnFindEventHandler;


    public delegate void OnFindCabinet();
    public event OnFindCabinet OnFindCabinetHandler;

    //DeathSizer password - 4 2 6 8 5
    public enum passwordType {
        normal,
        steeldoor,
        codeGame,
        Cabinet
    }
    public passwordType password = passwordType.normal;
    public SafeBox safeBox;
    public BoxCollider2D NoramlPassword;
    public Text PassWordText;
    List<int> numberList = new List<int>();
    public void SelectNumber(int index)
    {
        if(index == -1)
        {
            //del
            if(numberList.Count <=0)
            {                
                return;
            }
            else
            {
                numberList.RemoveAt(numberList.Count-1);              
            }
        }
        else if(index ==-2)
        {
            //commit
            string strNumber = string.Empty;
            for(int i=0; i< numberList.Count; i++)
            {
                strNumber += numberList[i];
            }
            if(password == passwordType.normal)
            {
                if (strNumber == "62381")
                {
                    
                    safeBox.gameObject.SetActive(true);
                    safeBox.SetOpen();
                    Debug.Log("번호 찾기 성공");
                }
                else
                {
                    Debug.Log("번호 찾기 실패");
                }
            }
            else if(password == passwordType.steeldoor)
            {
                if (strNumber == "42685")
                {
                    this.gameObject.SetActive(false);
                    //강철문 열림
                    //if(GameManager.Instance.isBeta)
                    //{
                    //    UIManager.Instance.BetaEndUI.SetActive(true);
                    //}
                    //else
                    //{
                    //    TestCodeManager.Instance.GoSkyTown(true);
                    //}
                    if(password == passwordType.steeldoor)
                    {
                        UIManager.Instance.SteerDoorTopPanel.GetComponent<SteelDoorController>().SetOpen();
                    }
                    this.gameObject.SetActive(false);
                    Debug.Log("번호 찾기 성공");
                }
                else
                {
                    Debug.Log("번호 찾기 실패");
                }
            }
            else if (password == passwordType.codeGame)
            {
                if (strNumber == "19")
                {
                    //this.gameObject.SetActive(false);
                    //GameManager.Instance.cameraEffectController._Matrix.enabled = false;

                    Debug.Log("번호 찾기 성공");

                    GameManager.Instance.styxData.EngineerComputerQuest = "returnToNPC";
                    DialogueLua.SetQuestField("EngineerComputerQuest", "State", GameManager.Instance.styxData.EngineerComputerQuest);                    
                }
                else
                {
                    Debug.Log("번호 찾기 실패");
                }
                OnFindEventHandler?.Invoke(strNumber);
            }
            else if(password == passwordType.Cabinet)
            {
                if(strNumber == "2142229")
                {
                    Debug.Log("번호 찾기 성공");
                    transform.Find("FindUI").gameObject.SetActive(true);
                    transform.Find("SelectNumber").gameObject.SetActive(false);
                    transform.Find("GridNumber").gameObject.SetActive(false);
                    transform.Find("Exit").gameObject.SetActive(false);
                    OnFindCabinetHandler?.Invoke();
                }
                else
                {
                    Debug.Log("번호 찾기 실패");
                }
            }
        }
        else
        {
            numberList.Add(index);
            //번호 입력
        }
        SetText();
    }
    bool bTween = false;
    IEnumerator EndRoutine()
    {
        if(masterController!=null)
            masterController.setEnableBox();
        yield return new WaitForSeconds(0.2f);
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Coin));
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Coin), 2.5f);
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Coin);
        yield return new WaitForSeconds(0.1f);
        TestCodeManager.Instance.GetCoins(false);
        if(password == passwordType.steeldoor)
        {
            UIManager.Instance.SteerDoorTopPanel.GetComponent<SteelDoorController>().SetOpen();
        }
        this.gameObject.SetActive(false);

    }
    private void OnEnable()
    {
        numberList.Clear();
        SetText();
        if(password== passwordType.Cabinet)
        {
            transform.Find("SelectNumber").gameObject.SetActive(true);
            transform.Find("GridNumber").gameObject.SetActive(true);
            transform.Find("FindUI").gameObject.SetActive(false);
            transform.Find("Exit").gameObject.SetActive(true);
        }
        if(password == passwordType.steeldoor)
        {
            UIManager.Instance.SteerDoorTopPanel.SetActive(true);
        }
        if(password == passwordType.normal)
        {
            safeBox.gameObject.SetActive(true);
            safeBox.OnCompleteHandler += SafeBox_OnCompleteHandler;
        }
    }

    private void SafeBox_OnCompleteHandler()
    {
        StartCoroutine(EndRoutine());
    }
    private void OnDisable()
    {
        if (password == passwordType.normal)
        {
            safeBox.OnCompleteHandler -= SafeBox_OnCompleteHandler;
            NoramlPassword.enabled = true;
        }
    }
    public void GetAccessCard()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.accesscard));
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.accesscard), 2.5f);
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.accesscard);
        TestCodeManager.Instance.mainAccesscardGet();
        this.gameObject.SetActive(false);
    }
    void SetText()
    {
        if (numberList.Count == 0)
        {
            PassWordText.text = "-----";
            return;
        }
        string strNumber = string.Empty;
        for (int i = 0; i < numberList.Count; i++)
        {
            strNumber += numberList[i];
        }
        PassWordText.text = strNumber;
        if(bTween ==false)
        {
            bTween = true;
            PassWordText.DOColor(new Color(1, 1, 1, 0.1f), 0.25f).From(false).SetLoops(3).OnComplete(EndTween);
        }
        
    }
    void EndTween()
    {
        bTween = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using DG.Tweening;
public class DragLineGameController : MonoBehaviour
{
    public GameObject BG;
    public List<GameObject> TopObject;
    List<int> cubeList = new List<int>();
    public List<GameObject> objectList;
    public List<GameObject> PanelList;
    private void Start()
    {
        bComplete = false;
    }
    private void OnDisable()
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            objectList[i].GetComponent<ObjectSettings>().OnGetDDMEventHandler -= DragLineGameController_OnGetDDMEventHandler;
        }
    }
    private void OnEnable()
    {
        bComplete = false;
        checkCount = 0;

        for (int i = 0; i < objectList.Count; i++)
        {
            objectList[i].GetComponent<ObjectSettings>().OnGetDDMEventHandler += DragLineGameController_OnGetDDMEventHandler;
        }
        if (ddmCount >= objectList.Count)
        {
            MakeRandom();
        }
    }
    bool bComplete = false;
    int checkCount = 0;
    public void CheckComplete()
    {
        CheckEffect();
        checkCount++;
        if(checkCount >= PanelList.Count)
        {
            bComplete = true;
            checkCount = 0;
        }
        if (bComplete == false)
            return;
        bool bCompleteObject = true;

        //4 5 9 13
        //
        for (int i =0; i< PanelList.Count;i++)
        {
            int panelIndex = i + 1;
            string strPanelID = "panel" + panelIndex;
            string strPanelObject = DragDropManager.GetPanelObject(strPanelID);
            string strObjectID = "object" + panelIndex;
            if(objectList[i].GetComponent<_2dxFX_StoneFX>().enabled == true)
            {                
                bCompleteObject = false;                
            }           
        }
        if (bCompleteObject == false)
            return;
        BG.transform.DOShakeScale(0.5f, 0.2f).SetEase(Ease.OutBounce).OnComplete(CompleteTween);                
    }
    void CheckEffect()
    {
        for (int i = 0; i < PanelList.Count; i++)
        {
            int panelIndex = i + 1;
            string strPanelID = "panel" + panelIndex;
            string strPanelObject = DragDropManager.GetPanelObject(strPanelID);
            string strObjectID = "object" + panelIndex;
            if (strPanelObject != strObjectID)
            {
                objectList[i].GetComponent<_2dxFX_StoneFX>().enabled = true;
            }
            else
            {
                objectList[i].GetComponent<_2dxFX_StoneFX>().enabled = false;
            }
        }
    }
    void CompleteTween()
    {
        StartCoroutine(endRoutine());

        TestCodeManager.Instance.GetRaido();
        Debug.Log("Complete");
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Radio));
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Radio);
    }
    IEnumerator endRoutine()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Radio));
        yield return new WaitForSeconds(0.7f);
        this.gameObject.SetActive(false);
    }
    int ddmCount;
    private void DragLineGameController_OnGetDDMEventHandler()
    {
        ddmCount++;
        if(ddmCount >=objectList.Count)
        {
            MakeRandom();
        }
    }
    void MakeRandom()
    {
        if (cubeList.Count > 0)
            cubeList.Clear();
        CreateUnDuplicateRandom(0, 15);
        for (int i = 0; i < objectList.Count; i++)
        {
            int index = cubeList[i] + 1;
            string panelId = "panel" + index.ToString();            
            objectList[i].GetComponent<RandomDrag>().SetRandom(panelId);
        }
        ///bComplete = true;
        CheckEffect();
    }


    // 랜덤 생성 (중복 배제)
    void CreateUnDuplicateRandom(int min, int max)
    {
        if (cubeList.Count > 0)
            return;
        int currentNumber = Random.Range(min, max);

        for (int i = 0; i < max;)
        {
            if (cubeList.Contains(currentNumber))
            {
                currentNumber = Random.Range(min, max);
                if(cubeList.Count >= max)
                {
                    break;
                }
            }
            else
            {
                cubeList.Add(currentNumber);
                i++;
            }
        }
    }
}

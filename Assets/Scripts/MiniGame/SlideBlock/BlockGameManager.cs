using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
public class BlockGameManager : MonoBehaviour
{
    public enum BlockItemType
    {
        line,
        sugar
    }
    public BlockItemType ItemType = BlockItemType.line;
    public int level;

    public List<BlockObject> Level_1Blocks;
    public GameObject Level1KeyObject;
    public bool isMove = true;
    GameObject keyObject;
    bool bFindKey = false;

    private void Start()
    {
        bFindKey = false;
       
    }    
    private void OnDisable()
    {
        if(keyObject !=null)
        {
            keyObject.transform.localPosition = new Vector3(0, 105, 0);
            bFindKey = false;
        }        
    }

    public void CheckKey()
    {
        if (bFindKey == true)
            return;
        if(isMove ==false)
        {
            switch(level)
            {
                case 0:
                    keyObject = Level1KeyObject;
                    break;
            }            
        }

        if(keyObject.transform.Find("BoxFinder").gameObject.GetComponent<RaySensor2D>().DetectedObjects.Count ==0)
        {
            keyObject.transform.DOLocalMove(new Vector3(keyObject.transform.localPosition.x, keyObject.transform.localPosition.y - 70, transform.localPosition.z), 0.2f).OnComplete(CheckNext);
            if(keyObject.transform.Find("GoalFinder").gameObject.GetComponent<RaySensor2D>().DetectedObjects.Count >0)
            {
                if(ItemType == BlockItemType.line)
                {
                    keyObject.transform.DOLocalMove(new Vector3(keyObject.transform.localPosition.x, -105f, transform.localPosition.z), 0.2f).OnComplete(EndTween);
                    Debug.Log("열쇠획득!");
                    DialogueLua.SetVariable("isShelf", false);
                    bFindKey = true;
                }
                else if(ItemType == BlockItemType.sugar)
                {
                    Debug.Log("설탕 획득");
                    bFindKey = true;
                }
                
            }
        }
    }
    public void EndTween()
    {
        StartCoroutine(DisablePanelRoutine());
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.stringLine));
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.stringLine);
        DialogueLua.SetVariable("leverQuestItem_2", 1);
        GameManager.Instance.data.stringline = 1;
    }
    IEnumerator DisablePanelRoutine()
    {
        yield return new WaitForSeconds(0.4f);
        this.gameObject.SetActive(false);
    }
    void CheckNext()
    {
        CheckKey();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class SugarGameManager : MonoBehaviour
{
    public GameObject WarehouseManager;
    public List<GameObject> LeftObjectList;
    public List<GameObject> RightObjectList;

    public List<GameObject> LeftPosList;
    public List<GameObject> RightPosList;

    public bool isMove;
    private void OnEnable()
    {
        for(int i=0; i< LeftObjectList.Count; i++)
        {
            LeftObjectList[i].transform.SetParent(LeftPosList[i].transform);
            LeftObjectList[i].transform.localPosition = new Vector3(0, 0, 0);
            LeftObjectList[i].GetComponent<SugarFindController>().setSensor();
        }
        for (int i = 0; i < RightObjectList.Count; i++)
        {
            RightObjectList[i].transform.SetParent(RightPosList[i].transform);
            RightObjectList[i].transform.localPosition = new Vector3(0, 0, 0);
            RightObjectList[i].GetComponent<SugarFindController>().setSensor();
        }
        isMove = true;
    }
    public void CheckGame()
    {
        for(int i=0; i< LeftPosList.Count; i++)
        {
            if(LeftPosList[i].transform.childCount <=0)
            {
                return;
            }
            else
            {
                if(LeftPosList[i].transform.GetChild(0).name =="0")
                {
                    return;
                }
            }
            if (RightPosList[i].transform.childCount <= 0)
            {
                return;
            }
            else
            {
                if (RightPosList[i].transform.GetChild(0).name == "1")
                {
                    return;
                }
            }
        }

        Debug.Log("성공!");
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);        
        WarehouseManager.GetComponent<SpriteRenderer>().enabled = true;
        WarehouseManager.GetComponent<BoxCollider2D>().enabled = true;
        //TestCodeManager.Instance.GetSugar();                
        StartCoroutine(DisableRoutine());
    }
    IEnumerator DisableRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        DialogueManager.StartConversation("lamptown_Sugar");
        this.gameObject.SetActive(false);
    }
}

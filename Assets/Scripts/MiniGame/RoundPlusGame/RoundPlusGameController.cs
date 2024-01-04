using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class RoundPlusGameController : MonoBehaviour
{
    public delegate void OnFind();
    public event OnFind OnFindEventHandler;
    public GameObject Round_1;
    public GameObject Round_2;
    public GameObject Round_3;
    public GameObject Round_4;
    public Image LeverImage;

    public Sprite LeverEnable;
    public Sprite LeverDisable;

    public List<int> RoundData_1 = new List<int>();
    public List<int> RoundData_2 = new List<int>();
    public List<int> RoundData_3 = new List<int>();
    public List<int> RoundDataResult = new List<int>();
    bool bRotate = false;
    private void OnEnable()
    {
        LeverImage.sprite = LeverDisable;
        bRotate = false;
        RoundData_1.Clear();
        RoundData_2.Clear();
        RoundData_3.Clear();
        RoundDataResult.Clear();
        Round_1.transform.DORotate(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);
        Round_2.transform.DORotate(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);
        Round_3.transform.DORotate(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);
        Round_4.transform.DORotate(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);

        RoundData_1.Add(1); RoundData_1.Add(3); RoundData_1.Add(2); RoundData_1.Add(3); RoundData_1.Add(3); RoundData_1.Add(2); RoundData_1.Add(4); RoundData_1.Add(3);
        RoundData_2.Add(2); RoundData_2.Add(2); RoundData_2.Add(4); RoundData_2.Add(3); RoundData_2.Add(3); RoundData_2.Add(1); RoundData_2.Add(4); RoundData_2.Add(2);
        RoundData_3.Add(4); RoundData_3.Add(5); RoundData_3.Add(4); RoundData_3.Add(6); RoundData_3.Add(5); RoundData_3.Add(5); RoundData_3.Add(6); RoundData_3.Add(5);
        RoundDataResult.Add(10); RoundDataResult.Add(10); RoundDataResult.Add(12); RoundDataResult.Add(10); RoundDataResult.Add(8); RoundDataResult.Add(12); RoundDataResult.Add(8);
        RoundDataResult.Add(12);
        GetComponent<Animator>().enabled = true;
        GetComponent<DisablePanelAnimaition>().StartAnimationEventHandler += RoundPlusGameController_EndAnimationEventHandler;
    }

    private void RoundPlusGameController_EndAnimationEventHandler()
    {
        GetComponent<DisablePanelAnimaition>().EndAnimationEventHandler -= RoundPlusGameController_EndAnimationEventHandler;
        GetComponent<Animator>().enabled = false;        
    }
    public void DisableClick()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().Play("RoundPlusBack"); 
    }
    public void rotateRound(int index)
    {
        if(bRotate)
        {
            return;
        }
        bRotate = true;
        int tempData = 0;
        switch (index)
        {
            case 0:
                tempData = RoundData_1[RoundData_1.Count-1];
                RoundData_1.RemoveAt(RoundData_1.Count-1);
                RoundData_1.Insert(0, tempData);
                Round_1.transform.DORotate(new Vector3(0, 0, Round_1.transform.eulerAngles.z - 45), 0.2f).SetEase(Ease.Linear).OnComplete(CompleteTween);
                break;
            case 1:
                tempData = RoundData_2[RoundData_2.Count - 1];
                RoundData_2.RemoveAt(RoundData_2.Count - 1);
                RoundData_2.Insert(0, tempData);
                Round_2.transform.DORotate(new Vector3(0, 0, Round_2.transform.eulerAngles.z - 45), 0.2f).SetEase(Ease.Linear).OnComplete(CompleteTween);
                break;
            case 2:
                tempData = RoundData_3[RoundData_3.Count - 1];
                RoundData_3.RemoveAt(RoundData_3.Count - 1);
                RoundData_3.Insert(0, tempData);
                Round_3.transform.DORotate(new Vector3(0, 0, Round_3.transform.eulerAngles.z - 45), 0.2f).SetEase(Ease.Linear).OnComplete(CompleteTween);
                break;
            case 3:
                tempData = RoundDataResult[RoundDataResult.Count - 1];
                RoundDataResult.RemoveAt(RoundDataResult.Count - 1);
                RoundDataResult.Insert(0, tempData);
                Round_4.transform.DORotate(new Vector3(0, 0, Round_4.transform.eulerAngles.z - 45), 0.2f).SetEase(Ease.Linear).OnComplete(CompleteTween);
                break;
        }
    }
    void CompleteTween()
    {       
        bRotate = false;        
    }
    public void CheckComplete()
    {
        bool isComplete = true;
        for (int i = 0; i < 8; i++)
        {
            int sum = RoundData_1[i] + RoundData_2[i] + RoundData_3[i];
            if (sum != RoundDataResult[i])
            {
                isComplete = false;
            }
        }
        if (isComplete)
        {

            Round_1.transform.DOShakeScale(0.5f, 0.1f);
            Round_2.transform.DOShakeScale(0.5f, 0.1f);
            Round_3.transform.DOShakeScale(0.5f, 0.1f);
            Round_4.transform.DOShakeScale(0.5f, 0.1f);
            DisableClick();
            StartCoroutine(endRoutine());
                        
            //TestCodeMvnager.Instance.GetRaido();
        }
        else
        {
            Round_1.transform.DOShakeScale(0.5f, 0.1f); 
            Round_2.transform.DOShakeScale(0.5f, 0.1f); 
            Round_3.transform.DOShakeScale(0.5f, 0.1f); 
            Round_4.transform.DOShakeScale(0.5f, 0.1f); 
            //LeverImage.transform.DOShakeScale(0.5f, 0.1f);
        }
    }
    IEnumerator endRoutine()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("성공");
        OnFindEventHandler?.Invoke();
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
    }
}

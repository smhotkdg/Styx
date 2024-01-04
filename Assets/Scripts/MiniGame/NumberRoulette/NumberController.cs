using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
using DG.Tweening;
using UnityEngine.UI;
public class NumberController : MonoBehaviour
{
    public NumberRouletteGameController gameController;
    public delegate void OnNumberComplete();
    public event OnNumberComplete OnNumberCompleteEventHandler;

    public RangeSensor2D Point_LeftTop;
    public RangeSensor2D Point_LeftBottom;
    public RangeSensor2D Point_RightTop;
    public RangeSensor2D Point_RightBottom;

    public int CompleteNumber_leftTop = 1;
    public int CompleteNumber_RightTop = 2;
    public int CompleteNumber_LeftBottom = 4;
    public int CompleteNumber_RightBottom = 5;

    public bool bComplete = false;

   
    public void MoveObject()
    {
        if (Point_LeftTop.DetectedObjects.Count == 0 || Point_LeftBottom.DetectedObjects.Count == 0 ||
            Point_RightTop.DetectedObjects.Count == 0 || Point_RightBottom.DetectedObjects.Count == 0)
        {            
            return;
        }            

        if (gameController.bMove == true)
            return;
        gameController.bMove = true;
        Vector3 LeftTop = Point_LeftTop.DetectedObjects[0].transform.localPosition;
        Vector3 LeftBottom = Point_LeftBottom.DetectedObjects[0].transform.localPosition;
        Vector3 RightTop = Point_RightTop.DetectedObjects[0].transform.localPosition;
        Vector3 RightBottom = Point_RightBottom.DetectedObjects[0].transform.localPosition;


        Point_LeftTop.DetectedObjects[0].transform.DOLocalMove(RightTop, 0.5f).SetEase(Ease.Linear).OnComplete(SetFalse);
        Point_RightTop.DetectedObjects[0].transform.DOLocalMove(RightBottom, 0.5f).SetEase(Ease.Linear).OnComplete(SetFalse);
        Point_RightBottom.DetectedObjects[0].transform.DOLocalMove(LeftBottom, 0.5f).SetEase(Ease.Linear).OnComplete(SetFalse);
        Point_LeftBottom.DetectedObjects[0].transform.DOLocalMove(LeftTop, 0.5f).SetEase(Ease.Linear).OnComplete(CheckComplete);        
    }
    private void FixedUpdate()
    {
        CheckCompleteUpdate();
    }
    void CheckCompleteUpdate()
    {
        if (Point_LeftTop.DetectedObjects.Count == 0 || Point_LeftBottom.DetectedObjects.Count == 0 ||
           Point_RightTop.DetectedObjects.Count == 0 || Point_RightBottom.DetectedObjects.Count == 0)
        {
            return;
        }
        string strLeftTop = Point_LeftTop.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;
        string strRightTop = Point_RightTop.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;
        string strRightBottom = Point_RightBottom.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;
        string strLeftBottom = Point_LeftBottom.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;

        if(strLeftTop == CompleteNumber_leftTop.ToString())
        {
            Point_LeftTop.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
        else
        {
            Point_LeftTop.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if(strRightTop == CompleteNumber_RightTop.ToString())
        {
            Point_RightTop.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
        else
        {
            Point_RightTop.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if(strRightBottom == CompleteNumber_RightBottom.ToString())
        {
            Point_RightBottom.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
        else
        {
            Point_RightBottom.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if(strLeftBottom == CompleteNumber_LeftBottom.ToString())
        {
            Point_LeftBottom.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
        else
        {
            Point_LeftBottom.DetectedObjects[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if (strLeftTop == CompleteNumber_leftTop.ToString() && strRightTop == CompleteNumber_RightTop.ToString() &&
           strRightBottom == CompleteNumber_RightBottom.ToString() && strLeftBottom == CompleteNumber_LeftBottom.ToString())
        {
            bComplete = true;            
        }
        else
        {
            bComplete = false;            
        }
    }
    void SetFalse()
    {
        gameController.bMove = false;
    }
    void CheckComplete()
    {
        
        string strLeftTop = Point_LeftTop.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;
        string strRightTop= Point_RightTop.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;
        string strRightBottom= Point_RightBottom.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;
        string strLeftBottom = Point_LeftBottom.DetectedObjects[0].transform.Find("text_Number").GetComponent<Text>().text;

        if(strLeftTop == CompleteNumber_leftTop.ToString() && strRightTop == CompleteNumber_RightTop.ToString() &&
           strRightBottom == CompleteNumber_RightBottom.ToString() && strLeftBottom == CompleteNumber_LeftBottom.ToString())
        {
            bComplete = true;
            OnNumberCompleteEventHandler?.Invoke();
        }
        else
        {
            bComplete = false;
            OnNumberCompleteEventHandler?.Invoke();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
using DG.Tweening;
public class SugarFindController : MonoBehaviour
{
    public SugarGameManager SugarGame;
    public RaySensor2D Sensor_Left;
    public RaySensor2D Sensor_Right;
    public RaySensor2D Sensor_Up;
    public RaySensor2D Sensor_Down;

    private void Start()
    {
        setSensor();
    }
    public void setSensor()
    {
        Sensor_Down.IgnoreList.Clear();
        Sensor_Right.IgnoreList.Clear();
        Sensor_Left.IgnoreList.Clear();
        Sensor_Up.IgnoreList.Clear();
        Sensor_Down.IgnoreList.Add(transform.parent.gameObject);
        Sensor_Up.IgnoreList.Add(transform.parent.gameObject);
        Sensor_Right.IgnoreList.Add(transform.parent.gameObject);
        Sensor_Left.IgnoreList.Add(transform.parent.gameObject);
    }
    public void Left()
    {
        if (SugarGame.isMove == false)
            return;
        if(Sensor_Left.DetectedObjects.Count >0)
        {
            if(Sensor_Left.DetectedObjects[0].transform.childCount== 0)
            {
                transform.SetParent(Sensor_Left.DetectedObjects[0].transform);
                transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(onCcompleteTween);
                setSensor();
                SugarGame.CheckGame();
                SugarGame.isMove = false;
            }
        }
    }
    public void Right()
    {
        if (SugarGame.isMove == false)
            return;
        if (Sensor_Right.DetectedObjects.Count > 0)
        {
            if (Sensor_Right.DetectedObjects[0].transform.childCount == 0)
            {
                transform.SetParent(Sensor_Right.DetectedObjects[0].transform);
                transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(onCcompleteTween);
                setSensor();
                SugarGame.CheckGame();
                SugarGame.isMove = false;
            }
        }
    }
    public void Up()
    {
        if (SugarGame.isMove == false)
            return;
        if (Sensor_Up.DetectedObjects.Count > 0)
        {
            if (Sensor_Up.DetectedObjects[0].transform.childCount == 0)
            {
                transform.SetParent(Sensor_Up.DetectedObjects[0].transform);
                transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(onCcompleteTween);
                setSensor();
                SugarGame.CheckGame();
                SugarGame.isMove = false;
            }
        }
    }
    public void Down()
    {
        if (SugarGame.isMove == false)
            return;
        if (Sensor_Down.DetectedObjects.Count > 0)
        {
            if (Sensor_Down.DetectedObjects[0].transform.childCount == 0)
            {
                transform.SetParent(Sensor_Down.DetectedObjects[0].transform);
                transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(onCcompleteTween);
                setSensor();
                SugarGame.CheckGame();
                SugarGame.isMove = false;
            }
        }
    }
    void onCcompleteTween()
    {
        SugarGame.isMove = true;
    }
   
}

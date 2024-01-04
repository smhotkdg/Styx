using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using SensorToolkit;
public class BlockObject : MonoBehaviour
{
    public BlockGameManager BlockGame;
    public RaySensor2D leftSensor;
    public RaySensor2D rightSensor;
    public bool isActiveObject;
    private void Start()
    {
        intPos = transform.localPosition;
        transform.localPosition = intPos;
        GetComponent<Button>().onClick.AddListener(moveClick);
        leftSensor.OnDetected.AddListener(onDetect);
        rightSensor.OnDetected.AddListener(onDetect);
    }
    private void OnEnable()
    {
        isActiveObject = false;
    }
    private void OnDisable()
    {
        transform.localPosition = intPos;
    }
    Vector3 intPos;
    void onDetect(GameObject detectObejct, Sensor sensor)
    {      
        if(isActiveObject ==true)
        {
            BlockGame.isMove = false;
            isActiveObject = false;
        }        
    }
    public enum BoxType
    {
        horizontalBox,
        verticalBox
    }
    public BoxType boxType = BoxType.horizontalBox;
    public bool bLeft;
    
    
    public float margin = 70;
    void CheckLeftRight()
    {
        if(boxType == BoxType.horizontalBox)
        {
            if (transform.localPosition.x <= -105f)
            {
                bLeft = false;                
            }
            if (transform.localPosition.x >= 105f)
            {
                bLeft = true;                
            }         
        }
        else
        {
            if (transform.localPosition.y >= 70)
            {
                bLeft = false;
            }
            if (transform.localPosition.y <= -70)
            {
                bLeft = true;
            }
        }
    }
    void moveClick()
    {       
        if(leftSensor.DetectedObjects.Count>0 && rightSensor.DetectedObjects.Count>0)
        {
            isActiveObject = false;
            return;
        }

        if (isActiveObject == true)
            return;
        if (BlockGame.isMove == true)
            return;
        else
        {
            CheckLeftRight();
        }
        if(leftSensor.DetectedObjects.Count >0)
        {
            bLeft = false;
        }
        if(rightSensor.DetectedObjects.Count >0)
        {
            bLeft = true;
        }
        
        BlockGame.isMove = true;
        isActiveObject = true;
        if (boxType == BoxType.horizontalBox)
        {
            if (bLeft == true)
            {             
                bLeft = false;
                if (transform.localPosition.x <=-105f)
                {
                    BlockGame.isMove = false;
                    isActiveObject = false;
                    return;
                }
                transform.DOLocalMove(new Vector3(transform.localPosition.x - margin, transform.localPosition.y, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveLeftX);
            }
            else
            {
                bLeft = true;
                if(transform.localPosition.x >= 105f)
                {
                    BlockGame.isMove = false;
                    isActiveObject = false;
                    return;
                }
                transform.DOLocalMove(new Vector3(transform.localPosition.x + margin, transform.localPosition.y, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveRightX);
            }
        }
        else
        {
            if (bLeft == true)
            {
                if (transform.localPosition.y >= 70)
                {
                    BlockGame.isMove = false;
                    isActiveObject = false;
                    return;
                }
                bLeft = false;
              
                transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y+ margin, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveLeftY);
            }
            else
            {
                if (transform.localPosition.y <= -70)
                {
                    BlockGame.isMove = false;
                    isActiveObject = false;
                    return;
                }
                bLeft = true;
                transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y- margin, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveRightY);
            }

        }
     
    }
    void moveLeftY()
    {
        if (BlockGame.isMove == false)
            return;
        if (Mathf.RoundToInt(transform.localPosition.y + margin) <= 70f)            
        {
            //그리고 오브젝트확인
            transform.DOLocalMove(new Vector3(transform.localPosition.x , transform.localPosition.y+margin, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveLeftY);
        }
        else
        {
            BlockGame.isMove = false;
            isActiveObject = false;
            BlockGame.CheckKey();
        }
    }
    void moveRightY()
    {
        if (BlockGame.isMove == false)
            return;
        if (Mathf.RoundToInt(transform.localPosition.y - margin) >= -70f)
        {
            //그리고 오브젝트확인
            transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y-margin, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveRightY);
        }
        else
        {
            BlockGame.isMove = false;
            isActiveObject = false;
            BlockGame.CheckKey();
        }
    }
    void moveLeftX()
    {
        if (BlockGame.isMove == false)
            return;
        if (Mathf.RoundToInt(transform.localPosition.x- margin) >= -105f)
        {
            //그리고 오브젝트확인
            transform.DOLocalMove(new Vector3(transform.localPosition.x - margin, transform.localPosition.y, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveLeftX);
        }
        else
        {
            BlockGame.isMove = false;
            isActiveObject = false;
            BlockGame.CheckKey();
        }
    }
    void moveRightX()
    {
        if (BlockGame.isMove == false)
            return;
        if (Mathf.RoundToInt(transform.localPosition.x+ margin) <= 105f)
        {
            //그리고 오브젝트확인
            transform.DOLocalMove(new Vector3(transform.localPosition.x + margin, transform.localPosition.y, transform.localPosition.z), 0.2f).SetEase(Ease.Linear).OnComplete(moveRightX);
        }
        else
        {
            BlockGame.isMove = false;
            isActiveObject = false;
            BlockGame.CheckKey();
        }
    }
    
    public void OnMoveEnd()
    {
        if(isActiveObject ==true)
        {
            
        }
    }
}

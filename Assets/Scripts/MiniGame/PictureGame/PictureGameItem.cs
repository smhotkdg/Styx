using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PictureGameItem : MonoBehaviour
{
    public delegate void OnClickObject();
    public event OnClickObject OnClickObjectEventHandler;
    public bool isOk;
    public float inity= 1000;
    private void Start()
    {
        inity = transform.localPosition.y;
    }
    public void Click()
    {
        if(bStart ==false)
        {
            Vector3 nextPos;
            nextPos = transform.localPosition;
            nextPos.x = Mathf.RoundToInt(transform.localPosition.x + 100);
            transform.DOLocalMove(nextPos, 0.5f).SetEase(Ease.Linear).OnComplete(onCompleteTween);
            bStart = true;
        }        
    }
    private void OnEnable()
    {
        isOk = false;
        SetRandom();        
    }
    void SetRandom()
    {
        int rand = Random.Range(0, 4);
        int xPos = rand * 100;
        Vector3 nextPos;
        nextPos = transform.localPosition;
        if(inity !=1000)
        {
            nextPos.y = inity;
        }
        
        nextPos.x = xPos;
        transform.localPosition = nextPos;
        if(xPos==0)
        {
            isOk = true;
        }
       
    }
    bool bStart = false;
    void onCompleteTween()
    {
        bStart = false;
        if(transform.localPosition.x>=500)
        {
            Vector3 pos = transform.localPosition;
            pos.x = 0;
            transform.localPosition = pos;
            isOk = true;
        }
        else
        {
            isOk = false;
        }
        OnClickObjectEventHandler?.Invoke();
    }
}

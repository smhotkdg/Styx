using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WorkerController : MonoBehaviour
{
    public Vector3 InitPosition;
    public Vector3 MoveEndPosition;
    public float speed = 10;
    bool bLeft = false;
    private void Start()
    {
        transform.DOLocalMove(MoveEndPosition, speed).SetEase(Ease.Linear).OnComplete(completeTween);
    }
    void completeTween()
    {
        if(bLeft == false)
        {
            transform.DOLocalMove(InitPosition, speed).SetEase(Ease.Linear).OnComplete(completeTween);
            GetComponent<SpriteRenderer>().flipX = true;
            bLeft = true;
        }
        else
        {
            transform.DOLocalMove(MoveEndPosition, speed).SetEase(Ease.Linear).OnComplete(completeTween);
            GetComponent<SpriteRenderer>().flipX = false;
            bLeft = false;
        }
        
    }
}

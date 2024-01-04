using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OutwallGameController : MonoBehaviour
{
    public GameObject CircleAds;
    public GameObject Circle;    
    public GameObject Line;
    public GameObject Target;
    public GameObject Target2;
    public OutwallLine outwallLine;
    IEnumerator LineRotateRoutine;
    bool isStartGame = true;
    int failIndex =0;
    private void OnEnable()
    {
        CircleAds.SetActive(false);
        Circle.SetActive(true);
        failIndex = 0;
        LineRotateRoutine = LineRotate();
        isStartGame = true;
        SetTarget();
        RotateEnd();
    }
    private void OnDisable()
    {
        StopCoroutine(LineRotateRoutine);
    }
    void RotateEnd()
    {
        StartCoroutine(LineRotateRoutine);             
    }
    IEnumerator LineRotate()
    {
        float RandomZ = Random.Range(0, 180);
        int RandomRound = Random.Range(1, 4);
        float time = Mathf.Abs(RandomZ / 340);
        float RandomTime = Random.Range(0.5f, 1.2f);
        time = time * RandomTime;
        Line.transform.DORotate(new Vector3(0, 0, Line.transform.eulerAngles.z - RandomZ), time).SetEase(Ease.Linear);
        //if(RandomRound ==1)
        //{
        //    Line.transform.DORotate(new Vector3(0, 0, Line.transform.eulerAngles.z - RandomZ), time).SetEase(Ease.Linear);
        //}
        //else
        //{
        //    Line.transform.DORotate(new Vector3(0, 0, Line.transform.eulerAngles.z - RandomZ), time).SetEase(Ease.Linear).SetLoops(RandomRound,LoopType.Incremental);            
        //}
        Line.transform.DORotate(new Vector3(0, 0, Line.transform.eulerAngles.z - RandomZ), time).SetEase(Ease.Linear).SetLoops(RandomRound, LoopType.Incremental);
        time = time * RandomRound;

        //Debug.Log("Angle = " + RandomZ.ToString("N1") + "  time = " + time.ToString("N1"));
        yield return new WaitForSeconds(time);
        LineRotateRoutine = LineRotate();
        StartCoroutine(LineRotateRoutine);
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.HintEnalbeList[21])
        {
            if(CircleAds.activeSelf ==false)
            {
                CircleAds.SetActive(true);
                Circle.SetActive(false);
            }
        }
        else
        {
            if (CircleAds.activeSelf == true)
            {
                CircleAds.SetActive(false);
                Circle.SetActive(true);
            }
        }
    }
    public void SelectMove()
    {
        if (GameManager.Instance.playerController.CheckFootLimitVent())
        {
            if (isStartGame)
            {
                isStartGame = false;
                CheckPosition();
                Line.transform.DOKill();
                StopCoroutine(LineRotateRoutine);
                //if (Line.transform.eulerAngles.z <= Target.transform.eulerAngles.z + 2 &&
                    //Line.transform.eulerAngles.z >= Target.transform.eulerAngles.z - 25)
                if(outwallLine.bIn)
                {
                    Target.GetComponent<Image>().DOColor(new Color(1, 0, 0, 0), 0.25f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);
                    Target2.GetComponent<Image>().DOColor(new Color(1, 0, 0, 0), 0.25f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);
                    Line.GetComponent<Image>().DOColor(new Color(1, 0, 0, 0), 0.25f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);
                    GameManager.Instance.playerController.SetWallmove();
                    StartCoroutine(SetInit(2));
                }
                else
                {
                    GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
                    GameManager.Instance.cameraEffectController.MangaFlash(0.5f);
                    failIndex++;
                    if (failIndex >= 5)
                    {
                        SetDie();
                        return;
                    }
                    else
                    {
                        GameManager.Instance.playerController.PlayOutwall();
                    }
                    StartCoroutine(SetInit(1));
                }
                
            }

            if (GameManager.Instance.data.isStyxApp == false)
            {
                //GameManager.Instance.data.FootCount -= 1;
            }

            UIManager.Instance.SetFootCount();
        }       
    }
    IEnumerator SetInit(float time)
    {
        yield return new WaitForSeconds(time);
        isStartGame = true;
        SetTarget();
        StartCoroutine(LineRotateRoutine);
    }
    void CheckPosition()
    {

    }
    float TargetZ;
    void SetTarget()
    {
        TargetZ = Random.Range(0, 360);
        Target.transform.DORotate(new Vector3(0, 0, Target.transform.eulerAngles.z - TargetZ), 0.1f).SetEase(Ease.Linear);
        Target2.transform.DORotate(new Vector3(0, 0, Target2.transform.eulerAngles.z - TargetZ), 0.1f).SetEase(Ease.Linear);
    }
    void SetDie()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.VillainEvent);
        GameManager.Instance.Player.GetComponent<PlayerController>().animator.Play("fall");

        GameManager.Instance.SetCliffDie();
        GetComponent<Animator>().Play("OutWallOff");

    }
   
}

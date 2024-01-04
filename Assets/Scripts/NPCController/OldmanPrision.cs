using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using DG.Tweening;
public class OldmanPrision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public GameObject repairPosition;
    Vector3 initPos;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        initPos = transform.position;
    }
    void StartMoveLever()
    {        
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        transform.localScale = new Vector3(-1, 1, 1);
        GetComponent<Animator>().Play("walking");
        transform.DOMove(repairPosition.transform.position, 6).SetEase(Ease.Linear).OnComplete(EndMove);
        GameManager.Instance.SetCameraTarget(this.gameObject,0.2f);
    }
    void EndMove()
    {
        transform.localScale = new Vector3(1, 1, 1);
        GetComponent<Animator>().Play("repair");
    }
    public void RepairEnd()
    {
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.lever);
        GameManager.Instance.SetSeaworkAnim(false,true);
        transform.localScale = new Vector3(1, 1, 1);
        GetComponent<Animator>().Play("walking");
        transform.DOMove(initPos, 6).SetEase(Ease.Linear).OnComplete(EndMoveInit);
    }
    void EndMoveInit()
    {        
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        
        GetComponent<Animator>().Play("idle");
        GameManager.Instance.SetPlayerCamera();
        DialogueManager.StartConversation("oldManLever");
        StartCoroutine(EnableColider());
    }
    IEnumerator EnableColider()
    {
        yield return new WaitForSeconds(.5f);
        boxCollider.enabled = true;
    }
    public void EndConversation()
    {        
        
        if (blever)
        {
            boxCollider.enabled = false;
            StartMoveLever();
            blever = false;
            return;
        }
        
        switch (DialogueLua.GetVariable("oldManIndex").asInt)
        {
            case 2:
                //드론 제작
                MakeDrone();
                break;
            case 3:
                //해조류 작업장으로 이동
                TestCodeManager.Instance.GoTowork();
                break;
            case 5:
                //해조류 작업 완료
                TestCodeManager.Instance.CompleteSeaWeed();
                break;
            case 6:
                //퀘스트 시작 대화 끝
                TestCodeManager.Instance.Part1MainQUest(false);
                break;
        }
        if(bChessQuest ==true)
        {
            bChessQuest = false;
            TestCodeManager.Instance.StartChessQuest();
        }
        
        UIManager.Instance.CheckQuestGuide();
    }
    void MakeDrone()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        UIManager.Instance.makeDronePanel.SetActive(true);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);

    }
    bool blever = false;
    public void MoveLever()
    {
        blever = true;
    }
    public void EnableOldMan()
    {        
        
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler()
    {
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler;
        UIManager.Instance.OnClosingTimeUIEventHandler += Instance_OnClosingTimeUIEventHandler;
        StartCoroutine(TimeUIRoutine());        
        
    }
    IEnumerator TimeUIRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.Instance.SetTimeUI(3);
    }

    private void Instance_OnClosingTimeUIEventHandler()
    {
        UIManager.Instance.OnClosingTimeUIEventHandler -= Instance_OnClosingTimeUIEventHandler;
        StartCoroutine(resetOldMan());
    }

    IEnumerator resetOldMan()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().Play("walking");        
        
        transform.DOLocalMoveX(0.825f, 4).From(true).OnComplete(completeTween).SetEase(Ease.Linear);
        //x = 0.825
        spriteRenderer.enabled = true;
        
    }
    void completeTween()
    {
        GetComponent<Animator>().Play("idle");
        boxCollider.enabled = true;
    }
    bool bChessQuest = false;
    public void setChessQuest()
    {
        bChessQuest = true;
    }
}

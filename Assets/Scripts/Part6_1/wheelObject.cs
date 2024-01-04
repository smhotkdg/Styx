using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class wheelObject : ObjectChekcer
{
    
    public GameObject uiElement;
    public GameObject EndView;

    public Transform PlayerPos;
    public Transform PlayerEndPos;
    Transform pTrans;
    bool bMove = false;
    private void Start()
    {
        bMove = false;
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        pTrans = transform.parent;
        bEndGame = false;
        if(GameManager.Instance.styxData.MoveDoor =="success")
        {
            Vector2 pos = transform.localPosition;
            pos.x = 8.25f;
            transform.localPosition = pos;
        }
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    bool bEndGame = false;
    private void OnEnable()
    {
        bMove = false;
    }
    private void FixedUpdate()
    {
        if(bEndGame ==false)
        {
            if (bMove)
            {
                if (GameManager.Instance.Player.transform.localPosition.x >= PlayerEndPos.position.x)
                {
                    Debug.Log("밀기 끝");
                    bEndGame = true;
                    EndGame();
                }
            }
        }
      
    }
    void EndGame()
    {
        transform.SetParent(pTrans);
        GameManager.Instance.playerController.isFlip = false;
        GameManager.Instance.playerController.isOnlyleft = false;
        GameManager.Instance.playerController.SetForceIdle();
        GameManager.Instance.playerController.forceMove = false;
        GameManager.Instance.playerController.speed = 2.5f;

        GameManager.Instance.styxData.MoveDoor = "success";
        DialogueLua.SetQuestField("MoveDoor", "State", GameManager.Instance.styxData.MoveDoor);
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.moveDoor);
    }
    void Click()
    {        
        if(AdManager.Instance.isShowPop ==true)
        {
            if (AdManager.Instance.ShowPopAds())
            {
                return;
            }
        }
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        GameManager.Instance.playerController.SetForceIdle();
        GameManager.Instance.cinemachineCamera.m_Follow = null;
        if(GameManager.Instance.Player.transform.position.x > PlayerPos.transform.position.x)
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        }
        GameManager.Instance.playerController.forceMove = true;
        float dis = Vector2.Distance(GameManager.Instance.Player.transform.localPosition, PlayerPos.position);
        GameManager.Instance.Player.transform.DOMove(PlayerPos.position, dis).SetEase(Ease.Linear).OnComplete(CompletePlayerMoveDoor);
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    IEnumerator CameraChangeRoutine()
    {
        GameManager.Instance.SetPlayerCamera(1f);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    void CompletePlayerMoveDoor()
    {
        EndView.SetActive(true);
        bMove = true;
        GameManager.Instance.playerController.isFlip = true;
        GameManager.Instance.playerController.isOnlyleft = true;

        GameManager.Instance.playerController.PushInit();
        GameManager.Instance.playerController.forceMove = false;
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        transform.SetParent(GameManager.Instance.Player.transform);
        GameManager.Instance.playerController.animator.SetFloat("speed", 0);
        GameManager.Instance.playerController.speed = 0.4f;
        GameManager.Instance.playerController.PushInit();
        StartCoroutine(CameraChangeRoutine());
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        if (bMove)
            return;
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.ObjectType.move, uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}
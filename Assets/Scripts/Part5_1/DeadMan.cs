using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class DeadMan : ObjectChekcer
{
    public bool isPart5_1 = true;
    public GameObject uiElement;
    public GameObject PlayerEventPos;
    public BoxCollider2D DeadManDoor;
    public DeadManDoor manDoor;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        DeadManDoor.enabled = false;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }
    void Click()
    {
        if (AdManager.Instance.isShowPop == true)
        {
            if (AdManager.Instance.ShowPopAds())
            {
                return;
            }
        }
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<BoxCollider2D>().enabled = false;
        GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.Player.transform.DOMoveX(PlayerEventPos.transform.position.x, 1f).SetEase(Ease.Linear).OnComplete(CompletePlayerMove);
        GameManager.Instance.Player.GetComponent<PlayerController>().animator.SetFloat("speed", 1);
    }
    void CompletePlayerMove()
    {

        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        GetComponent<SpriteRenderer>().sortingOrder = 3;
        DeadManDoor.enabled = true;
        GameManager.Instance.Player.GetComponent<PlayerController>().isDeadMan = true;
        GameManager.Instance.Player.GetComponent<PlayerController>().speed = 0.7f;
        GameManager.Instance.Player.GetComponent<PlayerController>().animator.SetFloat("speed", 0);
        GameManager.Instance.Player.GetComponent<PlayerController>().isFlip = true;
        GetComponent<FollowObject>().isFollow = true;
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        animator.Play("guard_event_start");
        GameManager.Instance.Player.GetComponent<PlayerController>().DeadManMove();
        manDoor.OnCompleteMoveDeadManaEventHandler += ManDoor_OnCompleteMoveDeadManaEventHandler;

    }

    private void ManDoor_OnCompleteMoveDeadManaEventHandler()
    {
        manDoor.OnCompleteMoveDeadManaEventHandler -= ManDoor_OnCompleteMoveDeadManaEventHandler;
        GameManager.Instance.Player.GetComponent<PlayerController>().isFlip = false;
        GameManager.Instance.Player.GetComponent<PlayerController>().isDeadMan = false;
        GameManager.Instance.Player.GetComponent<PlayerController>().speed = 2.5f;
        GameManager.Instance.Player.GetComponent<PlayerController>().animator.SetFloat("speed", 0);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetForceIdle();
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 2f);
        if(isPart5_1)
        {
            
            GameManager.Instance.styxData.DeadManMoveQuest = "success";
            DialogueLua.SetQuestField("DeadManMoveQuest", "State", "success");
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.DeadManmove);
        }
        else
        {            
            GameManager.Instance.styxData.MoveGuard = "success";
            DialogueLua.SetQuestField("MoveGuard", "State", "success");
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.MoveGuard);
        }
        
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.ObjectType.DeadMan, uiElement, this.gameObject, 10,-40);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}


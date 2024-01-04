using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
public class Part5_2Hardware : MonoBehaviour
{
    public BoxCollider2D cctvCollider;
    public GameObject Wall;
    public Transform PrisonPos;
    public Transform ChokePos;
    public Transform movePoolPos;
    public GameObject UIElement;
    public GameObject Villain;
    public GameObject EventView;
    public GameObject NPC;
    bool isMoveSearchRoom = false;
    public Transform SearchRoomMovePos;
    public Transform SearchRoomEndMovePos;
    public Animator animator;
    public BoxCollider2D boxCollider;
    public DialogueSystemTrigger systemTrigger_SearchRoom;
    bool isKitchen = false;
    public void DisableKitchenRoutine()
    {
        isKitchen = true;

    }
    public void SetLeft()
    {
        transform.localScale = new Vector3(-4, 4, 4);        
    }
    bool isAlhpa = false;
    public void DisableRoutine()
    {
        isAlhpa = true;

    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        Villain.SetActive(false);
    }
    public void SetMoveSearchRoom()
    {
        isMoveSearchRoom = true;
    }
    public void SetMoveReStartSearchRoom()
    {
        isMovereStartSearchRoom = true;
    }
    bool isMovereStartSearchRoom = false;
    public void villainEventStart()
    {
        //isvillainEvent = true;
        EventView.SetActive(true);
        DialogueManager.Pause();
        StartCoroutine(StartVillainEvent());
    }
    IEnumerator StartVillainEvent()
    {
        Villain.SetActive(true);        
        yield return new WaitForSeconds(1.2f);
        NPC.GetComponent<RandomMoveNPC>().forcePause = true;
        NPC.GetComponent<RandomMoveNPC>().moveVector = new Vector2(0, -2.92f);
        NPC.GetComponent<RandomMoveNPC>().moveRand = 0;
        NPC.GetComponent<RandomMoveNPC>().bMove = true;
        NPC.GetComponent<RandomMoveNPC>().OnCompleteMoveEventHandler += Part5_2Hardware_OnCompleteMoveEventHandler; 
        GameManager.Instance.SetCameraTarget(Villain, 2f);
        yield return new WaitForSeconds(1.5f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.VillainEvent);
    }

    private void Part5_2Hardware_OnCompleteMoveEventHandler()
    {
        NPC.GetComponent<RandomMoveNPC>().OnCompleteMoveEventHandler -= Part5_2Hardware_OnCompleteMoveEventHandler;
        StartCoroutine(VillainConversation());
    }
    IEnumerator VillainConversation()
    {
        yield return new WaitForSeconds(2f);
        Villain.GetComponent<Animator>().Play("event");
        UIElement.SetActive(true);
        UIElement.GetComponent<UiTargetManager>().WorldObject = Villain;
        UIElement.GetComponent<UiTargetManager>().y_Margin = 80;
        UIElement.GetComponent<UiTargetManager>().x_Margin = -70;
        StartCoroutine(Typing(UIElement.transform.Find("Text").GetComponent<Text>(), languageController.Instance.getPartyroomVillain(), 0.1f));
        yield return new WaitForSeconds(3f);
        UIElement.GetComponent<UiTargetManager>().x_Margin = -30;
        UIElement.GetComponent<UiTargetManager>().WorldObject = NPC;
        StartCoroutine(Typing(UIElement.transform.Find("Text").GetComponent<Text>(), ".......", 0.1f));
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetPlayerCamera(2f);
        yield return new WaitForSeconds(1f);
        Villain.GetComponent<Animator>().Play("idle");
        NPC.GetComponent<RandomMoveNPC>().forcePause = false;
        NPC.GetComponent<RandomMoveNPC>().bMove = false;
        Villain.SetActive(false);
        UIElement.SetActive(false);
        EventView.GetComponent<Animator>().Play("GetsubmarinKeyOff");
        DialogueManager.Unpause();
        
    }
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.typing);
            yield return new WaitForSeconds(speed);
        }
    }
    bool bSleeping = false;
    public void StartSieepingQuest()
    {
        bSleeping = true;
    }
    bool bMovePool = false;
    public void StartMovePool()
    {
        bMovePool = true;
    }
    void onMoveComplete()
    {
        animator.SetFloat("speed", 0);
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f).OnComplete(onCompleteColorChange);
        UIManager.Instance.Part5_2LamptownManager.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f);
    }
    void onCompleteColorChange()
    {
        GameManager.Instance.SetPlayerCamera(1.5f);
        StartCoroutine(SetStateNoting(1.5f));
    }
    IEnumerator SetStateNoting(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void StartfaintEvent()
    {
        EventView.SetActive(true);
        DialogueManager.instance.Pause();
        StartCoroutine(GuardFaintEvent());
        
    }
    public void setEndManagerEvnet()
    {
        StartCoroutine(EndEventManagerRoutine());
    }
    IEnumerator EndEventManagerRoutine()
    {
        yield return new WaitForSeconds(1f);
        DialogueManager.Unpause();
        EventView.SetActive(false);
    }
    IEnumerator GuardFaintEvent()
    {
        GameManager.Instance.SetCameraTarget(UIManager.Instance.Part5_2LamptownManager, 1);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Part5_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part5_2LamptownManager.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part5_2LamptownManager.transform.localScale = new Vector3(-4, 4, 4);
        UIManager.Instance.Part5_2LamptownManager.transform.DOMove(ChokePos.transform.position, Vector3.Distance(UIManager.Instance.Part5_2LamptownManager.transform.position,
            ChokePos.transform.position)).SetEase(Ease.Linear).OnComplete(ChokePosEnd);
    }
    bool bMoveGuard = false;
  
    void ChokePosEnd()
    {
        UIManager.Instance.Part5_2LamptownManager.GetComponent<Part5_2LampTownManager>().StartChoke();
        UIManager.Instance.Part5_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 0);
    }
    bool bMovePrision = false;
    public void MovePrision()
    {
        bMovePrision = true;
    }
    void CompleteMovePrison()
    {
        animator.SetFloat("speed", 0);
        GetComponent<SpriteRenderer>().DOColor(new Color(1,1,1,0),1);
        UIManager.Instance.Part5_2LamptownManager.transform.localScale = new Vector3(-4, 4, 4);
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
        UIManager.Instance.Part5_2LamptownManager.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
        GameManager.Instance.SetPlayerCamera(2f);
        StartCoroutine(SetStateNoting(2f));
    }
    IEnumerator PrisionMoveStart()
    {
        yield return new WaitForSeconds(1f);
        animator.SetFloat("speed", 1);
        transform.localScale = new Vector3(-4, 4, 4);
        transform.DOMove(PrisonPos.position, Vector3.Distance(transform.position, PrisonPos.position)).SetEase(Ease.Linear).OnComplete(CompleteMovePrison);
    }
    bool isCCTVQuest = false;
    public void StartCCTVQuest()
    {
        isCCTVQuest = true;
        cctvCollider.enabled = true;
    }
    IEnumerator CliffGameRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetPlayerCamera(2f);
        yield return new WaitForSeconds(1.8f);
        //GameManager.Instance.Player.GetComponent<PlayerController>().speed = 1f;
        //UIManager.Instance.CliffGameUI.SetActive(true);
        UIManager.Instance.OutwallGameUI.SetActive(true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void SetIdle()
    {
        animator.SetFloat("speed", 0);
    }
    IEnumerator KitchenGameRoutine()
    {

        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetPlayerCamera(2f);
        yield return new WaitForSeconds(1.8f);
        UIManager.Instance.kitchenDetector_2.StartGame();
        UIManager.Instance.SitGameUI.SetActive(true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void EndConversation()
    {
        if (isKitchen)
        {
            GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
            StartCoroutine(KitchenGameRoutine());
            SetStateNoting(2f);
            isKitchen = false;
        }
        if (isAlhpa)
        {
            isAlhpa = false;
            GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
            StartCoroutine(CliffGameRoutine());
            SetStateNoting(2f);
        }
        if (isCCTVQuest)
        {
            isCCTVQuest = false;
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            TestCodeManager.Instance.StartPart5_2StartCCTVQuest(false);
        }
        if(bMovePrision)
        {
            bMovePrision = false;
            boxCollider.enabled = false;
            UIManager.Instance.CheckQuestGuide();
            GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
            StartCoroutine(PrisionMoveStart());
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        }
        if(bMovePool)
        {
            bMovePool = false;
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            
            boxCollider.enabled = false;
            transform.Find("NPCController").gameObject.GetComponent<NPCController>().ForceExit();
            animator.SetFloat("speed", 1);
            GetComponent<FollowObject>().enabled = false;
            //GameManager.Instance.SetCameraTarget(this.gameObject, 1.5f);
            boxCollider.enabled = false;
            transform.localScale = new Vector3(-4, 4, 4);
            transform.DOMoveX(movePoolPos.position.x, 5f).SetEase(Ease.Linear).OnComplete(onMoveComplete);
        }
        if(bSleeping)
        {
            TestCodeManager.Instance.StartPart5_2StartDrugQuest(false);
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest), 2.5f);
            UIManager.Instance.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest));
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            GetComponent<FollowObject>().enabled = true;
            GetComponent<FollowObject>().isFollow = true;
            
            bSleeping = false;
        }
        if(isMoveSearchRoom)
        {
            isMoveSearchRoom = false;
            transform.DOMove(SearchRoomMovePos.transform.position, 4.5f).SetEase(Ease.Linear).OnComplete(OnCompleteSearchRoomMove);
            animator.SetFloat("speed", 1);
        }
        if(isMovereStartSearchRoom)
        {
            isMovereStartSearchRoom = false;
            GetComponent<FollowObject>().isFollow = false;
            transform.DOMove(SearchRoomEndMovePos.transform.position, 4.5f).SetEase(Ease.Linear).OnComplete(OnCompleteSearchRoomMove_re);
            animator.SetFloat("speed", 1);
        }
    }
    void OnCompleteSearchRoomMove()
    {        
        animator.SetFloat("speed", 0);
        DialogueManager.StartConversation(systemTrigger_SearchRoom.conversation, transform);
    }
    void OnCompleteSearchRoomMove_re()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        //boxCollider.enabled = true;
        animator.SetFloat("speed", 0);
        transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.SetPlayerCamera(2f);
    }
}

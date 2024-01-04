using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
public class Part5_1FarmFriend : MonoBehaviour
{
    public Transform CliffPos;
    public GameObject WallColider;
    public BoxCollider2D boxCollider;
    public GameObject EventView;
    public GameObject UIElement;
    public GameObject SearchRoomMovePos;
    private Animator animator;

    public Transform Pool_TO_PrisonPos;
    public GameObject Villain;
    public GameObject NPC;
    public Transform movePoolPos;
    public BoxCollider2D cctvColider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Villain.SetActive(false);
      
    }
    bool isAlhpa = false;
    public void DisableRoutine()
    {
        isAlhpa = true;
        
    }
    bool isKitchen = false;
    public void DisableKitchenRoutine()
    {
        isKitchen = true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    bool isMoveCliff = false;
    public void MoveCliff()
    {
        isMoveCliff = true;
    }
    bool isMovePrision = false;
    public void MovePrison()
    {
        isMovePrision = true;
    }
    bool isDeadmanQuest = false;
    public void MoveDeadManQuest()
    {
        isDeadmanQuest = true;
    }

    bool bStartDrugQuest = false;
    public void StartDrugQuest()
    {
        bStartDrugQuest = true;
    }
    bool isMovePool = false;
    public void SetMovePool()
    {
        isMovePool = true;
    }
    bool isStartCCTV = false;
    public void StartCCTVQuest()
    {
        isStartCCTV = true;
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
    IEnumerator KitchenGameRoutine()
    {

        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetPlayerCamera(2f);
        yield return new WaitForSeconds(1.8f);
        UIManager.Instance.kitchenDetector.StartGame();
        UIManager.Instance.SitGameUI.SetActive(true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void EndConversation()
    {
        if(isKitchen)
        {
            GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
            StartCoroutine(KitchenGameRoutine());
            SetStateNoting(2f);
            isKitchen = false;
        }
        if(isAlhpa)
        {
            isAlhpa = false;
            GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);            
            StartCoroutine(CliffGameRoutine());
            SetStateNoting(2f);
        }
        if(isStartCCTV)
        {
            isStartCCTV = false;
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            TestCodeManager.Instance.StartPart5_1StartCCTVQuest(false);
            cctvColider.enabled = true;
        }
        if(isSearchroomMove)
        {
            isSearchroomMove = false;
            boxCollider.enabled = false;
            transform.DOMove(SearchRoomMovePos.transform.position, 7).SetEase(Ease.Linear).OnComplete(OnCompleteSearchRoomMove);
            animator.SetFloat("speed", 1);
            transform.Find("NPCController").gameObject.SetActive(false);
        }
        if(bStartDrugQuest)
        {
            TestCodeManager.Instance.StartPart5_1StartDrugQuest(false);
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest), 2.5f);
            UIManager.Instance.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest));
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            bStartDrugQuest = false;
        }
        if(isMovePool)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            boxCollider.enabled = false;
            transform.Find("NPCController").gameObject.GetComponent<NPCController>().ForceExit();
            animator.SetFloat("speed", 1);
            //GameManager.Instance.SetCameraTarget(this.gameObject, 1.5f);
            GetComponent<FollowObject>().isFollow = false;
            transform.localScale = new Vector3(-4, 4, 4);
            transform.DOMoveX(movePoolPos.position.x, 5f).SetEase(Ease.Linear).OnComplete(onMoveComplete);
        }
        if(isDeadmanQuest)
        {
            isDeadmanQuest = false;
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            GetComponent<FollowObject>().isFollow = false;
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest), 2.5f);
            TestCodeManager.Instance.StartPart5_1StartDeadManMove(false);
        }
        if(isMovePrision)
        {
            isMovePrision = false;
            boxCollider.enabled = false;
            transform.Find("NPCController").gameObject.GetComponent<NPCController>().ForceExit();
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            
            transform.DOMoveX(Pool_TO_PrisonPos.position.x, 8).SetEase(Ease.Linear).OnComplete(onCompleteMovePrison);
            transform.localScale = new Vector3(-4, 4, 4);
            animator.SetFloat("speed", 1);
        }
        if(isMoveCliff)
        {
            TestCodeManager.Instance.StartPart5_1StartCCTVQuestComplete(false);
            isMoveCliff = false;
            boxCollider.enabled = false;
            WallColider.SetActive(false);
            transform.Find("NPCController").gameObject.GetComponent<NPCController>().ForceExit();
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            //GetComponent<FollowObject>().isSetMargin = true;
            GetComponent<FollowObject>().isFollow = true;
            GetComponent<Part5_1FarmFriend>().boxCollider.enabled = true;
        }
        
    }
  
    public void SetIdle()
    {
        animator.SetFloat("speed", 0);
    }
    void onCompleteMovePrison()
    {
        animator.SetFloat("speed", 0);
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
        GameManager.Instance.SetPlayerCamera(2f);
        StartCoroutine(MoveStartRoutine());
    }
    IEnumerator MoveStartRoutine()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void GunshootDirect()
    {
        animator.SetFloat("speed", 0);
        animator.Play("gun_shooting_direct");
    }
    void onMoveComplete()
    {
        animator.SetFloat("speed", 0);
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f).OnComplete(onCompleteColorChange);
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
    IEnumerator StartVillainEvent()
    {
        
        Villain.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        //Villain.GetComponent<Animator>().Play("event");
        //UIManager.Instance.setDialogue(Villain,languageController.Instance.getPartyroomVillain(),100,2);
        yield return new WaitForSeconds(1f);        
        NPC.GetComponent<RandomMoveNPC>().forcePause = true;
        NPC.GetComponent<RandomMoveNPC>().moveVector = new Vector2(0, -2.92f);
        NPC.GetComponent<RandomMoveNPC>().moveRand = 0;
        NPC.GetComponent<RandomMoveNPC>().bMove = true;
        NPC.GetComponent<RandomMoveNPC>().OnCompleteMoveEventHandler += Part5_1FarmFriend_OnCompleteMoveEventHandler;        
        GameManager.Instance.SetCameraTarget(Villain, 2f);
        yield return new WaitForSeconds(1.5f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.VillainEvent);
    }

    private void Part5_1FarmFriend_OnCompleteMoveEventHandler()
    {
        NPC.GetComponent<RandomMoveNPC>().OnCompleteMoveEventHandler -= Part5_1FarmFriend_OnCompleteMoveEventHandler;
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
    public void villainEventStart()
    {
        //isvillainEvent = true;
        EventView.SetActive(true);
        DialogueManager.Pause();
        
        StartCoroutine(StartVillainEvent());
    }
    void OnCompleteSearchRoomMove()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        boxCollider.enabled = true;
        animator.SetFloat("speed", 0);
        transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.SetPlayerCamera(2f);
        transform.Find("NPCController").gameObject.SetActive(false);
    }
    bool isSearchroomMove = false;
    public void SetSearchRoomMove()
    {
        isSearchroomMove = true;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class anchorManagerController : MonoBehaviour
{
    public GameObject SubmarinCameraPos;
    public QuestMovePlayer QuestMove;
    public Transform submarinPos;
    public Transform TargetPos;
    public GameObject FactoryManager;
    public GameObject Submarin;
    public BoxCollider2D FactoryManagerBox;
    bool isEmergencyRoom = false;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetFarmFriend()
    {
        GameManager.Instance.FarmFriend.SetActive(true);        
    }
    public void SetEmergencyRoomQuest()
    {
        isEmergencyRoom = true;
    }
    public void EndConversation()
    {
        if(isEmergencyRoom)
        {
            TestCodeManager.Instance.EscapeQuest_EndAnchorConversation(false);
            UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.EmergencyQuest);
            isEmergencyRoom = false;
        }
        if (isMoveOnConversation == true)
        {
            TestCodeManager.Instance.EscapeQuestComplete(false);
            FactoryManagerBox.enabled = false;
            StartCoroutine(MoveRoutine());
            isMoveOnConversation = false;
            transform.Find("NPCController").GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        }
    }
    public void MoveFactoryManager()
    {
        GameManager.Instance.SetCameraTarget(FactoryManager, 1f);
    }
    bool isMoveOnConversation = false;
    public void MoveMove()
    {
        GameManager.Instance.SetCameraTarget(this.gameObject, 1f);        
        isMoveOnConversation = true;
    }
    void endConverstation()
    {
       
    }
    IEnumerator MoveRoutine()
    {
        yield return new WaitForSeconds(1f);
        isMove = true;
        transform.localScale = new Vector3(-4, 4, 4);
        animator.Play("walking");
    }
    bool isMove = false;
    float speed = 1;
    public bool isMoveSubmarin;
    public void SetSubmarin()
    {
        isMoveSubmarin = true;
        GameManager.Instance.Player.GetComponent<PlayerController>().Margin = 1;
        FactoryManager.GetComponent<FactoryManagerController>().Margin = 1;
        FactoryManagerBox.enabled = false;
        transform.Find("NPCController").GetComponent<BoxCollider2D>().enabled = false;
        FactoryManager.transform.Find("NPCController").GetComponent<BoxCollider2D>().enabled = false;
        FactoryManager.GetComponent<BoxCollider2D>().enabled = false;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
    }
    public void SetInitMove()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().isFollowAnchor = true;
        FactoryManager.GetComponent<FactoryManagerController>().isStartMove = true;
        FactoryManager.GetComponent<FactoryManagerController>().speed = 1;

    }
    private void FixedUpdate()
    {
        if (isMove)
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().isFollowAnchor = true;
            FactoryManager.GetComponent<FactoryManagerController>().isStartMove = true;
            FactoryManager.GetComponent<FactoryManagerController>().speed = 1;
            transform.position = Vector2.MoveTowards(transform.position, TargetPos.position, speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - TargetPos.position.x) <= 0.1f)
            {
                Debug.Log("도착");                
                animator.Play("idle");
                GameManager.Instance.Player.GetComponent<PlayerController>().Margin = 0.1f;
                FactoryManager.GetComponent<FactoryManagerController>().Margin = 0.1f;
                isMove = false;
                QuestMove.Click();
            }
        }
        if(isMoveSubmarin)
        {
            animator.Play("walking");
            transform.localScale = new Vector3(4, 4, 4);
            transform.position = Vector2.MoveTowards(transform.position, submarinPos.position, speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - submarinPos.position.x) <= 0.1f)
            {                
                animator.Play("idle");
                GameManager.Instance.Player.GetComponent<PlayerController>().Margin = 0.22f;
                FactoryManager.GetComponent<FactoryManagerController>().Margin = 0.22f;
                GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f);
                isMoveSubmarin = false;
                CheckPlayer = true;
            }          
        }
        if(CheckPlayer)
        {
            if (GameManager.Instance.Player.GetComponent<PlayerController>().animator.GetFloat("speed") == 0 && isPlayerSprite == false)
            {
                isPlayerSprite = true;
                GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f);
            }
            if (FactoryManager.GetComponent<FactoryManagerController>().animator.GetFloat("speed") == 0 && isFactoryManagerSprite == false)
            {
                isFactoryManagerSprite = true;
                FactoryManager.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f).OnComplete(StartMarin);
            }
        }

    }
    bool CheckPlayer = false;
    void StartMarin()
    {
        GameManager.Instance.SetCameraTarget(SubmarinCameraPos, 2f);
        StartCoroutine(SubmarineRoutine());
        Debug.Log("시작!!");
        StartCoroutine(ChangeView());
    }
    IEnumerator ChangeView()
    {
        yield return new WaitForSeconds(4f);
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.sea);
        TestCodeManager.Instance.ShipGameStart();
    }
    IEnumerator SubmarineRoutine()
    {
        yield return new WaitForSeconds(2f);
        Submarin.GetComponent<Animator>().Play("event");
    }
    bool isPlayerSprite =false;
    bool isFactoryManagerSprite =false;
}

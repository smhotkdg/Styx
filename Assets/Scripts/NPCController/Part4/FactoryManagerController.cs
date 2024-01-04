using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManagerController : MonoBehaviour
{
    public Transform InitPos;
    public Transform AnchorPos;
    public bool isStartMove =false;
    public float speed = 1f;
    public GameObject FactoryQuestManager;
    public Transform FactoryEventPlayerPos;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();

        //test
        //transform.position = AnchorPos.position;
    }
    public void StartFactoryQuest()
    {
        FactoryQuestManager.SetActive(true);
        
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, FactoryEventPlayerPos, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
    }
    bool isGotoAncho = false;
    public void SetGoAnchor()
    {
        isGotoAncho = true;
    }
    
    public void EndConversation()
    {
        if(isGotoAncho)
        {
            isStartMove = true;
            isGotoAncho = false;
            UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.AnchorConversation);
            TestCodeManager.Instance.EscapeQuest_EndFactoryManager(false);
            transform.Find("NPCController").gameObject.SetActive(false);
        }
    }
    public void SetPosition(bool isOn)
    {
        isStartMove = false;
        if (isOn)
        {            
            transform.position = InitPos.position;
        }
        else
        {

            transform.position = AnchorPos.position;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="FactoryManagerEndPos")
        {
            isStartMove = false;
            animator.SetFloat("speed", 0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "FactoryManagerEndPos")
        {
            isStartMove = false;
            animator.SetFloat("speed", 0);
        }
    }
    public void DctorQuestStart()
    {
        if(GameManager.Instance.GameIndex ==40)
        {
            TestCodeManager.Instance.FactoryManagerQuest_Complete();
        }
    }
    float horizontal_index;
    public float Margin = 1f;
    private void Update()
    {
        if (isStartMove)
        {
            if (Mathf.Abs(transform.position.x - GameManager.Instance.Player.transform.localPosition.x) <= Margin)
            {
                animator.SetFloat("speed", 0);
                Vector3 vector = new Vector3(transform.position.x, GameManager.Instance.Player.transform.localPosition.y , 0);
                transform.position = vector;

                if (Mathf.Abs(transform.position.x - GameManager.Instance.Player.transform.localPosition.x) > 5 || Mathf.Abs(transform.position.y - GameManager.Instance.Player.transform.localPosition.y) > 5)
                {
                    transform.position = new Vector3(GameManager.Instance.Player.transform.localPosition.x - 2, GameManager.Instance.Player.transform.localPosition.y , 0);
                }
                return;
            }
            else
            {
                animator.SetFloat("speed", 1);
            }
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.Player.transform.localPosition, speed * Time.deltaTime);

            horizontal_index = transform.position.x - GameManager.Instance.Player.transform.localPosition.x;

            
            if(Mathf.Abs(transform.position.x - GameManager.Instance.Player.transform.localPosition.x)>5|| Mathf.Abs(transform.position.y - GameManager.Instance.Player.transform.localPosition.y) >5)
            {
                transform.position = new Vector3(GameManager.Instance.Player.transform.localPosition.x - 2, GameManager.Instance.Player.transform.localPosition.y, 0);
            }
            CheckFlip();
            //CheckDestination();
        }

        void CheckFlip()
        {
            if (horizontal_index != 0)
            {
                if (horizontal_index > 0)
                {
                    transform.localScale = new Vector3(1 * 4, 1 * 4, 1 * 4);
                }
                else
                {
                    transform.localScale = new Vector3(-1 * 4, 1 * 4, 1 * 4);
                }
            }
        }
    }
}

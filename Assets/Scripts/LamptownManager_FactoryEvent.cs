using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamptownManager_FactoryEvent : MonoBehaviour
{
    public Transform initPos;
    public Transform RoomPos;
    public List<GameObject> restroomPeople;
    Animator animator;
    public GameObject JuiceMakeGame;
    public DialogueSystemTrigger systemTrigger;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetWalk()
    {
        transform.Find("NPCController").gameObject.SetActive(false);
        transform.localScale = new Vector3(4, 4, 4);
        animator.Play("walking");
    }
    public void SetIdle()
    {
        transform.Find("NPCController").gameObject.SetActive(true);
        animator.Play("idle");
    }
    public void SetIdleInit()
    {
        animator.Play("idle");
    }
    public void SetPos()
    {
        if(GameManager.Instance.styxData.FactorySelectMemeber == "unassigned")
        {
            transform.position = initPos.position;
            transform.localScale = new Vector3(4, 4, 4);
            setRestroom(true);
            SetIdle();
        }
        else
        {
            transform.position = RoomPos.position;
            transform.localScale = new Vector3(-4, 4, 4);
            setRestroom(false);
            SetIdle();
        }
    }
    void setRestroom(bool flag)
    {
        for (int i = 0; i < restroomPeople.Count; i++)
        {
            restroomPeople[i].SetActive(flag);
        }
    }
    public void EndConversation()
    {
        GameManager.Instance.PharmercyDoor.enabled = true;
        if(isStartDrugQuest)
        {
            isStartDrugQuest = false;
            TestCodeManager.Instance.StartDrugQuest(false);
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.FactorySelectMemeber_Manager);
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;

        }
        if(isMakeJuice)
        {
            isMakeJuice = false;
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            JuiceMakeGame.SetActive(true);            
            JuiceMakeGame.GetComponent<SleepingJuiceController>().OnCompleteEventHandler += LamptownManager_FactoryEvent_OnCompleteEventHandler;
            JuiceMakeGame.GetComponent<SleepingJuiceController>().OnDisableEventHandler += LamptownManager_FactoryEvent_OnDisableEventHandler;
        }
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler()
    {
        
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler;
        
    }

    bool isMakeJuice = false;
    public void MakeJuice()
    {
        isMakeJuice = true;        
    }

    private void LamptownManager_FactoryEvent_OnDisableEventHandler()
    {
        JuiceMakeGame.GetComponent<SleepingJuiceController>().OnDisableEventHandler -= LamptownManager_FactoryEvent_OnDisableEventHandler;
        
    }

    private void LamptownManager_FactoryEvent_OnCompleteEventHandler()
    {
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.factoryDrugMake);
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler1;
        JuiceMakeGame.GetComponent<SleepingJuiceController>().OnCompleteEventHandler -= LamptownManager_FactoryEvent_OnCompleteEventHandler;
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler1()
    {
        
        StartCoroutine(ConversationStartRoutine());
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler1;
        
    }
 
    IEnumerator ConversationStartRoutine()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        yield return new WaitForSeconds(0.1f);
        DialogueManager.StartConversation(systemTrigger.conversation, transform);
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
    }

    bool isStartDrugQuest = false;
    public void GetDrugQuest()
    {
        isStartDrugQuest = true;
    }
}

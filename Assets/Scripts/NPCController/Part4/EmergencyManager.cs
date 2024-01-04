using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyManager : MonoBehaviour
{
    public Transform movePosition;
    Animator animator;
    public BoxCollider2D boxCollider;
    public bool isSetLeft = true;
    private void Start()
    {
        animator = GetComponent <Animator>();
    }

    public void EndConversation()
    {
        if(GameManager.Instance.styxData.EscapeSubQuestNumber >=5)
        {
            return;
        }
        if(isSleep)
        {
            TestCodeManager.Instance.EscapeQuest_StartSub5();
            isSleep = false;            
            return;
        }
        if (isNotToutch)
        {
            isNotToutch = false;
            StartCoroutine(PlayerSet());
            return;
        }
        if (GameManager.Instance.data.slpeepingJuice ==0)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, movePosition, 4);
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
            SetWorking();
            if (GameManager.Instance.styxData.EscapeNumber == 2)
            {
                if(GameManager.Instance.styxData.EscapeSubQuestNumber==0)
                    UIManager.Instance.EmergencyRoomIndex = 2;
            }
            else
            {
                UIManager.Instance.EmergencyRoomIndex = 1;
            }
        }
        
    }
    bool isSleep = false;
    public void SetSleep()
    {
        isSleep = true;
        animator.Play("sleep");
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 5)
        {
            boxCollider.enabled = false;
            animator.Play("sleep");
        }
        else
        {
            if(isSleep == false && setTrun ==false)
            {
                boxCollider.enabled = true;
                animator.Play("working");
            }            
        }
    }
    IEnumerator PlayerSet()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SetPlayerCamera();
        SetWorking();
    }
    bool isNotToutch = false;
    public void DoNotTouch()
    {
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
        SetSign();
        isNotToutch = true;
    }
    bool setTrun = false;
    public void SetSign()
    {
        setTrun = true;
        if(isSetLeft)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        animator.Play("turn");
    }
    public void SetWorking()
    {
        setTrun = false;
        animator.Play("working");
    }
}

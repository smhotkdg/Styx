using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDronePoint : MonoBehaviour
{
    public CheckDronePoint near;
    BoxCollider2D boxCollider;
    public DroneBookGame bookGame;
    public DialogueSystemTrigger CheckDialogue;
    public DialogueSystemTrigger KillDialogue;
    public DialogueSystemTrigger SaveDialogue;

    public GameObject DroneObejct;
    Animator DroneAnimator;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
        m_isComplete = false;
        DroneObejct.transform.Find("Sensor").gameObject.SetActive(false);
        DroneAnimator = DroneObejct.GetComponent<Animator>();
    }
    bool m_isComplete = false;
    private void BookGame_OnCompleteEventHandler(bool isComplete)
    {
        bookGame.OnCompleteEventHandler -= BookGame_OnCompleteEventHandler;
        m_isComplete = isComplete;
        CheckEnd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            bookGame.OnCompleteEventHandler += BookGame_OnCompleteEventHandler;
            GameManager.Instance.playerController.SetForceIdle();
            DroneObejct.transform.Find("Sensor").gameObject.SetActive(true);
            DialogueManager.StartConversation(CheckDialogue.conversation, transform);
            boxCollider.enabled = false;
            isKill = false;
            isSave = false;
            isCheck = false;
        }
    }
    bool isCheck =false;
    public void SetIsCheck()
    {
        isCheck = true;
    }
    public void DroneCheckStart()
    {
        if(isCheck)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            bookGame.gameObject.SetActive(true);
            GameManager.Instance.playerController.GunStart_Motion();
            UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().Play("gun_ready");
            isCheck = false;
        }
        
        
    }
    public void CheckEnd()
    {
        if(m_isComplete)
        {
            DialogueManager.StartConversation(SaveDialogue.conversation, transform);
        }
        else
        {
            DialogueManager.StartConversation(KillDialogue.conversation, transform);
        }
    }
    bool isKill = false;
    public void KillStart()
    {
        if(isKill)
        {
            DroneObejct.transform.Find("Sensor").gameObject.SetActive(false);
            DroneAnimator.Play("attack_idle");
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
            //여기서 부터 코루틴
            StartCoroutine(EventRoutine());
            
            isKill = false;
        }        
    }
    IEnumerator EventRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.cameraEffectController.MangaFlash(1);
        GameManager.Instance.cameraEffectController.SetEarthQuake(1f);
        GameManager.Instance.playerController.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.playerController.animator.Play("dead");
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(1f);
        TestCodeManager.Instance.StartPart6_Fountian(true);
        yield return new WaitForSeconds(3f);
        near.boxCollider.enabled = true;
        boxCollider.enabled = true;    
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void SetIsKill()
    {
        isKill = true;
    }
    bool isSave = false;
    public void SetIsSave()
    {
        isSave = true;
    }
    public void SaveStart()
    {
        if(isSave)
        {
            GameManager.Instance.playerController.animator.Play("gun_end");
            UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().Play("gun_end");
            DroneObejct.transform.Find("Sensor").gameObject.SetActive(false);
            //DroneAnimator.Play("attack_idle");
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            isSave = false;
        }
      
    }
}

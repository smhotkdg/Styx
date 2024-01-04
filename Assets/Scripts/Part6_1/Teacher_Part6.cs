using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class Teacher_Part6 : MonoBehaviour
{
    Animator animator;    
    public GameObject StudentEndPos;
    public GameObject KillUI;
    public DialogueSystemTrigger systemTrigger;
    public GameObject DieTeacher;
    Sequence sequence;
    IEnumerator gunRoutine;
    private void Start()
    {
        animator = GetComponent<Animator>();
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(StudentEndPos.transform.position, Vector2.Distance(transform.position, StudentEndPos.transform.position)).SetEase(Ease.Linear)).OnComplete(onCompleteMove);
        sequence.Pause();
        gunRoutine = GunshootRoutine();
    }
    bool isDie = false;
    void onCompleteMove()
    {
        if(isDie)
        {
            GetComponent<Animator>().Play("dead");
        }
        else
        {
            DieTeacher.gameObject.SetActive(true);
            DieTeacher.GetComponent<Animator>().Play("dead");
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator GunshootRoutine()
    {
        yield return new WaitForSeconds(5f);
        isKill(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            GameManager.Instance.playerController.SetForceIdle();
            DialogueManager.StartConversation(systemTrigger.conversation, transform);
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.KitchenAlarm);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }
    //KillTeacher
    //saveTeacher
    public void EndConverstaion()
    {
        if(bStartkill)
        {
            bStartkill = false;
            //GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            KillUI.SetActive(true);            
            GameManager.Instance.playerController.GunStart_Motion();
            GameManager.Instance.cameraEffectController.SetGlitch(true);
            GetComponent<Animator>().Play("walking");
            sequence.Play();
            transform.localScale = new Vector3(-4, 4, 4);
            StartCoroutine(gunRoutine);
            
        }
    }
    bool bStartkill = false;
    public void StartKillQuest()
    {
        bStartkill = true;
    }
    public void isKill(bool flag)
    {
        //KillUI.SetActive(false);
        GameManager.Instance.isKillScholl = flag;
        KillUI.GetComponent<Animator>().Play("GunshootpoolOff");
        GameManager.Instance.cameraEffectController.SetGlitch(false);
        isDie = flag;
        if (flag)
        {
            GameManager.Instance.playerController.ShootGun();
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
            StartCoroutine(DeadRoutine());
        }
        else
        {
            //transform.DOMove(StudentEndPos.transform.position, 15).SetEase(Ease.Linear);

            //UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().Play("gun_shooting");      
            GameManager.Instance.playerController.GunEnd();
            DialogueManager.StartConversation("saveTeacher");
        }        
        StopCoroutine(gunRoutine);
    }
    //gun_end
    IEnumerator FamerFriendShootRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.5f);
        GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(1f);
        GameManager.Instance.playerController.GunEnd();
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().Play("gun_end");
        
    }
    IEnumerator DeadRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.5f);
        sequence.Kill();
        transform.localScale = new Vector3(4, 4, 4);
        GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(1f);
        //GameManager.Instance.playerController.GunEnd();
        DialogueManager.StartConversation("KillTeacher");
        
    }

}

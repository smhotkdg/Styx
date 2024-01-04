using DG.Tweening;
using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom_EventPart6_2 : MonoBehaviour
{
    public Animator DoorAnim;
    public Animator BodyGuard;
    public Transform EventPos_1;
    public Transform EventPos_2;

    public GameObject Boss_1;
    public GameObject Boss_2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            GameManager.Instance.playerController.SetForceIdle();
            GetComponent<BoxCollider2D>().enabled = false;            
            DialogueManager.StartConversation(UIManager.Instance.Part6_2Hardware.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
                                        UIManager.Instance.Part6_2Hardware.transform);
            GameManager.Instance.SetCameraTarget(Boss_1.gameObject, 1);
        }
    }

    public void StartEvent()
    {
        DoorAnim.Play("event");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.LeaderRoom_Door);
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_2Hardware.transform.DOMove(EventPos_1.position,
            Vector2.Distance(UIManager.Instance.Part6_2Hardware.transform.position,
            EventPos_1.transform.position)).SetEase(Ease.Linear).OnComplete(KillBodyGuard);
        BodyGuard.Play("idle");
        GetComponent<BoxCollider2D>().enabled = true;
    }
    void KillBodyGuard()
    {
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().Play("gun");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunInit);
        //GameManager.Instance.cameraEffectController.SetGlitch(true);
        StartCoroutine(DeadRoutine());
    }

    IEnumerator DeadRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        BodyGuard.Play("dead");
        yield return new WaitForSeconds(0.1f);
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().Play("shoot");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);        
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.4f);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().Play("gunEnd");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().SetFloat("speed", 1);
        //yield return new WaitForSeconds(0.4f);
        UIManager.Instance.Part6_2Hardware.transform.DOMove(EventPos_2.position,
            Vector2.Distance(UIManager.Instance.Part6_2Hardware.transform.position,
            EventPos_2.transform.position)).SetEase(Ease.Linear).OnComplete(moveEnd);

        GameManager.Instance.playerController.forceMove = true;
        GameManager.Instance.Player.transform.DOMove(EventPos_1.position,
            Vector2.Distance(GameManager.Instance.Player.transform.position,
            EventPos_1.transform.position)).SetEase(Ease.Linear).OnComplete(OnCompleteMovePlayer_1);
    }
    void moveEnd()
    {
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().SetFloat("speed", 0);
    }
    void OnCompleteMovePlayer_1()
    {
        GameManager.Instance.playerController.forceMove = false;
        GameManager.Instance.playerController.SetForceIdle();
        GameManager.Instance.SetPlayerCamera(1f);
        StartCoroutine(NottingRoutine());
    }
    IEnumerator NottingRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    void SetInit()
    {
        DoorAnim.Play("idle");

    }
}

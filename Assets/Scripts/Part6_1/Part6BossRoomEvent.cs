using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class Part6BossRoomEvent : MonoBehaviour
{
    public DialogueSystemTrigger systemTrigger;
    public Animator DoorAnim;
    public Transform EventPos_1;
    public Transform EventPos_2;
    public Animator BodyGuard;
    public GameObject GunGameUI;

    public Transform Boss1;
    public Transform Boss2;
    
    public void StartEvent()
    {
        DoorAnim.Play("event");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.LeaderRoom_Door);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_Ememy.transform.DOMove(EventPos_1.position, 
            Vector2.Distance(UIManager.Instance.Part6_Ememy.transform.position, 
            EventPos_1.transform.position)).SetEase(Ease.Linear).OnComplete(OnCompleteMoveEnmey);
        BodyGuard.Play("idle");
        GetComponent<BoxCollider2D>().enabled = true;
    }
    void SetInit()
    {
        DoorAnim.Play("idle");
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            GameManager.Instance.playerController.SetForceIdle();
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.styxData.Part5_1EventCount = 25;
            DialogueLua.SetVariable("Part5_1EventCount", GameManager.Instance.styxData.Part5_1EventCount);
            DialogueManager.StartConversation(systemTrigger.conversation,
            UIManager.Instance.Part6_Cult.transform);
            GameManager.Instance.SetCameraTarget(Boss1.gameObject,1);
        }
    }
    void OnCompleteMoveEnmey()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.traumaSound);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().Play("Gun");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunInit);
        GameManager.Instance.cameraEffectController.SetGlitch(true);
        StartCoroutine(DeadRoutine());
        
    }
    IEnumerator DeadRoutine()
    {
        yield return new WaitForSeconds(0.4f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        BodyGuard.Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.4f);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 1);
        yield return new WaitForSeconds(0.4f);
        UIManager.Instance.Part6_Ememy.transform.DOMove(EventPos_2.position,
            Vector2.Distance(UIManager.Instance.Part6_Ememy.transform.position,
            EventPos_2.transform.position)).SetEase(Ease.Linear).OnComplete(OnCompleteMoveEnmey_2);

        GameManager.Instance.playerController.forceMove =true;
        GameManager.Instance.Player.transform.DOMove(EventPos_1.position,
            Vector2.Distance(GameManager.Instance.Player.transform.position,
            EventPos_1.transform.position)).SetEase(Ease.Linear).OnComplete(OnCompleteMovePlayer_1);
    }
    void OnCompleteMovePlayer_1()
    {
        GameManager.Instance.playerController.forceMove = false;
        GameManager.Instance.playerController.SetForceIdle();
        GunGameUI.SetActive(true);
        GameManager.Instance.playerController.GunStart_Motion();
    }
    bool boolKillEnmey =false;
    IEnumerator DiePlayer()
    {
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_Ememy, 0.5f);
        UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(4, 4, 4);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().Play("Gun");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunInit);
        yield return new WaitForSeconds(0.4f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.SetPlayerCamera(0.5f);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.playerController.Dead_2();
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(1.5f);
        SetInit();
        TestCodeManager.Instance.StartPart6_BossRoom();
    }
    IEnumerator DieEnemy()
    {
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.playerController.ShootGun();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.4f);
        GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_Ememy, 0.5f);
        yield return new WaitForSeconds(0.2f);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().Play("dead_back");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        //UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(4, 4, 4);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetPlayerCamera(1f);
        DialogueManager.StartConversation(systemTrigger.conversation,
            UIManager.Instance.Part6_Cult.transform);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void Shoot(bool isShoot)
    {
        GameManager.Instance.cameraEffectController.SetGlitch(false);
        boolKillEnmey = isShoot;
        
        GunGameUI.GetComponent<Animator>().Play("GunshootpoolOff");
        if(boolKillEnmey ==false)
        {
            StartCoroutine(DiePlayer());
        }
        else
        {
            StartCoroutine(DieEnemy());
        }
    }
    void OnCompleteMoveEnmey_2()
    {
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 0);
        GameManager.Instance.SetPlayerCamera(1f);
        StartCoroutine(KillEnmeyRoutine());
    }
    IEnumerator KillEnmeyRoutine()
    {
        yield return new WaitForSeconds(0.2f);
    }
    // Start is called before the first frame update
    void Start()
    {
        DoorAnim.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

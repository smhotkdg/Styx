using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PoolGuard : MonoBehaviour
{
    public BoxCollider2D HardwareColider;
    public bool isPart5_1 = true;
    public GameObject EventView;
    public GameObject EvnetCameraView;
    public GameObject Guard2;
    public Transform EndPoint;
    public GameObject GunUI;
    // Start is called before the first frame update

    void Start()
    {
        if(isPart5_1)
        {
            if (GameManager.Instance.styxData.DeadManMoveQuest == "active" || GameManager.Instance.styxData.DeadManMoveQuest == "success")
            {
                Guard2.GetComponent<Animator>().Play("dead");
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            if (GameManager.Instance.styxData.MoveGuard == "active" || GameManager.Instance.styxData.MoveGuard == "success")
            {
                Guard2.GetComponent<Animator>().Play("dead_2");
                this.gameObject.SetActive(false);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    //bool isShoot = false;
    public void Shoot(bool flag)
    {
        if(flag)
        {
            GameManager.Instance.styxData.killGuard = 1;
            DialogueLua.SetVariable("killGuard", GameManager.Instance.styxData.killGuard);
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.data.isShootPoolGuard= flag;
            GameManager.Instance.Player.GetComponent<PlayerController>().ShootGun();
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
            GameManager.Instance.cameraEffectController.SetEarthQuake(1f);
            StartCoroutine(EndKillRoutine());

        }
        else
        {           
            shootFriend();
        }
        GunUI.GetComponent<Animator>().Play("GunshootpoolOff");
        GameManager.Instance.cameraEffectController.SetGlitch(false);
    }
    IEnumerator EndKillRoutine()
    {        
        yield return new WaitForSeconds(0.5f);        
        GameManager.Instance.SetCameraTarget(Guard2, 0.5f);
        yield return new WaitForSeconds(0.35f);
        Guard2.GetComponent<Animator>().Play("dead");        
        yield return new WaitForSeconds(3f);
        GameManager.Instance.SetPlayerCamera(1.5f);        
        DialogueManager.StartConversation(UIManager.Instance.Part5_1FarmFriend.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
            UIManager.Instance.Part5_1FarmFriend.transform);

        transform.Find("NPCController").gameObject.SetActive(false);
        //GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    bool farmFriendShoot = false;
    bool bMoveGuard = false;
    public void StartMoveGuardQuest()
    {
        bMoveGuard = true;
    }
    public void endConversation()
    {
        if(isKillQuest)
        {
            GameManager.Instance.StartGuardKillQuest_Inpool();
            GameManager.Instance.cameraEffectController.SetGlitch(true);
            GunUI.SetActive(true);
            StartCoroutine(GunFarmFriendRoutine());
            isKillQuest = false;
        }
        if (bMoveGuard)
        {
            bMoveGuard = false;
            GameManager.Instance.styxData.MoveGuard = "active";
            DialogueLua.SetQuestField("MoveGuard", "State", GameManager.Instance.styxData.MoveGuard);
            UIManager.Instance.CheckQuestGuide();
            UIManager.Instance.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest));            
            HardwareColider.enabled = true;
            GameManager.Instance.SetPlayerCamera(1f);
            StartCoroutine(SetStateNoting(1.2f));
        }
    }
    IEnumerator SetStateNoting(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    void shootFriend()
    {
        if(farmFriendShoot==false)
        {
            farmFriendShoot = true;
            GameManager.Instance.SetCameraTarget(UIManager.Instance.Part5_1FarmFriend, 0.5f);
            StartCoroutine(friendShootRoutine());
            
        }
        GameManager.Instance.styxData.killGuard = 0;
        DialogueLua.SetVariable("killGuard", GameManager.Instance.styxData.killGuard);
        GameManager.Instance.SaveStyxData();
    }
    IEnumerator friendShootRoutine()
    {
        UIManager.Instance.Part5_1FarmFriend.GetComponent<Part5_1FarmFriend>().GunshootDirect();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.6f);        
        GameManager.Instance.cameraEffectController.SetEarthQuake(1f);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.Player.GetComponent<PlayerController>().GunEnd();
        StartCoroutine(EndKillRoutine());
    }
    IEnumerator GunFarmFriendRoutine()
    {
        yield return new WaitForSeconds(5f);
        if(farmFriendShoot ==false && GameManager.Instance.data.isShootPoolGuard == false)
        {
            GunUI.GetComponent<Animator>().Play("GunshootpoolOff");
            GameManager.Instance.cameraEffectController.SetGlitch(false);
            shootFriend();
        }
    }
    public void SetPartroomEvent()
    {
        
        DialogueManager.Pause();
        //EventView.SetActive(true);
        EvnetCameraView.GetComponent<PartroomEventCamera>().onCompleteEventHandler += PoolGuard_onCompleteEventHandler;
        EvnetCameraView.SetActive(true);
    }

    private void PoolGuard_onCompleteEventHandler()
    {
        EvnetCameraView.GetComponent<PartroomEventCamera>().onCompleteEventHandler -= PoolGuard_onCompleteEventHandler;
        EventView.GetComponent<Animator>().Play("GetsubmarinKeyOff");
        DialogueManager.Unpause();
    }
    public void MoveStart()
    {
        transform.Find("NPCController").GetComponent<BoxCollider2D>().enabled = false;
        transform.Find("Wall").gameObject.SetActive(false);
        transform.Find("NPCController").GetComponent<NPCController>().ForceExit();
        GetComponent<Animator>().Play("walking");
        transform.DOMove(EndPoint.position, 3).SetEase(Ease.Linear).OnComplete(onCompleteMove);
    }
    void onCompleteMove()
    {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f);
        
        GetComponent<Animator>().Play("idle");
    }
    bool isKillQuest = false;
    public void KillQuest()
    {
        isKillQuest = true;
    }
    
    
}

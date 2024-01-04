using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class Part6Cult : MonoBehaviour
{
    public GameObject Hallway_End;
    public Transform CultPos;
    public Part6BossRoomEvent BossRoomEvent;
    public GameObject KillLeaderUI;
    // Start is called before the first frame update
    public GuardGame_Controller GuardGame_Controller;
    public Transform wheelHouseEndPos;
    public GameObject KillUI;
    public List<GameObject> NPCLIst_WheelHouse;
    public BoxCollider2D WheelHouseObject;
    public List<GameObject> WheelHouseAlarm;
    public Transform Campos;
    public MemoryCard memoryCard;
    public Animator FountainBg;
    public GameObject Cloud;
    public BoxCollider2D MoveWall;

    public BoxCollider2D boxCollider;
    public Transform End_residentialarea;
    public Transform End_StreeingHallway;
    public List<GameObject> DroneList;
    Animator animator;

    public Animator boomBG;
    public Animator Boom_Effect;

    public GameObject Hardware;
    public GameObject Manager;
    public Vector2 hardwarePos;
    public Vector2 ManangerPos;
    FollowObject followObject;
    bool bStop = false;
    private void FixedUpdate()
    {
        if(GameManager.Instance.roomPosition == GameManager.RoomPosition.leadersroom)
        {
            if(bStop ==false)
            {
                if (transform.position.x > CultPos.position.x)
                {
                    followObject.isFollow = false;
                    animator.SetBool("isRun", false);
                    animator.SetFloat("speed", 0);
                    Debug.Log("멈춤");
                    bStop = true;
                }
            }           
        }
        else
        {
            bStop = false;
        }
    }
    void Start()
    {
        bStop = false;
        followObject = GetComponent<FollowObject>();
        animator = GetComponent<Animator>();
        bNight = false;
        Hardware.SetActive(false);
        Manager.SetActive(false);
        UIManager.Instance.BoomTimer.GetComponent<BoomTimer>().OnTimerEndEvnetHandler += Part6Cult_OnTimerEndEvnetHandler;
        hardwarePos = Hardware.transform.position;
        ManangerPos = Manager.transform.position;
        if (GameManager.Instance.styxData.MoveDoor == "active" || GameManager.Instance.styxData.MoveDoor == "success")
        {
            for (int i = 0; i < WheelHouseAlarm.Count; i++)
            {
                WheelHouseAlarm[i].GetComponent<Animator>().Play("on");
            }
            if (GameManager.Instance.styxData.MoveDoor == "active")
                WheelHouseObject.enabled = true;
            else
                WheelHouseObject.enabled = false;
        }
        else
        {
            for (int i = 0; i < WheelHouseAlarm.Count; i++)
            {
                WheelHouseAlarm[i].GetComponent<Animator>().Play("off");
            }
            WheelHouseObject.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    bool isEnding = false;
    public void Part6Ending()
    {
        isEnding = true;
    }
    bool isKillDoorMna = false;
    public void KillDoorMan()
    {
        isKillDoorMna = true;
    }
    bool bWheelHouseEventAlarm = false;
    public void wheelHouseEventAlarm()
    {
        bWheelHouseEventAlarm = true;
        DialogueManager.Pause();
        StartCoroutine(AlarmEventRoutine());
    }
    IEnumerator AlarmEventRoutine()
    {
        for (int i = 0; i < WheelHouseAlarm.Count; i++)
        {
            WheelHouseAlarm[i].GetComponent<Animator>().Play("on");
        }
        yield return new WaitForSeconds(2f);
        DialogueManager.Unpause();
    }
    bool bMoveBlock = false;
    public void StartMoveBlockEvent()
    {
        bMoveBlock = true;

    }
    public void SetTextNPC()
    {
        StartCoroutine(SetTextRoutine());
    }
    IEnumerator SetTextRoutine()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.setDialogue(NPCLIst_WheelHouse[3], languageController.Instance.GetWheelHouseEvent(0), 150, 2);
        //NPCLIst_WheelHouse[3]
        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.setDialogue(NPCLIst_WheelHouse[2], languageController.Instance.GetWheelHouseEvent(1), 110, 2.5f);
        yield return new WaitForSeconds(0.4f);
        UIManager.Instance.setDialogue(NPCLIst_WheelHouse[1], languageController.Instance.GetWheelHouseEvent(2), 100, 2);
        yield return new WaitForSeconds(0.2f);
        UIManager.Instance.setDialogue(NPCLIst_WheelHouse[0], languageController.Instance.GetWheelHouseEvent(3), 130, 3);
    }
    bool wheelKillEvent = false;
    public void StartWheelKillEvent()
    {
        wheelKillEvent = true;
    }
    public bool bNight = false;
    IEnumerator KillEventRoutine()
    {
        UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(4, 4, 4);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.traumaSound);
        yield return new WaitForSeconds(2f);        
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().Play("GunShot");
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SetCameraTarget(NPCLIst_WheelHouse[1], 1f);
        yield return new WaitForSeconds(0.5f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        GameManager.Instance.cameraEffectController.MangaFlash(0.2f);
        NPCLIst_WheelHouse[0].GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(0.2f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        GameManager.Instance.cameraEffectController.MangaFlash(0.2f);
        NPCLIst_WheelHouse[2].GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(0.2f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        GameManager.Instance.cameraEffectController.MangaFlash(0.2f);
        NPCLIst_WheelHouse[1].GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(0.2f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        GameManager.Instance.cameraEffectController.MangaFlash(0.2f);
        NPCLIst_WheelHouse[3].GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(0.2f);

        GameManager.Instance.SetCameraTarget(NPCLIst_WheelHouse[4], 1.5f);
        DialogueManager.StartConversation("KillWheelHouse", transform);
        UIManager.Instance.setDialogue(NPCLIst_WheelHouse[4], languageController.Instance.GetWheelHouseEvent(3), 110, 3);
    }
    public bool isKillSet = false;
    public void SetisKill()
    {
        //Debug.Log("선택은?");
        isKillSet = true;
    }
    bool bEndWheelHouse = false;
    public void EndWheelHouse()
    {
        bEndWheelHouse = true;

    }
    public void StartMoveWheelHouseEnd()
    {
        boxCollider.enabled = false;
        UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(4, 4, 4);
        float dis2 = Vector3.Distance(UIManager.Instance.Part6_Ememy.transform.position, wheelHouseEndPos.position);
        UIManager.Instance.Part6_Ememy.transform.DOMove(wheelHouseEndPos.position, dis2/1.6f).SetEase(Ease.Linear).OnComplete(wheelHouseEnd_1);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 1);
        //UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetBool("isRun", true);


        transform.localScale = new Vector3(4, 4, 4);
        animator.SetFloat("speed", 1);
        //animator.SetBool("isRun", true);
        float dis1 = Vector3.Distance(transform.position, wheelHouseEndPos.position);
        transform.DOMove(wheelHouseEndPos.position, dis1/1.6f).SetEase(Ease.Linear).OnComplete(wheelHouseEnd_2);
        MoveWall.enabled = false;
        if (GameManager.Instance.cinemachineCamera.m_Follow.gameObject.name != "Player")
        {
            GameManager.Instance.SetPlayerCamera(1.5f);
            StartCoroutine(CamerPlayerRoutine());
        }
        else
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        }

    }
    IEnumerator CamerPlayerRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    void wheelHouseEnd_1()
    {
        UIManager.Instance.Part6_Ememy.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1f);
        //UIManager.Instance.Part6_Ememy.SetActive(false);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 0);
        //UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetBool("isRun", false);
    }
    void wheelHouseEnd_2()
    {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f);
        
        animator.SetFloat("speed", 0);
        //animator.SetBool("isRun", false);
    }
    IEnumerator GunEvent(bool flag)
    {
        yield return new WaitForSeconds(1f);
        if (flag)
        {
            GameManager.Instance.playerController.ShootGun();
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
            yield return new WaitForSeconds(0.5f);
            GameManager.Instance.SetCameraTarget(NPCLIst_WheelHouse[4], .5f);
            yield return new WaitForSeconds(0.2f);
            GameManager.Instance.cameraEffectController.SetEarthQuake(0.5f);
            GameManager.Instance.cameraEffectController.MangaFlash(0.5f);
            NPCLIst_WheelHouse[4].GetComponent<Animator>().Play("dead");
            yield return new WaitForSeconds(2.5f);
            GameManager.Instance.SetPlayerCamera(1.5f);
            yield return new WaitForSeconds(1.5f);
            DialogueManager.StartConversation("WheelHouseKill", transform);
        }
        else
        {
            UIManager.Instance.Part6_Ememy.GetComponent<Animator>().Play("Gun");
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunInit);
            yield return new WaitForSeconds(0.5f);
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
            GameManager.Instance.SetCameraTarget(NPCLIst_WheelHouse[4], .5f);
            yield return new WaitForSeconds(0.2f);
            GameManager.Instance.cameraEffectController.SetEarthQuake(0.5f);
            GameManager.Instance.cameraEffectController.MangaFlash(0.5f);
            NPCLIst_WheelHouse[4].GetComponent<Animator>().Play("dead");
            yield return new WaitForSeconds(2.5f);
            GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_Ememy, 1.5f);
            yield return new WaitForSeconds(1.5f);
            DialogueManager.StartConversation("WheelHouseSave", transform);
        }
    }
    public void SetKill(bool flag)
    {
        if (flag)
        {
            GameManager.Instance.SetPlayerCamera(1f);
            GameManager.Instance.playerController.GunStart_Motion();
            StartCoroutine(GunEvent(true));
        }
        else
        {
            GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_Ememy, 1f);
            StartCoroutine(GunEvent(false));
        }
        KillUI.GetComponent<Animator>().Play("GunshootpoolOff");
        GameManager.Instance.cameraEffectController.SetGlitch(false);
        //true 죽임
        //false 살림
    }
    void StartKillDoorManEvent()
    {
        GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_Ememy, 2f);
        StartCoroutine(KillDoorManRoutine());
    }
    IEnumerator KillDoorManRoutine()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.traumaSound);
        yield return new WaitForSeconds(2f);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().Play("Gun");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunInit);
        yield return new WaitForSeconds(0.4f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.cameraEffectController.SetGlitch(true);        
        GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_SteelDoorMan, 0.5f);
        yield return new WaitForSeconds(0.6f);
        UIManager.Instance.Part6_SteelDoorMan.GetComponent<Animator>().Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.SetPlayerCamera(2f);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.data.isDeadGateKeeper = true;
        GameManager.Instance.cameraEffectController.SetGlitch(false);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        UIManager.Instance.Part6_Ememy.GetComponent<FollowObject>().isFollow = true;
    }

    IEnumerator ChangeCameraPlus_ori()
    {
        for (int i = 0; i < 50; i++)
        {
            GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize += 0.05f;
            GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY += 0.0005f;
            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize = 7.5f;
        GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = 0.555f;
    }
    
    IEnumerator ChangeCameraPlus()
    {
        UIManager.Instance.GunGameUI.SetActive(true);
        for (int i = 0; i < 50; i++)
        {
            GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenX -= 0.006f;
            yield return new WaitForSeconds(0.01f);
        }

        GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenX = 0.2f;
        animator.Play("gun");

        GameManager.Instance.playerController.GunStart_Motion();
        GuardGame_Controller.StartGame();
        //GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
        //UIManager.Instance.Part6_Ememy.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
    }
    public void isKillLeader(bool flag)
    {
        KillLeaderUI.GetComponent<Animator>().Play("GunshootpoolOff");
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        if (flag)
        {
            //죽임
            GameManager.Instance.styxData.Part5_1EventCount = 100;
            DialogueLua.SetVariable("Part5_1EventCount", GameManager.Instance.styxData.Part5_1EventCount);
            StartCoroutine(KillLeaderRoutine());
        }
        else
        {
            //살림
            GameManager.Instance.styxData.Part5_1EventCount = 200;
            DialogueLua.SetVariable("Part5_1EventCount", GameManager.Instance.styxData.Part5_1EventCount);
            GameManager.Instance.playerController.GunEnd();
            StartCoroutine(SaveLeaderRoutine());
        }        
    }
    IEnumerator SaveLeaderRoutine()
    {
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
        yield return new WaitForSeconds(1f);
        animator.Play("shoot");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.4f);
        GameManager.Instance.SetCameraTarget(BossRoomEvent.Boss1.gameObject, 0.5f);
        BossRoomEvent.Boss2.GetComponent<Animator>().Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.4f);
        BossRoomEvent.Boss1.GetComponent<Animator>().Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetPlayerCamera(1f);
        yield return new WaitForSeconds(1f);
        DialogueManager.StartConversation(transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
            transform);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
    }
    IEnumerator KillLeaderRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.playerController.ShootGun();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.4f);
        BossRoomEvent.Boss1.GetComponent<Animator>().Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        GameManager.Instance.SetCameraTarget(BossRoomEvent.Boss1.gameObject,0.5f);
        yield return new WaitForSeconds(1f);        
        GameManager.Instance.playerController.ShootGun();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.4f);
        BossRoomEvent.Boss2.GetComponent<Animator>().Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetPlayerCamera(1f);
        yield return new WaitForSeconds(1.5f);
        DialogueManager.StartConversation(transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
            transform);
    }
    public void EndingKillEvent()
    {
        animator.Play("gun");        
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
    }
    public bool IsEndingSaveBoss = false;
    public void SetEndingBossSave()
    {
        IsEndingSaveBoss = true;
        animator.Play("gun");        
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);        
    }

    public bool IsEndingKillBoss = false;
    public void SetEndingBossKill()
    {
        IsEndingKillBoss = true;
    }
    public void EndingStart_Save()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.VillainEvent);
        StartCoroutine(KillPlayer_2());
    }
    public void EndingStart_Kill()
    {
        StartCoroutine(KillPlayer());
    }
    IEnumerator KillPlayer()
    {
        //교주 엔딩 살인
        animator.Play("shootOne");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.playerController.Dead_2();
        yield return new WaitForSeconds(2f);
        UIManager.Instance.Block.SetActive(true);
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.CreditBGM);
        UIManager.Instance.Ending_Headmaster.SetActive(true);
        yield return new WaitForSeconds(6f);


        GameManager.Instance.endingType = GameManager.EndingType.headmaster_kill;
        GameManager.Instance.data.EndingList[4] = 1;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        //UIManager.Instance.EndingPanel.SetActive(true);
        //UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.headmaster_kill);
        GameManager.Instance.SaveNormalData();
        //yield return new WaitForSeconds(1f);
        UIManager.Instance.Ending_Headmaster.GetComponent<Animator>().Play("Back_ending");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.EndingPanel.SetActive(true);
        UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.headmaster_kill);
    }
    IEnumerator KillPlayer_2()
    {
        //교주 엔딩 살림
        
        animator.Play("shootOne");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.playerController.Dead_2();
        yield return new WaitForSeconds(2f);
        UIManager.Instance.Block.SetActive(true);
        //UIManager.Instance.Ending_Headmaster.SetActive(true);
        UIManager.Instance.EndingHeadmaster_die.SetActive(true);
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.CreditBGM);
        yield return new WaitForSeconds(6f);
        GameManager.Instance.endingType = GameManager.EndingType.headmaster;
        GameManager.Instance.data.EndingList[5] = 1;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        //UIManager.Instance.EndingPanel.SetActive(true);
        //UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.headmaster);
        GameManager.Instance.SaveNormalData();
        //yield return new WaitForSeconds(1f);
        //UIManager.Instance.EndingHeadmaster_die.SetActive(false);
        UIManager.Instance.EndingHeadmaster_die.GetComponent<Animator>().Play("Back_ending");

        yield return new WaitForSeconds(1f);
        UIManager.Instance.EndingPanel.SetActive(true);
        UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.headmaster);
    }
    public void Part6CultEndConversation()
    {
        if(IsEndingSaveBoss)
        {
            IsEndingSaveBoss = false;
            EndingStart_Save();
        }
        if(IsEndingKillBoss)
        {
            IsEndingKillBoss = false;
            EndingStart_Kill();
        }

        if(isEnding)
        {
            isEnding = false;
            KillLeaderUI.SetActive(true);
            GameManager.Instance.SetPlayerCamera(1f);
            GameManager.Instance.playerController.GunStart_Motion();
        }
        if(isStartHallway_2Quest)
        {
            isStartHallway_2Quest = false;
            StartCoroutine(ChangeCameraPlus());
            StartCoroutine(ChangeCameraPlus_ori());
            
            //총싸움 시작
        }
        if(isKillDoorMna)
        {
            isKillDoorMna = false;
            StartKillDoorManEvent();
        }
        if(bEndWheelHouse)
        {
            StartMoveWheelHouseEnd();
            bEndWheelHouse = false;
        }
        if(isKillSet)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            GameManager.Instance.cameraEffectController.SetGlitch(true);
            KillUI.SetActive(true);
            isKillSet = false;
        }
        if(wheelKillEvent)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_Ememy, 2f);
            StartCoroutine(KillEventRoutine());
            wheelKillEvent = false;
        }
        if(bMoveBlock)
        {
            bMoveBlock = false;
            WheelHouseObject.enabled = true;            
            GameManager.Instance.styxData.MoveDoor = "active";            
            DialogueLua.SetQuestField("MoveDoor", "State", GameManager.Instance.styxData.MoveDoor);            
            UIManager.Instance.CheckQuestGuide();
        }
        if(isFountain)
        {
            transform.localScale = new Vector3(-4, 4, 4);
            transform.DOMove(End_residentialarea.position, 5).OnComplete(onCompleteFoutainMove).SetEase(Ease.Linear);

            animator.SetFloat("speed", 1);
            memoryCard.OnCompleteViewEventHandler += MemoryCard_OnCompleteViewEventHandler;
            isFountain = false;
        }
        if(isNight)
        {
            isNight = false;
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Fountain, GameManager.Instance.Player.transform, 6);            
            StartCoroutine(NightRoutine());
            bNight = true;
        }
        if(isStartLadder)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            GameManager.Instance.playerController.GunEnd();
            UIManager.Instance.Part6_1FarmFriend.GetComponent<FollowObject>().isFollow = false;
            UIManager.Instance.Part6_1FarmFriend.GetComponent<Part6FamerFriend>().boxCollider.enabled = false;
            GetComponent<FollowObject>().isFollow = false;
            UIManager.Instance.Part6_Ememy.GetComponent<FollowObject>().isFollow = false;
            boxCollider.enabled = false;
            UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(-4, 4, 4);
            StartCoroutine(LadderMoveRoutine());
            isStartLadder = false;
        }
        if(isBoom)
        {
            GameManager.Instance.playerController.GunEnd();
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            isBoom = false;
        }
    }

 
    public void MoveStreeingRoom()
    {
        GetComponent<FollowObject>().isFollow = false;
        transform.localScale = new Vector3(-4, 4, 4);        
        UIManager.Instance.Part6_1FarmFriend.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(-4, 4, 4);

        float dis1 = Vector2.Distance(transform.position, End_StreeingHallway.position);
        transform.DOMove(End_StreeingHallway.position, dis1).SetEase(Ease.Linear).OnComplete(MoveComplete_1);
        animator.SetFloat("speed", 1);

        float dis3 = Vector2.Distance(UIManager.Instance.Part6_Ememy.transform.position, End_StreeingHallway.position);
        UIManager.Instance.Part6_Ememy.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_Ememy.transform.DOMove(End_StreeingHallway.position, dis3).SetEase(Ease.Linear).OnComplete(MoveComplete_3);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 1);

        GameManager.Instance.playerController.GunStart_Motion();
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().Play("gun_ready");
        Hardware.GetComponent<Animator>().Play("gun");
        Manager.GetComponent<Animator>().Play("gun");
    }
  
    public bool isBoom = false;
    public void BoomStart()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_EVENT;
        isBoom = true;
        transform.Find("NPCController").gameObject.SetActive(false);
        UIManager.Instance.Part6_1FarmFriend.transform.Find("NPCController").gameObject.SetActive(false);
        UIManager.Instance.BoomTimer.SetActive(true);
        Hallway_End.SetActive(false);
        Hallway_End.SetActive(true);
    }
    bool SetEnd = false;
    public void BoomGame(bool flag)
    {
        //false == saveplayer
        //true == killplayer
        SetEnd = true;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        
        boxCollider.enabled = false;
        StartCoroutine(MoveEventRoutine(!flag));
    }
    void MoveEndPlayer()
    {
        StartCoroutine(MoveEventRoutine(false));
    }
    IEnumerator MoveEventRoutine(bool flag)
    {
        float dis = Vector2.Distance(Campos.position, GameManager.Instance.Player.transform.position);
        GameManager.Instance.SetCameraTarget(Campos.gameObject, dis/2f);
        yield return new WaitForSeconds(dis/10f);
        Boom_Effect.gameObject.SetActive(true);
        GameManager.Instance.cameraEffectController.SetEarthQuake(1f);
        boomBG.Play("boom_start");      
        if(flag)
        {
            GameManager.Instance.playerController.Dead();
        }
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.Expolsion_Hallway);
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().Play("boom_dead");
        yield return new WaitForSeconds(dis / 10f);
        Hardware.transform.localScale = new Vector3(4, 4, 4);
        Hardware.GetComponent<Animator>().Play("boom_dead");
        yield return new WaitForSeconds(dis / 10f);
        Manager.transform.localScale = new Vector3(4, 4, 4);
        Manager.GetComponent<Animator>().Play("boom_dead");
        Boom_Effect.gameObject.SetActive(false);
        if(flag)
        {
            yield return new WaitForSeconds(3f);
            TestCodeManager.Instance.StartPart6_steering_Hallway();
            yield return new WaitForSeconds(1f);
            Manager.GetComponent<Animator>().Play("idle");
            Hardware.GetComponent<Animator>().Play("idle");
            Manager.transform.position = ManangerPos;
            Hardware.transform.position = hardwarePos;
            Manager.transform.localScale = new Vector3(-4, 4, 4);
            Hardware.transform.localScale = new Vector3(-4, 4, 4);
            Manager.SetActive(false);
            Hardware.SetActive(false);
            boomBG.Play("init");
            GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            GameManager.Instance.SteelRoomEvent = false;
            boxCollider.enabled = true;
            UIManager.Instance.Part6_1FarmFriend.transform.Find("NPCController").gameObject.SetActive(true);            
        }
        else
        {
            GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 1);
            yield return new WaitForSeconds(3f);
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wheelhouse);
            TestCodeManager.Instance.StartPart6_steering();
            yield return new WaitForSeconds(3f);
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            boxCollider.enabled = true;
        }
        transform.Find("NPCController").gameObject.SetActive(true);
    }
    public bool isSave = false;
    private void Part6Cult_OnTimerEndEvnetHandler()
    {
        //UIManager.Instance.BoomTimer.GetComponent<BoomTimer>().OnTimerEndEvnetHandler -= Part6Cult_OnTimerEndEvnetHandler;
        UIManager.Instance.BoomTimer.SetActive(false);
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        BoomGame(isSave);
    }

    private void Instance_OnCompleteEventChangeHandler()
    {
        
    }

    private void MemoryCard_OnCompleteViewEventHandler()
    {
        memoryCard.OnCompleteViewEventHandler -= MemoryCard_OnCompleteViewEventHandler;
        TestCodeManager.Instance.StartDroneBookQuest();
    }

    void MoveComplete_1()
    {
        animator.SetFloat("speed", 0);
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
    }
    void MoveComplete_2()
    {
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_1FarmFriend.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
    }
    void MoveComplete_3()
    {
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_Ememy.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
    }
    IEnumerator LadderMoveRoutine()
    {
        float dis1 = Vector2.Distance(transform.position, TestCodeManager.Instance.emergencyLadder_End.position);
        transform.DOMove(TestCodeManager.Instance.emergencyLadder_End.position, dis1).SetEase(Ease.Linear).OnComplete(MoveComplete_1);
        animator.SetFloat("speed", 1);

        float dis2 = Vector2.Distance(UIManager.Instance.Part6_1FarmFriend.transform.position, TestCodeManager.Instance.emergencyLadder_End.position);
        UIManager.Instance.Part6_1FarmFriend.transform.DOMove(TestCodeManager.Instance.emergencyLadder_End.position, dis2).SetEase(Ease.Linear).OnComplete(MoveComplete_2);        
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().SetFloat("speed", 1);

        float dis3 = Vector2.Distance(UIManager.Instance.Part6_Ememy.transform.position, TestCodeManager.Instance.emergencyLadder_End.position);
        UIManager.Instance.Part6_Ememy.transform.DOMove(TestCodeManager.Instance.emergencyLadder_End.position, dis3).SetEase(Ease.Linear).OnComplete(MoveComplete_3);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 1);

        yield return new WaitForSeconds(2f);        
        GameManager.Instance.SetPlayerCamera(2f);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void MoveHardware()
    {
        Hardware.SetActive(true);
        Manager.SetActive(true);
        GameManager.Instance.SetCameraTarget(Hardware);
        StartCoroutine(MoveRoutineHardward());
    

        
        //
    }
    IEnumerator MoveRoutineHardward()
    {
        yield return new WaitForSeconds(2.2f);
        float dis2 = Vector2.Distance(Hardware.transform.position, TestCodeManager.Instance.hallway_2_Start.position);
        Hardware.transform.DOMove(TestCodeManager.Instance.hallway_2_Start.position, dis2).SetEase(Ease.Linear).OnComplete(move_end1);
        Hardware.GetComponent<Animator>().SetFloat("speed", 1);

        Vector2 managerPos = TestCodeManager.Instance.hallway_2_Start.position;
        managerPos.x = managerPos.x - 2;
        float dis3 = Vector2.Distance(Manager.transform.position, managerPos);
        Manager.transform.DOMove(managerPos, dis3).SetEase(Ease.Linear).OnComplete(move_end2);
        Manager.GetComponent<Animator>().SetFloat("speed", 1);
    }
    void move_end2()
    {
        Manager.GetComponent<Animator>().SetFloat("speed", 0);

    }
    void move_end1()
    {
        DialogueManager.StartConversation(transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation, transform);
        Hardware.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_1FarmFriend.transform.localScale = new Vector3(4, 4, 4);
        UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(4, 4, 4);
        this.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
    }
    IEnumerator NightRoutine()
    {
        yield return new WaitForSeconds(1f);
        Cloud.SetActive(false);
        FountainBg.Play("night");
        
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Part6FamerFriend>().boxCollider.enabled = false;
        GameManager.Instance.styxData.Part5_1EventCount = 15;
        DialogueLua.SetVariable("Part5_1EventCount", GameManager.Instance.styxData.Part5_1EventCount);
        //boxCollider.enabled = false;
        MoveWall.enabled = false;
        UIManager.Instance.OnCompleteEventChangeHandler -= Instance_OnCompleteEventChangeHandler;
        for (int i = 0; i < DroneList.Count; i++)
        {
            DroneList[i].SetActive(false);
        }

    }
    void onCompleteFoutainMove()
    {        
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1).OnComplete(CompleteColor);
        animator.SetFloat("speed", 0);
    }
    void CompleteColor()
    {
        MoveFoutain();
    }
    public void MoveFoutain()
    {
        transform.position = TestCodeManager.Instance.fountain_headmasterPos.position;
        transform.localScale = new Vector3(4, 4, 4);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        boxCollider.enabled = true;
        animator.SetFloat("speed", 0);
        MoveWall.enabled = true;
    }
    bool isFountain = false;
    public void movefountain()
    {
        boxCollider.enabled = false;
        isFountain = true;
    }
    bool isNight = false;
    public void SetNight()
    {
        isNight = true;
    }
    bool isStartLadder = false;
    public void StartMoveLadder()
    {
        isStartLadder = true;
    }

    bool isStartHallway_2Quest =false;
    public void StartHallway_2Quest()
    {
        isStartHallway_2Quest = true;
    }
}

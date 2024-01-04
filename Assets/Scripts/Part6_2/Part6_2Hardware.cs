using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class Part6_2Hardware : MonoBehaviour
{
    public Transform EventPos;
    public GameObject KillLeaderUI;
    public GuardGame_Controller guardGame_Controller;
    public BoxCollider2D DoorColider;
    public Part6_2GunGame gunGame;
    public Transform Hallway_2Pos;
    public Transform Hallway_1Target;
    public List<GameObject> HallwayGuard;
    public Transform LadderCultPos;
    public BoxCollider2D boxCollider;
    public GameObject Wall;
    public List<GameObject> WheelHouseMembers;
    List<Vector2> GuardInitPos = new List<Vector2>();
    
    private void Start()
    {
        UIManager.Instance.BoomTimer.GetComponent<BoomTimer>().OnTimerEndEvnetHandler += Part6_2Hardware_OnTimerEndEvnetHandler;
        for(int i =0; i< HallwayGuard.Count; i++)
        {
            GuardInitPos.Add(HallwayGuard[i].transform.position);
        }
        if(GameManager.Instance.styxData.MoveDoor =="active")
        {
            DoorColider.enabled = true;
        }
        else
        {
            DoorColider.enabled = false;
        }
    }
    bool isStartPart6 = false;
    public void StartPart6()
    {
        isStartPart6 = true;
    }
    bool isSewerQuest = false;
    public void SewerQuestStart()
    {
        isSewerQuest = true;
    }
    bool bStartLadderNight = false;
    public void StartLadderNight()
    {
        bStartLadderNight = true;
    }
    public void StartLadderEvent()
    {
        UIManager.Instance.HeadMaster_Part6_2.transform.position = LadderCultPos.position;
        UIManager.Instance.HeadMaster_Part6_2.transform.localScale = new Vector3(-4, 4, 4);
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_2LamptownManager.transform.localScale = new Vector3(4, 4, 4);
        transform.localScale = new Vector3(4, 4, 4);
        GetComponent<Animator>().SetFloat("speed", 0);
        GetComponent<FollowObject>().isFollow = false;
        GameManager.Instance.SetCameraTarget(UIManager.Instance.HeadMaster_Part6_2, 1f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.VillainEvent);
        DialogueManager.StartConversation(transform.Find("NPCController").GetComponent<DialogueSystemTrigger>().conversation, transform);

    }
    public bool isHallway_1 = false;
    public void SetHallway_1()
    {
        isHallway_1 = true;
    }
    void CompleteGuard0()
    {
        HallwayGuard[0].GetComponent<Animator>().Play("idle");
    }
    void CompleteGuard1()
    {
        HallwayGuard[1].GetComponent<Animator>().Play("idle");
    }
    void CompleteGuard2()
    {
        HallwayGuard[2].GetComponent<Animator>().Play("idle");
    }
    bool isStartMoveWheelRoom = false;
    public void StartMoveWheelRoom()
    {
        isStartMoveWheelRoom = true;
    }
    bool isStartVillanGame = false;
    public void StartVillianQuest()
    {
        isStartVillanGame = true;
    }
    void CompleteHallway1()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_2LamptownManager.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1);
    }
    void CompleteHallway2()
    {
        GetComponent<Animator>().SetFloat("speed", 0);
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
    }
    public void SetLeft()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = false;
        GetComponent<FollowObject>().isFollow = false;
        transform.localScale = new Vector3(4, 4, 4);
        UIManager.Instance.Part6_2LamptownManager.transform.localScale = new Vector3(4, 4, 4);
    }
    public void SetHold()
    {
        
    }
    IEnumerator BindRoutine()
    {
        
        Wall.SetActive(false);
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        yield return new WaitForSeconds(1f);
        for(int i =0; i< WheelHouseMembers.Count; i++)
        {
            WheelHouseMembers[i].GetComponent<Animator>().Play("bind");
        }
        yield return new WaitForSeconds(3f);
        DialogueManager.StartConversation("MoveNext_Part6_2");
        GetComponent<FollowObject>().isFollow = true;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = true;
    }
    bool bStartNPC = false;
    public void SetCameraWheelMember()
    {
        bStartNPC = true;
        
    }

    public void SetTextNPC()
    {
        boxCollider.enabled = false;
        GameManager.Instance.SetCameraTarget(WheelHouseMembers[0], 2);
        StartCoroutine(SetTextRoutine());
    }
    IEnumerator SetTextRoutine()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.setDialogue(WheelHouseMembers[3], languageController.Instance.GetWheelHouseEvent2(0), 150, 2);
        //NPCLIst_WheelHouse[3]
        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.setDialogue(WheelHouseMembers[2], languageController.Instance.GetWheelHouseEvent2(1), 110, 2.5f);
        yield return new WaitForSeconds(0.4f);
        UIManager.Instance.setDialogue(WheelHouseMembers[1], languageController.Instance.GetWheelHouseEvent2(2), 100, 2);
        yield return new WaitForSeconds(0.2f);
        UIManager.Instance.setDialogue(WheelHouseMembers[0], languageController.Instance.GetWheelHouseEvent2(3), 130, 3);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetPlayerCamera(2f);
        yield return new WaitForSeconds(2f);
        UIManager.Instance.ScenesChangeView.SetActive(true);
        StartCoroutine(BindRoutine());
    }

    public void GetQuestMoveDoor()
    {
        GameManager.Instance.styxData.MoveDoor = "active";
        UIManager.Instance.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest));
        DialogueLua.SetQuestField("MoveDoor", "State", GameManager.Instance.styxData.MoveDoor);
        UIManager.Instance.CheckQuestGuide();
        
        DoorColider.enabled = true;
    }
    bool isMoveDoor = false;
    public void StartMoveDoor()
    {
        isMoveDoor = true;
    }
    IEnumerator ChangeCameraPlus()
    {
        UIManager.Instance.GunGameUI_2.SetActive(true);
        for (int i = 0; i < 50; i++)
        {
            GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenX -= 0.006f;
            yield return new WaitForSeconds(0.01f);
        }

        GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenX = 0.2f;
        GetComponent<Animator>().Play("gun");
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().Play("gun");
        GameManager.Instance.playerController.GunStart_Motion();
        guardGame_Controller.StartGame();
        //GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
        //UIManager.Instance.Part6_Ememy.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
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
    [Button("==테스트 카메라==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void TestCamera()
    {
        StartCoroutine(ChangeCameraPlus_ori());
    }
    public bool isStartHallway_2Quest = false;
    public void StartGunshootHallway()
    {
        isStartHallway_2Quest = true;
    }
    public bool isEnding = false;
    public void SetEnding()
    {
        isEnding = true;
    }
    public void isKillLeader(bool flag)
    {
        KillLeaderUI.GetComponent<Animator>().Play("GunshootpoolOff");
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        if (flag)
        {
            //죽임
            GameManager.Instance.styxData.Part5_2EventCount = 100;
            DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);
            StartCoroutine(KillLeaderRoutine());

        }
        else
        {
            //살림
            GameManager.Instance.styxData.Part5_2EventCount = 200;
            DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);
            GameManager.Instance.playerController.GunEnd();
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            DialogueManager.StartConversation(transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
           transform);
            boxCollider.enabled = true;
            SaveLeaderRoutine();
        }
    }
    public void BindStart()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isPlayer = true;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().FollowTarget = GameManager.Instance.Player;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().Margin = 0.8f;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = true;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().onDistanceZeroEventHandler += Part6_2Hardware_onDistanceZeroEventHandler2;

    }

    private void Part6_2Hardware_onDistanceZeroEventHandler2()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().onDistanceZeroEventHandler -= Part6_2Hardware_onDistanceZeroEventHandler2;
        GameManager.Instance.playerController.animator.Play("bind");
    }

    IEnumerator KillLeaderRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.playerController.ShootGun();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.4f);
        UIManager.Instance.BossRoomEvent6_2.Boss_1.GetComponent<Animator>().Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        GameManager.Instance.SetCameraTarget(UIManager.Instance.BossRoomEvent6_2.Boss_2.gameObject, 0.5f);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.playerController.ShootGun();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.4f);
        UIManager.Instance.BossRoomEvent6_2.Boss_2.GetComponent<Animator>().Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetCameraTarget(UIManager.Instance.Part6_2Hardware, 1f);
        yield return new WaitForSeconds(1.5f);
        DialogueManager.StartConversation(transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
            transform);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);

    }
    void SaveLeaderRoutine()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_2LamptownManager.transform.DOMove(EventPos.position, 
            Vector2.Distance(EventPos.position,UIManager.Instance.Part6_2LamptownManager.transform.position)).SetEase(Ease.Linear).OnComplete(CompleteLamp);
    }    
    void CompleteLamp()
    {
        StartCoroutine(MoveLeaderRoutine());
    }
    bool isStandUP = false;
    IEnumerator MoveLeaderRoutine()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.BossRoomEvent6_2.Boss_1.GetComponent<Animator>().Play("moveIdle");
        UIManager.Instance.BossRoomEvent6_2.Boss_2.GetComponent<Animator>().Play("moveIdle");
        isStandUP = true;
        yield return new WaitForSeconds(1f);
        if (bMove == true && isStandUP == true)
        {
            LeaderMove();
        }
    }
    void StandUp()
    {
        isStandUP = true;
    }
    void LeaderMove()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 1);
        GameManager.Instance.styxData.Part5_2EventCount = 300;
        DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);

        UIManager.Instance.BossRoomEvent6_2.Boss_1.GetComponent<FollowObject>().isFollow = true;
        UIManager.Instance.BossRoomEvent6_2.Boss_2.GetComponent<FollowObject>().isFollow = true;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_2LamptownManager.transform.localScale = new Vector3(4, 4, 4);
        UIManager.Instance.Part6_2LamptownManager.transform.DOMove(TestCodeManager.Instance.leaderroom_Start6_2.position,
            Vector2.Distance(TestCodeManager.Instance.leaderroom_Start6_2.position, UIManager.Instance.Part6_2LamptownManager.transform.position)).SetEase(Ease.Linear).OnComplete(CompleteBoss);
        isStandUP = false;
        bMove = false;
    }
    bool bMove = false;
    public void MoveLeaderStart()
    {
        bMove = true;
        if(bMove == true && isStandUP==true)
        {
            LeaderMove();
        }        
    }
    void CompleteBoss()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1);
        UIManager.Instance.BossRoomEvent6_2.Boss_1.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1);
        UIManager.Instance.BossRoomEvent6_2.Boss_2.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1);

        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.BossRoomEvent6_2.Boss_2.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.BossRoomEvent6_2.Boss_1.GetComponent<Animator>().SetFloat("speed", 0);
    }
    bool isSaveEnding = false;
    public void SaveEnding()
    {
        isSaveEnding = true;
    }
    IEnumerator SaveEndingRoutine()
    {
        //혁명군 엔딩
        yield return new WaitForSeconds(2f);
        UIManager.Instance.Block.SetActive(true);
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.CreditBGM);
        UIManager.Instance.Ending_Hardward_Save.SetActive(true);
        yield return new WaitForSeconds(6f);

        GameManager.Instance.endingType = GameManager.EndingType.revolutionary_army;
        GameManager.Instance.data.EndingList[3] = 1;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        //UIManager.Instance.EndingPanel.SetActive(true);
        //UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.revolutionary_army);
        GameManager.Instance.SaveNormalData();
        //yield return new WaitForSeconds(1f);
        UIManager.Instance.Ending_Hardward_Save.GetComponent<Animator>().Play("Back_ending");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.EndingPanel.SetActive(true);
        UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.revolutionary_army);
    }
    bool isBedEnding = false;
    public void BedEnding()
    {
        isBedEnding = true;
    }
  
    IEnumerator BedEndingRoutine()
    {
        //혁명군 엔딩 사망
        UIManager.Instance.Part6_2LamptownManager.transform.localScale = new Vector3(4, 4, 4);
        //Player Binding Move
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        UIManager.Instance.Part6_2LamptownManager.transform.DOMove(TestCodeManager.Instance.leaderroom_Start6_2.transform.position,
            Vector2.Distance(TestCodeManager.Instance.leaderroom_Start6_2.position, UIManager.Instance.Part6_2LamptownManager.transform.position)).SetEase(Ease.Linear);
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = false;
        GameManager.Instance.Player.transform.DOMove(TestCodeManager.Instance.leaderroom_Start6_2.transform.position,
            Vector2.Distance(TestCodeManager.Instance.leaderroom_Start6_2.position, GameManager.Instance.Player.transform.position)).SetEase(Ease.Linear);
        GameManager.Instance.playerController.animator.Play("bindwalking");
        yield return new WaitForSeconds(2f);
        UIManager.Instance.Block.SetActive(true);
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.CreditBGM);
        UIManager.Instance.Ending_Hardward_kill.SetActive(true);
        yield return new WaitForSeconds(6f);

        GameManager.Instance.endingType = GameManager.EndingType.revolutionary_army_Kill;
        GameManager.Instance.data.EndingList[2] = 1;        
        //UIManager.Instance.EndingPanel.SetActive(true);
        //UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.revolutionary_army_Kill);
        GameManager.Instance.SaveNormalData();
        //yield return new WaitForSeconds(1f);
        UIManager.Instance.Ending_Hardward_kill.GetComponent<Animator>().Play("Back_ending");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.EndingPanel.SetActive(true);
        UIManager.Instance.EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.revolutionary_army_Kill);
    }
    public void EndConversation()
    {
        if(isBedEnding)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            isBedEnding = false;
            StartCoroutine(BedEndingRoutine());
        }
        if(isSaveEnding)
        {
            isSaveEnding = false;
            boxCollider.enabled = true;
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            StartCoroutine(SaveEndingRoutine());
        }
        if (isEnding)
        {
            isEnding = false;
            KillLeaderUI.SetActive(true);
            GameManager.Instance.SetPlayerCamera(1f);
            GameManager.Instance.playerController.GunStart_Motion();
        }
        if (isStartHallway_2Quest)
        {
            isStartHallway_2Quest = false;
            StartCoroutine(ChangeCameraPlus());
            StartCoroutine(ChangeCameraPlus_ori());

            //총싸움 시작
        }

        if (bStartNPC)
        {
            SetTextNPC();
            bStartNPC = false;
        }
        if(isMoveDoor)
        {
            isMoveDoor = false;
            GetQuestMoveDoor();
        }
        if(isStartVillanGame)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            isStartVillanGame = false;
            GetComponent<FollowObject>().isFollow = false;
            UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = false;
            UIManager.Instance.Part6_2LamptownManager.transform.localScale = new Vector3(-4, 4, 4);
            UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 1);
            UIManager.Instance.Part6_2LamptownManager.transform.DOMove(Hallway_2Pos.position,
                Vector2.Distance(Hallway_2Pos.position, UIManager.Instance.Part6_2LamptownManager.transform.position)).SetEase(Ease.Linear).OnComplete(CompleteHallway1);

            transform.localScale = new Vector3(-4, 4, 4);
            GetComponent<Animator>().SetFloat("speed", 1);
            transform.DOMove(Hallway_2Pos.position,
                Vector2.Distance(Hallway_2Pos.position, transform.position)).SetEase(Ease.Linear).OnComplete(CompleteHallway2);
            GameManager.Instance.playerController.GunStart_Motion();
            gunGame.SetInit();
        }
        if(isStartMoveWheelRoom)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            boxCollider.enabled = false;
            GameManager.Instance.styxData.Part5_2EventCount = 22;
            UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().Margin = 1f;
            UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isSetMargin = true;
            DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);
            isStartMoveWheelRoom = false;
        }
        if(isHallway_1)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;

            GetComponent<FollowObject>().Margin = 0;
            GetComponent<FollowObject>().isPlayer = false;
            GetComponent<FollowObject>().FollowTarget = Hallway_1Target.gameObject;
            boxCollider.enabled = false;
            GetComponent<FollowObject>().isFollow = true;
            GetComponent<FollowObject>().onDistanceZeroEventHandler += Part6_2Hardware_onDistanceZeroEventHandler1;
            //GameManager.Instance.SetCameraTarget(HallwayGuard[0], 0.5f);
            Vector2 NextPos = GameManager.Instance.Player.transform.position;            
            isHallway_1 = false;
            UIManager.Instance.BoomTimer.SetActive(true);
            //UIManager.Instance.BoomTimer.GetComponent<BoomTimer>().StartTImer();
            
        }
        if(bStartLadderNight)
        {
            bStartLadderNight = false;
            TestCodeManager.Instance.StartPart6_2_EmergencyLadder_night();
        }
        if(isStartPart6)
        {
            GameManager.Instance.styxData.Part5_2EventCount = 12;
            DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            isStartPart6 = false;
        }
        if(isSewerQuest)
        {
            isSewerQuest = false;
            GameManager.Instance.styxData.Part5_2EventCount = 14;
            DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            UIManager.Instance.SewerGame.SetActive(true);
            GameManager.Instance.playerController.PlayFlashIdle();
        }
    }

    private void Part6_2Hardware_onDistanceZeroEventHandler1()
    {
        GetComponent<FollowObject>().onDistanceZeroEventHandler -= Part6_2Hardware_onDistanceZeroEventHandler1;
        
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
        StartCoroutine(EndMemroyMove());
    }
    IEnumerator EndMemroyMove()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<FollowObject>().isPlayer = true;
        GetComponent<FollowObject>().FollowTarget = GameManager.Instance.Player;
        GetComponent<FollowObject>().Margin = 1.5f;
    }

    private void Part6_2Hardware_OnTimerEndEvnetHandler()
    {
        //죽는 이벤트
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        GameManager.Instance.playerController.SetForceIdle();
        GameManager.Instance.SetCameraTarget(HallwayGuard[0], 0.5f);
        StartCoroutine(PlayerDieRoutine());
    }
    IEnumerator PlayerDieRoutine()
    {
        GetComponent<FollowObject>().Margin = 1.5f;
        GetComponent<FollowObject>().isPlayer = true;
        GetComponent<FollowObject>().FollowTarget = GameManager.Instance.Player;
        GetComponent<FollowObject>().isFollow = false;
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.SetCameraTarget(HallwayGuard[0], 0.5f);
        for (int i = 0; i < HallwayGuard.Count; i++)
        {
            HallwayGuard[i].transform.position = GuardInitPos[i];
            HallwayGuard[i].SetActive(true);
            HallwayGuard[i].GetComponent<Animator>().Play("run");
        }
        HallwayGuard[0].GetComponent<FollowObject>().onDistanceZeroEventHandler += Part6_2Hardware_onDistanceZeroEventHandler;

        //GetComponent<Animator>()    
    }

    private void Part6_2Hardware_onDistanceZeroEventHandler()
    {
        StartCoroutine(ShootRoutine());
    }
    IEnumerator ShootRoutine()
    {
        HallwayGuard[0].GetComponent<Animator>().Play("shooting");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.3f);
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.3f);
        GameManager.Instance.playerController.Dead();
        yield return new WaitForSeconds(1.3f);
        UIManager.Instance.BoomTimer.SetActive(false);
        TestCodeManager.Instance.StartPart6_2_Hallway_1();
        //HallwayGuard[0].GetComponent<Animator>().Play("shooting");
    }
}

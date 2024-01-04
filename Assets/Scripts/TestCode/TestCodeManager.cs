using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using DG.Tweening;
public class TestCodeManager : MonoBehaviour
{
    private static TestCodeManager _instance = null;
    public static TestCodeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return null;
            }
            else
            {
                return _instance;
            }
        }
    }
    private void Awake()
    {
        if (_instance != null)
        {
        }
        else
        {
            _instance = this;
        }
    }
    public Transform SubMarinePos;
    public List<GameObject> SkyTownNormalNPC;
    public List<GameObject> SkyTownNormalFireNPC;

    public Transform FactoryPos;
    public Transform MachinePos;
    public Transform EngineerRoomPos;

    public Transform SkytownWareHousePos;
    public Transform DomitoryPosition;
    public Transform FruitInitPos;
    public bool isResetQuestData = false;
    public List<GameObject> Part3InitObjects;
    public Transform SkyTownInitPos;
    public Transform ChapelPos;
    public GameObject RoomOldMan;
    public GameObject SeaWorkManager;

    public Transform LampTownInitPos;

    public Transform warehousePosition;
    public Transform warehouseManagerPosition;
    public Transform warehouseMangerStorePosition;
    public Transform warehouseMangerNextPos;

    public Transform VentPosition;

    public Transform marinaPosition;
    public Transform ShipPosition;
    public Transform RoomPosition;
    public Transform seaworkPosition;

    public Transform DringEventPlayerPos;

    public void SetInit()
    {
        switch (GameManager.Instance.GameIndex)
        {
            case 0:
                StartMarina();
                break;
            case 1:
                startShip();
                break;
            case 2:
                RoomStart();
                break;
            case 3:
                OneDay();
                break;
            case 4:
                DroneMake();
                break;
            case 5:
                GoTowork();
                break;
            case 6:
                CompleteSeaWeed();
                break;
            case 7:
                Part1MainQUest(true);
                break;
            case 8:
                Part1MainQUest_GetItem();
                break;
            case 9:
                Part1CompleteLeverQuest();
                break;
            case 10:
                MoveToVent();
                break;
            case 11:
                WareHouse();
                break;
            case 12:
                warehouseInitConversationEnd(true);
                break;
            case 13:
                WarehouseManagerGetQuest(true);
                break;
            case 14:
                getPupQuest(true);
                break;
            case 15:
                DeliveryQuestComplete();
                break;
            case 16:
                SetSpeacialSeaweedQuest();
                break;
            case 17:
                SetEndSpeacialSeaweedQuest();
                break;
            case 18:
                EndDrinkManEvent();
                break;
            case 19:
                GetSteelDoorPasswordQuest();
                break;
            case 20:
                GetSteelDoorPasswordQuest_ManangerMove();
                break;
            case 21:
                GetCoinQuest();
                break;
            case 22:
                GetCoins();
                break;
            case 23:
                GetPart2SteelDoorPasswordQuest();
                break;
            case 24:
                GetPart2SubQuest();
                break;
            case 25:
                GoSkyTown();
                break;
            case 26:
                fruitQuestStart();
                break;
            case 27:
                CompleteFruitQuest();
                break;
            case 28:
                FullTimeFamerQuest();
                break;
            case 29:
                FullTimeFamerQuestGet();
                break;
            case 30:
                FullTimeFamerQuestComplete();
                break;
            case 31:
                AccessCardQuestGet();
                break;
            case 32:
                GetAccessCardQuest();
                break;
            case 33:
                CompleteFireQuest();
                break;
            case 34:
                StartPart4();
                break;
            case 35:
                GuardComplete();
                break;
            case 36:
                DeliveryManQeustStart();
                break;
            case 37:
                DeliveryManQeustMoveEnd();
                break;
            case 38:
                DeliveryManQeustMoveSuccess();
                break;
            case 39:
                GetFactoryManagerQeust();
                break;
            case 40:
                FactoryManagerQuest_MoveComplete();
                break;
            case 41:
                FactoryManagerQuest_Complete();
                break;
            case 42:
                DoctorEvent_Complete();
                break;
            case 43:
                CompleteManager();
                break;
            case 44:
                ComputerQuestStart();
                break;
            case 45:
                ComputerQuestComplete();
                break;
            //잠수함 탈출 퀘스트
            case 501:
                StartEscapeQuest();
                break;
            case 502:
                EscapeQuest_EndFactoryManager();
                break;
            case 503:
                EscapeQuest_EndAnchorConversation();
                break;
            case 504:
                EscapeQuestComplete();
                break;
            case 505:
                ShipGameStart();
                break;
            default:

                Debug.Log("로딩 데이터 부족!!");
                break;
        }
     
    }
    public void CheckDialogueData()
    {
        DialogueLua.SetVariable("delivery_NPC1", GameManager.Instance.styxData.delivery_NPC1);
        DialogueLua.SetVariable("delivery_varietystore", GameManager.Instance.styxData.delivery_varietystore);

        DialogueLua.SetVariable("ManagerQuestItem_Radio", GameManager.Instance.styxData.ManagerQuestItem_Radio);
        DialogueLua.SetVariable("ManagerQuestItem_Bolt", GameManager.Instance.styxData.ManagerQuestItem_Bolt);
        DialogueLua.SetVariable("ManagerQuestItem_SeeweedJuice", GameManager.Instance.styxData.ManagerQuestItem_SeeweedJuice);
     

        DialogueLua.SetVariable("PopOwnerQuest_SKyV", GameManager.Instance.styxData.PopOwnerQuest_SKyV);
        DialogueLua.SetVariable("PopOwnerQuest_SpeacialSeaweed", GameManager.Instance.styxData.PopOwnerQuest_SpeacialSeaweed);
        DialogueLua.SetVariable("PopOwnerQuest_Sugar", GameManager.Instance.styxData.PopOwnerQuest_Sugar);

        DialogueLua.SetQuestField("Oldmanchess","State", GameManager.Instance.styxData.strEnableChessQuest);
        DialogueLua.SetVariable("ChessItem", GameManager.Instance.styxData.ChessQuestIndex);

        DialogueLua.SetQuestField("warehouseManagerQuest", "State", GameManager.Instance.styxData.strManagerQuset);
        DialogueLua.SetQuestField("SpeacialSeaweedQuest", "State", GameManager.Instance.styxData.SpeacialSeaweedQuest);


        DialogueLua.SetQuestField("Copperwire", "State", GameManager.Instance.styxData.strEnableCopperwire);
        DialogueLua.SetVariable("CopperWireIndex", GameManager.Instance.styxData.CopperWireIndex);

        DialogueLua.SetQuestField("steeldoorPasswordQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);
        DialogueLua.SetVariable("steeldoorQuestCoin", GameManager.Instance.styxData.steeldoorQuestCoin);
        DialogueLua.SetVariable("steelManDrinkCount", GameManager.Instance.styxData.steelManDrinkCount);
        DialogueLua.SetVariable("steelKeeperPos", GameManager.Instance.styxData.steelKeeperPos);


        DialogueLua.SetQuestField("CoinQuest", "State", GameManager.Instance.styxData.strCoinQuest);


        DialogueLua.SetQuestField("Part2PasswordQuest", "State", GameManager.Instance.styxData.Part2PasswordQuest);

        DialogueLua.SetVariable("Letter", GameManager.Instance.data.Letter);
        DialogueLua.SetVariable("ChurchPass", GameManager.Instance.data.ChurchPass);
        DialogueLua.SetVariable("FarmPass", GameManager.Instance.data.FarmPass);

        DialogueLua.SetQuestField("part2_subQuest", "State", GameManager.Instance.styxData.part2_subQuest);

        DialogueLua.SetVariable("Lamptownbrooch", GameManager.Instance.data.Lamptownbrooch);



        DialogueLua.SetQuestField("fruitQuest", "State", GameManager.Instance.styxData.fruitQuest);
        DialogueLua.SetVariable("fruitCount", GameManager.Instance.styxData.fruitCount);

        DialogueLua.SetQuestField("fullTimeFamerQuest", "State", GameManager.Instance.styxData.fullTimeFamerQuest);

        DialogueLua.SetQuestField("AccesscardQuest", "State", GameManager.Instance.styxData.AccesscardQuest);


        DialogueLua.SetQuestField("FireQuest", "State", GameManager.Instance.styxData.FireQuest);

        DialogueLua.SetVariable("LighterCount", GameManager.Instance.styxData.LighterCount);
        DialogueLua.SetVariable("SteelLeverCount", GameManager.Instance.styxData.SteelLeverCount);
        DialogueLua.SetVariable("WarehouseKeyCount", GameManager.Instance.styxData.WarehouseKeyCount);

        DialogueLua.SetVariable("Part3_MainAccessCard", GameManager.Instance.styxData.Part3_MainAccessCard);

        DialogueLua.SetQuestField("deliveryManQuest", "State", GameManager.Instance.styxData.deliveryManQuest);
        
        DialogueLua.SetQuestField("FactoryManagerQuest", "State", GameManager.Instance.styxData.FactoryManagerQuest);

        DialogueLua.SetQuestField("FactorydoctorQuest", "State", GameManager.Instance.styxData.FactorydoctorQuest);

        DialogueLua.SetQuestField("EngineerComputerQuest", "State", GameManager.Instance.styxData.EngineerComputerQuest);

        DialogueLua.SetQuestField("StartEscapeQuest", "State", GameManager.Instance.styxData.StartEscapeQuest);
        DialogueLua.SetVariable("EscapeNumber", GameManager.Instance.styxData.EscapeNumber);

        DialogueLua.SetVariable("Drug", GameManager.Instance.data.Drug);
        DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);

        DialogueLua.SetVariable("isEnableEmergency", GameManager.Instance.styxData.isEnableEmergency);
        DialogueLua.SetVariable("SubmarinKey", GameManager.Instance.data.SubmarinKey);

    }

    [Button("선착장 시작",ButtonSizes.Medium,ButtonStyle.FoldoutButton)]    
    public void StartMarina()
    {        
        GameManager.Instance.TurnLight(false);
        RoomOldMan.SetActive(true);
        GameManager.Instance.ResetQuestData();
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        DialogueManager.ResetDatabase();
        GameManager.Instance.GameIndex = 0;
        
        UIManager.Instance.SetTempBG();
        
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.theShip,marinaPosition,0);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.port);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();

        
    }   
    [Button("배", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void startShip()
    {
        GameManager.Instance.TurnLight(false);
        RoomOldMan.SetActive(true);
        GameManager.Instance.ResetQuestData();
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        DialogueManager.ResetDatabase();
        GameManager.Instance.GameIndex = 1;
        
        UIManager.Instance.SetTempBG();
        
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.theShip,ShipPosition,0);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.ship);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();
    }
    [Button("숙소_시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void RoomStart()
    {        
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        DialogueLua.SetVariable("oldManIndex", 0);
        RoomOldMan.SetActive(true);
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 2;
        
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        UIManager.Instance.SetTempBG();
        
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.startprision, RoomPosition,1);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();
    }
    [Button("첫날 후", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void OneDay()
    {
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        DialogueLua.SetVariable("oldManIndex", 2);
        RoomOldMan.SetActive(true);
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 3;
        
        UIManager.Instance.SetTempBG();
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.FirstSleepPrision, RoomPosition, 1);
        GameManager.Instance.roomPosition = GameManager.RoomPosition.room;
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();
    }


    [Button("드론 제작 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DroneMake(bool binit =true)
    {
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        DialogueLua.SetVariable("oldManIndex", 3);
        GameManager.Instance.TurnLight(true);
        RoomOldMan.SetActive(true);
        GameManager.Instance.GameIndex = 4;
        
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        UIManager.Instance.SetTempBG();
        if (binit ==true)
        {
            
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.FirstSleepPrision, RoomPosition, 1);
            
        }
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();
    }

    [Button("해조류 작업장으로 이동", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GoTowork()
    {
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        SeaWorkManager.SetActive(true);
        RoomOldMan.SetActive(false);
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        DialogueLua.SetVariable("oldManIndex", 4);
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 5;
        
        UIManager.Instance.SetTempBG();
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.secondDayPrison, seaworkPosition, 1);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();
    }
    [Button("해조류 작업 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CompleteSeaWeed()
    {
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        RoomOldMan.SetActive(false);
        SeaWorkManager.SetActive(false);
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        DialogueLua.SetVariable("oldManIndex", 5);
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 6;
        UIManager.Instance.SetTempBG();
        
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.oneYears, seaworkPosition, 1);        
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();
    }

    [Button("파트1 메인 퀘스트 받음", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Part1MainQUest(bool bInit = true)
    {
        if (isResetQuestData)
        {
            DialogueManager.ResetDatabase();
            DialogueLua.SetVariable("leverQuestItem_1", 0);
            DialogueLua.SetVariable("leverQuestItem_2", 0);
            DialogueLua.SetVariable("leverQuestItem_3", 0);
        }
        
        GameManager.Instance.ResetQuestData();
        SeaWorkManager.SetActive(false);
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);        
        GameManager.Instance.TurnLight(true);
        RoomOldMan.SetActive(false);
        GameManager.Instance.GameIndex = 7;
        DialogueLua.SetVariable("oldManIndex", 6);
        DialogueLua.SetVariable("isBed", true);
        DialogueLua.SetVariable("isRoomDoor", true);
        DialogueLua.SetVariable("isShelf", true);
        
        
        DialogueLua.SetQuestField("part1MainQuest", "State", "active");
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {            
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.oneYears, seaworkPosition, 1);

        }
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
        GameManager.Instance.SetSeaworkAnim(false);
        GameManager.Instance.SaveData();
    }

    [Button("파트1 메인 아이템만 획득 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Part1GetItem(bool bInit = true)
    {        

        DialogueLua.SetVariable("leverQuestItem_1", 1);
        DialogueLua.SetVariable("leverQuestItem_2", 1);
        DialogueLua.SetVariable("leverQuestItem_3", 1);
        GameManager.Instance.data.spoon = 1;
        GameManager.Instance.data.stringline = 1;
        GameManager.Instance.data.Brokenparts = 1;
        GameManager.Instance.SaveData();
    }
    [Button("파트1 메인 아이템 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Part1MainQUest_GetItem(bool bInit = true)
    {
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        RoomOldMan.SetActive(false);
        SeaWorkManager.SetActive(false);
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 8;
        DialogueLua.SetVariable("oldManIndex",7);
        DialogueLua.SetVariable("isBed", false);
        DialogueLua.SetVariable("isRoomDoor", false);
        DialogueLua.SetVariable("isShelf", false);
        
        DialogueLua.SetVariable("leverQuestItem_1", 1);
        DialogueLua.SetVariable("leverQuestItem_2", 1);
        DialogueLua.SetVariable("leverQuestItem_3", 1);

        GameManager.Instance.data.spoon = 0;
        GameManager.Instance.data.stringline = 0;
        GameManager.Instance.data.Brokenparts = 0;

        DialogueLua.SetQuestField("part1MainQuest", "State", "grantable");
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {            
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.oneYears, seaworkPosition, 1);

        }
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }
    
    [Button("파트1 레버 퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Part1CompleteLeverQuest(bool bInit = true)
    {
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        RoomOldMan.SetActive(false);
        SeaWorkManager.SetActive(false);
        if(bInit)
        {
            GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        }        
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 9;
        DialogueLua.SetVariable("oldManIndex", 7);
        DialogueLua.SetVariable("isBed", false);
        DialogueLua.SetVariable("isRoomDoor", false);
        DialogueLua.SetVariable("isShelf", false);

        DialogueLua.SetVariable("leverQuestItem_1", 1);
        DialogueLua.SetVariable("leverQuestItem_2", 1);
        DialogueLua.SetVariable("leverQuestItem_3", 1);
        
        DialogueLua.SetQuestField("part1MainQuest", "State", "success");

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.startGame_part1, seaworkPosition, 1);

        }
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }

    [Button("기어가기 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void MoveToVent(bool bInit = true)
    {
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        RoomOldMan.SetActive(false);
        SeaWorkManager.SetActive(false);
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 10;
        DialogueLua.SetVariable("oldManIndex", 7);
        DialogueLua.SetVariable("isBed", false);
        DialogueLua.SetVariable("isRoomDoor", false);
        DialogueLua.SetVariable("isShelf", false);

        DialogueLua.SetVariable("leverQuestItem_1", 1);
        DialogueLua.SetVariable("leverQuestItem_2", 1);
        DialogueLua.SetVariable("leverQuestItem_3", 1);

        GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        DialogueLua.SetQuestField("part1MainQuest", "State", "success");
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.goLampTown, VentPosition, 1);
        }
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.vent);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }

    void SetPart1()
    {
        
        RoomOldMan.SetActive(false);
        SeaWorkManager.SetActive(false);
        //GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        DialogueLua.SetVariable("oldManIndex", 7);
        DialogueLua.SetVariable("isBed", false);
        DialogueLua.SetVariable("isRoomDoor", false);
        DialogueLua.SetVariable("isShelf", false);
        
        DialogueLua.SetVariable("leverQuestItem_1", 1);
        DialogueLua.SetVariable("leverQuestItem_2", 1);
        DialogueLua.SetVariable("leverQuestItem_3", 1);

        DialogueLua.SetQuestField("part1MainQuest", "State", "success");
        UIManager.Instance.SetTempBG();
    }

    [Button("파트2 -> 창고", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void WareHouse()
    {
        //GameManager.Instance.warehouseManager.SetActive(false);
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        DialogueManager.ResetDatabase();
        GameManager.Instance.ResetQuestData();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 11;  
        
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Warehouse, warehousePosition, 2);
        GameManager.Instance.warehouseManager.transform.position = warehouseManagerPosition.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }

    [Button("창고 이벤트 대화 종료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void warehouseInitConversationEnd(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        GameManager.Instance.SetPlayerCamera();
        DialogueManager.ResetDatabase();
        if (isResetQuestData)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 12;
        DialogueLua.SetVariable("warehouseManagerIndex", 1);
        UIManager.Instance.SetTempBG();
        if (bInit ==true)
        {
            
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Warehouse, warehousePosition, 2);
        }
        
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerStorePosition.position;
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }

    [Button("관리자 퀘스트 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void WarehouseManagerGetQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "active";
        }        
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 13;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);
        //DialogueLua.SetQuestField("warehouseManagerQuest", "State", "active");
        UIManager.Instance.SetTempBG();
        CheckDialogueData();
        if (bInit == true)
        {            
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.LampTown, LampTownInitPos, 2);

        }
        //GameManager.Instance.styxData.strManagerQuset = "active";
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
        
    }
    //
    // GameIndex >=13 
    //
    public void WarehouseManagerGetQuestSaver()
    {
        GameManager.Instance.GameIndex = 13;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);
        //DialogueLua.SetQuestField("warehouseManagerQuest", "State", "active");
        GameManager.Instance.styxData.strManagerQuset = "active";
        GameManager.Instance.SaveData();
        CheckDialogueData();
    }

   [Button("배달 퀘스트 받음", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void getPupQuest(bool bInit =true)
    {        
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if(isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "active";
        }
        
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 14;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);
        //DialogueLua.SetQuestField("warehouseManagerQuest", "State", "active");
        DialogueLua.SetQuestField("PupOwnerQuest", "State", "active");
        //GameManager.Instance.styxData.strManagerQuset = "active";
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.LampTown, LampTownInitPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
       
    }
    [Button("배달 완료 - NPC1", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeliveryQuestComplete_NPC1(bool bUI =false)
    {
        GameManager.Instance.styxData.delivery_NPC1 = 1;
        GameManager.Instance.SaveStyxData();
        if(bUI)
        {
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.drinkMake);
        }
        CheckDialogueData();
    }
    [Button("배달 완료 - NPC_잡화점", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeliveryQuestComplete_NPCVarietyStore(bool bUI = false)
    {
        GameManager.Instance.styxData.delivery_varietystore = 1;
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
        if(bUI)
        {
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.drinkMake);
        }
    }

    [Button("배달 퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeliveryQuestComplete(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "active";
        }
        //GameManager.Instance.styxData.strManagerQuset = "active";
        //DialogueLua.SetQuestField("warehouseManagerQuest", "State", "active");
        
        //GameManager.Instance.styxData.SpeacialSeaweedQuest = "active";
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 15;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);       
        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GetSeaweedJuice();
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.CrazyPopOwnmer, LampTownInitPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
        
    }

    [Button("고급 해조류 퀘스트 받음", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetSpeacialSeaweedQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {            
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "active";
            GameManager.Instance.styxData.PopOwnerQuest_SpeacialSeaweed =0;
            GameManager.Instance.styxData.SpeacialSeaweedQuest = "unassigned";
        }
        GetSeaweedJuice();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 16;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);
      
        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.SpeacialSeaweedQuest = "active";        
        //DialogueLua.SetQuestField("warehouseManagerQuest", "State", "active");
        //DialogueLua.SetQuestField("SpeacialSeaweedQuest", "State", "active");
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.CrazyPopOwnmer, LampTownInitPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
        
    }
    [Button("고급 해조류 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void getSpeacialSeaweed()
    {
        GameManager.Instance.styxData.strEnableChessQuest = "success";
        GameManager.Instance.styxData.PopOwnerQuest_SpeacialSeaweed = 1;
        GameManager.Instance.styxData.ChessQuestIndex = 1;
        GameManager.Instance.SaveStyxData();        
        CheckDialogueData();
        UIManager.Instance.CheckQuestGuide();
    }
    [Button("볼트 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void getBolt()
    {
        GameManager.Instance.styxData.ManagerQuestItem_Bolt = 1;
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
    }
    [Button("해조류 쥬스 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSeaweedJuice()
    {        
        GameManager.Instance.styxData.ManagerQuestItem_SeeweedJuice = 1;
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
    }
    [Button("라디오 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetRaido()
    {
        GameManager.Instance.styxData.ManagerQuestItem_Radio = 1;
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
    }
    [Button("관리자 퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetManagerQuestComplete()
    {
        GameManager.Instance.styxData.ManagerQuestItem_Radio = 1;
        GameManager.Instance.styxData.ManagerQuestItem_Bolt = 1;
        GameManager.Instance.styxData.ManagerQuestItem_SeeweedJuice = 1;
        GameManager.Instance.styxData.strManagerQuset = "success";        
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
        UIManager.Instance.CheckQuestGuide();
    }

    [Button("할아버지 체스 퀘스트 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartChessQuest()
    {        
        if (isResetQuestData == true)
        {            
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "active";
        }
        GameManager.Instance.styxData.strEnableChessQuest = "active";
        GetSeaweedJuice();        
        GameManager.Instance.styxData.SpeacialSeaweedQuest = "active";
        CheckDialogueData();
        //DialogueLua.SetQuestField("warehouseManagerQuest", "State", "active");
        GameManager.Instance.SaveStyxData();        
        UIManager.Instance.CheckQuestGuide();
    }
    [Button("체스 말 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetChess()
    {
        GameManager.Instance.styxData.ChessQuestIndex = 1;
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
    }

    [Button("구리선 퀘스트 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartCopperWire()
    {
        GameManager.Instance.styxData.strEnableCopperwire = "active";
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
        UIManager.Instance.CheckQuestGuide();
        UIManager.Instance.disableUI();
        UIManager.Instance.nPCLamptownLightGame.StartLightOff();
        GameManager.Instance.styxData.CopperWireIndex = 0;
        GameManager.Instance.SaveStyxData();
    }

    [Button("구리선 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetCopper()
    {
        GameManager.Instance.styxData.CopperWireIndex = 1;
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
    }
    [Button("구리선 퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EndCopperWire()
    {
        GameManager.Instance.styxData.strEnableCopperwire = "success";
        UIManager.Instance.flashLightUI.SetActive(false);
        GameManager.Instance.styxData.CopperWireIndex = 1;
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
        UIManager.Instance.CheckQuestGuide();
        UIManager.Instance.disableUI();
        UIManager.Instance.nPCLamptownLightGame.StartLightOn();
        //GameManager.Instance.Player.GetComponent<PlayerController>().FlashLight.SetActive(false);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetFlashLight(false);
    }


    [Button("하늘 식초 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSkyvinegar()
    {
        GameManager.Instance.styxData.PopOwnerQuest_SKyV = 1;
        DialogueManager.Pause();
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler5;
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.skyvinegar);

        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler5()
    {
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler5;
        DialogueManager.Unpause();
    }

    [Button("설탕 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSugar()
    {
        GameManager.Instance.styxData.PopOwnerQuest_Sugar = 1;
        GameManager.Instance.SaveStyxData();
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.sugar));
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.sugar);
        CheckDialogueData();
    }
    [Button("고급 해조류 퀘슽 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetEndSpeacialSeaweedQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        //GetSeaweedJuice();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 17;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.SpeacialSeaweedEnd, DringEventPlayerPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }
    [Button("술주정뱅이 이벤트 종료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EndDrinkManEvent(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 18;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.SpeacialSeaweedEnd, DringEventPlayerPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }
    [Button("강철문 퀘스트 받음(password)", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSteelDoorPasswordQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 19;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GameManager.Instance.styxData.strSteeldoorPasswordQuest = "active";
        DialogueLua.SetQuestField("steeldoorPasswardQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);
        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.SpeacialSeaweedEnd, ChapelPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Chapel);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }

    [Button("강철문 퀘스트 - 펍으로 이동", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSteelDoorPasswordQuest_ManangerMove(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 20;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GameManager.Instance.styxData.strSteeldoorPasswordQuest = "active";
        DialogueLua.SetQuestField("steeldoorPasswardQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);

        GameManager.Instance.styxData.steelKeeperPos = true;
        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.DrunkMan, DringEventPlayerPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }

    [Button("강철문 퀘스트 - 코인2개 얻기", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetCoinQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 21;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GameManager.Instance.styxData.strSteeldoorPasswordQuest = "active";
        DialogueLua.SetQuestField("steeldoorPasswardQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);

        GameManager.Instance.styxData.strCoinQuest = "active";
        DialogueLua.SetQuestField("CoinQuest", "State", GameManager.Instance.styxData.strCoinQuest);

        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.steelKeeperPos = true;

        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.DrunkMan, DringEventPlayerPos, 2);
        }
        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }
    [Button("코인2개 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]    
    public void GetCoins(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 22;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GameManager.Instance.styxData.strSteeldoorPasswordQuest = "active";
        DialogueLua.SetQuestField("steeldoorPasswardQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);

        GameManager.Instance.styxData.strCoinQuest = "success";
        DialogueLua.SetQuestField("CoinQuest", "State", GameManager.Instance.styxData.strCoinQuest);

        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.steelKeeperPos = true;

        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            if(GameManager.Instance.styxData.steelManDrinkCount ==3)
            {
                UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Coin, DringEventPlayerPos, 2);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
            }
            else
            {
                UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Coin, ChapelPos, 2);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Chapel);
            }               
                
        }
        else
        {
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Chapel);
        }
        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        
        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }
    [Button("술 제조 성공", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void MakeDrinkComplete(bool bInit =true)
    {
        GameManager.Instance.styxData.steelManDrinkCount = 3;
        GameManager.Instance.SaveStyxData();
        
        CheckDialogueData();
        if(bInit ==true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.drinkMake), 2.5f);
            DialogueManager.Pause();
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler4;
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.drinkMake);
            
        }
            
     
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler4()
    {
        DialogueManager.Unpause();
    }

    [Button("part2 강철문 비밀번호 퀘슽 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetPart2SteelDoorPasswordQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }        
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        MakeDrinkComplete(false);
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 23;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GameManager.Instance.styxData.strSteeldoorPasswordQuest = "success";
        DialogueLua.SetQuestField("steeldoorPasswardQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);

        GameManager.Instance.styxData.strCoinQuest = "success";
        DialogueLua.SetQuestField("CoinQuest", "State", GameManager.Instance.styxData.strCoinQuest);

        GameManager.Instance.styxData.Part2PasswordQuest = "active";
        DialogueLua.SetQuestField("Part2PasswordQuest", "State", GameManager.Instance.styxData.Part2PasswordQuest);

        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.steelKeeperPos = false;

        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Password, DringEventPlayerPos, 2);
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);           
           

        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
        
        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);

        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }
    [Button("part2 서브 퀘스트", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetPart2SubQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.strManagerQuset = "success";
        }
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        MakeDrinkComplete(false);
        SetPart1();
        GameManager.Instance.TurnLight(true);
        GameManager.Instance.GameIndex = 24;
        DialogueLua.SetVariable("warehouseManagerIndex", 2);

        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GameManager.Instance.styxData.strSteeldoorPasswordQuest = "success";
        DialogueLua.SetQuestField("steeldoorPasswardQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);

        GameManager.Instance.styxData.strCoinQuest = "success";
        DialogueLua.SetQuestField("CoinQuest", "State", GameManager.Instance.styxData.strCoinQuest);

        GameManager.Instance.styxData.Part2PasswordQuest = "active";
        DialogueLua.SetQuestField("Part2PasswordQuest", "State", GameManager.Instance.styxData.Part2PasswordQuest);

        GameManager.Instance.styxData.part2_subQuest = "active";
        DialogueLua.SetQuestField("part2_subQuest", "State", GameManager.Instance.styxData.part2_subQuest);

        getChurchPass(false);
        getFarmPass(false);        
        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.steelKeeperPos = false;

        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        CheckDialogueData();

        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Password, ChapelPos, 2);
            GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Chapel);

        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Chapel);

        GameManager.Instance.SetPlayerCamera();
        //GameManager.Instance.Player.transform.position = DringEventPlayerPos.position;
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);

        GameManager.Instance.SetSeaworkAnim(true);
        GameManager.Instance.SaveData();
    }
    [Button("편지 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void getLetter(bool bInit =false)
    {
        GameManager.Instance.data.Letter = 1;
        DialogueLua.SetVariable("Letter", GameManager.Instance.data.Letter);
        GameManager.Instance.SaveStyxData();
        CheckDialogueData();
        if (bInit == true)
        {
            DialogueManager.Pause();
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Letter));
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Letter);
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler3;
        }
        else
        {

        }
            
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler3()
    {
        DialogueManager.Unpause();
    }

    [Button("교인 신분증", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void getChurchPass(bool bInit = false)
    {
        GameManager.Instance.data.ChurchPass = 1;
        DialogueLua.SetVariable("ChurchPass", GameManager.Instance.data.ChurchPass);
        
        CheckDialogueData();
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.ChurchPass));
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.ChurchPass), 2.5f);
            DialogueManager.Pause();
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.ChurchPass);
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }
            
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler()
    {
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler;
        DialogueManager.Unpause();
    }

    [Button("농부 통행증", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void getFarmPass(bool bInit = false)
    {
        GameManager.Instance.data.FarmPass = 1;
        DialogueLua.SetVariable("FarmPass", GameManager.Instance.data.FarmPass);
        
        CheckDialogueData();
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.FarmPass));
            DialogueManager.Pause();
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.FarmPass);
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler1;
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }

    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler1()
    {
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler1;
        DialogueManager.Unpause();
    }

    [Button("빨간 브로치 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetRedBrooch(bool bInit = false)
    {
        GameManager.Instance.data.Lamptownbrooch = 1;
        DialogueLua.SetVariable("Lamptownbrooch", GameManager.Instance.data.Lamptownbrooch);

        CheckDialogueData();
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.LampTownBrooch));
            DialogueManager.Pause();
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.LampTownBrooch);
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler2;
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler2()
    {
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler2;
        DialogueManager.Unpause();
    }

    public void SetPart2()
    {       
        GameManager.Instance.styxData.strManagerQuset = "success";
        getSpeacialSeaweed();
        SetManagerQuestComplete();
        EndCopperWire();
        MakeDrinkComplete(false);        
                
        DialogueLua.SetVariable("warehouseManagerIndex", 2);
        DialogueLua.SetQuestField("PupOwnerQuest", "State", "success");
        GameManager.Instance.styxData.strSteeldoorPasswordQuest = "success";
        DialogueLua.SetQuestField("steeldoorPasswardQuest", "State", GameManager.Instance.styxData.strSteeldoorPasswordQuest);
        GameManager.Instance.styxData.strCoinQuest = "success";
        DialogueLua.SetQuestField("CoinQuest", "State", GameManager.Instance.styxData.strCoinQuest);
        GameManager.Instance.styxData.Part2PasswordQuest = "success";
        DialogueLua.SetQuestField("Part2PasswordQuest", "State", GameManager.Instance.styxData.Part2PasswordQuest);
        GameManager.Instance.styxData.part2_subQuest = "active";
        DialogueLua.SetQuestField("part2_subQuest", "State", GameManager.Instance.styxData.part2_subQuest);

        getChurchPass(false);
        getFarmPass(false);
        //고급 해조류 퀘스트        
        GameManager.Instance.styxData.steelKeeperPos = false;
        GameManager.Instance.styxData.SpeacialSeaweedQuest = "success";
        //CheckDialogueData();
        //UIManager.Instance.SetTempBG();            
        //GameManager.Instance.SetPlayerCamera();        
        GameManager.Instance.warehouseManager.transform.position = warehouseMangerNextPos.position;
        GameManager.Instance.warehouseManager.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.SetSeaworkAnim(true);        
    }
    [Button("스카이 타운 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GoSkyTown(bool bInit = true)
    {
        //GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();            
        }
        SetPart1();
        SetPart2();
        //for (int i = 0; i < Part3InitObjects.Count; i++)
        //{
        //    Part3InitObjects[i].SetActive(true);
        //}
        //
        //여기에 코드
        GameManager.Instance.GameIndex = 25;
        GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        ///
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.skyTown, SkyTownInitPos, 3);          
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
        GameManager.Instance.SetPlayerCamera();               
        GameManager.Instance.SaveData();
    }

    [Button("과일 수확퀘스트", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void fruitQuestStart(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
      
        //
        //여기에 코드
        GameManager.Instance.GameIndex = 26;
        GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "active";
        GameManager.Instance.styxData.fruitCount = 0;
        ///        
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.frute, FruitInitPos, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("과일 수확퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CompleteFruitQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();

        //
        //여기에 코드
        GameManager.Instance.GameIndex = 27;
        //GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        ///        
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.frute, FruitInitPos, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
        GameManager.Instance.SetPlayerCamera();        
        GameManager.Instance.SaveData();
    }

    [Button("정식 농부 퀘스트(동료 대화종료)", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void FullTimeFamerQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();

        //
        //여기에 코드
        GameManager.Instance.GameIndex = 28;
        //GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        GameManager.Instance.styxData.fullTimeFamerQuest = "grantable";
        ///        
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Domitory, DomitoryPosition, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Domitory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("정식 농부 퀘스트 받음", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void FullTimeFamerQuestGet(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();

        //
        //여기에 코드
        GameManager.Instance.GameIndex = 29;
        //GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        GameManager.Instance.styxData.fullTimeFamerQuest = "active";
        if(bInit ==false)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.watering));
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.WaterCan);
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler2;
            DialogueManager.Pause();
        }
        GameManager.Instance.data.wateringCan = 1;
        ///        
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Domitory, FruitInitPos, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("정식 농부 퀘스트 수집완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void FullTiemFarmerQuestItemGet(bool bInit = true)
    {       
        DialogueLua.SetVariable("fullTimeFamerQuestItme_1", 10);
        DialogueLua.SetVariable("fullTimeFamerQuestItme_2", 3);
        DialogueLua.SetVariable("fullTimeFamerQuestItme_3", 3);
        DialogueLua.SetVariable("fullTimeFamerQuestItme_4", 3); 
    }
    
    [Button("정식 농부 퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void FullTimeFamerQuestComplete(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();

        //
        //여기에 코드
        GameManager.Instance.GameIndex = 30;
        //GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        GameManager.Instance.data.FulltimeFamer = 1;
        GameManager.Instance.styxData.fullTimeFamerQuest = "success";     
        GameManager.Instance.data.wateringCan = 1;
        ///        
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Domitory, FruitInitPos, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }


    [Button("출입 카드퀘스트 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AccessCardQuestGet(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();

        //
        //여기에 코드
        GameManager.Instance.GameIndex = 31;
        //GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        GameManager.Instance.styxData.fullTimeFamerQuest = "success";
        GameManager.Instance.data.wateringCan = 1;
        GameManager.Instance.styxData.AccesscardQuest = "active";
        GameManager.Instance.data.Map = 1;
        ///        
     
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Domitory, DomitoryPosition, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Domitory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("수레 퀘슽 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CompleteWagonQuest(bool bInit = true)
    {
        DialogueLua.SetVariable("bCompleteOldFamer", true);        
    }

    [Button("라이터 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetLighter(bool bInit = true)
    {
        GameManager.Instance.styxData.LighterCount = 1;
        DialogueLua.SetVariable("ChurchPass", GameManager.Instance.styxData.LighterCount);

        CheckDialogueData();
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.lighter));
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.lighter);
            GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler5;
            DialogueManager.Pause();
            GameManager.Instance.SaveStyxData();
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }
    }

    [Button("창고 열쇠 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetWarehouseKey(bool bInit = true)
    {
        GameManager.Instance.styxData.WarehouseKeyCount = 1;
        DialogueLua.SetVariable("WarehouseKeyCount", GameManager.Instance.styxData.WarehouseKeyCount);

        CheckDialogueData();
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.warehouseKey));
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.warehouseKey);
            GameManager.Instance.SaveStyxData();
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }
    }
    [Button("빠루 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSteellever(bool bInit =true)
    {
        GameManager.Instance.styxData.SteelLeverCount = 1;
        DialogueLua.SetVariable("SteelLeverCount", GameManager.Instance.styxData.SteelLeverCount);

        CheckDialogueData();
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.steellever));
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.steellever);
            GameManager.Instance.SaveStyxData();
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }
    }

    [Button("출입 카드퀘스트 완료- 불 퀘스트 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetAccessCardQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();

        //
        //여기에 코드
        GameManager.Instance.GameIndex = 32;
        //GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        GameManager.Instance.styxData.fullTimeFamerQuest = "success";
        GameManager.Instance.data.wateringCan = 1;
        GameManager.Instance.styxData.AccesscardQuest = "success";
        GameManager.Instance.data.Map = 1;
        GameManager.Instance.styxData.FireQuest = "active";

        GetLighter(false);
        GetSteellever(false);
        GetWarehouseKey(false);
        ///        

        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Domitory, DomitoryPosition, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Domitory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("불 퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CompleteFireQuest(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();            
            GameManager.Instance.data.Accesscard = 0;
        }
        SetPart1();
        SetPart2();

        //
        //여기에 코드
        GameManager.Instance.GameIndex = 33;
        //GameManager.Instance.TurnLight(false);
        GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        GameManager.Instance.styxData.fullTimeFamerQuest = "success";
        GameManager.Instance.data.wateringCan = 1;
        GameManager.Instance.styxData.AccesscardQuest = "success";
        GameManager.Instance.data.Map = 1;
        GameManager.Instance.styxData.FireQuest = "success";

        GetLighter(false);
        GetSteellever(false);
        GetWarehouseKey(false);
        ///        

        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.SkytownWareHouse, SkytownWareHousePos, 3);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.SkytownWareHouse);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("출입카드 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void mainAccesscardGet(bool bInit = true)
    {
        GameManager.Instance.styxData.Part3_MainAccessCard = 1;
        GameManager.Instance.data.Accesscard = 1;
        DialogueLua.SetVariable("Part3_MainAccessCard", GameManager.Instance.styxData.Part3_MainAccessCard);
        CheckDialogueData();     
        GameManager.Instance.SaveStyxData();       
    }

    public void SetPart3()
    {
        mainAccesscardGet();
        GameManager.Instance.styxData.fruitQuest = "success";
        GameManager.Instance.styxData.fruitCount = 5;
        GameManager.Instance.styxData.fullTimeFamerQuest = "success";
        GameManager.Instance.data.wateringCan = 1;
        if(GameManager.Instance.styxData.deliveryManQuest == "grantable" || GameManager.Instance.styxData.deliveryManQuest == "success")
        {
            GameManager.Instance.data.Accesscard = 0;
        }
        else
        {
            GameManager.Instance.data.Accesscard = 1;
        }
        
        GameManager.Instance.data.FarmPass = 1;
        GameManager.Instance.data.Lamptownbrooch = 1;
        GameManager.Instance.styxData.AccesscardQuest = "success";
        GameManager.Instance.data.Map = 1;
        GameManager.Instance.styxData.FireQuest = "success";

    }

    [Button("파트4 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartPart4(bool bInit = true)
    {
        GameManager.Instance.data.SubmarinKey = 0;
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();            
        }
        SetPart1();
        SetPart2();
        SetPart3();
        GameManager.Instance.data.RingerGameSuccess = false;
        GameManager.Instance.GameIndex = 34;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, FactoryPos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("출입카드 확인", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GuardComplete(bool bInit =true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();        
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        GameManager.Instance.GameIndex = 35;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, FactoryPos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("농장으로 보내기 퀘스트시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeliveryManQeustStart(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        GameManager.Instance.styxData.deliveryManQuest = "active";
        GameManager.Instance.GameIndex = 36;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, FactoryPos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("이송 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeliveryManQeustMoveEnd(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        GameManager.Instance.data.Accesscard = 0;
        GameManager.Instance.styxData.deliveryManQuest = "grantable";
        GameManager.Instance.GameIndex = 37;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, FactoryPos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("공장 브로치 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void factorybrooch(bool bInit = false)
    {
        GameManager.Instance.data.FactoryBrooch = 1;        
        DialogueLua.SetVariable("FactoryBrooch", GameManager.Instance.data.FactoryBrooch);
        CheckDialogueData();        
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.factoryBrooch));
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.factoryBrooch);
            GameManager.Instance.SaveStyxData();
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }
    }
    [Button("이송 완료-관리자 대화끝", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeliveryManQeustMoveSuccess(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.FactoryManagerEvent_1.SetActive(true);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.GameIndex = 38;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, FactoryPos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("공장장 퀘스트 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetFactoryManagerQeust(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "active";
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 39;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.machineroom, MachinePos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();        
    }

    [Button("박스 이동 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void FactoryManagerQuest_MoveComplete(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "returnToNPC";
        GameManager.Instance.styxData.FactorydoctorQuest = "unassigned";
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 40;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.machineroom, MachinePos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("공장장 퀘스트 완료-기절 이벤트 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void FactoryManagerQuest_Complete(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";       
        GameManager.Instance.styxData.FactorydoctorQuest = "unassigned";
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 41;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.machineroom, MachinePos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("의사 이벤트 종료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DoctorEvent_Complete(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 42;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.machineroom, MachinePos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("엔지니어 브로치 획득", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetEngineerBrooch(bool bInit = true)
    {
        GameManager.Instance.data.engineerBrooch = 1;
        GameManager.Instance.data.isEscapeShip = -1;
        DialogueLua.SetVariable("engineerBrooch", GameManager.Instance.data.engineerBrooch);
        CheckDialogueData();
        if (bInit == true)
        {
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.engineerBrooch));
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.engineerBrooch);
            GameManager.Instance.SaveStyxData();
        }
        else
        {
            GameManager.Instance.SaveStyxData();
        }
    }
    [Button("엔지니어실로 이동해보자", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CompleteManager(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        GameManager.Instance.data.isEscapeShip = -1;
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 43;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.machineroom, MachinePos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("컴퓨터 퀘스트 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ComputerQuestStart(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        GameManager.Instance.data.isEscapeShip = -1;
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        GameManager.Instance.styxData.EngineerComputerQuest = "active";
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 44;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        GameManager.Instance.data.RingerGameSuccess = false;
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, EngineerRoomPos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("컴퓨터 퀘스트 완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ComputerQuestComplete(bool bInit = true)
    {
        GameManager.Instance.data.SubmarinKey = 0;
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        GameManager.Instance.styxData.EngineerComputerQuest = "success";
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 45;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        GameManager.Instance.data.RingerGameSuccess = false;
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, EngineerRoomPos, 4);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }


    [Button("==탈출 퀘스트 시작==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartEscapeQuest(bool bInit = true)
    {
        GameManager.Instance.data.isEscapeShip = 1;
        GameManager.Instance.data.SubmarinKey = 0;
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.data.RingerGameSuccess = false;
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        GameManager.Instance.styxData.EngineerComputerQuest = "success";
        GameManager.Instance.styxData.StartEscapeQuest = "active";
        GameManager.Instance.styxData.EscapeNumber = 0;
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 501;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, EngineerRoomPos, 4);
            GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().SetPosition(true);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }

    [Button("==탈출 퀘스트 공장장 대화종료 ==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuest_EndFactoryManager(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        GameManager.Instance.data.SubmarinKey = 0;
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.data.RingerGameSuccess = false;
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        GameManager.Instance.styxData.EngineerComputerQuest = "success";
        GameManager.Instance.styxData.StartEscapeQuest = "active";
        GameManager.Instance.styxData.EscapeNumber = 1;
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 502;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, EngineerRoomPos, 4);
            GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().SetPosition(false);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("==탈출 퀘스트 닻 관리인 대화종료 ==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuest_EndAnchorConversation(bool bInit = true)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();        
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.EscapeSubQuestNumber = 0;
            GameManager.Instance.data.Juice = 0;
            GameManager.Instance.data.sleepingpill = 0;
            GameManager.Instance.data.slpeepingJuice = 0;
            GameManager.Instance.data.SubmarinKey = 0;
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.data.RingerGameSuccess = false;
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        GameManager.Instance.styxData.EngineerComputerQuest = "success";
        GameManager.Instance.styxData.StartEscapeQuest = "active";
        GameManager.Instance.styxData.EscapeNumber = 2;
  
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 503;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, EngineerRoomPos, 4);
            GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().SetPosition(false);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
    }
    [Button("==탈출 퀘스트 서브퀘스트-수면제 ==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuest_StartSub1(bool bInit = true)
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 0)
        {
            if(bInit ==true)
            {
                UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.EscapeSub1);
            }
            //
            GameManager.Instance.styxData.EscapeSubQuestNumber = 1;
            GameManager.Instance.data.RingerGameSuccess = false;
            GameManager.Instance.SaveStyxData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
    }
    [Button("==탈출 퀘스트 서브퀘스트-수면제 획득 ==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuest_StartSub2(bool bInit = true)
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 1)
        {
            if(bInit ==true)
            {
                UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.EscapeSub1);
            }            
            GameManager.Instance.styxData.EscapeSubQuestNumber = 2;
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.data.sleepingpill = 1;
            GameManager.Instance.SaveData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
    }
    [Button("==탈출 퀘스트 서브퀘스트-음료수 획득 ==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuest_StartSub3(bool bInit = true)
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 2)
        {
            if (bInit == true)
            {
                UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.EscapeSub2);
            }
            GameManager.Instance.styxData.EscapeSubQuestNumber = 3;
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.data.Juice = 1;
            GameManager.Instance.SaveData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
    }
    [Button("==탈출 퀘스트 서브퀘스트- 음료 제조 성공==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuest_StartSub4(bool bInit = true)
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 3)
        {
            GameManager.Instance.data.SubmarinKey = 0;
            if (bInit == true)
            {
                //UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.sleeping);
            }
            GameManager.Instance.styxData.EscapeSubQuestNumber = 4;
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.data.sleepingpill = 0;
            GameManager.Instance.data.Juice = 0;
            GameManager.Instance.data.slpeepingJuice = 1;
            GameManager.Instance.SaveData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
    }
    [Button("==탈출 퀘스트 서브퀘스트- 잠 재우기 성공==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuest_StartSub5(bool bInit = true)
    {
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 4)
        {
            GameManager.Instance.data.SubmarinKey = 0;
            if (bInit == true)
            {
                GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.EscapeSub3);
            }
            GameManager.Instance.styxData.EscapeSubQuestNumber = 5;
            GameManager.Instance.SaveStyxData();
            GameManager.Instance.data.sleepingpill = 0;
            GameManager.Instance.data.Juice = 0;
            GameManager.Instance.data.slpeepingJuice = 0;
            GameManager.Instance.SaveData();
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
    }
    [Button("==잠수함 열쇠 획득==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSubmarinKey(bool bInit = true)
    {       
        if (bInit == true)
        {
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.submarinkey);
        }
        GameManager.Instance.styxData.EscapeSubQuestNumber = 5;
        GameManager.Instance.SaveStyxData();
        GameManager.Instance.data.SubmarinKey = 1;
        GameManager.Instance.data.sleepingpill = 0;
        GameManager.Instance.data.Juice = 0;
        GameManager.Instance.data.slpeepingJuice = 0;
        GameManager.Instance.SaveData();
        DialogueLua.SetVariable("SubmarinKey", GameManager.Instance.data.SubmarinKey);        
    }
    [Button("==비상구역 활성화 획득==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetEmergencyLever(bool bInit = true)
    {
        if (bInit == true)
        {
            GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.EmergencyLever);
        }
        GameManager.Instance.styxData.EscapeSubQuestNumber = 5;
        GameManager.Instance.styxData.isEnableEmergency = true;
        GameManager.Instance.SaveStyxData();        
        GameManager.Instance.data.sleepingpill = 0;
        GameManager.Instance.data.Juice = 0;
        GameManager.Instance.data.slpeepingJuice = 0;        
        GameManager.Instance.SaveData();
        DialogueLua.SetVariable("isEnableEmergency", GameManager.Instance.styxData.isEnableEmergency);
    }

    [Button("==탈출 퀘스트 완료==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EscapeQuestComplete(bool bInit = true)
    {
        //GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        DialogueManager.ResetDatabase();
        if (isResetQuestData == true)
        {
            GameManager.Instance.ResetQuestData();
            GameManager.Instance.styxData.isEnableEmergency = true;
            GameManager.Instance.styxData.EscapeSubQuestNumber = 5;
            GameManager.Instance.data.Juice = 0;
            GameManager.Instance.data.sleepingpill = 0;
            GameManager.Instance.data.slpeepingJuice = 0;
            GameManager.Instance.data.SubmarinKey = 1;
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
        }
        SetPart1();
        SetPart2();
        SetPart3();
        factorybrooch(false);
        GameManager.Instance.data.RingerGameSuccess = false;
        GameManager.Instance.styxData.deliveryManQuest = "success";
        GameManager.Instance.styxData.FactoryManagerQuest = "success";
        GameManager.Instance.styxData.FactorydoctorQuest = "success";
        GameManager.Instance.styxData.EngineerComputerQuest = "success";
        GameManager.Instance.styxData.StartEscapeQuest = "success";
        GameManager.Instance.styxData.EscapeNumber = 5;

        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.GameIndex = 504;
        CheckDialogueData();
        UIManager.Instance.SetTempBG();
        if (bInit == true)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.submarineroom, SubMarinePos, 4);
            GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().SetPosition(false);
        }

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.submarineroom);
        //if(isCamera)
        //GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.SaveData();
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        
    }
    [Button("==TestDrunk==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void PauseTest()
    {
        GameManager.Instance.cameraEffectController.LightEffect();
    }
    [Button("==EndingTest==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void TestEnding()
    {
        UIManager.Instance.TestEnding();
    }

    public void ShipGameStart()
    {
        SetPart1();
        SetPart2();
        SetPart3();
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.sea);
        GameManager.Instance.GameIndex = 505;
    }
}

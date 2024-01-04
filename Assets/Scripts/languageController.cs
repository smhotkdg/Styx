using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class languageController : MonoBehaviour
{
    private static languageController _instance = null;
    public static languageController Instance
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
    public enum CardType
    {
        Card1,
        Card2,
        Card3
    }

    public string GetCardText(CardType cardType)
    {
        switch(cardType)
        {
            case CardType.Card1:
                return "물속에 가라앉다.";
            case CardType.Card2:
                return "We'll meet again";

        }
        return "물속에 가라앉다.";
    }
    public enum ObjectType
    {
        bed,
        door,
        seaWeed,
        vent,
        move,
        up,
        down,
        get,
        steeldoor,
        fruit,
        wagon,
        dstWagon,
        fire
        
    }
    
    public string GetText(ObjectType type)
    {
        switch (type)
        {
            case ObjectType.bed:               
                return "확인";
            case ObjectType.seaWeed:
                return "채집";
            case ObjectType.vent:
                if(DialogueLua.GetQuestField("part1MainQuest", "State").asString == "success")
                {
                    return "이동";
                }
                return "확인";
            case ObjectType.door:
                if (DialogueLua.GetQuestField("part1MainQuest", "State").asString == "active")
                {
                    return "이동";
                }
                return "확인";
            case ObjectType.move:
                return "이동";
            case ObjectType.up:
                return "올라가기";
            case ObjectType.down:
                return "내려가기";
            case ObjectType.get:
                return "획득";
            case ObjectType.steeldoor:
                return "열기";
            case ObjectType.fruit:
                return "수확";
            case ObjectType.wagon:
                return "수레";
            case ObjectType.dstWagon:
                return "도착";
            case ObjectType.fire:
                return "투척";
        }
        return "알수 없음";
    }
    public string getTextConversation()
    {
        return "대화하기";
    }
    public string GetQuestTitle(QuestCheckerController.CheckerType checkerType)
    {
        switch(checkerType)
        {
            case QuestCheckerController.CheckerType.part0:
                return "잠수부";
            case QuestCheckerController.CheckerType.OldMan:
                return "할아버지의 요청";
            case QuestCheckerController.CheckerType.LampTownManager:
                return "관리자의 요구";
            case QuestCheckerController.CheckerType.PopOwner:
                return "배달의 민족";
            case QuestCheckerController.CheckerType.PopOwnerMain:
                return "펍 주인의 요구";
            case QuestCheckerController.CheckerType.OldManchess:
                return "할아버지와 체스";
            case QuestCheckerController.CheckerType.Copper:
                return "뜻밖의 정전";
            case QuestCheckerController.CheckerType.steeldoorpassword:
                return "비밀번호";
            case QuestCheckerController.CheckerType.Coin:
                return "술값...";
            case QuestCheckerController.CheckerType.steeldoorpassword_Info:
                return "강철문 비밀번호";
            case QuestCheckerController.CheckerType.fruit:
                return "수확의 정석";
            case QuestCheckerController.CheckerType.fulltime:
                return "정식농부 시험";
            case QuestCheckerController.CheckerType.accesscard:
                return "출입 카드";
            case QuestCheckerController.CheckerType.seaweed:
                return "해조류 채집";
            case QuestCheckerController.CheckerType.fire:
                return "위험한 선택";
            case QuestCheckerController.CheckerType.part3_MainAccessCard:
                return "마지막 열쇠";
            case QuestCheckerController.CheckerType.deliveryMan:
                return "이 사람을 농장으로";
            case QuestCheckerController.CheckerType.factoryManager:
                return "제어의 시작";
            case QuestCheckerController.CheckerType.factoryDoctor:
                return "뜻밖의 고통";
            case QuestCheckerController.CheckerType.engineerComputer:
                return "컴퓨터 수리공";
            case QuestCheckerController.CheckerType.AnchorConversation:
                return "출항 계획";
            case QuestCheckerController.CheckerType.factoryManager_Escape:
                return "탈출의 시작";
            case QuestCheckerController.CheckerType.EmergencyQuest:
                return "잠수정 열쇠 획득";
            case QuestCheckerController.CheckerType.OldFamer:
                return "라이터를 켜라";

        }
        return "";
    }
    public string GetEndingTitle()
    {
        return "";
    }
    public string sePosition(GameManager.RoomPosition positionStatus)
    {
        switch(positionStatus)
        {
            case GameManager.RoomPosition.underWater:
                return "바닷속";
            case GameManager.RoomPosition.port:
                return "선착장";
            case GameManager.RoomPosition.room:
                return "숙소";
            case GameManager.RoomPosition.ship:
                return "배";
            case GameManager.RoomPosition.seawork:
                return "해조류 작업장";
            case GameManager.RoomPosition.vent:
                return "환풍구";
            case GameManager.RoomPosition.wareHouse:
                return "램프타운 창고";
            case GameManager.RoomPosition.lampTown:
                return "램프 타운";
            case GameManager.RoomPosition.steeldoor:
                return "강철문";
            case GameManager.RoomPosition.hardwareStore:
                return "철물점";
            case GameManager.RoomPosition.Chapel:
                return "예배당";
            case GameManager.RoomPosition.skytown:
                return "스카이 타운";
            case GameManager.RoomPosition.Domitory:
                return "숙소";
            case GameManager.RoomPosition.Storage:
                return "농기구 보관실";
            case GameManager.RoomPosition.FarmRoom:
                return "농부 관리실";
            case GameManager.RoomPosition.orchard:
                return "과수원";
            case GameManager.RoomPosition.Farm:
                return "밭";
            case GameManager.RoomPosition.SkytownWareHouse:
                return "창고";
            case GameManager.RoomPosition.FarmManagerRoom:
                return "관리자 방";

            case GameManager.RoomPosition.factory:
                return "공장";
            case GameManager.RoomPosition.pharmacy:
                return "병원";
            case GameManager.RoomPosition.machineroom:
                return "기계실";
            case GameManager.RoomPosition.factorymanagerroom:
                return "공장장방";
            case GameManager.RoomPosition.restroom:
                return "휴게실";
            case GameManager.RoomPosition.mainfactoryroom:
                return "메인 기계실";
            case GameManager.RoomPosition.powerroom:
                return "발전실";
            case GameManager.RoomPosition.anchoroom:
                return "닻 관리실";
            case GameManager.RoomPosition.submarineroom:
                return "잠수함실";
            case GameManager.RoomPosition.sea:
                return "심해";
            case GameManager.RoomPosition.emergencyarea:
                return "비상구역";
        }
        return "알수없는 곳";
    }
    public enum SceneTextType
    {
        underWater,
        theShip,
        startprision,
        FirstSleepPrision,
        secondDayPrison,
        oneYears,
        startGame_part1,
        Warehouse,
        goLampTown,
        random,
        LampTown,
        HardwareStor,
        steelDoor,
        CrazyPopOwnmer,
        SpeacialSeaweedEnd,
        ChapelPos,
        DrunkMan,
        Coin,
        Password,
        skyTown,
        Domitory,
        Storage,
        FarmRoom,
        //과수원
        orchard,
        Farm,
        SkytownWareHouse,
        FarmManagerRoom,
        frute,
        shipEvent,

        factory,
        //병원
        pharmacy,
        machineroom,
        factorymanagerroom,
        restroom,
        mainfactoryroom,
        powerroom,
        anchoroom,
        emergencyarea,
        submarineroom,
        sea,
        doctor,
        submarinEnding
    }
    public enum ObjectName
    {
        codeGame,
        part0,
        StaffOnly,
        harvestObject,
        needWaterCan,
        Pens,
        lever,
        Spoon,
        stringLine,
        Brokenparts,
        Error,
        Radio,
        bolt,
        seaweedjuice,
        speacialseaweed,
        sugar,
        skyvinegar,
        delivery_1,
        delivery_2,
        non,
        Chess,
        juiceError,
        NotSuccess,
        Copper,
        steeldoorPassword,
        Coin,
        drinkMake,
        part2Password,
        Letter,
        ChurchPass,
        FarmPass,
        LampTownBrooch,
        fruit,
        fruit_10,
        //씨뿌리기
        sowing,
        //물주기
        watering,
        //수확하기
        harvest,
        fullTimeFamer,
        warehouseKey,
        steellever,
        lighter,
        dstWagon,
        map,
        CCTV,
        seaweed,
        drone,
        quest,
        accesscard,
        fire,
        deliveryMan,
        factoryBrooch,
        factorymanager,
        factoryDoctor,
        engineerBrooch,
        engineerComputer,
        factoryManager_Escape,
        AnchorConversation,
        EmergencyQuest,
        pacemaker,
        EscapeSub1,
        EscapeSub2,
        EscapeSub3,
        SleepingJuice,
        EmergencyLever,
        submarinkey,        
        WaterCan,
        OldFamer,
        box

    }
    public string GetSeedresult(ObjectName objectName)
    {
        switch(objectName)
        {
            case ObjectName.sowing:
                return "씨뿌리기 완료!";
            case ObjectName.watering:
                return "물 주기 완료!";
            case ObjectName.harvest:
                return "수확 완료!";
        }
        return "완료!";

    }
    public string GetItme(ObjectName objectName)
    {
        switch (objectName)
        {        
            case ObjectName.part0:
                return "배 수리";
            case ObjectName.OldFamer:
                return "수레 배달";
            case ObjectName.Spoon:
                return "숟가락";
            case ObjectName.stringLine:
                return "노끈";
            case ObjectName.Brokenparts:
                return "고장난 부품";
            case ObjectName.Error:
                return "오류!";
            case ObjectName.Radio:
                return "라디오";
            case ObjectName.bolt:
                return "볼트";
            case ObjectName.seaweedjuice:
                return "해조류 쥬스";
            case ObjectName.speacialseaweed:
                return "고급 해조류";
            case ObjectName.sugar:
                return "설탕";
            case ObjectName.skyvinegar:
                return "하늘 식초";
            case ObjectName.non:
                return "";
            case ObjectName.delivery_1:
                return "하늘 구경";
            case ObjectName.delivery_2:
                return "장사꾼";
            case ObjectName.Chess:
                return "체스 말";
            case ObjectName.Copper:
                return "구리 선";
            case ObjectName.steeldoorPassword:
                return "강철문 비밀번호";
            case ObjectName.Coin:
                return "코인";
            case ObjectName.fruit:
                return "과일 ("+GameManager.Instance.styxData.fruitCount +" / 5개)";
            case ObjectName.fruit_10:
                return "과일 ("+DialogueLua.GetVariable("fullTimeFamerQuestItme_1").asInt+" / 10개)";
            case ObjectName.sowing:
                return "씨뿌리기 ("+ DialogueLua.GetVariable("fullTimeFamerQuestItme_2").asInt + " / 3번)";
            case ObjectName.watering:
                return "물 주기 (" + DialogueLua.GetVariable("fullTimeFamerQuestItme_3").asInt + " / 3번)";
            case ObjectName.harvest:
                return "수확하기 (" + DialogueLua.GetVariable("fullTimeFamerQuestItme_4").asInt + " / 3번)";
            case ObjectName.lighter:
                return "라이터";
            case ObjectName.warehouseKey:
                return "창고 열쇠";
            case ObjectName.steellever:
                return "쇠지렛대";
            case ObjectName.seaweed:
                return "해조류 채집 (" + DialogueLua.GetVariable("seaweedCount").asInt + " / 5)";
            case ObjectName.fire:
                return "불 지르기";
            case ObjectName.accesscard:
                return "출입카드";
            case ObjectName.deliveryMan:
                return "이송";
            case ObjectName.factorymanager:
                return "물건 20개 옮기기";
            case ObjectName.factoryDoctor:
                return "의사 모셔오기";
            case ObjectName.engineerComputer:
                return "해킹";
            case ObjectName.factoryManager_Escape:
                return "공장장과 대화";
            case ObjectName.AnchorConversation:
                return "닻 관리인과 대화";
            case ObjectName.EmergencyQuest:
                return "잠수함 열쇠";
            case ObjectName.EmergencyLever:
                return "비상구역 활성화";
            case ObjectName.EscapeSub1:
                return "수면제 획득";
            case ObjectName.EscapeSub2:
                return "음료수 획득";
            case ObjectName.EscapeSub3:
                return "관리자 재우기";
            case ObjectName.submarinkey:
                return "잠수함 열쇠 획득!";


        }
        return "획득!";
    }

    public string setAlert(ObjectName objectName)
    {
        switch(objectName)
        {
            case ObjectName.EmergencyLever:
                return "비상구역 활성화 완료 !";
            case ObjectName.engineerComputer:
                return "컴퓨터 수리 완료 !";
            case ObjectName.part0:
                return "배 수리 완료 !";
            case ObjectName.StaffOnly:
                return "관계자외 출입금지";
            case ObjectName.dstWagon:
                return "수레 배달완료 !";
            case ObjectName.needWaterCan:
                return "물뿌리개가 필요합니다.";
            case ObjectName.Pens:
                return "레버 작동 완료 !";
            case ObjectName.lever:
                return "레버 수리 완료 !";
            case ObjectName.quest:
                return "퀘스트 획득!";
            case ObjectName.drone:
                return "제작 완료!";
            case ObjectName.Spoon:
                
                return "숟가락 획득!";
            case ObjectName.stringLine:
                return "노끈 획득!";
            case ObjectName.Brokenparts:
                return "고장난 부품 획득!";
            case ObjectName.Error:
                return "오류!";
            case ObjectName.seaweedjuice:
                return "해조류 쥬스 획득!";
            case ObjectName.Radio:
                return "라디오 획득!";
            case ObjectName.Chess:
                return "체스 말 획득!";
            case ObjectName.bolt:
                return "볼트 획득!";
            case ObjectName.juiceError:
                return "실패 !";
            case ObjectName.speacialseaweed:
                return "고급 해조류 획득!";
            case ObjectName.NotSuccess:
                return "아직 이용할 수 없어.";
            case ObjectName.Copper:
                return "구리선 획득!";
            case ObjectName.sugar:
                return "설탕 획득!";
            case ObjectName.Coin:
                return "2코인 획득!";
            case ObjectName.drinkMake:
                return "제조 성공!";
            case ObjectName.Letter:
                return "편지 획득";
            case ObjectName.ChurchPass:
                return "교인 신분증 획득!";
            case ObjectName.FarmPass:
                return "농부 통행증 획득!";
            case ObjectName.LampTownBrooch:
                return "빨간 브로치 획득!";
            case ObjectName.fruit:
                return "과일 획득!";
            case ObjectName.WaterCan:
                return "물뿌리개 획득!";
            case ObjectName.fullTimeFamer:
                return "정식농부 자격 획득!";
            case ObjectName.lighter:
                return "라이터 획득!";
            case ObjectName.steellever:
                return "쇠지렛대 획득!";
            case ObjectName.warehouseKey:
                return "창고 열쇠 획득!";        
            case ObjectName.map:
                return "지도 획득!";
            case ObjectName.CCTV:
                return "감시 중...";
            case ObjectName.accesscard:
                return "출입카드 획득!";
            case ObjectName.factoryBrooch:
                return "공장 브로치 획득!";
            case ObjectName.factorymanager:
                return "퀘스트 획득!";
            case ObjectName.engineerBrooch:
                return "엔지니어 브로치 획득!";
            case ObjectName.pacemaker:
                return "심박동기 고장 완료!";
            case ObjectName.EscapeSub1:
                return "수면제 획득!";
            case ObjectName.EscapeSub2:
                return "음료수 획득!";
            case ObjectName.SleepingJuice:
                return "음료수 제조 성공!";
            case ObjectName.EscapeSub3:
                return "잠재우기 완료!";
            case ObjectName.submarinkey:
                return "잠수함 열쇠 획득!";
            case ObjectName.skyvinegar:
                return "하늘식초 획득!";
            case ObjectName.sowing:
                return "씨 뿌리기 완료!";
            case ObjectName.watering:
                return "물 주기 완료!";
            case ObjectName.harvestObject:
                return "수확 완료!";
            case ObjectName.box:
                return "박스 옮기기 완료!";

        }
        return "획득!";
    }
    public string GetQuestChekcerInfoText(QuestCheckerController.CheckerType checkerType)
    {
        switch(checkerType)
        {
            case QuestCheckerController.CheckerType.part0:
                return "갑자기 무슨 일이지??";
            case QuestCheckerController.CheckerType.LampTownManager:
                return "관리자의 부탁을 들어준다면 나에게 도움이 될까?";
            case QuestCheckerController.CheckerType.OldMan:
                return "레버를 고치면 램프타운으로 갈 수 있을까?";
            case QuestCheckerController.CheckerType.PopOwner:
                return "배달이라고?? 이게뭐지....";
            case QuestCheckerController.CheckerType.PopOwnerMain:
                return "보통 x끼가 아님은 분명하다...";
            case QuestCheckerController.CheckerType.OldManchess:
                return "체스 말이 왜 필요할까???";
            case QuestCheckerController.CheckerType.Copper:
                return "어둠으로 모든 것을 가릴 수는 없다.";
            case QuestCheckerController.CheckerType.steeldoorpassword:
                return "교주는 어떤 사람이지? 하늘도시는 도대체 뭐지?";
            case QuestCheckerController.CheckerType.Coin:
                return "월급도 안주면서 돈도 구해오라니...";
            case QuestCheckerController.CheckerType.steeldoorpassword_Info:
                return "거꾸로 말한다고?? 무슨말이지?";
            case QuestCheckerController.CheckerType.fruit:
                return "사과는 맛있어 맛있으면 바나나?";
            case QuestCheckerController.CheckerType.fulltime:
                return "농부가 되는 것도 나쁘지 않을지도?";
            case QuestCheckerController.CheckerType.accesscard:
                return "불을 지르는 것이 최선의 선택일까?";
            case QuestCheckerController.CheckerType.seaweed:
                return "5개만 채집하면 된다 이거지...";
            case QuestCheckerController.CheckerType.fire:
                return "어쩔 수 없지 일단 저질러 보자.";
            case QuestCheckerController.CheckerType.part3_MainAccessCard:
                return "출입카드만 구하면 위로 올라갈 수 있어!";
            case QuestCheckerController.CheckerType.deliveryMan:
                return "이 사람은 또 누굴까?";
            case QuestCheckerController.CheckerType.factoryManager:
                return "물건이 내려오는 타이밍이 중요하겠어....";
            case QuestCheckerController.CheckerType.factoryDoctor:
                return "공장 입구에 병원이 있었던거 같아..";
            case QuestCheckerController.CheckerType.engineerComputer:
                return "내가 컴퓨터를 만질 수 있을까?";
            case QuestCheckerController.CheckerType.factoryManager_Escape:
                return "탈출의 시작.... 일이 잘 마무리 되길";
            case QuestCheckerController.CheckerType.AnchorConversation:
                return "어디로든 우선 빠져나가보자...";
            case QuestCheckerController.CheckerType.EmergencyQuest:
                return "비상구역을 활성화 하고, 열쇠도 찾아야 한다...";
            case QuestCheckerController.CheckerType.OldFamer:
                return "과수원에서부터 밭까지";
        }
        return "";
    }
    public string GetSecenChangeText(SceneTextType sceneText)
    {        
        switch(sceneText)
        {
            case SceneTextType.underWater:
                return "바닷속으로...";
            case SceneTextType.shipEvent:
                return "사고";
            case SceneTextType.theShip:
                return "멀고 먼 여행";                
            case SceneTextType.startprision:
                return "별과 해가 만나는 시간";
            case SceneTextType.FirstSleepPrision:
                return "첫 번째 아침";
            case SceneTextType.secondDayPrison:
                return "두 번째 아침";
            case SceneTextType.oneYears:
                return "몇 달 후";
            case SceneTextType.startGame_part1:
                return "여정의 시작";
            case SceneTextType.Warehouse:
                return "램프타운 창고";
            case SceneTextType.goLampTown:
                return "램프타운으로";
            case SceneTextType.random:
                return "시간이 지나고";
            case SceneTextType.LampTown:
                return "[램프 타운]";
            case SceneTextType.HardwareStor:
                return "철물점";
            case SceneTextType.steelDoor:
                return "강철문으로";
            case SceneTextType.CrazyPopOwnmer:
                return "일로만난사이";
            case SceneTextType.SpeacialSeaweedEnd:
                return "적응과 진화";
            case SceneTextType.ChapelPos:
                return "종교적 정치와 정치적 종교";
            case SceneTextType.DrunkMan:
                return "술은 행복한 자에게만 달콤하다.";
            case SceneTextType.Coin:
                return "빚을 지는 것은 노예가 되는 것이다.";
            case SceneTextType.Password:
                return "강 철 문";
            case SceneTextType.skyTown:
                return "[스카이 타운]";      
            case SceneTextType.Domitory:
                return "모든 위기에서 기회를 본다.";
            case SceneTextType.Storage:
                return "비록 농기구가 있어도 때를 기다림만 같지 못하다.";
            case SceneTextType.FarmRoom:
                return "주어진 일을 바르게";
            case SceneTextType.orchard:
                return "인내는 일을 받쳐주는 자본이다.";
            case SceneTextType.Farm:
                return "손은 갈수록 좋고 비는 올수록 좋다.";
            case SceneTextType.SkytownWareHouse:
                return "서두르지 않고, 그러나 쉬지도 않고.";
            case SceneTextType.FarmManagerRoom:
                return "올바른 일";
            case SceneTextType.frute:
                return "의시적, 그리고 무의식적 선택";

            case SceneTextType.factory:
                return "첫 마음 그대로";
            case SceneTextType.pharmacy:
                return "버티는 게 이기는 것이다.";
            case SceneTextType.machineroom:
                return "강하고 담대하라";
            case SceneTextType.factorymanagerroom:
                return "별을 노래하는 마음";
            case SceneTextType.restroom:
                return "마음의 휴식";
            case SceneTextType.mainfactoryroom:
                return "판을 뒤집는 시대";
            case SceneTextType.powerroom:
                return "공존을 대체할 유일한 것은 공멸이다.";
            case SceneTextType.anchoroom:
                return "조금씩 나아가다";
            case SceneTextType.emergencyarea:
                return "불러드리는 방법";
            case SceneTextType.submarineroom:
                return "마음속 사랑을 바람에 실어 당신에게";         
            case SceneTextType.sea:
                return "[별이 빛나는 밤]";
            case SceneTextType.doctor:
                return "사랑은 사람을 치료한다.";
            case SceneTextType.submarinEnding:
                return "시간이 흐르고...";
        }
        return "별과 해가 만나는 시간";
    }
    public string GetInventoryItemName(InventoryController.ItemType itemType)
    {
        switch (itemType)
        {
            case InventoryController.ItemType.fulltimeFamer:
                return "정식농부 자격증";
            case InventoryController.ItemType.Spoon:
                return "숟가락";
            case InventoryController.ItemType.stringLine:
                return "노끈";
            case InventoryController.ItemType.Brokenparts:
                return "고장난 부품";
            case InventoryController.ItemType.Letter:
                return "편지";
            case InventoryController.ItemType.ChurchPass:
                return "교인 신분증";
            case InventoryController.ItemType.FarmPass:
                return "농부 신분증";
            case InventoryController.ItemType.Lamptownbrooch:
                return "빨강 브로치";
            case InventoryController.ItemType.wateringCan:
                return "물뿌리개";
            case InventoryController.ItemType.Map:
                return "지도";
            case InventoryController.ItemType.Accesscard:
                return "출입 카드";
            case InventoryController.ItemType.factorybrooch:
                return "공장 브로치";
            case InventoryController.ItemType.engineerBrooch:
                return "엔지니어 브로치";
            case InventoryController.ItemType.Juice:
                return "쥬스";
            case InventoryController.ItemType.sleepingpill:
                return "수면제";
            case InventoryController.ItemType.SubmarinKey:
                return "잠수함 열쇠";
            case InventoryController.ItemType.slpeepingJuice:
                return "수면제 음료수";
        }
        return "없음";
    }
    public string GetInventoryItemInfo(InventoryController.ItemType itemType)
    {
        switch (itemType)
        {
            case InventoryController.ItemType.fulltimeFamer:
                return "정식 농부만이 가질 수 있는 자격증.";
            case InventoryController.ItemType.Spoon:
                return "숟가락으로 무엇을 할 수 있지?";
            case InventoryController.ItemType.stringLine:
                return "노인의 부탁";
            case InventoryController.ItemType.Brokenparts:
                return "무언가 고칠 수 있을 것 같아";
            case InventoryController.ItemType.Letter:
                return "펍주인이 아들에게 주는 편지";
            case InventoryController.ItemType.ChurchPass:
                return "교인임을 증명하는 증명서";
            case InventoryController.ItemType.FarmPass:
                return "농장에서 없으면 안되는 신분증";
            case InventoryController.ItemType.Lamptownbrooch:
                return "빨간색 브로치, 무슨 용도로 사용되는지는 알 수 없다.";
            case InventoryController.ItemType.wateringCan:
                return "농작물을 키우기 위한 물뿌리개";
            case InventoryController.ItemType.Accesscard:
                return "강철문 출입카드";
            case InventoryController.ItemType.factorybrooch:
                return "공장 출입 브로치";
            case InventoryController.ItemType.engineerBrooch:
                return "엔지니어실 출입 브로치";
            case InventoryController.ItemType.slpeepingJuice:
                return "수면제를 탄 음료수";
            case InventoryController.ItemType.Juice:
                return "일반 음료수";
            case InventoryController.ItemType.sleepingpill:
                return "수면제를 어디에 섞으면 유용할듯하다";
            case InventoryController.ItemType.SubmarinKey:
                return "잠수함 열쇠";
        }
        return "없음";
    }
    public string GetOutLoudFammer()
    {
        int rand = Random.Range(0, 5);
        switch(rand)
        {
            case 0:
                return "너무 힘들어!";
            case 1:
                return "빨리 정식농부가...";
            case 2:
                return "언제 돈을 벌지";
            case 3:
                return "오늘 TV봤어?";
            case 4:
                return "커피한잔 먹고하자";
        }
        return "휴.....";
    }
 
    public string GetGunEventConversation(int index)
    {
        switch (index)
        {
            case 0:
                return "얌전히 잡혀가면\n목숨은 살려주지";                            
            case 1:
                return "니넨 누구냐!\n어떻게 선";     
            case 2:
                return "살고 싶은 생각이\n없는 노인네구만";
        }
        return "휴.....";
    }

    public string GetFireEvent(int index)
    {
        switch (index)
        {
            case 0:
                return "무슨 일이야";                
            case 1:
                return "불이야!!";                
            case 2:
                return "창고에 불이!";
            case 3:
                return "어서가자";
        }
        return "휴.....";
    }
    public string GetFireEventRandom()
    {
        int rand = Random.Range(0, 5);
        switch(rand)
        {
            case 0:
                return "후.......";
            case 1:
                return "어떻게 된거지?";
            case 2:
                return "불이나다니";
            case 3:
                return "안에 누가 있나?";
            case 4:
                return "큰일이네";
        }
        return "휴....";
    }
    public string GetNewPostionText(int index)
    {
        switch (index)
        {
            case 0:
                return "[ 선착장 ] 에서 여정을 시작 합니다.";
            case 1:
                return "[ 강제 노역소 ] 에서 여정을 시작 합니다.";
            case 2:
                return "[ 램프타운 ] 에서 여정을 시작 합니다.";
            case 3:
                return "[ 스카이 타운 ] 에서 여정을 시작 합니다.";
            case 4:
                return "[ 공장 ] 에서 여정을 시작 합니다.";
        }
        return "선택이 필요 합니다.";
    }
}

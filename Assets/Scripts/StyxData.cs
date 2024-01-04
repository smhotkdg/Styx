using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class StyxData 
{    
    //관리인 퀘스트
    [Header("관리인 퀘스트")]
    public int ManagerQuestItem_Radio;
    public int ManagerQuestItem_Bolt;    
    public int ManagerQuestItem_SeeweedJuice;
    public string strManagerQuset = "unassigned";
    public float questTime = 1200;
    //펍주인 배달 퀘스트
    [Header("펍주인 배달퀘스트")]
    public int delivery_NPC1;
    public int delivery_varietystore;

    //펍주인 퀘스트
    [Header("펍주인 메인 퀘스트")]
    public int PopOwnerQuest_Sugar;
    public int PopOwnerQuest_SKyV;    
    public int PopOwnerQuest_SpeacialSeaweed;
    public string SpeacialSeaweedQuest = "unassigned";

    [Header("할아버지 체스 퀘스트")]
    public string strEnableChessQuest = "unassigned";
    public int ChessQuestIndex;

    [Header("구리선 퀘스트")]
    public string strEnableCopperwire = "unassigned";
    public int CopperWireIndex;

    [Header("강철문 비밀번호 퀘스트")]
    public string strSteeldoorPasswordQuest = "unassigned";
    public int steeldoorQuestCoin;
    public int steelManDrinkCount;
    public bool steelKeeperPos = false;

    [Header("코인 퀘스트")]
    public string strCoinQuest = "unassigned";

    [Header("메인파트 2 비밀번호 퀘스트")]
    public string Part2PasswordQuest = "unassigned";

    [Header("파트 2 서브 퀘스트")]
    public string part2_subQuest = "unassigned";


    [Header("과일 수확 퀘스트")]
    public string fruitQuest = "unassigned";
    public int fruitCount;

    [Header("정식 농부 퀘스트")]

    public string fullTimeFamerQuest = "unassigned";

    [Header("출입카드 퀘스트")]
    public string AccesscardQuest = "unassigned";
    public int LighterCount;
    public int SteelLeverCount;
    public int WarehouseKeyCount;

    [Header("불 퀘스트")]
    public string FireQuest = "unassigned";

    [Header("파트3 메인 출입카드")]
    public int Part3_MainAccessCard;


    [Header("농장으로 사람 이동 퀘스트")]
    public string deliveryManQuest = "unassigned";

    [Header("공장장 매니저 퀘스트")]
    public string FactoryManagerQuest = "unassigned";

    [Header("공장 의사 퀘스트")]
    public string FactorydoctorQuest = "unassigned";

    [Header("컴퓨터 퀘스트")]
    public string EngineerComputerQuest = "unassigned";

    //엔딩1 탈출 퀘스트
    [Header("잠수함 탈출 퀘스트")]
    public string StartEscapeQuest = "unassigned";
    public int EscapeNumber = 0;
    public int EscapeSubQuestNumber = 0;
    public bool isEnableEmergency = false;
}

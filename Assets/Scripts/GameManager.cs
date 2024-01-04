using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using DG.Tweening;
using Sirenix.OdinInspector;
public class GameManager : MonoBehaviour
{

    
    //이건 GameManager로 이동
    public enum EndingType
    {
        EscapeFail, // 0 1 2 3 4 5, 7
        EscapeSuccess, // 0 1 2 3 4 5,6
        revolutionary_army_Kill, //0,1,2,3,4,8,9,11
        revolutionary_army, //0,1,2,3,4,8,9,10
        headmaster_kill,//0,1,2,3,4,8,13,15
        headmaster,//0,1,2,3,4,8,13,14
        hidden, //0,1,2,3,4,8,910,12
        non

    };

    public EndingType endingType = EndingType.non;
    
    public enum GameStatus
    {
        NOTING,
        DO_FORCE,
        DO_SOMETHING,
        DO_QUEST,
        CONVERSATION
    }
    public enum RoomPosition
    {
        underWater,
        port,
        ship,
        room,
        seawork,
        wareHouse,
        vent,
        lampTown,
        steeldoor,
        hardwareStore,
        Chapel,
        skytown,
        Domitory,
        Storage,
        FarmRoom,
        //과수원
        orchard,
        Farm,
        SkytownWareHouse,
        FarmManagerRoom,


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

    }
    [System.Serializable]
    public class Data
    {
        public int memoryCard_1;
        public int memoryCard_2;
        public int memoryCard_3;
        public int memoryCard_4;
        public int memoryCard_6;
        public int memoryCard_7;
        public int memoryCard_8;
        public int memoryCard_9;
        public int memoryCard_10;
        public int memoryCard_11;


        public int EndingCard_1;
        public int EndingCard_2;
        public int EndingCard_3;
        public int EndingCard_4;
        public int EndingCard_5;
        public int EndingCard_6;
        public int EndingCard_7;
        public int EndingCard_8;
        public int EndingCard_9;

        public int spoon;
        public int stringline;
        public int Brokenparts;
        public int Letter;
        public int ChurchPass;
        public int FarmPass;
        public int Lamptownbrooch;
        public int wateringCan;
        public int Map;
        public int Accesscard;
        public int FactoryBrooch;
        public int engineerBrooch;

        public int sleepingpill;
        public int Juice;
        public int slpeepingJuice;
        public int SubmarinKey;
        public int FulltimeFamer;
        public List<int> EndingList = new List<int>();

        public int Drug;

        public bool BGM = true;
        public bool FX = true;
        public int language = 1;

        //잠수함 탈출 플레그
        public int isEscapeShip = -1;

        public bool RingerGameSuccess = false;
    }
    public ChangeSceneNpc part0NPC;

    [Header("베터버전")]
    public bool isBeta = true;

    [Header("Part0Event")]
    public bool isPart0Event = false;

    //잠수함 탈출 할지말지
    public void SetEscapeShip(int flag)
    {
        //1탈출
        //2 탈출안함
        data.isEscapeShip = flag;
        SaveData();
    }

    public void GetWarehouseManagerEvent()
    {
        Debug.Log("관리자 이벤트 UI 시작");
        UIManager.Instance.CheckQuestGuide();
        TestCodeManager.Instance.WarehouseManagerGetQuestSaver();
    }
    public void GetPupOwnerQuest()
    {
        Debug.Log("펍주인 UI 시작");
        UIManager.Instance.CheckQuestGuide();        
    }
    public void GetSeaweedJuice()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.seaweedjuice));
        DialogueManager.Pause();
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.seaweedjuice);
        Debug.Log("해조류 주스 획득");
        TestCodeManager.Instance.GetSeaweedJuice();        
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler()
    {
        DialogueManager.Unpause();
    }

    public void ShowGetBoltText()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.bolt));
        DialogueManager.Pause();
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.bolt);
    }
    public void ShowGetSpeacialSeaWeed()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.speacialseaweed));
        DialogueManager.Pause();
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.speacialseaweed);
    }
    public GameObject ShipGame;
    public CameraEffectController cameraEffectController;
    public GameObject ChapelMaster;
    public StyxData styxData;
    public Data data;
    [Header("========")]
    public GameObject warehouseManager;
    public GameObject FactoryManagerEvent_1;
    public GameObject FactoryQuest;
    public GameObject FactoryManager;
    public GameObject FactorySickPerson;
    public GameObject FactoryDoctor;
    public GameObject FactoryManagerEvent_2;
    public GameObject FarmFriend;
    
    public RoomPosition roomPosition = RoomPosition.port;
    //맵 정보
    public int PartType;
    public List<GameObject> PartList;
    //게임 진행 상황
    public int GameIndex;
    public GameObject LightGame;
    public GameObject RuningGame; 
    public CollectingEffectController SeaWeedEffectController;
    public CollectingEffectController FruiteEffectController;
    public CollectingEffectController seedEffectController;
    public Cinemachine.CinemachineVirtualCamera cinemachineCamera;
    public Cinemachine.CinemachineVirtualCamera cinemachineCamera_top;

    //LeverEvent
    public GameObject CameraPos1;
    public GameObject CameraPos2;
    //해조류 작업장 매니저
    public GameObject WorkerManager;
    public GameObject Player;
    public GameStatus gameStatus = GameStatus.NOTING;
    public LightingManager2D lightingManager;
    private static GameManager _instance = null;
    public static GameManager Instance
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
    public void SetPart(int partIndex)
    {        
        for(int i=0; i< PartList.Count; i++)
        {
            PartList[i].SetActive(false);
        }
        PartList[partIndex].SetActive(true);
        if(GameIndex <8)
        {
            SetSeaworkAnim(false);
        }
        else
        {
            SetSeaworkAnim(true);
        }
    }
    public void SetGameStatus(GameManager.GameStatus status)
    {
        gameStatus = status;
    }
    public void SetStatusNoting()
    {
        gameStatus = GameStatus.NOTING;
    }
    public void SetPlayerPosition(Transform Pos)
    {
        Player.SetActive(false);
        Player.transform.position = Pos.position;
        Player.SetActive(true);
    }
    public void SetPlayerFlip(bool isRight)
    {
        if(isRight)
        {
            Player.transform.localScale = new Vector3(-4, 4, 4);
        }
        else
        {
            Player.transform.localScale = new Vector3(4, 4, 4);
        }
    }
    //bool lightGameTest = false;
    private void Start()
    {
        UIManager.Instance.TempBG.SetActive(true);

        ActionCount = 20;
        GameIndex = 0;
        styxData = new StyxData();
        
        data = new Data();
        for(int i =0; i< 7;i++)
        {
            data.EndingList.Add(0);
        }       
        //if(lightGameTest ==false)
        //{
        LoadData();
        //}
        //else
        //{
        //    Player.SetActive(false);
        //    UIManager.Instance.TempBG.SetActive(false);
        //}

        //TurnLight(true);

        cinemachineCamera.m_Lens.OrthographicSize = 5;
    }
    public void StartRuningGame()
    {
        //LightGame.SetActive(true);
        RuningGame.SetActive(true);
        Player.SetActive(false);
        Player.SetActive(true);
        //SetCamearTarget(null);
        UIManager.Instance.TempBG.SetActive(false);
        Player.GetComponent<PlayerController>().SetRun(true);
    }
    public void SetCamearTarget(Transform playerObject)
    {        
        cinemachineCamera.Follow = playerObject;
    }
    public void SetPlayerCamera(float time = 0.5f)
    {
        //SetCameraTarget(Player, 0.5f);
        cinemachineCamera.m_Follow = null;
        CameraTargetObject = Player;
        Vector3 targetvec = cinemachineCamera.transform.position;
        targetvec.x = Player.transform.position.x;
        //targetvec.y = target.transform.position.y;
        cinemachineCamera.transform.DOMove(targetvec, time).SetEase(Ease.Linear).OnComplete(OnSetTarget);
    }
  
    private void OnApplicationQuit()
    {
        string saveQuestData = Serializer.ObjectToStringSerialize(styxData);
        ES3.Save("styxData", saveQuestData);

        string strdata = Serializer.ObjectToStringSerialize(data);
        ES3.Save("MemoryData", strdata);
        
    }
    public float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    public float UnwrapAngle(float angle)
    {
        if (angle >= 0)
            return angle;

        angle = -angle % 360;

        return 360 - angle;
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
            string saveQuestData = Serializer.ObjectToStringSerialize(styxData);
            ES3.Save("styxData", saveQuestData);

            string strdata = Serializer.ObjectToStringSerialize(data);
            ES3.Save("MemoryData", strdata);
        }
    }
    public enum EffectType {
        seaWeed,
        fruit,
        seed
    }

    public void SetEffect(EffectType effectType, Vector3 pos)
    {
        switch (effectType)
        {
            case EffectType.seaWeed:                
                SeaWeedEffectController.CollectItemAtPosition(1, pos);
                break;
            case EffectType.fruit:
                FruiteEffectController.CollectItemAtPosition(1, pos);
                break;
            case EffectType.seed:
                seedEffectController.CollectItemAtPosition(1, pos);
                break;
        }
    }
    string strSaveData;
    public void ResetQuestData()
    {
        styxData = new StyxData();
        SaveStyxData();
        TestCodeManager.Instance.CheckDialogueData();
    }
    public void SaveStyxData()
    {
        string saveQuestData = Serializer.ObjectToStringSerialize(styxData);
        ES3.Save("styxData", saveQuestData);

        string strdata = Serializer.ObjectToStringSerialize(data);
        ES3.Save("MemoryData", strdata);
    }
    public void SaveNormalData()
    {
        string strdata = Serializer.ObjectToStringSerialize(data);
        ES3.Save("Data", strdata);
    }
    public void SaveData()
    {
        string saveQuestData = Serializer.ObjectToStringSerialize(styxData);
        ES3.Save("styxData", saveQuestData);


        string strdata = Serializer.ObjectToStringSerialize(data);
        ES3.Save("Data", strdata);

        SaveManager.Instance.SaveData("RoomPos", (int)roomPosition);
        SaveManager.Instance.SaveData("GameIndex", (int)GameIndex);
    }
    public void SavePartPos()
    {
        SaveManager.Instance.SaveData("PartType", PartType);
    }
    public void LoadData()
    {
        if (ES3.KeyExists("styxData"))
        {
            string QuestDatastr = ES3.Load<string>("styxData");
            styxData = Serializer.Deserialize<StyxData>(QuestDatastr);                          
        }

        if(ES3.KeyExists("MemoryData"))
        {
            string strData = ES3.Load<string>("MemoryData");
            data = Serializer.DeserializeData<Data>(strData);
        }
        if (SaveManager.Instance.LoadData("isLight") != null)
        {
            isLight = (bool)SaveManager.Instance.LoadData("isLight");
            TurnLight(isLight);
        }
        if(SaveManager.Instance.LoadData("ActionCount")!=null)
        {
            ActionCount = (int)SaveManager.Instance.LoadData("ActionCount");
        }
        if(SaveManager.Instance.LoadData("GameIndex") !=null)
        {
            GameIndex = (int)SaveManager.Instance.LoadData("GameIndex");
        }
        TestCodeManager.Instance.SetInit();
        Player.SetActive(true);
        
        if(SaveManager.Instance.LoadData("RoomPos")!=null)
        {
            roomPosition = (RoomPosition)SaveManager.Instance.LoadData("RoomPos");
            UIManager.Instance.SetPositionText(roomPosition);                  
        }
        TestCodeManager.Instance.CheckDialogueData();
    }

    //
    
    public void ChangeRoom(RoomPosition room)
    {
        roomPosition = room;
    }
    bool isCameraTarget = false;
    public void ChangeCamera(GameObject Target,bool isPlayer =false)
    {
        isCameraTarget = isPlayer;
        if (isPlayer ==false)
        {
            cinemachineCamera.Follow = null;
        }

        Vector3 targetvec = cinemachineCamera.transform.position;
        targetvec.x = Target.transform.position.x;
        //targetvec.y = Target.transform.position.y;
        cinemachineCamera.transform.DOMove(targetvec, 0.5f).SetEase(Ease.Linear).OnComplete(OnEndMoveCamera);
    }
    GameObject CameraTargetObject;
    public void SetCameraTargetXY(GameObject target, float Time)
    {
        cinemachineCamera.Follow = null;
        CameraTargetObject = target;

        Vector3 targetvec = cinemachineCamera.transform.position;
        targetvec.x = target.transform.position.x;
        targetvec.y = target.transform.position.y;
        cinemachineCamera.transform.DOMove(targetvec, Time).SetEase(Ease.Linear).OnComplete(OnSetTarget);
    }
    public void SetCameraTarget(GameObject target,float Time)
    {
        cinemachineCamera.Follow = null;
        CameraTargetObject = target;
        
        Vector3 targetvec = cinemachineCamera.transform.position;
        targetvec.x = target.transform.position.x;
        //targetvec.y = target.transform.position.y;
        cinemachineCamera.transform.DOMove(targetvec, Time).SetEase(Ease.Linear).OnComplete(OnSetTarget);
    }
    public void SetCameraZoom(float Zoom)
    {
        //cinemachineCamera.m_Lens.OrthographicSize = 5;
        StartCoroutine(ZoomChange(Zoom));
    }
    IEnumerator ZoomChange(float zoom)
    {
        float deltaZoom = zoom / 50;
        for(int i=0;i < 50; i++)
        {
            cinemachineCamera.m_Lens.OrthographicSize += deltaZoom;
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void SetCameraFire()
    {
        cinemachineCamera.Follow = null;
        Vector3 targetvec = cinemachineCamera.transform.position;
        targetvec.x = targetvec.x - 2;
        //targetvec.y = target.transform.position.y;
        cinemachineCamera.transform.DOMove(targetvec, 0.5f).SetEase(Ease.Linear);
    }
    void OnSetTarget()
    {
        if (CameraTargetObject == null)
            return;
        cinemachineCamera.Follow = CameraTargetObject.transform;
    }
    void OnEndMoveCamera()
    {
        if (isCameraTarget)
        {
            cinemachineCamera.Follow = Player.transform;
        }     
        else if(DialogueLua.GetVariable("oldManIndex").asInt ==4)
        {
            WorkerManager.GetComponent<seaWorkManager>().StartConversation();
            
        }
    }

    public void SetCameraYmargin(bool isTop)
    {
        if(isTop == true)
        {
            cinemachineCamera.gameObject.SetActive(false);
            cinemachineCamera_top.gameObject.SetActive(true);
        }
        else
        {
            cinemachineCamera.gameObject.SetActive(true);
            cinemachineCamera_top.gameObject.SetActive(false);
        }
    }
    
    public int ActionCount = 0;
    public void DiscountActionCount()
    {
        SaveManager.Instance.SaveData("ActionCount", ActionCount);
    }

    public bool isLight = false;
    
  
    public void TurnLight(bool bTrun)
    {
        //true = 켜짐
        if (lightingManager == null)
        {
            return;
        }
        isLight = bTrun;
        if (isLight == false)
        {
            lightingManager.cameraSettings[0].renderMode = CameraSettings.RenderMode.Disabled;
        }
        else
        {
            lightingManager.cameraSettings[0].renderMode = CameraSettings.RenderMode.Draw;
        }
        SaveManager.Instance.SaveData("isLight", isLight);
    }

    [TestMethod]
    void Test()
    {
        int value = DialogueLua.GetVariable("ClickCount").asInt;
        Debug.Log(value);
    }


    public IEnumerator StartPart1()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.Instance.Part1Effect.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        DialogueManager.StartConversation("monologue");
    }
    
    public void SetEnableDroneGame()
    {
        UIManager.Instance.makeDronePanel.SetActive(true);
    }

    public void SetSeaWorkRoutine()
    {
        ChangeCamera(WorkerManager);
    }

    public void Quest_1Complete()
    {
        Debug.Log("퀘슽 성공");
    }

    public void SetSeaworkAnim(bool flag,bool isRepair = false)
    {      
        if(flag)
        {
            if (GameIndex == 8)
            {
                UIManager.Instance.pensObject.sprite = UIManager.Instance.PensOff;
                UIManager.Instance.seaWorkAnim.Play("Off");
                UIManager.Instance.VentObject.transform.localPosition = new Vector3(1.5147f, -0.6053f, 0);
            }
            else
            {
                UIManager.Instance.pensObject.sprite = UIManager.Instance.PensOn;
                UIManager.Instance.seaWorkAnim.Play("On");
                UIManager.Instance.VentObject.transform.localPosition = new Vector3(1.535f, -0.768f, 0);
            }       
        }
        else
        {
            if(isRepair)
            {
                UIManager.Instance.pensObject.sprite = UIManager.Instance.PensBroken;
                UIManager.Instance.seaWorkAnim.Play("Off");
                UIManager.Instance.VentObject.transform.localPosition = new Vector3(1.5147f, -0.6053f, 0);
            }
            else
            {
                UIManager.Instance.pensObject.sprite = UIManager.Instance.PensBrokenInit;
                UIManager.Instance.seaWorkAnim.Play("Off");
                UIManager.Instance.VentObject.transform.localPosition = new Vector3(1.5147f, -0.6053f, 0);
            }
        }
    }
    [Button("제작완료", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void TestQuestComplete()
    {
        cameraEffectController.SetCompleteGameUI(languageController.ObjectName.watering);
    }
    [Button("NewData", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void NewData()
    {
        data = new Data();
    }
    [Button("SaveData", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void saveData_Button()
    {
        SaveData();
    }
    [Button("SetLua", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetLua()
    {
        TestCodeManager.Instance.CheckDialogueData();
    }

    public int HarvestFruitCount;

    public int fullTimeFamerQuestItme_2;
    public int fullTimeFamerQuestItme_3;
    public int fullTimeFamerQuestItme_4;

    public void ShowFullTimeFarmerAlter()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.fullTimeFamer));
        cameraEffectController.SetCompleteGameUI(languageController.ObjectName.fullTimeFamer);
        DialogueManager.Pause();
        cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;

    }
    public void ShowGetMapAlter()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.map));      
        cameraEffectController.SetCompleteGameUI(languageController.ObjectName.map);
        DialogueManager.Pause();
        cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
    }
    public void SetPlayerWork(bool flag)
    {
        Player.GetComponent<PlayerController>().SetWorkingMotion(flag);
    }

    [Button("SetFireEvent", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetFireEvent()
    {
        StartCoroutine(StartFireEvent());        
    }
    IEnumerator StartFireEvent()
    {
        CameraPlay.Noise();
        yield return new WaitForSeconds(1.5f);        
        UIManager.Instance.FireEventCamera.SetActive(true);
        UIManager.Instance.FireEventPanel.SetActive(true);        
        yield return new WaitForSeconds(6.5f);
        CameraPlay.Noise();
        yield return new WaitForSeconds(0.5f);
        UIManager.Instance.FireEventCamera.SetActive(false);
        UIManager.Instance.FireEventPanel.SetActive(false);
    }
    [Button("StartMatrix", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetMatrix(bool flag)
    {        
        if (flag)
        {
            cameraEffectController.Start_Matrix();
            UIManager.Instance.CodeGame.SetActive(true);
        }
        else
        {
            StartCoroutine(EndMaxtrixRoutine());            
        }        
    }
    IEnumerator EndMaxtrixRoutine()
    {   
        yield return new WaitForSeconds(1f);
        cameraEffectController.Start_Matrix(false);
        UIManager.Instance.CodeGame.SetActive(false);
        GameManager.Instance.SetPlayerWork(false);
    }
    public void LeverEvent()
    {
        cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Pens);
    }
    public void startLeverEvent()
    {
        StartCoroutine(LeverEventRoutine());
    }
    IEnumerator LeverEventRoutine()
    {
        gameStatus = GameStatus.DO_FORCE;        
        SetCameraTarget(CameraPos1, 1f);
        yield return new WaitForSeconds(2f);
        SetCameraZoom(-1);
        yield return new WaitForSeconds(1f);
        TestCodeManager.Instance.Part1CompleteLeverQuest(false);
        UIManager.Instance.VentObject.transform.localPosition = new Vector3(1.5147f, -0.6053f, 0);
        yield return new WaitForSeconds(1f);
        SetPlayerCamera(1f);
        yield return new WaitForSeconds(1f);
        SetCameraTarget(CameraPos2, 1f);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.VentObject.transform.DOLocalMove(new Vector3(1.535f, -0.768f, 0), 0.75f).SetEase(Ease.OutBounce);
        //UIManager.Instance.VentObject.transform.localPosition = new Vector3(1.535f, -0.768f, 0);
        SetCameraZoom(1);
        yield return new WaitForSeconds(1.5f);
        SetPlayerCamera(1f);
        yield return new WaitForSeconds(1f);
        gameStatus = GameStatus.NOTING;
    }
}

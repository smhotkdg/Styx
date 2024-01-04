using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using Sirenix.OdinInspector;
using PixelCrushers;
public class UIManager : MonoBehaviour
{
    //public enum PositionStatus
    //{
    //    Marina,//선착장
    //    Ship,
    //    Rooms,//숙소
    //    workplace,//작업장
    //    vent,
    //    none        

    //}
    public CanvasGroup UIGruop;
    public GameObject EndingPanel;
    public GameObject ShipGameLife;
    public GameObject TimeUI;
    public delegate void OnClosingTimeUI();
    public event OnClosingTimeUI OnClosingTimeUIEventHandler;
    public delegate void OnClosedTimeUI();
    public event OnClosedTimeUI OnClosedTimeUIEventHandler;

    public DialogueSystemTrigger EscapeConversation;
    public QuestUpdate questUpdate;
    public List<GameObject> ButtonCheckerList;
    public GameObject TopObejct;
    public delegate void OnCompleteEventChange();
    public event OnCompleteEventChange OnCompleteEventChangeHandler;

    public delegate void OnCompleteEventChangeEnd();
    public event OnCompleteEventChangeEnd OnCompleteEventChangeEndHandler;

    public GameObject BetaEndUI;
    public NPCLamptownLightGame nPCLamptownLightGame;

    public GameObject DragTutorial;
    //기어가기 게임
    public GameObject SteerDoorTopPanel;
    [Header("가이트 목록")]
    public GameObject QuestGuideFactoryManager;
    public GameObject QuestGuideSeaweed;
    public GameObject QuestGuideAccessCard;
    public GameObject QuestGuideSteelDoorPassword;
    public GameObject QuestGuideCopperWIre;
    public GameObject QuestGuideOldman;
    public GameObject QuestGuideLampTownManager;
    public GameObject QuestGuidePopOwner;
    public GameObject QuestGuidePopOwnerSeaWeed;
    public GameObject QuestGuideOldmanchess;
    public GameObject QuestBuideCoinQuest;
    public GameObject QuestGuidePassword;
    public GameObject QuestGuideFurit;
    public GameObject DrinkMan;
    public GameObject SteelDoorkeeper;
    public GameObject QuestGuildeDoctor;
    public GameObject QuestGuideComputer;
    public GameObject QuestGuideEspcae_Ship;


    public GameObject QuestGuidePart0;
    public GameObject QuestGuideFire;
    public GameObject QuestGuidePart3AccessCard;

    public GameObject QuestGuideFullTimeFamer;

    public GameObject QuestGuideDeliveryMan;
    public GameObject QuestOldFamer;

    /// <summary>
    /// bottom UILIst
    /// </summary>
    public List<GameObject> BottomUIList;
    public Animator seaWorkAnim;
    public SpriteRenderer pensObject;
    public GameObject VentObject;
    public Sprite PensBrokenInit;
    public Sprite PensBroken;
    public Sprite PensOn;
    public Sprite PensOff;

    public GameObject VentCrawlGameUI;
    public GameObject RunGamePanel;
    public GameObject TempBG;
    //Code Game
    public GameObject CodeGame;
    //불 이벤트
    public GameObject FireEventPanel;
    public GameObject FireEventCamera;
    //public GameManager. positionStatus = PositionStatus.none;
    //농작물 게임
    public GameObject SeedGameController;
    //과일 수확게임
    public GameObject FruitGamePanel;
    //드론 제작 창
    public GameObject makeDronePanel;
    //숟가락 찾기 게임
    public GameObject ScratchGamePanel;
    //고장난 부품 게임
    public GameObject ScratchBrokenPartGamePanel;
    //밀기 게임    
    public GameObject SlideGeGamePanel;
    //레버 게임
    public GameObject leverGamePanel;
    //쥬스 게임
    public GameObject JuiceGamePanel;
    //Part1 Effect    
    //라디오 게임
    public GameObject RadioGame;
    //그림 -> 체스말 찾기
    public GameObject ChessFindGame;
    //설탕 게임
    public GameObject SugarFindGame;
    //금고 찾기
    public GameObject SteelDoorPassword;
    public GameObject SelectNumberGame;
    public GameObject Part1Effect;
    public GameObject Part0Effect;
    public Text PositionText;
    public GameObject BottomRect;
    public GameObject ScenesChangeView;
    public GameObject SeeWeedsQuestPanel;
    public GameObject Part_1_KnockPanel;

    public GameObject flashLightUI;


    public Sprite spriteDrone;
    public Sprite spriteSpoon;
    public Sprite spriteBrokenPart;
    public Sprite spriteStringLIne;
    public Sprite spriteRadio;
    public Sprite spriteBlot;
    public Sprite spriteSeaweedJuice;
    public Sprite spriteSpeacialSeaweed;
    public Sprite spriteSugar;
    public Sprite spriteSkyvinegar;
    public Sprite spriteDelivery1;
    public Sprite spriteDelivery2;
    public Sprite spriteChess;
    public Sprite spriteCopper;
    public Sprite spritSteelDoorMan;
    public Sprite spritCoin;
    public Sprite spritePassword;
    public Sprite Spriteseaweed;
    public Sprite SpritePart0;
    public Sprite SpriteBox;

    [Header("인벤토리 아이템 Sprite")]
    public Sprite letterSprite;
    public Sprite ChurchPassSprite;
    public Sprite FarmPassSprite;
    public Sprite LampTownbroochSprite;
    public Sprite fruitSprite;
    public Sprite wateringCanSprite;
    public Sprite MapSprite;
    public Sprite AccesscardSprite;

    public Sprite DeliveryManSprite;

    public Sprite LIghterSprite;
    public Sprite WarehouseKeySprite;
    public Sprite SteelleverSprite;

    public Sprite SpriteFire;

    public Sprite factoryBroochSprite;
    public Sprite FactoryManagerBoxSprite;
    public Sprite FactoryDoctorSprite;
    public Sprite engineerBroochSprite;
    public Sprite engineerComputerSprite;

    public Sprite sleepingpillSprite;            
    public Sprite sleepingJuiceSprite;            
    public Sprite submarinKeySprite;            
    public Sprite JuiceSprite;

    public Sprite FulltimeFamerSprite;
    ////씨뿌리기
    //sowing,
    ////물주기
    //watering,
    ////수확하기
    //harvest

    public Sprite sowingSprite;
    public Sprite wateringSprite;
    public Sprite harvestSprite;
    public Sprite AnchorSprite;
    public Sprite FactoryManagerSprite;
    public Sprite EmergencySprite;
    public Sprite pacemakerSprite;
    public Sprite EscapeSub1Sprite;
    public Sprite EscapeSub2Sprite;
    public Sprite EscapeSub3Sprite;
    public Sprite haarvestObjectSprite;

    public Sprite EmergencyLeverSprite;
    public Sprite WagonSprite;
    public List<Sprite> SpriteDrink;

    public void SetTimeUI(float time)
    {
        if(TimeUI.activeSelf ==false)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            TimeUI.SetActive(true);
            StartCoroutine(EndTimeUIRoutine(time));
        }        
    }
    IEnumerator EndTimeUIRoutine(float time)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        OnClosingTimeUIEventHandler?.Invoke();
        yield return new WaitForSeconds(time);
        TimeUI.GetComponent<Animator>().Play("TimerBackAnimation");
        OnClosedTimeUIEventHandler?.Invoke();
    }
    public Sprite GetQuestSprite(QuestCheckerController.CheckerType checkerType)
    {
        switch(checkerType)
        {
            case QuestCheckerController.CheckerType.AnchorConversation:
                return AnchorSprite;
            case QuestCheckerController.CheckerType.EmergencyQuest:
                return EmergencySprite;
            case QuestCheckerController.CheckerType.EscapeSub1:
                return EscapeSub1Sprite;
            case QuestCheckerController.CheckerType.EscapeSub2:
                return EscapeSub2Sprite;
            case QuestCheckerController.CheckerType.EscapeSub3:
                return EscapeSub3Sprite;
        }
        return null;
    }
    public void SetquestUpdate(QuestCheckerController.CheckerType checkerType)
    {
        questUpdate.gameObject.SetActive(true);
        questUpdate.SetQuest(checkerType);
    }
    public GameObject TimerObject;
    private static UIManager _instance = null;
    public static UIManager Instance
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

    public GameObject DialogueUITemp;
    public List<GameObject> DialogueList = new List<GameObject>();
    private int dialogueIndex;

    public bool CheckBottomUI()
    {
        for (int i = 0; i < BottomUIList.Count; i++)
        {
            if (BottomUIList[i].activeSelf == true)
            {
                return false;
            }
        }
        return true;
    }
    public void disableUI()
    {
        for (int i = 0; i < BottomUIList.Count; i++)
        {
            BottomUIList[i].SetActive(false);
        }
        if (GameManager.Instance.styxData.strEnableCopperwire == "active")
        {
            UIManager.Instance.flashLightUI.SetActive(true);
        }
        for (int i = 0; i < ButtonCheckerList.Count; i++)
        {
            ButtonCheckerList[i].SetActive(false);
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
    string Strsave;
    bool bEnableQuest = false;
    public void SetOldFamerQuest(bool flag)
    {
        QuestOldFamer.SetActive(flag);
        if(flag ==true)
        {
            DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest), 2.5f);
        }
    }
    public void CheckQuestGuide()
    {
        TimerObject.SetActive(false);
        bEnableQuest = false;

        if (DialogueLua.GetQuestField("Part0Quest", "State").asString == "active")
        {
            if (QuestGuidePart0.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuidePart0.SetActive(true);
        }
        else
        {
            QuestGuidePart0.SetActive(false);
        }


        if (DialogueLua.GetQuestField("FireQuest", "State").asString == "active")
        {
            if (QuestGuideFire.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideFire.SetActive(true);
        }
        else
        {
            QuestGuideFire.SetActive(false);
        }

        if (DialogueLua.GetQuestField("FireQuest", "State").asString == "success" && GameManager.Instance.styxData.Part3_MainAccessCard == 0)
        {
            if (QuestGuidePart3AccessCard.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuidePart3AccessCard.SetActive(true);
        }
        else
        {
            QuestGuidePart3AccessCard.SetActive(false);
        }

        if (GameManager.Instance.styxData.FactorydoctorQuest == "active" || GameManager.Instance.styxData.FactorydoctorQuest == "returnToNPC")
        {
            if (QuestGuildeDoctor.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuildeDoctor.SetActive(true);
        }
        else
        {
            QuestGuildeDoctor.SetActive(false);
        }

        // 컴퓨터 퀘스트
        if (GameManager.Instance.styxData.EngineerComputerQuest == "active" || GameManager.Instance.styxData.EngineerComputerQuest == "returnToNPC")
        {
            if (QuestGuideComputer.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideComputer.SetActive(true);
        }
        else
        {
            QuestGuideComputer.SetActive(false);
        }


        // 탈출 퀘스트
        if (GameManager.Instance.styxData.StartEscapeQuest == "active" || GameManager.Instance.styxData.StartEscapeQuest == "returnToNPC")
        {
            if (QuestGuideEspcae_Ship.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideEspcae_Ship.SetActive(true);
        }
        else
        {
            QuestGuideEspcae_Ship.SetActive(false);
        }

        if (GameManager.Instance.styxData.FactoryManagerQuest == "active" || GameManager.Instance.styxData.FactoryManagerQuest == "returnToNPC")
        {
            if (QuestGuideFactoryManager.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideFactoryManager.SetActive(true);
        }
        else
        {
            QuestGuideFactoryManager.SetActive(false);
        }
        if (DialogueLua.GetQuestField("seaweed", "State").asString == "active")
        {
            if (QuestGuideSeaweed.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideSeaweed.SetActive(true);
        }
        else
        {
            QuestGuideSeaweed.SetActive(false);
        }
        if (DialogueLua.GetQuestField("part1MainQuest", "State").asString == "active")
        {
            if (QuestGuideOldman.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideOldman.SetActive(true);

        }
        else
        {
            QuestGuideOldman.SetActive(false);
        }
        if (DialogueLua.GetQuestField("warehouseManagerQuest", "State").asString == "active")
        {
            if (TimerObject.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideLampTownManager.SetActive(true);
            TimerObject.SetActive(true);

        }
        else
        {
            QuestGuideLampTownManager.SetActive(false);
        }
        if (DialogueLua.GetQuestField("PupOwnerQuest", "State").asString == "active")
        {
            if (QuestGuidePopOwner.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuidePopOwner.SetActive(true);

        }
        else
        {
            QuestGuidePopOwner.SetActive(false);
        }

        if (DialogueLua.GetQuestField("SpeacialSeaweedQuest", "State").asString == "active")
        {
            if (QuestGuidePopOwnerSeaWeed.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuidePopOwnerSeaWeed.SetActive(true);

        }
        else
        {
            QuestGuidePopOwnerSeaWeed.SetActive(false);
        }

        if (DialogueLua.GetQuestField("Oldmanchess", "State").asString == "active")
        {
            if (QuestGuideOldmanchess.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideOldmanchess.SetActive(true);

        }
        else
        {
            QuestGuideOldmanchess.SetActive(false);
        }

        if (DialogueLua.GetQuestField("Copperwire", "State").asString == "active")
        {
            if (QuestGuideCopperWIre.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideCopperWIre.SetActive(true);

        }
        else
        {
            QuestGuideCopperWIre.SetActive(false);
        }


        if (DialogueLua.GetQuestField("steeldoorPasswordQuest", "State").asString == "active")
        {
            if (QuestGuideSteelDoorPassword.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideSteelDoorPassword.SetActive(true);

        }
        else
        {
            QuestGuideSteelDoorPassword.SetActive(false);
        }

        if (GameManager.Instance.styxData.strCoinQuest == "active")
        {
            if (QuestBuideCoinQuest.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestBuideCoinQuest.SetActive(true);

        }
        else
        {
            QuestBuideCoinQuest.SetActive(false);
        }


        if (GameManager.Instance.styxData.Part2PasswordQuest == "active")
        {
            if (QuestGuidePassword.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuidePassword.SetActive(true);

        }
        else
        {
            QuestGuidePassword.SetActive(false);
        }

        if (GameManager.Instance.styxData.fruitQuest == "active")
        {
            if (QuestGuideFurit.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideFurit.SetActive(true);

        }
        else
        {
            QuestGuideFurit.SetActive(false);
        }

        if (GameManager.Instance.styxData.fullTimeFamerQuest == "active")
        {
            if (QuestGuideFullTimeFamer.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideFullTimeFamer.SetActive(true);

        }
        else
        {
            QuestGuideFullTimeFamer.SetActive(false);
        }

        if (GameManager.Instance.styxData.deliveryManQuest == "active" || GameManager.Instance.styxData.deliveryManQuest == "grantable")
        {
            if (QuestGuideDeliveryMan.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideDeliveryMan.SetActive(true);
        }
        else
        {
            QuestGuideDeliveryMan.SetActive(false);
        }

        if (GameManager.Instance.styxData.AccesscardQuest == "active")
        {
            if (QuestGuideAccessCard.activeSelf == false)
            {
                bEnableQuest = true;
            }
            QuestGuideAccessCard.SetActive(true);

        }
        else
        {
            QuestGuideAccessCard.SetActive(false);
        }
        if (bEnableQuest && ScenesChangeView.activeSelf == false && bCompleteRoutine)
        {

            StartCoroutine(EnableQuestRoutine());
            bCompleteRoutine = false;
        }


    }
    bool bCompleteRoutine = true;
    IEnumerator EnableQuestRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        if (ScenesChangeView.activeSelf == false)
        {
            DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest), 2.5f);
            Debug.Log("퀘스트 획득");
        }
        yield return new WaitForSeconds(5f);
        bCompleteRoutine = true;
    }
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(DialogueUITemp);
            temp.transform.SetParent(DialogueUITemp.transform.parent);
            temp.transform.localScale = new Vector3(1, 1, 1);
            DialogueList.Add(temp);
        }
    }
    public void SetTempBG()
    {
        if (ScenesChangeView.activeSelf == false)
        {
            //TempBG.SetActive(true);
        }
        CheckQuestGuide();
    }
    public void SetBottomRect(bool flag)
    {
        BottomRect.SetActive(flag);
    }
    public void SetPositionText(GameManager.RoomPosition position)
    {
        //positionStatus = position;
        PositionText.text = languageController.Instance.sePosition(position);
    }
    public void setDialogue(GameObject target, string strtext, float yMargin = 100f, float endTime = 1f)
    {
        if (dialogueIndex >= DialogueList.Count)
            dialogueIndex = 0;

        DialogueList[dialogueIndex].SetActive(true);
        DialogueList[dialogueIndex].transform.Find("Text").gameObject.GetComponent<Text>().text = strtext;
        DialogueList[dialogueIndex].GetComponent<UiTargetManager>().WorldObject = target;
        DialogueList[dialogueIndex].GetComponent<UiTargetManager>().y_Margin = yMargin;
        StartCoroutine(EndSetDialogueRoutine(dialogueIndex, endTime));
        dialogueIndex++;
    }
    IEnumerator EndSetDialogueRoutine(int index, float time)
    {
        yield return new WaitForSeconds(time);
        DialogueList[index].SetActive(false);
    }
    bool bEndSetDialogueRoutine = false;
    IEnumerator DialogueRoutine;


    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.typing);
            yield return new WaitForSeconds(speed);
        }
        bEndSetDialogueRoutine = false;
    }
    public DialogueSystemTrigger ShipActor;
    public void SetScensChangeSubMarinEnding(languageController.SceneTextType sceneText)
    {
        if (ScenesChangeView.activeSelf == true)
        {
            return;
        }

        ScenesChangeView.SetActive(true);
        ScenesChangeView.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetSecenChangeText(sceneText);
        
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler += UIManager_OnCompleteChangeEndHandler3;
    }

    private void UIManager_OnCompleteChangeEndHandler3()
    {
        //잠수함 엔딩
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler -= UIManager_OnCompleteChangeEndHandler3;
        DialogueManager.StartConversation(ShipActor.conversation, ShipActor.gameObject.transform);
    }

  

    public void SetScenesChangeViewEnable(languageController.SceneTextType sceneText)
    {
        if (ScenesChangeView.activeSelf == true)
        {
            return;
        }

        ScenesChangeView.SetActive(true);
        ScenesChangeView.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetSecenChangeText(sceneText);
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeHandler += UIManager_OnCompleteChangeHandler;
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler += UIManager_OnCompleteChangeEndHandler;
    }

    Transform nextPos = null;
    int m_PartPosition = -1;
    public void SetScenesChangeViewEnable(languageController.SceneTextType sceneText, Transform PlayerPos, int partPosition)
    {
        if (ScenesChangeView.activeSelf == true)
        {
            return;
        }
        SteelDoorkeeper.SetActive(false);
        ScenesChangeView.SetActive(true);
        nextPos = PlayerPos;
        m_PartPosition = partPosition;
        ScenesChangeView.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetSecenChangeText(sceneText);
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeHandler += UIManager_OnCompleteChangeHandler;
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler += UIManager_OnCompleteChangeEndHandler;
    }

    public void SetScenesChangeViewEnable_ShipEvent(languageController.SceneTextType sceneText, Transform PlayerPos)
    {
        if (ScenesChangeView.activeSelf == true)
        {
            return;
        }
        ScenesChangeView.SetActive(true);
        nextPos = PlayerPos;
        ScenesChangeView.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetSecenChangeText(sceneText);
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeHandler += UIManager_OnCompleteChangeHandlerShipEvent;
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler += UIManager_OnCompleteChangeEndHandler1;
    }
    GameObject DoctorObject;
    public void SetScenesChangeViewEnable_DoctorEvent(languageController.SceneTextType sceneText, Transform PlayerPos, int partPosition, GameObject _Doctor)
    {
        DoctorObject = _Doctor;
        if (ScenesChangeView.activeSelf == true)
        {
            return;
        }
        SteelDoorkeeper.SetActive(false);
        ScenesChangeView.SetActive(true);
        nextPos = PlayerPos;
        m_PartPosition = partPosition;
        ScenesChangeView.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetSecenChangeText(sceneText);
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeHandler += UIManager_OnCompleteChangeHandler1;
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler += UIManager_OnCompleteChangeEndHandler2;
    }

    private void UIManager_OnCompleteChangeEndHandler2()
    {
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler -= UIManager_OnCompleteChangeEndHandler2;
        //의사 이벤트 완전 종료

        setDialogue(GameManager.Instance.FactoryDoctor, "어서 병원으로 갑시다", 130, 2);
        StartCoroutine(EndDoctorEvent());
    }
    IEnumerator EndDoctorEvent()
    {
        yield return new WaitForSeconds(2f);
        TestCodeManager.Instance.DoctorEvent_Complete(true);
        GameManager.Instance.FactoryDoctor.SetActive(false);
    }

    private void UIManager_OnCompleteChangeHandler1()
    {
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeHandler -= UIManager_OnCompleteChangeHandler1;
        //의사 이벤트
        DoctorObject.GetComponent<DoctorController>().SetInit();
        GameManager.Instance.FactoryDoctor.SetActive(true);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
        GameManager.Instance.SetCameraTarget(GameManager.Instance.FactoryDoctor, 0.2f);

    }

    private void UIManager_OnCompleteChangeEndHandler1()
    {
        OnCompleteEventChangeEndHandler?.Invoke();
    }
    public GameObject anchorObject;
    public GameObject Submarin;
    private void UIManager_OnCompleteChangeHandlerShipEvent()
    {

        OnCompleteEventChangeHandler?.Invoke();

        GameManager.Instance.cameraEffectController.SetEarthQuake(false);
        Part0Effect.SetActive(false);

        GameManager.Instance.Player.transform.position = nextPos.position;

       
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeHandler -= UIManager_OnCompleteChangeHandlerShipEvent;
    }
    public int EmergencyRoomIndex = 0;
    private void UIManager_OnCompleteChangeEndHandler()
    {
        //완전 종료
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeEndHandler -= UIManager_OnCompleteChangeEndHandler;

        DragTutorial.SetActive(false);
        if(GameManager.Instance.GameIndex <501)
        {
            GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().SetPosition(true);
        }
        switch (GameManager.Instance.GameIndex)
        {
            case 0:
                //선착장
                DragTutorial.SetActive(true);
                break;
            case 1:
                //배
                
                break;
            case 2:
                GameManager.Instance.SetGameStatus(GameManager.GameStatus.DO_SOMETHING);
                Part1Effect.SetActive(true);
                StartCoroutine(GameManager.Instance.StartPart1());
                //감옥
                break;
            case 5:
                //해조류 작업장
                GameManager.Instance.SetSeaWorkRoutine();
                break;
            case 10:
                //기어가기                
                break;
            case 11:
                //램프타운 창고 시작
                GameManager.Instance.warehouseManager.GetComponent<WarehouseManger>().MoveStart();
                break;
            case 17:
                //술주정뱅이 퀘스트시작                
                DrinkMan.GetComponent<DrinkManController>().StartDrinkmanEvent();
                break;
            case 25:
                //스카이 타운 시작
                if (GameManager.Instance.data.memoryCard_3 == 0)
                {
                    DialogueManager.StartConversation("SkyTownInit");
                }
                break;
            case 33:

                break;
            case 38:
                if (GameManager.Instance.roomPosition == GameManager.RoomPosition.factorymanagerroom)
                {
                    DialogueManager.StartConversation(GameManager.Instance.FactoryManager.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
                        GameManager.Instance.FactoryManager.transform);
                }
                if (GameManager.Instance.roomPosition == GameManager.RoomPosition.machineroom)
                {
                    if (GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().FactoryQuestManager.activeSelf)
                    {
                        DialogueManager.StartConversation(GameManager.Instance.FactoryQuest.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
                                                GameManager.Instance.FactoryQuest.transform);
                    }
                }

                break;
            case 41:
                GameManager.Instance.FactorySickPerson.GetComponent<Factorysickperson>().StartSickEvent();
                break;
            case 42:
                GameManager.Instance.FactorySickPerson.GetComponent<Factorysickperson>().SickEventEnd();
                //관리자 다시 시작
                if (GameManager.Instance.roomPosition == GameManager.RoomPosition.machineroom)
                {
                    GameManager.Instance.FactoryManagerEvent_2.SetActive(true);
                    GameManager.Instance.FactoryManagerEvent_2.GetComponent<FactoryManagerEvent_2>().EventStart();
                }

                if (GameManager.Instance.roomPosition == GameManager.RoomPosition.factorymanagerroom)
                {
                    DialogueManager.StartConversation("FactoryManager3", GameManager.Instance.FactoryManagerEvent_2.transform);
                }
                //관리자의 편지
                break;

        }

        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.Chapel)
        {
            GameManager.Instance.ChapelMaster.GetComponent<ChapelMasterController>().SetStartData();
        }

        if (GameManager.Instance.FarmFriend.activeSelf)
        {
            
            DialogueManager.StartConversation(GameManager.Instance.FarmFriend.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
            GameManager.Instance.FarmFriend.transform);

        }
        if(EmergencyRoomIndex ==1)
        {
            DialogueManager.StartConversation("EmergencyNoting");
            EmergencyRoomIndex = 0;
        }
        if(EmergencyRoomIndex==2)
        {
            DialogueManager.StartConversation(EscapeConversation.conversation, EscapeConversation.transform);
            GameManager.Instance.Player.GetComponent<PlayerController>().animator.SetFloat("speed",0);
            GameManager.Instance.Player.GetComponent<PlayerController>().SetIdle();
            EmergencyRoomIndex = 0;
        }
    }
    public void EscapeSubQuestStart()
    {        
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 0)
        {
            SetquestUpdate(QuestCheckerController.CheckerType.EscapeSub1);
            GameManager.Instance.styxData.EscapeSubQuestNumber = 1;
            GameManager.Instance.SaveStyxData();            
            DialogueLua.SetVariable("EscapeSubQuestNumber", GameManager.Instance.styxData.EscapeSubQuestNumber);
            
        }
    }

    public int DrinkIndex=0;
    public Sprite setItemIcon(languageController.ObjectName objectName)
    {
       switch(objectName)
        {
            case languageController.ObjectName.fullTimeFamer:
                return FulltimeFamerSprite;
            case languageController.ObjectName.dstWagon:
                return WagonSprite;
            case languageController.ObjectName.OldFamer:
                return WagonSprite;
            case languageController.ObjectName.LampTownBrooch:
                return LampTownbroochSprite;
            case languageController.ObjectName.drinkMake:
                return SpriteDrink[DrinkIndex];
            case languageController.ObjectName.Letter:
                return letterSprite;
            case languageController.ObjectName.ChurchPass:
                return ChurchPassSprite;
            case languageController.ObjectName.FarmPass:
                return FarmPassSprite;
            case languageController.ObjectName.Pens:
                return PensOn;
            case languageController.ObjectName.lever:
                return PensBroken;
            case languageController.ObjectName.drone:
                return spriteDrone;
            case languageController.ObjectName.Spoon:
                return spriteSpoon;                
            case languageController.ObjectName.Brokenparts:
                return  spriteBrokenPart;                
            case languageController.ObjectName.stringLine:
                return spriteStringLIne;                
            case languageController.ObjectName.Radio:
                return spriteRadio;                
            case languageController.ObjectName.bolt:
                return spriteBlot;                
            case languageController.ObjectName.seaweedjuice:
                return spriteSeaweedJuice;                
            case languageController.ObjectName.speacialseaweed:
                return spriteSpeacialSeaweed;                
            case languageController.ObjectName.sugar:
                return spriteSugar;                
            case languageController.ObjectName.skyvinegar:
                return spriteSkyvinegar;
            case languageController.ObjectName.delivery_1:
                return spriteDelivery1;
            case languageController.ObjectName.delivery_2:
                return spriteDelivery2;
            case languageController.ObjectName.Chess:
                return spriteChess;
            case languageController.ObjectName.Copper:
                return spriteCopper;
            case languageController.ObjectName.non:
                return null;
            case languageController.ObjectName.steeldoorPassword:
                return spritSteelDoorMan;
            case languageController.ObjectName.Coin:
                return spritCoin;
            case languageController.ObjectName.part2Password:
                return spritePassword;
            case languageController.ObjectName.fruit:
                return fruitSprite;
            case languageController.ObjectName.map:
                return MapSprite;
            case languageController.ObjectName.sowing:
                return sowingSprite;
            case languageController.ObjectName.watering:
                return wateringSprite;
            case languageController.ObjectName.WaterCan:
                return wateringCanSprite;
            case languageController.ObjectName.harvest:
                return harvestSprite;
            case languageController.ObjectName.harvestObject:
                return haarvestObjectSprite;
            case languageController.ObjectName.fruit_10:
                return fruitSprite;
            case languageController.ObjectName.lighter:
                return LIghterSprite;
            case languageController.ObjectName.warehouseKey:
                return WarehouseKeySprite;
            case languageController.ObjectName.steellever:
                return SteelleverSprite;
            case languageController.ObjectName.seaweed:
                return Spriteseaweed;
            case languageController.ObjectName.part0:
                return SpritePart0;
            case languageController.ObjectName.fire:
                return SpriteFire;
            case languageController.ObjectName.accesscard:
                return AccesscardSprite;
            case languageController.ObjectName.deliveryMan:
                return DeliveryManSprite;
            case languageController.ObjectName.factorymanager:
                return FactoryManagerBoxSprite;
            case languageController.ObjectName.box:
                return SpriteBox;
            case languageController.ObjectName.factoryDoctor:
                return FactoryDoctorSprite;
            case languageController.ObjectName.engineerComputer:
                return engineerComputerSprite;
            case languageController.ObjectName.AnchorConversation:
                return AnchorSprite;
            case languageController.ObjectName.factoryManager_Escape:
                return FactoryManagerSprite;
            case languageController.ObjectName.EmergencyQuest:
                return EmergencySprite;
            case languageController.ObjectName.EmergencyLever:
                return EmergencyLeverSprite;
                //심박동기
            case languageController.ObjectName.pacemaker:
                return pacemakerSprite;
            case languageController.ObjectName.EscapeSub1:
                return EscapeSub1Sprite;
            case languageController.ObjectName.EscapeSub2:
                return EscapeSub2Sprite;
            case languageController.ObjectName.EscapeSub3:
                return EscapeSub3Sprite;
            case languageController.ObjectName.SleepingJuice:
                return sleepingJuiceSprite;
            case languageController.ObjectName.submarinkey:
                return submarinKeySprite;
        }
        return null;
    }
    public Sprite GetInventorySprite(InventoryController.ItemType itemType)
    {
        switch (itemType)
        {
            case InventoryController.ItemType.fulltimeFamer:
                return FulltimeFamerSprite;
            case InventoryController.ItemType.Spoon:
                return spriteSpoon;
            case InventoryController.ItemType.stringLine:
                return spriteStringLIne;
            case InventoryController.ItemType.Brokenparts:
                return spriteBrokenPart;
            case InventoryController.ItemType.Letter:
                return letterSprite;
            case InventoryController.ItemType.ChurchPass:
                return ChurchPassSprite;
            case InventoryController.ItemType.FarmPass:
                return FarmPassSprite;
            case InventoryController.ItemType.Lamptownbrooch:
                return LampTownbroochSprite;
            case InventoryController.ItemType.wateringCan:
                return wateringCanSprite;
            case InventoryController.ItemType.Map:
                return MapSprite;
            case InventoryController.ItemType.Accesscard:
                return AccesscardSprite;
            case InventoryController.ItemType.factorybrooch:
                return factoryBroochSprite;
            case InventoryController.ItemType.engineerBrooch:
                return engineerBroochSprite;
            case InventoryController.ItemType.sleepingpill:
                return sleepingpillSprite;
            case InventoryController.ItemType.slpeepingJuice:
                return sleepingJuiceSprite;
            case InventoryController.ItemType.SubmarinKey:
                return submarinKeySprite;
            case InventoryController.ItemType.Juice:
                return JuiceSprite;

        }
        return null;
    }
    public FlashLIghtOnOff FlashLIghtOnOff;
    private void UIManager_OnCompleteChangeHandler()
    {
        GameManager.Instance.ShipGame.SetActive(false);
        UIGruop.alpha = 1;
        ShipGameLife.SetActive(false);

        for (int i = 0; i < TestCodeManager.Instance.SkyTownNormalNPC.Count; i++)
        {
            if (TestCodeManager.Instance.SkyTownNormalNPC[i].activeSelf == false)
            {
                TestCodeManager.Instance.SkyTownNormalNPC[i].SetActive(true);
            }
        }

        for (int i = 0; i < TestCodeManager.Instance.SkyTownNormalFireNPC.Count; i++)
        {
            if (TestCodeManager.Instance.SkyTownNormalFireNPC[i].activeSelf == true)
            {
                TestCodeManager.Instance.SkyTownNormalFireNPC[i].SetActive(false);
            }
        }
        disableUI();
        CheckQuestGuide();
        UIManager.Instance.SetBottomRect(true);
        GameManager.Instance.SetPlayerCamera();
        GameManager.Instance.cinemachineCamera.gameObject.SetActive(true);
        GameManager.Instance.cinemachineCamera_top.gameObject.SetActive(false);
        UIManager.Instance.SetPositionText(GameManager.Instance.roomPosition);
        //라이트 셋팅
        switch(GameManager.Instance.roomPosition)
        {
            case GameManager.RoomPosition.skytown:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.Domitory:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.Storage:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.FarmRoom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.FarmManagerRoom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.SkytownWareHouse:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.Farm:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.orchard:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.factory:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.pharmacy:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.machineroom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.factorymanagerroom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.restroom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.mainfactoryroom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.powerroom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.anchoroom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.emergencyarea:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.submarineroom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.sea:
                GameManager.Instance.TurnLight(false);
                break;

        }
        GameManager.Instance.Player.SetActive(false);
        SteelDoorkeeper.SetActive(true);
        if (nextPos !=null)
        {
            GameManager.Instance.Player.transform.position = nextPos.position;
        }
        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.submarineroom)
        {
            anchorObject.transform.position = nextPos.position;
            GameManager.Instance.FactoryManager.transform.position = nextPos.position;
            anchorObject.GetComponent<anchorManagerController>().SetSubmarin();
            GameManager.Instance.SetCameraTarget(anchorObject, 0.1f);
            anchorObject.GetComponent<anchorManagerController>().SetInitMove();
        }
        if(GameManager.Instance.roomPosition == GameManager.RoomPosition.sea)
        {
            //잠수함
            GameManager.Instance.ShipGame.SetActive(true);
            SetBottomRect(false);
            ShipGameLife.SetActive(true);
            GameManager.Instance.SetCameraTarget(Submarin, 0.1f);
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
            GameManager.Instance.ShipGame.GetComponent<ShipGame>().isStart = true;
            GameManager.Instance.ShipGame.GetComponent<ShipGame>().SetMissile();
            GameManager.Instance.ShipGame.GetComponent<ShipGame>().CompleteGameEventHandler += UIManager_CompleteGameEventHandler;
        }
        if (m_PartPosition != -1)
        {
            GameManager.Instance.SetPart(m_PartPosition);
            m_PartPosition = -1;
        }
        ScenesChangeView.GetComponent<ChangeSceneController>().OnCompleteChangeHandler -= UIManager_OnCompleteChangeHandler;
        TempBG.SetActive(false);
        GameManager.Instance.Player.SetActive(true);
        nextPos = null;
        if (GameManager.Instance.styxData.strEnableCopperwire == "active")
        {
            if (FlashLIghtOnOff.bTurn)
            {
                GameManager.Instance.Player.GetComponent<PlayerController>().SetFlashLight(true);            
            }
            
        }
        else
        {
            if(GameManager.Instance.roomPosition != GameManager.RoomPosition.underWater)
            {
                GameManager.Instance.Player.GetComponent<PlayerController>().SetFlashLight(false);
                nPCLamptownLightGame.StartLightOn();
            }
            else
            {
                GameManager.Instance.Player.GetComponent<PlayerController>().Swiming();
            }
        }
        for (int i = 0; i < TestCodeManager.Instance.Part3InitObjects.Count; i++)
        {
            TestCodeManager.Instance.Part3InitObjects[i].SetActive(false);
        }
        GameManager.Instance.cameraEffectController.SetRain(false);
        switch (GameManager.Instance.GameIndex)
        {
            case 0:
                //선착장
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                UIManager.Instance.SetBottomRect(false);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.port);
                GameManager.Instance.cameraEffectController.SetRain(true);
                break;
            case 1:
                //배
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                UIManager.Instance.SetBottomRect(false);
                if(GameManager.Instance.roomPosition != GameManager.RoomPosition.underWater)
                {
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.ship);
                    GameManager.Instance.cameraEffectController.SetRain(true);
                }                
                break;
            case 2:
                //감옥
                SoundsManager.Instance.PlayMainBGM();
                GameManager.Instance.cameraEffectController.wideScreenH.enabled = false;
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
                break;
            case 3:
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
                break;
            case 4:
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
                break;
            case 5:
                //해조류 작업장 세팅
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
                break;
            case 9:
                //하수구 이동
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
                break;
            case 10:
                GameManager.Instance.cinemachineCamera.gameObject.SetActive(false);
                GameManager.Instance.cinemachineCamera_top.gameObject.SetActive(true);
                GameManager.Instance.Player.GetComponent<PlayerController>().SetCrawlIdle();
                VentCrawlGameUI.SetActive(true);
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.vent);
                break;
            case 11:
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);
                GameManager.Instance.warehouseManager.SetActive(true);
                break;
            case 12:
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);
                GameManager.Instance.warehouseManager.SetActive(true);
                break;
            case 17:
                //주정뱅이
                DrinkMan.gameObject.SetActive(true);
                break;
            case 20:
                //
                SteelDoorkeeper.GetComponent<SteelDoorKeeper>().SetPopPos();
                break;
            case 25:
                //사과 수확퀘스트 시작
                for (int i = 0; i <TestCodeManager.Instance.Part3InitObjects.Count; i++)
                {
                    TestCodeManager.Instance.Part3InitObjects[i].SetActive(true);
                }
                break;
            case 33:              
                break;
            case 38:
                //팩토리 관리자 이벤트 시작                
                if (GameManager.Instance.roomPosition == GameManager.RoomPosition.machineroom)
                {
                    GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                    if(GameManager.Instance.FactoryManagerEvent_1.activeSelf ==true)
                    {
                        GameManager.Instance.FactoryManagerEvent_1.GetComponent<FactoryManagerEvent_1>().EventStart();
                    }               
                 
                }
                if(GameManager.Instance.roomPosition == GameManager.RoomPosition.factorymanagerroom)
                {
                    GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                }
                break;
            case 42:
                //의사 이벤트 종료
                GameManager.Instance.SetCamearTarget(GameManager.Instance.Player.transform);
                break;
            case 44:
                
                break;
            case 504:
                
                UIManager.Instance.SetBottomRect(false);
                break;
        }
        if(GameManager.Instance.styxData.FireQuest =="success")
        {
            for (int i = 0; i < TestCodeManager.Instance.SkyTownNormalNPC.Count; i++)
            {
                if (TestCodeManager.Instance.SkyTownNormalNPC[i].activeSelf == true)
                {
                    TestCodeManager.Instance.SkyTownNormalNPC[i].SetActive(false);
                }
            }
            for (int i = 0; i < TestCodeManager.Instance.SkyTownNormalFireNPC.Count; i++)
            {
                if (TestCodeManager.Instance.SkyTownNormalFireNPC[i].activeSelf == false)
                {
                    TestCodeManager.Instance.SkyTownNormalFireNPC[i].SetActive(true);
                }
            }
        }
        if(GameManager.Instance.roomPosition == GameManager.RoomPosition.hardwareStore)
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        }
        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.Chapel)
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        }

        switch(GameManager.Instance.roomPosition)
        {
            case GameManager.RoomPosition.machineroom:
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                break;
            case GameManager.RoomPosition.pharmacy:
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                break;
            case GameManager.RoomPosition.factorymanagerroom:
                GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                break;
            case GameManager.RoomPosition.restroom:
                GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                break;
            case GameManager.RoomPosition.mainfactoryroom:
                GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                break;
            case GameManager.RoomPosition.emergencyarea:
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                break;
            case GameManager.RoomPosition.anchoroom:
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                break;
            case GameManager.RoomPosition.powerroom:
                GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                break;
            case GameManager.RoomPosition.submarineroom:
                GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                break;
           
        }
        if (GameManager.Instance.FarmFriend.activeSelf)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        }
            //술주정뱅이 테스트
            //DrinkMan.SetActive(true);
            //DrinkMan.GetComponent<DrinkManController>().startConverstation();
    }
    public void TestEnding()
    {
        GameManager.Instance.endingType = GameManager.EndingType.EscapeSuccess;
        GameManager.Instance.data.EndingList[1] = 1;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        EndingPanel.SetActive(true);
        EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.EscapeSuccess);
        StartCoroutine(ShipGameObjectDisableRoutine());
    }
    private void UIManager_CompleteGameEventHandler(bool flag)
    {
        GameManager.Instance.ShipGame.GetComponent<ShipGame>().CompleteGameEventHandler -= UIManager_CompleteGameEventHandler;
        if(flag)
        {
            GameManager.Instance.endingType = GameManager.EndingType.EscapeSuccess;
            GameManager.Instance.data.EndingList[1]= 1;
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            EndingPanel.SetActive(true);            
            EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.EscapeSuccess);
            StartCoroutine(ShipGameObjectDisableRoutine());
            
            //성공
        }
        else
        {
            GameManager.Instance.endingType = GameManager.EndingType.EscapeFail;
            GameManager.Instance.data.EndingList[0] = 1;
            StartCoroutine(EndingViewPlayRoutine());
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            GameManager.Instance.cameraEffectController.SetEarthQuake(true);
            //실패
        }
        GameManager.Instance.SaveNormalData();
    }
    IEnumerator ShipGameObjectDisableRoutine()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.ShipGame.SetActive(false);
        SetEnding();
    }
    public void SetEnding()
    {
        UIGruop.alpha = 0;
        ShipGameLife.SetActive(false);
    }
    IEnumerator EndingViewPlayRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.cameraEffectController.SetEarthQuake(false);        
        EndingPanel.SetActive(true);
        EndingPanel.transform.Find("EndingScroll").GetComponent<EndingScrollManager>().CheckData(GameManager.EndingType.EscapeFail);
        StartCoroutine(ShipGameObjectDisableRoutine());
    }
}

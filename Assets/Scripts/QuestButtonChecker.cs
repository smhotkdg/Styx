using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class QuestButtonChecker : MonoBehaviour
{
    public string InfoType;
    public GameObject EscapeQuest;
    public GameObject Escape1;
    public GameObject Escape2;
    public GameObject Escape3;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    public enum CheckerType
    {
        part0,
        OldMan,
        LampTownManager,
        PopOwner,
        PopOwnerMain,
        OldManchess,
        Copper,
        non,
        steeldoorpassword,
        Coin,
        steeldoorpassword_Info,
        fruit,
        fulltime,
        accesscard,
        seaweed,
        fire,
        part3_MainAccessCard,
        deliveryMan,
        factoryManager,
        factoryDoctor,
        engineerComputer,
        AnchorConversation,
        factoryManager_Escape,
        EmergencyQuest,
        EscapeSub1,
        EscapeSub2,
        EscapeSub3,
        OldFamer,
        FactoryEscape,
        Factory_GetPill,
        Factory_SelectMember,
        Factory_Drug,
        PartyroomQuest,
        DeadManMove,
        ccvtQuest,
        DroneCheck,
        moveDoor,
        Sleeping,
        MoveGuard,
        CCTV_5_2

    }
    
    
    private void Start()
    {
 

    }
    void setData()
    {
        Item1 = transform.Find("Info1").gameObject;
        Item2 = transform.Find("Info2").gameObject;
        Item3 = transform.Find("Info3").gameObject;
        Item4 = transform.Find("Info4").gameObject;

        Escape1 = transform.Find("Info5").gameObject;
        Escape2 = transform.Find("Info6").gameObject;
        Escape3 = transform.Find("Info7").gameObject;


        Item1.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 15;
        Item1.transform.Find("Text").gameObject.GetComponent<Text>().resizeTextMaxSize = 15;

        Item2.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 15;
        Item2.transform.Find("Text").gameObject.GetComponent<Text>().resizeTextMaxSize = 15;

        Item3.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 15;
        Item3.transform.Find("Text").gameObject.GetComponent<Text>().resizeTextMaxSize = 15;

        Item4.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 15;
        Item4.transform.Find("Text").gameObject.GetComponent<Text>().resizeTextMaxSize = 15;

        Escape1.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 15;
        Escape1.transform.Find("Text").gameObject.GetComponent<Text>().resizeTextMaxSize = 15;

        Escape2.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 15;
        Escape2.transform.Find("Text").gameObject.GetComponent<Text>().resizeTextMaxSize = 15;

        Item1.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 15;
        Escape3.transform.Find("Text").gameObject.GetComponent<Text>().resizeTextMaxSize = 15;
    }
    private void OnEnable()
    {
        if(Item1 ==null)
        {
            setData();
        }
        SetItem(InfoType);
    }
    float time = 0;
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time >=1)
        {
            time = 0;
            SetItem(InfoType);
        }
        
    }

    public void SetItem(string type)
    {
        switch (type)
        {
            case "seaweed":
                setSeaweed();
                break;
            case "oldman":
                setOldMan();
                break;
            case "popowner":
                setPopOwner();
                break;
            case "lamptownmanager":
                setLampTownManager();
                break;
            case "speacialseaweed":
                setPopOwnerMain();
                break;
            case "chess":
                setOldmanChess();
                break;
            case "copperwire":
                setCopperWIre();
                break;
            case "steeldoorpassword":
                setSteelDoorPassword();
                break;
            case "coinquest":
                setCoinQuest();
                break;
            case "steeldoorpassword_info":
                setsteeldoorpassword_info();
                break;
            case "fruit":
                setfruit();
                break;
            case "fulltimeFamer":
                setfulltimeFamer();
                break;
            case "accesscard":
                setaccesscard();
                break;
            case "fire":
                setFire();
                break;
            case "part3_MainAccessCard":
                setpart3_MainAccessCard();
                break;
            case "deliveryman":
                setDeliveryMan();
                break;
            case "factorymanager":
                setfactorymanager();
                break;
            case "FactoryDoctor":
                setFactoryDoctor();
                break;
            case "ComputerQuest":
                setComputerQuest();
                break;
            case "Escape":
                setEscape();
                break;
            case "OldFamer":
                setOldFamer();
                break;
            case "part0":
                setpart0();
                break;
            case "Factory_Escape":
                setFactoryEscape();
                break;
            case "Factory_GetPill":
                Factory_GetPill();
                break;
            case "Factory_SelectMember":
                Factory_SelectMember();
                break;
            case "Factory_Drug":
                Factory_Drug();
                break;
            case "PartyroomQuest":
                SetPartyroomQuest();
                break;
            case "DeadManMove":
                setDeadManMove();
                break;
            case "ccvtQuest":
                setccvtQuest();
                break;
            case "DroneCheck":
                setDroneCheck();
                break;
            case "MoveDoor":
                setMoveDoor();
                break;
            case "Sleeping":
                setSleeping();
                break;
            case "MoveGuard":
                setMoveGuard();
                break;
            case "ccvtQuest5_2":
                setccvtQuest5_2();
                break;

        }
    }

    void ItemDisable()
    {
        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        Item4.SetActive(false);
        //JuiceRecipe.SetActive(false);
        //EscapeQuest.SetActive(false);
        //SteelDoorPassword.SetActive(false);
        //Escape1.SetActive(false);
        //Escape2.SetActive(false);
        //Escape3.SetActive(false);
        //Escape1.transform.Find("Complete").gameObject.SetActive(false);
        //Escape2.transform.Find("Complete").gameObject.SetActive(false);
        //Escape3.transform.Find("Complete").gameObject.SetActive(false);
        Item1.transform.Find("Complete").gameObject.SetActive(false);
        Item2.transform.Find("Complete").gameObject.SetActive(false);
        Item3.transform.Find("Complete").gameObject.SetActive(false);
        Item4.transform.Find("Complete").gameObject.SetActive(false);
    }
    void ItemEnable(int index, languageController.ObjectName objectName_1, languageController.ObjectName objectName_2,
        languageController.ObjectName objectName_3, languageController.ObjectName objectName_4, CheckerType checkerType)
    {
        if (index == 1)
        {
            Item1.SetActive(true);
            Item1.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_1);
            //Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            Item1.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
        }
        else if (index == 2)
        {
            Item1.SetActive(true);
            Item1.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_1);
            Item2.SetActive(true);

            Item2.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_2);
            //Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            //Item2.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            Item1.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            Item2.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            
        }
        else if (index == 3)
        {
            Item1.SetActive(true);
            Item1.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_1);
            Item2.SetActive(true);
            Item2.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_2);
            Item3.SetActive(true);
            Item3.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_3);
            //Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            //Item2.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            //Item3.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_3);
            Item1.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            Item2.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            Item3.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_3);

        }
        else if (index == 4)
        {
            Item1.SetActive(true);
            Item1.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_1);
            Item2.SetActive(true);
            Item2.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_2);
            Item3.SetActive(true);
            Item3.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_3);
            Item4.SetActive(true);
            Item4.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_4);
            //Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            //Item2.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            //Item3.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_3);
            //Item4.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_4);
            Item1.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            Item2.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            Item3.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_3);
            Item4.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_4);

        }

        switch (checkerType)
        {
            case CheckerType.seaweed:
                if (DialogueLua.GetVariable("seaweedCount").asInt < 5)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                break;
            case CheckerType.OldMan:
                if (DialogueLua.GetVariable("leverQuestItem_1").asInt == 0)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                if (DialogueLua.GetVariable("leverQuestItem_2").asInt == 0)
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(true);
                }
                if (DialogueLua.GetVariable("leverQuestItem_3").asInt == 0)
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(true);
                }
                break;
            case CheckerType.LampTownManager:
                if (GameManager.Instance.styxData.ManagerQuestItem_Radio == 0)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.ManagerQuestItem_Bolt == 0)
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.ManagerQuestItem_SeeweedJuice == 0)
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(true);
                }
                break;
            case CheckerType.PopOwner:
                if (GameManager.Instance.styxData.delivery_NPC1 == 0)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.delivery_varietystore == 0)
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(true);
                }
                break;
            case CheckerType.OldManchess:
                if (GameManager.Instance.styxData.ChessQuestIndex == 0)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                break;
            case CheckerType.PopOwnerMain:
                if (GameManager.Instance.styxData.PopOwnerQuest_Sugar == 0)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.PopOwnerQuest_SKyV == 0)
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.PopOwnerQuest_SpeacialSeaweed == 0)
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(true);
                }
                break;
            case CheckerType.Copper:
                if (GameManager.Instance.styxData.CopperWireIndex == 0)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                break;
            case CheckerType.steeldoorpassword:
                if (GameManager.Instance.styxData.strSteeldoorPasswordQuest == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.Coin:
                if (GameManager.Instance.styxData.strCoinQuest == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.steeldoorpassword_Info:
                if (GameManager.Instance.styxData.Part2PasswordQuest == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.fruit:
                if (GameManager.Instance.styxData.fruitCount >= 5)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.fulltime:
                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_1").asInt >= 8)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }

                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_2").asInt >= 3)
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(false);
                }
                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_3").asInt >= 3)
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(false);
                }
                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_4").asInt >= 3)
                {
                    Item4.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item4.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.accesscard:
                if (GameManager.Instance.styxData.LighterCount >= 1)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }

                if (GameManager.Instance.styxData.WarehouseKeyCount >= 1)
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(false);
                }
                if (GameManager.Instance.styxData.SteelLeverCount >= 1)
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item3.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.part3_MainAccessCard:
                if (GameManager.Instance.styxData.Part3_MainAccessCard >= 1)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.deliveryMan:
                if (GameManager.Instance.styxData.deliveryManQuest == "grantable")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.factoryManager:
                if (GameManager.Instance.styxData.FactoryManagerQuest == "returnToNPC")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.engineerComputer:
                if (GameManager.Instance.styxData.EngineerComputerQuest == "returnToNPC")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.EmergencyQuest:
                if (GameManager.Instance.data.SubmarinKey != 0)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }

                if (GameManager.Instance.styxData.isEnableEmergency == true)
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item2.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.part0:
                if (DialogueLua.GetQuestField("Part0Quest", "State").asString == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.Factory_GetPill:
                if (GameManager.Instance.data.FactoryPill == 1)
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.PartyroomQuest:
                if (GameManager.Instance.styxData.PartyroomQuest == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.DeadManMove:
                if (GameManager.Instance.styxData.DeadManMoveQuest == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.ccvtQuest:
                if (GameManager.Instance.styxData.CCTVQuest == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.DroneCheck:
                if (GameManager.Instance.styxData.DroneCheck == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.moveDoor:
                if (GameManager.Instance.styxData.MoveDoor == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.Sleeping:
                if (GameManager.Instance.styxData.PartyroomQuest5_2 == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
            case CheckerType.MoveGuard:
                if (GameManager.Instance.styxData.MoveGuard == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;

            case CheckerType.CCTV_5_2:
                if (GameManager.Instance.styxData.CCTV_Part5_2 == "success")
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Complete").gameObject.SetActive(false);
                }
                break;
        }
    }
    void setSeaweed()
    {
        ItemDisable();
        ItemEnable(1, languageController.ObjectName.seaweed,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.seaweed);
        
    }
    void setOldMan()
    {
        ItemDisable();
        ItemEnable(3, languageController.ObjectName.Spoon,
            languageController.ObjectName.stringLine,
            languageController.ObjectName.Brokenparts, languageController.ObjectName.non, CheckerType.OldMan);
     
    }
    void setLampTownManager()
    {
        ItemDisable();

        
        //TItleText.text = "관리자의 요구";
        ItemEnable(3, languageController.ObjectName.Radio,
            languageController.ObjectName.bolt,
            languageController.ObjectName.seaweedjuice, languageController.ObjectName.non, CheckerType.LampTownManager);
        
    }
    void setPopOwner()
    {
        ItemDisable();        

        ItemEnable(2, languageController.ObjectName.delivery_1,
            languageController.ObjectName.delivery_2,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.PopOwner);
        
        //JuiceRecipe.SetActive(true);
    }
    void setPopOwnerMain()
    {
        ItemDisable();

        
        //TItleText.text = "펍 주인의 요구";
        ItemEnable(3, languageController.ObjectName.sugar,
            languageController.ObjectName.skyvinegar,
            languageController.ObjectName.speacialseaweed, languageController.ObjectName.non, CheckerType.PopOwnerMain);
        
    }
    public void setOldmanChess()
    {
        ItemDisable();

        ItemEnable(1, languageController.ObjectName.Chess,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.OldManchess);        
    }
    public void setCopperWIre()
    {
        ItemDisable();

   
        ItemEnable(1, languageController.ObjectName.Copper,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Copper); 
    }
    public void setSteelDoorPassword()
    {
        ItemDisable();


        ItemEnable(1, languageController.ObjectName.steeldoorPassword,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.steeldoorpassword);  
    }
    public void setCoinQuest()
    {
        ItemDisable();

        ItemEnable(1, languageController.ObjectName.Coin,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Coin);        
    }
    public void setsteeldoorpassword_info()
    {
        ItemDisable();
        //SteelDoorPassword.SetActive(true);
        transform.Find("Dummy").gameObject.SetActive(false);
        transform.Find("Dummy (1)").gameObject.SetActive(false);
    }
    public void setfruit()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.fruit,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.fruit);

        
    }
    public void setfulltimeFamer()
    {
        ////씨뿌리기
        //sowing,
        ////물주기
        //watering,
        ////수확하기
        //harvest

        ItemDisable();
        
        ItemEnable(4, languageController.ObjectName.fruit_10,
           languageController.ObjectName.sowing,
           languageController.ObjectName.watering, languageController.ObjectName.harvest, CheckerType.fulltime);

        
    }
    public void setaccesscard()
    {
        ItemDisable();
        
        ItemEnable(3, languageController.ObjectName.lighter,
           languageController.ObjectName.warehouseKey,
           languageController.ObjectName.steellever, languageController.ObjectName.non, CheckerType.accesscard);

        
    }
    public void setFire()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.fire,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.fire);

        
    }
    public void setpart3_MainAccessCard()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.accesscard,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.part3_MainAccessCard);

        
    }
    public void setDeliveryMan()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.deliveryMan,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.deliveryMan);

        
    }
    public void setfactorymanager()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.factorymanager,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.factoryManager);

        
    }
    public void setFactoryDoctor()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.factoryDoctor,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.factoryDoctor);

        
    }
    public void setComputerQuest()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.engineerComputer,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.engineerComputer);

        
    }
    public void setEscape()
    {
        ItemDisable();
        if (GameManager.Instance.styxData.EscapeNumber == 0)
        {
            
            ItemEnable(1, languageController.ObjectName.factoryManager_Escape,
               languageController.ObjectName.non,
               languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.factoryManager_Escape);

            
        }
        else if (GameManager.Instance.styxData.EscapeNumber == 1)
        {
            
            ItemEnable(1, languageController.ObjectName.AnchorConversation,
               languageController.ObjectName.non,
               languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.AnchorConversation);

            
        }
        else if (GameManager.Instance.styxData.EscapeNumber == 2)
        {
            
            ItemEnable(2, languageController.ObjectName.EmergencyQuest,
               languageController.ObjectName.EmergencyLever,
               languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.EmergencyQuest);
        }
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 1)
        {
            //EscapeQuest.SetActive(true);
            if(Item3.activeSelf ==false)
            {
                Item3.SetActive(true);
                Item3.transform.Find("Complete").gameObject.SetActive(false);
                UIManager.Instance.setQuestRect();                
            }
            ItemEnable(3, languageController.ObjectName.EmergencyQuest,
               languageController.ObjectName.EmergencyLever,
               languageController.ObjectName.PuttoSleep, languageController.ObjectName.non, CheckerType.EmergencyQuest);
            
            //Item3.transform.Find("Complete").gameObject.SetActive(false);
        }
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 2)
        {
            ItemEnable(3, languageController.ObjectName.EmergencyQuest,
               languageController.ObjectName.EmergencyLever,
               languageController.ObjectName.PuttoSleep, languageController.ObjectName.non, CheckerType.EmergencyQuest);
            //Item3.transform.Find("Complete").gameObject.SetActive(false);
        }
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 3)
        {
            ItemEnable(3, languageController.ObjectName.EmergencyQuest,
               languageController.ObjectName.EmergencyLever,
               languageController.ObjectName.PuttoSleep, languageController.ObjectName.non, CheckerType.EmergencyQuest);
            //Item3.transform.Find("Complete").gameObject.SetActive(false);
        }
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 4)
        {
            ItemEnable(3, languageController.ObjectName.EmergencyQuest,
                 languageController.ObjectName.EmergencyLever,
                 languageController.ObjectName.PuttoSleep, languageController.ObjectName.non, CheckerType.EmergencyQuest);
            //Item3.transform.Find("Complete").gameObject.SetActive(false);
        }
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 5)
        {
            ItemEnable(3, languageController.ObjectName.EmergencyQuest,
               languageController.ObjectName.EmergencyLever,
               languageController.ObjectName.PuttoSleep, languageController.ObjectName.non, CheckerType.EmergencyQuest);
            Item3.transform.Find("Complete").gameObject.SetActive(true);
        }
    }
    void setOldFamer()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.OldFamer,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.OldFamer);

        
    }
    void setpart0()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.part0,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.part0);

        
    }
    void setFactoryEscape()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.FactoryEscape,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.FactoryEscape);

    }
    void Factory_GetPill()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.FactoryGetPill,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Factory_GetPill);

        
    }
    void Factory_SelectMember()
    {
        ItemDisable();
        
        ItemEnable(2, languageController.ObjectName.FactorySelectMemeber_Manager,
           languageController.ObjectName.FactorySelectMemeber_HeadMaster,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Factory_SelectMember);

        
    }
    void Factory_Drug()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.FactoryDrug,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Factory_Drug);

        
    }
    void SetPartyroomQuest()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.PartyRoomDrug,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.PartyroomQuest);

        
    }
    void setDeadManMove()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.DeadManmove,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.DeadManMove);

        
    }
    void setccvtQuest()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.CCTV,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.ccvtQuest);

        
    }
    void setDroneCheck()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.DroneCheck,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.DroneCheck);

        
    }
    void setMoveDoor()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.moveDoor,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.moveDoor);

        
    }
    void setSleeping()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.Sleeping,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Sleeping);

        
    }
    void setMoveGuard()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.MoveGuard,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.MoveGuard);

        
    }
    void setccvtQuest5_2()
    {
        ItemDisable();
        
        ItemEnable(1, languageController.ObjectName.CCTV,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.ccvtQuest);

        
    }
}

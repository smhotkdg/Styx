using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
public class QuestCheckerController : MonoBehaviour
{

    public Text TItleText;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    public Text InfoText;

    public GameObject JuiceRecipe;
    public GameObject SteelDoorPassword;

    public GameObject EscapeQuest;
    public GameObject Escape1;
    public GameObject Escape2;
    public GameObject Escape3;
    void Update()
    {

        if (Input.GetKey("escape"))
            gameObject.SetActive(false);

    }

    public enum CheckerType {
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
        OldFamer

    }
    private void OnEnable()
    {
        transform.SetAsLastSibling();
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
        }
    }
    void ItemDisable()
    {
        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        Item4.SetActive(false);
        JuiceRecipe.SetActive(false);
        EscapeQuest.SetActive(false);
        SteelDoorPassword.SetActive(false);
        Escape1.SetActive(false);
        Escape2.SetActive(false);
        Escape3.SetActive(false);
        Escape1.transform.Find("Line").gameObject.SetActive(false);
        Escape2.transform.Find("Line").gameObject.SetActive(false);
        Escape3.transform.Find("Line").gameObject.SetActive(false);
        Item1.transform.Find("Line").gameObject.SetActive(false);
        Item2.transform.Find("Line").gameObject.SetActive(false);
        Item3.transform.Find("Line").gameObject.SetActive(false);
        Item4.transform.Find("Line").gameObject.SetActive(false);
    }
    void ItemEnable(int index, languageController.ObjectName objectName_1, languageController.ObjectName objectName_2,
        languageController.ObjectName objectName_3, languageController.ObjectName objectName_4, CheckerType checkerType)
    {
        if (index == 1)
        {
            Item1.SetActive(true);
            Item1.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_1);
            Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
        }
        else if (index == 2)
        {
            Item1.SetActive(true);
            Item1.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_1);
            Item2.SetActive(true);

            Item2.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_2);
            Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            Item2.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
        }
        else if (index == 3)
        {
            Item1.SetActive(true);
            Item1.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_1);
            Item2.SetActive(true);
            Item2.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_2);
            Item3.SetActive(true);
            Item3.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetItme(objectName_3);
            Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            Item2.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            Item3.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_3);

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
            Item1.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_1);
            Item2.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_2);
            Item3.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_3);
            Item4.transform.Find("Image").gameObject.GetComponent<Image>().sprite = UIManager.Instance.setItemIcon(objectName_4);
        }

        switch (checkerType)
        {
            case CheckerType.seaweed:
                if (DialogueLua.GetVariable("seaweedCount").asInt < 5)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                break;
            case CheckerType.OldMan:
                if (DialogueLua.GetVariable("leverQuestItem_1").asInt == 0)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                if (DialogueLua.GetVariable("leverQuestItem_2").asInt == 0)
                {
                    Item2.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Line").gameObject.SetActive(true);
                }
                if (DialogueLua.GetVariable("leverQuestItem_3").asInt == 0)
                {
                    Item3.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item3.transform.Find("Line").gameObject.SetActive(true);
                }
                break;
            case CheckerType.LampTownManager:
                if (GameManager.Instance.styxData.ManagerQuestItem_Radio == 0)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.ManagerQuestItem_Bolt == 0)
                {
                    Item2.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Line").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.ManagerQuestItem_SeeweedJuice == 0)
                {
                    Item3.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item3.transform.Find("Line").gameObject.SetActive(true);
                }
                break;
            case CheckerType.PopOwner:
                if (GameManager.Instance.styxData.delivery_NPC1 == 0)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.delivery_varietystore == 0)
                {
                    Item2.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Line").gameObject.SetActive(true);
                }
                break;
            case CheckerType.OldManchess:
                if (GameManager.Instance.styxData.ChessQuestIndex == 0)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                break;
            case CheckerType.PopOwnerMain:
                if (GameManager.Instance.styxData.PopOwnerQuest_Sugar == 0)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.PopOwnerQuest_SKyV == 0)
                {
                    Item2.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item2.transform.Find("Line").gameObject.SetActive(true);
                }
                if (GameManager.Instance.styxData.PopOwnerQuest_SpeacialSeaweed == 0)
                {
                    Item3.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item3.transform.Find("Line").gameObject.SetActive(true);
                }
                break;
            case CheckerType.Copper:
                if (GameManager.Instance.styxData.CopperWireIndex == 0)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                break;
            case CheckerType.steeldoorpassword:
                if (GameManager.Instance.styxData.strSteeldoorPasswordQuest == "success")
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.Coin:
                if (GameManager.Instance.styxData.strCoinQuest == "success")
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.steeldoorpassword_Info:
                if (GameManager.Instance.styxData.Part2PasswordQuest == "success")
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.fruit:
                if (GameManager.Instance.styxData.fruitCount >= 5)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.fulltime:
                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_1").asInt >= 10)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }

                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_2").asInt >= 3)
                {
                    Item2.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item2.transform.Find("Line").gameObject.SetActive(false);
                }
                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_3").asInt >= 3)
                {
                    Item3.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item3.transform.Find("Line").gameObject.SetActive(false);
                }
                if (DialogueLua.GetVariable("fullTimeFamerQuestItme_4").asInt >= 3)
                {
                    Item4.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item4.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.accesscard:
                if (GameManager.Instance.styxData.LighterCount >= 1)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }

                if (GameManager.Instance.styxData.WarehouseKeyCount >= 1)
                {
                    Item2.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item2.transform.Find("Line").gameObject.SetActive(false);
                }
                if (GameManager.Instance.styxData.SteelLeverCount >= 1)
                {
                    Item3.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item3.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.part3_MainAccessCard:
                if (GameManager.Instance.styxData.Part3_MainAccessCard >= 1)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.deliveryMan:
                if (GameManager.Instance.styxData.deliveryManQuest == "grantable")
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.factoryManager:
                if (GameManager.Instance.styxData.FactoryManagerQuest == "returnToNPC")
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.engineerComputer:
                if (GameManager.Instance.styxData.EngineerComputerQuest == "returnToNPC")
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.EmergencyQuest:
                if (GameManager.Instance.data.SubmarinKey !=0)
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
                }

                if (GameManager.Instance.styxData.isEnableEmergency == true)
                {
                    Item2.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item2.transform.Find("Line").gameObject.SetActive(false);
                }
                break;
            case CheckerType.part0:
                if (DialogueLua.GetQuestField("Part0Quest", "State").asString == "success")
                {
                    Item1.transform.Find("Line").gameObject.SetActive(true);
                }
                else
                {
                    Item1.transform.Find("Line").gameObject.SetActive(false);
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

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.seaweed);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.seaweed);
    }
    void setOldMan()
    {
        ItemDisable();
        ItemEnable(3, languageController.ObjectName.Spoon,
            languageController.ObjectName.stringLine,
            languageController.ObjectName.Brokenparts, languageController.ObjectName.non, CheckerType.OldMan);

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.OldMan);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.OldMan);
    }
    void setLampTownManager()
    {
        ItemDisable();

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.LampTownManager);
        //TItleText.text = "관리자의 요구";
        ItemEnable(3, languageController.ObjectName.Radio,
            languageController.ObjectName.bolt,
            languageController.ObjectName.seaweedjuice, languageController.ObjectName.non, CheckerType.LampTownManager);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.LampTownManager);
    }
    void setPopOwner()
    {
        ItemDisable();

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.PopOwner);

        ItemEnable(2, languageController.ObjectName.delivery_1,
            languageController.ObjectName.delivery_2,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.PopOwner);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.PopOwner);
        JuiceRecipe.SetActive(true);
    }
    void setPopOwnerMain()
    {
        ItemDisable();

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.PopOwner);
        //TItleText.text = "펍 주인의 요구";
        ItemEnable(3, languageController.ObjectName.sugar,
            languageController.ObjectName.skyvinegar,
            languageController.ObjectName.speacialseaweed, languageController.ObjectName.non, CheckerType.PopOwnerMain);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.PopOwnerMain);
    }
    public void setOldmanChess()
    {
        ItemDisable();

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.OldManchess);

        ItemEnable(1, languageController.ObjectName.Chess,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.OldManchess);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.OldManchess);
    }
    public void setCopperWIre()
    {
        ItemDisable();

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.Copper);

        ItemEnable(1, languageController.ObjectName.Copper,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Copper);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.Copper);
    }
    public void setSteelDoorPassword()
    {
        ItemDisable();

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.steeldoorpassword);

        ItemEnable(1, languageController.ObjectName.steeldoorPassword,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.steeldoorpassword);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.steeldoorpassword);
    }
    public void setCoinQuest()
    {
        ItemDisable();

        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.Coin);

        ItemEnable(1, languageController.ObjectName.Coin,
            languageController.ObjectName.non,
            languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.Coin);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.Coin);
    }
    public void setsteeldoorpassword_info()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.steeldoorpassword_Info);
        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.steeldoorpassword_Info);
        SteelDoorPassword.SetActive(true);
    }
    public void setfruit()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.fruit);
        ItemEnable(1, languageController.ObjectName.fruit,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.fruit);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.fruit);
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
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.fulltime);
        ItemEnable(4, languageController.ObjectName.fruit_10,
           languageController.ObjectName.sowing,
           languageController.ObjectName.watering, languageController.ObjectName.harvest, CheckerType.fulltime);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.fulltime);
    }
    public void setaccesscard()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.accesscard);
        ItemEnable(3, languageController.ObjectName.lighter,
           languageController.ObjectName.warehouseKey,
           languageController.ObjectName.steellever, languageController.ObjectName.non, CheckerType.accesscard);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.accesscard);
    }
    public void setFire()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.fire);
        ItemEnable(1, languageController.ObjectName.fire,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.fire);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.fire);
    }
    public void setpart3_MainAccessCard()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.part3_MainAccessCard);
        ItemEnable(1, languageController.ObjectName.accesscard,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.part3_MainAccessCard);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.part3_MainAccessCard);
    }
    public void setDeliveryMan()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.deliveryMan);
        ItemEnable(1, languageController.ObjectName.deliveryMan,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.deliveryMan);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.deliveryMan);
    }
    public void setfactorymanager()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.factoryManager);
        ItemEnable(1, languageController.ObjectName.factorymanager,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.factoryManager);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.factoryManager);
    }
    public void setFactoryDoctor()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.factoryDoctor);
        ItemEnable(1, languageController.ObjectName.factoryDoctor,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.factoryDoctor);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.factoryDoctor);
    }
    public void setComputerQuest()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.engineerComputer);
        ItemEnable(1, languageController.ObjectName.engineerComputer,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.engineerComputer);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.engineerComputer);
    }
    public void setEscape()
    {
        ItemDisable();
        if(GameManager.Instance.styxData.EscapeNumber ==0)
        {
            TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.factoryManager_Escape);
            ItemEnable(1, languageController.ObjectName.factoryManager_Escape,
               languageController.ObjectName.non,
               languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.factoryManager_Escape);

            InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.factoryManager_Escape);
        }
        else if(GameManager.Instance.styxData.EscapeNumber ==1)
        {
            TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.AnchorConversation);
            ItemEnable(1, languageController.ObjectName.AnchorConversation,
               languageController.ObjectName.non,
               languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.AnchorConversation);

            InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.AnchorConversation);
        }
        else if (GameManager.Instance.styxData.EscapeNumber == 2)
        {
            TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.EmergencyQuest);
            ItemEnable(2, languageController.ObjectName.EmergencyQuest,
               languageController.ObjectName.EmergencyLever,
               languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.EmergencyQuest);

            InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.EmergencyQuest);
        }
        if(GameManager.Instance.styxData.EscapeSubQuestNumber ==1)
        {
            EscapeQuest.SetActive(true);
            Escape1.SetActive(true);
        }
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 2)
        {
            EscapeQuest.SetActive(true);
            Escape1.SetActive(true);
            Escape1.transform.Find("Line").gameObject.SetActive(true);
            Escape2.SetActive(true);
        }
        if (GameManager.Instance.styxData.EscapeSubQuestNumber == 3)
        {
            EscapeQuest.SetActive(true);
            Escape1.SetActive(true);
            Escape1.transform.Find("Line").gameObject.SetActive(true);
            Escape2.SetActive(true);
            Escape2.transform.Find("Line").gameObject.SetActive(true);
            Escape3.SetActive(true);
        }
        if(GameManager.Instance.styxData.EscapeSubQuestNumber ==4)
        {
            EscapeQuest.SetActive(true);
            Escape1.SetActive(true);
            Escape1.transform.Find("Line").gameObject.SetActive(true);
            Escape2.SetActive(true);
            Escape2.transform.Find("Line").gameObject.SetActive(true);
            Escape3.SetActive(true);
        }
        if(GameManager.Instance.styxData.EscapeSubQuestNumber ==5)
        {
            EscapeQuest.SetActive(true);
            Escape1.SetActive(true);
            Escape1.transform.Find("Line").gameObject.SetActive(true);
            Escape2.SetActive(true);
            Escape2.transform.Find("Line").gameObject.SetActive(true);
            Escape3.SetActive(true);
            Escape3.transform.Find("Line").gameObject.SetActive(true);
        }
    }
    void setOldFamer()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.OldFamer);
        ItemEnable(1, languageController.ObjectName.OldFamer,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.OldFamer);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.OldFamer);
    }
    void setpart0()
    {
        ItemDisable();
        TItleText.text = languageController.Instance.GetQuestTitle(CheckerType.part0);
        ItemEnable(1, languageController.ObjectName.part0,
           languageController.ObjectName.non,
           languageController.ObjectName.non, languageController.ObjectName.non, CheckerType.part0);

        InfoText.text = languageController.Instance.GetQuestChekcerInfoText(CheckerType.part0);
    }
}

using DanielLochner.Assets.SimpleScrollSnap;
using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DroneUIController : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject Left;
    public GameObject Right;
    public InterfaceAnimManager animManager;
    public SimpleScrollSnap simpleScrollSnap;
    public Color MainColor;
    public Color FullColor;
    public Text FillText_0;
    public Text FillText_2;
    public Text FillText_3;
    public Text FillText_4;
    public Text FillText_5;
    public Text FillText_6;
    public Text FillText_6_2;

    int TotalIndex;

    public Image FillPart_0_1;    
    public Image FillPart_2;
    public Image FillPart_3;
    public Image FillPart_4;
    public Image FillPart_5;
    public Image FillPart_6;
    public Image FillPart_6_2;


    public GameObject Part0_Main;
    public GameObject Part0_Ship;
    public GameObject Part0_Lodging;
    public GameObject Part0_Seaweed;
    public GameObject Part0_Vent;

    public GameObject Part2_Main;
    public GameObject Part2_Warehouse;
    public GameObject Part2_Lamptown;
    public GameObject Part2_Steeldoor;
    public GameObject Part2_HardwareStore;
    public GameObject Part2_Church;

    public GameObject Part3_Main;
    public GameObject Part3_Dormitory;
    public GameObject Part3_SteelDoor;
    public GameObject Part3_FarmManagerRoom;
    public GameObject Part3_FarmTool;
    public GameObject Part3_FarmManagerRoom_H;
    public GameObject Part3_Orchard;
    public GameObject Part3_Farm;
    public GameObject Part3_wareHouse;

    public GameObject Part4_Main;
    public GameObject Part4_Hostpital;
    public GameObject Part4_Factory_Room;
    public GameObject Part4_FactoryManagerRoom;
    public GameObject Part4_RestRoom;
    public GameObject Part4_EngineerArea;
    public GameObject Part4_EmergencyArea;
    public GameObject Part4_PowerRoom;
    public GameObject Part4_Anchor_Office;
    public GameObject Part4_Submarine;

    public GameObject Part5_Main;
    public GameObject Part5_SearchBar;
    public GameObject Part5_PartyRoom;
    public GameObject Part5_Pool;
    public GameObject Part5_Prison;
    public GameObject Part5_Handrail;
    public GameObject Part5_Kitchen;
    public GameObject Part5_Vent;

    public GameObject Part6_1_Main;
    public GameObject Part6_1_ResidentialArea;
    public GameObject Part6_1_School;
    public GameObject Part6_1_Sewer;
    public GameObject Part6_1_fountain;
    public GameObject Part6_1_Park;

    public GameObject Part6_2_Main;
    public GameObject Part6_2_MemroyRoom_Hallway;
    public GameObject Part6_2_MemoryRoom;
    public GameObject Part6_2_Wheelhouse_Hallway;
    public GameObject Part6_2_Wheelhouse;
    public GameObject Part6_2_Hallway;
    public GameObject Part6_2_Steeldoor;
    public GameObject Part6_2_LeaderRoom_hallway;
    public GameObject Part6_2_LeaderRoom;
    public GameObject Part6_2_LightHouse;

    public OldmanPrision oldmanPrision;


    private void OnEnable()
    {
        if(ES3.KeyExists("D_tutorial"))
        {
            if(ES3.Load<bool>("D_tutorial") == true)
            {
                tutorial.SetActive(false);
            }
        }
        else
        {
            tutorial.SetActive(true);
            ES3.Save("D_tutorial", true);
        }
        CheckUI();
        Animate();
    }
    void Animate()
    {
        GameManager.Instance.cameraEffectController.StartGlitch();        
        animManager.startAppear();
    }
    public void DisableAnimStart()
    {
        animManager.startDisappear();
        GameManager.Instance.cameraEffectController.StartGlitch();
    }
    

    public void CheckUI()
    {
        string temp = "???";

        Part0_Main.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.port);
        Part0_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.ship] == 1)
            Part0_Ship.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.ship);
        else
            Part0_Ship.transform.Find("Title").GetComponent<Text>().text = temp;
        Part0_Ship.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.room] == 1)
            Part0_Lodging.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.room);
        else
            Part0_Lodging.transform.Find("Title").GetComponent<Text>().text = temp;
        Part0_Lodging.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;
        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.seawork] == 1)
            Part0_Seaweed.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.seawork);
        else
            Part0_Seaweed.transform.Find("Title").GetComponent<Text>().text = temp;
        Part0_Seaweed.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.vent] == 1)
            Part0_Vent.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.vent);
        else
            Part0_Vent.transform.Find("Title").GetComponent<Text>().text = temp;
        Part0_Vent.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;


        Part2_Main.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.lampTown);
        Part2_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.wareHouse] == 1)
            Part2_Warehouse.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.wareHouse);
        else
            Part2_Warehouse.transform.Find("Title").GetComponent<Text>().text = temp;

        Part2_Warehouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.hardwareStore] == 1)
            Part2_HardwareStore.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.hardwareStore);
        else
            Part2_HardwareStore.transform.Find("Title").GetComponent<Text>().text = temp;
        Part2_HardwareStore.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.lampTown] == 1)
            Part2_Lamptown.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.lampTown);
        else
            Part2_Lamptown.transform.Find("Title").GetComponent<Text>().text = temp;
        Part2_Lamptown.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Chapel] == 1)
            Part2_Church.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Chapel);
        else
            Part2_Church.transform.Find("Title").GetComponent<Text>().text = temp;
        Part2_Church.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.steeldoor] == 1)
            Part2_Steeldoor.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.steeldoor);
        else
            Part2_Steeldoor.transform.Find("Title").GetComponent<Text>().text = temp;
        Part2_Steeldoor.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        Part3_Main.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.skytown);
        Part3_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Domitory] == 1)
            Part3_Dormitory.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Domitory);
        else
            Part3_Dormitory.transform.Find("Title").GetComponent<Text>().text = temp;
        Part3_Dormitory.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Storage] == 1)
            Part3_FarmTool.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Storage);
        else
            Part3_FarmTool.transform.Find("Title").GetComponent<Text>().text = temp;

        Part3_FarmTool.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.FarmManagerRoom] == 1)
            Part3_FarmManagerRoom.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.FarmManagerRoom);
        else
            Part3_FarmManagerRoom.transform.Find("Title").GetComponent<Text>().text = temp;
        Part3_FarmManagerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.FarmManagerRoom_H] == 1)
            Part3_FarmManagerRoom_H.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.FarmManagerRoom_H);
        else
            Part3_FarmManagerRoom_H.transform.Find("Title").GetComponent<Text>().text = temp;
        Part3_FarmManagerRoom_H.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.SkytownWareHouse] == 1)
            Part3_wareHouse.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.SkytownWareHouse);
        else
            Part3_wareHouse.transform.Find("Title").GetComponent<Text>().text = temp;
        Part3_wareHouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Farm] == 1)
            Part3_Farm.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Farm);
        else
            Part3_Farm.transform.Find("Title").GetComponent<Text>().text = temp;
        Part3_Farm.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.orchard] == 1)
            Part3_Orchard.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.orchard);
        else
            Part3_Orchard.transform.Find("Title").GetComponent<Text>().text = temp;
        Part3_Orchard.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;


        Part4_Main.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.factory);
        Part4_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.pharmacy] == 1)
            Part4_Hostpital.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.pharmacy);
        else
            Part4_Hostpital.transform.Find("Title").GetComponent<Text>().text = temp;


        Part4_Hostpital.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.machineroom] == 1)
            Part4_Factory_Room.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.machineroom);
        else
            Part4_Factory_Room.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_Factory_Room.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.factorymanagerroom] == 1)
            Part4_FactoryManagerRoom.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.factorymanagerroom);
        else
            Part4_FactoryManagerRoom.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_FactoryManagerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.restroom] == 1)
            Part4_RestRoom.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.restroom);
        else
            Part4_RestRoom.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_RestRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.mainfactoryroom] == 1)
            Part4_EngineerArea.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.mainfactoryroom);
        else
            Part4_EngineerArea.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_EngineerArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.anchoroom] == 1)
            Part4_Anchor_Office.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.anchoroom);
        else
            Part4_Anchor_Office.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_Anchor_Office.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.submarineroom] == 1)
            Part4_Submarine.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.submarineroom);
        else
            Part4_Submarine.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_Submarine.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.emergencyarea] == 1)
            Part4_EmergencyArea.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.emergencyarea);
        else
            Part4_EmergencyArea.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_EmergencyArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.powerroom] == 1)
            Part4_PowerRoom.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.powerroom);
        else
            Part4_PowerRoom.transform.Find("Title").GetComponent<Text>().text = temp;
        Part4_PowerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        Part5_Main.transform.Find("Title").GetComponent<Text>().text = I2.Loc.LocalizationManager.GetTermTranslation("SkyTown");
        Part5_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.SearchRoom] == 1)
            Part5_SearchBar.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.SearchRoom);
        else
            Part5_SearchBar.transform.Find("Title").GetComponent<Text>().text = temp;

        Part5_SearchBar.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.PartyRoom] == 1)
            Part5_PartyRoom.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.PartyRoom);
        else
            Part5_PartyRoom.transform.Find("Title").GetComponent<Text>().text = temp;
        Part5_PartyRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Pool] == 1)
            Part5_Pool.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Pool);
        else
            Part5_Pool.transform.Find("Title").GetComponent<Text>().text = temp;
        Part5_Pool.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;
        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Prison] == 1)
            Part5_Prison.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Prison);
        else
            Part5_Prison.transform.Find("Title").GetComponent<Text>().text = temp;

        Part5_Prison.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Cliff] == 1)
            Part5_Handrail.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Cliff);
        else
            Part5_Handrail.transform.Find("Title").GetComponent<Text>().text = temp;
        Part5_Handrail.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Kitchen] == 1)
            Part5_Kitchen.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Kitchen);
        else
            Part5_Kitchen.transform.Find("Title").GetComponent<Text>().text = temp;
        Part5_Kitchen.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Passage] == 1)
            Part5_Vent.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Passage);
        else
            Part5_Vent.transform.Find("Title").GetComponent<Text>().text = temp;
        Part5_Vent.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        Part6_1_Main.transform.Find("Title").GetComponent<Text>().text = I2.Loc.LocalizationManager.GetTermTranslation("SkyTown");
        Part6_1_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.residentialarea] == 1)
            Part6_1_ResidentialArea.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.residentialarea);
        else
            Part6_1_ResidentialArea.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_1_ResidentialArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.School] == 1)
            Part6_1_School.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.School);
        else
            Part6_1_School.transform.Find("Title").GetComponent<Text>().text = temp;


        Part6_1_School.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;
        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Fountain] == 1)
            Part6_1_fountain.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Fountain);
        else
            Part6_1_fountain.transform.Find("Title").GetComponent<Text>().text = temp;


        Part6_1_fountain.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.sewer] == 1)
            Part6_1_Sewer.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.sewer);
        else
            Part6_1_Sewer.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_1_Sewer.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.EmergencyLadder] == 1)
            Part6_1_Park.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.EmergencyLadder);
        else
            Part6_1_Park.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_1_Park.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        Part6_2_Main.transform.Find("Title").GetComponent<Text>().text = I2.Loc.LocalizationManager.GetTermTranslation("SkyTown");
        Part6_2_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Hallway_1] == 1)
            Part6_2_MemroyRoom_Hallway.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Hallway_1);
        else
            Part6_2_MemroyRoom_Hallway.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_MemroyRoom_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Recodingroom] == 1)
            Part6_2_MemoryRoom.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Recodingroom);
        else
            Part6_2_MemoryRoom.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_MemoryRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;
        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Hallway_2] == 1)
            Part6_2_Wheelhouse_Hallway.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Hallway_2);
        else
            Part6_2_Wheelhouse_Hallway.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_Wheelhouse_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.wheelhouse] == 1)
            Part6_2_Wheelhouse.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.wheelhouse);
        else
            Part6_2_Wheelhouse.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_Wheelhouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.hallway_3] == 1)
            Part6_2_Hallway.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.hallway_3);
        else
            Part6_2_Hallway.transform.Find("Title").GetComponent<Text>().text = temp;

        Part6_2_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.Part6_steeldoor] == 1)
            Part6_2_Steeldoor.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.Part6_steeldoor);
        else
            Part6_2_Steeldoor.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_Steeldoor.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.hallway_4] == 1)
            Part6_2_LeaderRoom_hallway.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.hallway_4);
        else
            Part6_2_LeaderRoom_hallway.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_LeaderRoom_hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.leadersroom] == 1)
            Part6_2_LeaderRoom.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.leadersroom);
        else
            Part6_2_LeaderRoom.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_LeaderRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;

        if (GameManager.Instance.RoomCome[(int)GameManager.RoomPosition.LightHouse] == 1)
            Part6_2_LightHouse.transform.Find("Title").GetComponent<Text>().text = languageController.Instance.sePosition(GameManager.RoomPosition.LightHouse);
        else
            Part6_2_LightHouse.transform.Find("Title").GetComponent<Text>().text = temp;
        Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 0;


     


        //1번 퀘스트
        float part1_index = 0;
        if (GameManager.Instance.GameIndex >= 2)
        {
            part1_index += 1;
        }
        if (GameManager.Instance.GameIndex >= 4)
        {
            part1_index += 1;
        }
        if (GameManager.Instance.GameIndex >= 6)
        {
            part1_index += 1;
        }
        if (GameManager.Instance.GameIndex >= 9)
        {
            part1_index += 1;
        }

        FillText_0.text = ((part1_index / 4) * 100).ToString("N0") + "%";
        FillPart_0_1.fillAmount = (part1_index / 4);

        if(part1_index>=4)
        {
            Part0_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part0_Main.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part0_Ship.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part0_Ship.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part0_Lodging.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part0_Lodging.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part0_Seaweed.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part0_Seaweed.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part0_Vent.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part0_Vent.transform.Find("Fill").GetComponent<Image>().color = FullColor;
        }
        else
        {
            Part0_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part0_Ship.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part0_Lodging.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part0_Seaweed.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part0_Vent.transform.Find("Fill").GetComponent<Image>().color = MainColor;            
        }


        float part2_index = 0;
        if (GameManager.Instance.GameIndex >= 15)
        {
            part2_index += 1;
        }
        if (GameManager.Instance.styxData.strManagerQuset == "success")
        {
            part2_index += 1;
        }
        if (GameManager.Instance.styxData.SpeacialSeaweedQuest == "success")
        {
            part2_index += 1;
        }
        if (GameManager.Instance.styxData.strSteeldoorPasswordQuest == "success")
        {
            part2_index += 1;
        }

        FillText_2.text = ((part2_index / 4) * 100).ToString("N0") + "%";
        FillPart_2.fillAmount = (part2_index / 4);

        if (part2_index >= 4)
        {
            Part2_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part2_Main.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part2_Warehouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part2_Warehouse.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part2_Lamptown.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part2_Lamptown.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part2_Steeldoor.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part2_Steeldoor.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part2_HardwareStore.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part2_HardwareStore.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part2_Church.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part2_Church.transform.Find("Fill").GetComponent<Image>().color = FullColor;
        }
        else
        {
            Part2_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part2_Warehouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part2_Lamptown.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part2_Steeldoor.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part2_HardwareStore.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part2_Church.transform.Find("Fill").GetComponent<Image>().color = MainColor;
        }


        float part3_index = 0;
        if (GameManager.Instance.styxData.fruitQuest == "success")
        {
            part3_index += 1;
        }
        if (GameManager.Instance.styxData.fullTimeFamerQuest == "success")
        {
            part3_index += 1;
        }
        if (GameManager.Instance.styxData.FireQuest == "success")
        {
            part3_index += 1;
        }
        if (GameManager.Instance.styxData.AccesscardQuest == "success")
        {
            part3_index += 1;
        }
        if (GameManager.Instance.styxData.Part3_MainAccessCard != 0)
        {
            part3_index += 1;
        }

        FillText_3.text = ((part3_index / 5) * 100).ToString("N0") + "%";
        FillPart_3.fillAmount = (part3_index / 5);

        if (part3_index >= 5)
        {
            Part3_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_Main.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_Dormitory.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_Dormitory.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_SteelDoor.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_SteelDoor.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_FarmManagerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_FarmManagerRoom.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_FarmTool.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_FarmTool.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_FarmManagerRoom_H.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_FarmManagerRoom_H.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_Orchard.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_Orchard.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_Farm.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_Farm.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part3_wareHouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part3_wareHouse.transform.Find("Fill").GetComponent<Image>().color = FullColor;
        }
        else
        {
            Part3_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part3_Dormitory.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part3_SteelDoor.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part3_FarmManagerRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part3_FarmTool.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part3_FarmManagerRoom_H.transform.Find("Fill").GetComponent<Image>().color = MainColor;

            Part3_Orchard.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part3_Farm.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part3_wareHouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;

        }


        float part4_index = 0;
        if (GameManager.Instance.styxData.deliveryManQuest == "success")
        {
            part4_index += 1;
        }
        if (GameManager.Instance.styxData.FactoryManagerQuest == "success")
        {
            part4_index += 1;
        }
        if (GameManager.Instance.styxData.FactorydoctorQuest == "success")
        {
            part4_index += 1;
        }
        if (GameManager.Instance.styxData.EngineerComputerQuest == "success")
        {
            part4_index += 1;
        }
        if (GameManager.Instance.styxData.FactorySelectMemeber == "success")
        {
            part4_index += 1;
        }    
        if (part4_index >5)
        {
            part4_index = 5;
        }

        FillText_4.text = ((part4_index / 5) * 100).ToString("N0") + "%";
        FillPart_4.fillAmount = (part4_index / 5);



        if (part4_index >= 5)
        {
            Part4_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_Main.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_Hostpital.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_Hostpital.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_Factory_Room.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_Factory_Room.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_FactoryManagerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_FactoryManagerRoom.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_RestRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_RestRoom.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_EngineerArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_EngineerArea.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_EmergencyArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_EmergencyArea.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_PowerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_PowerRoom.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_Anchor_Office.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_Anchor_Office.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part4_Submarine.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part4_Submarine.transform.Find("Fill").GetComponent<Image>().color = FullColor;
        }
        else
        {
            Part4_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_Hostpital.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_Factory_Room.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_FactoryManagerRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_RestRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_EngineerArea.transform.Find("Fill").GetComponent<Image>().color = MainColor;

            Part4_EmergencyArea.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_PowerRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_Anchor_Office.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part4_Submarine.transform.Find("Fill").GetComponent<Image>().color = MainColor;

        }


        float part5_index = 0;
        if (GameManager.Instance.styxData.PartyroomQuest == "success")
        {
            part5_index += 1;
        }
        if (GameManager.Instance.styxData.PartyroomQuest5_2 == "success")
        {
            part5_index += 1;
        }

        if (GameManager.Instance.styxData.MoveGuard == "success")
        {
            part5_index += 1;
        }
        if (GameManager.Instance.styxData.DeadManMoveQuest == "success")
        {
            part5_index += 1;
        }

        if (GameManager.Instance.styxData.CCTVQuest == "success")
        {
            part5_index += 1;
        }
        if (GameManager.Instance.styxData.CCTV_Part5_2 == "success")
        {
            part5_index += 1;
        }
        //난간
        if(GameManager.Instance.data.isChoiceMember ==1)
        {
            if (GameManager.Instance.GameIndex >=709)
            {
                part5_index += 1;
            }
            if (GameManager.Instance.GameIndex >= 712)
            {
                part5_index += 1;
            }
        }
        else
        {
            if (GameManager.Instance.GameIndex >= 907)
            {
                part5_index += 1;
            }
            if (GameManager.Instance.GameIndex >= 909)
            {
                part5_index += 1;
            }
        }
        

        FillText_5.text = ((part5_index / 5) * 100).ToString("N0") + "%";
        FillPart_5.fillAmount = (part5_index / 5);



        if (part5_index >= 5)
        {
            Part5_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_Main.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part5_SearchBar.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_SearchBar.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part5_PartyRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_PartyRoom.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part5_Pool.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_Pool.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part5_Prison.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_Prison.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part5_Handrail.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_Handrail.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part5_Kitchen.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_Kitchen.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part5_Vent.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part5_Vent.transform.Find("Fill").GetComponent<Image>().color = FullColor;
        }
        else
        {
            Part5_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part5_SearchBar.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part5_PartyRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part5_Pool.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part5_Prison.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part5_Handrail.transform.Find("Fill").GetComponent<Image>().color = MainColor;

            Part5_Kitchen.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part5_Vent.transform.Find("Fill").GetComponent<Image>().color = MainColor;


        }

        float part6_0index = 0;
        if (GameManager.Instance.data.isChoiceMember == 1)
        {
            if (GameManager.Instance.GameIndex == 715)
            {
                part6_0index += 1;
            }
        }
        else
        {
            if (GameManager.Instance.GameIndex >= 912)
            {
                part6_0index += 1;
            }
        }

        if (part6_0index >= 1)
        {
            Part6_1_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_1_Main.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part6_1_ResidentialArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_1_ResidentialArea.transform.Find("Fill").GetComponent<Image>().color = FullColor;
            if (GameManager.Instance.data.isChoiceMember == 1)
            {
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().color = FullColor;
                Part6_1_fountain.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                Part6_1_fountain.transform.Find("Fill").GetComponent<Image>().color = FullColor;
            }
            else
            {
                Part6_1_Sewer.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                Part6_1_Sewer.transform.Find("Fill").GetComponent<Image>().color = FullColor;
            }

            Part6_1_Park.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_1_Park.transform.Find("Fill").GetComponent<Image>().color = FullColor;
     
        }
        else
        {
            Part6_1_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_1_ResidentialArea.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_1_School.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_1_Sewer.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_1_fountain.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_1_Park.transform.Find("Fill").GetComponent<Image>().color = MainColor;
        }

        FillText_6.text = ((part6_0index / 1) * 100).ToString("N0") + "%";
        FillPart_6.fillAmount = (part6_0index / 1);


        float part6_index = 0;
        if (GameManager.Instance.data.isChoiceMember == 1)
        {

            if (GameManager.Instance.styxData.MoveDoor == "success")
            {
                part6_index += 1;
            }
            if (GameManager.Instance.GameIndex >= 720)
            {
                part6_index += 1;
            }
            if (GameManager.Instance.GameIndex >= 721)
            {
                part6_index += 1;
            }
        }
        else
        {
            
            if (GameManager.Instance.styxData.MoveDoor == "success")
            {
                part6_index += 1;
            }
            if (GameManager.Instance.GameIndex >= 919)
            {
                part6_index += 1;
            }
            if (GameManager.Instance.GameIndex >= 920)
            {
                part6_index += 1;
            }
        }


        if (part6_0index >= 1)
        {
            Part6_2_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_Main.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part6_2_MemroyRoom_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_MemroyRoom_Hallway.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part6_2_MemoryRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_MemoryRoom.transform.Find("Fill").GetComponent<Image>().color = FullColor;
            Part6_2_Wheelhouse_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_Wheelhouse_Hallway.transform.Find("Fill").GetComponent<Image>().color = FullColor;


            Part6_2_Wheelhouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_Wheelhouse.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part6_2_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_Hallway.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part6_2_Steeldoor.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_Steeldoor.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part6_2_LeaderRoom_hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_LeaderRoom_hallway.transform.Find("Fill").GetComponent<Image>().color = FullColor;


            Part6_2_LeaderRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_LeaderRoom.transform.Find("Fill").GetComponent<Image>().color = FullColor;

            Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
            Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().color = FullColor;

        }
        else
        {
            Part6_2_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_MemroyRoom_Hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_MemoryRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_Wheelhouse_Hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_Wheelhouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_Hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_Steeldoor.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_LeaderRoom_hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_LeaderRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
            Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
        }


        FillText_6_2.text = ((part6_index / 3) * 100).ToString("N0") + "%";
        FillPart_6_2.fillAmount = (part6_index / 3);



        switch (GameManager.Instance.roomPosition)
        {
            case GameManager.RoomPosition.port:
                Part0_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part0_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.ship:
                Part0_Ship.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part0_Ship.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.room:
                Part0_Lodging.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part0_Lodging.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.seawork:
                Part0_Seaweed.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part0_Seaweed.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.vent:
                Part0_Vent.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part0_Vent.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;

            case GameManager.RoomPosition.lampTown:
                Part2_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part2_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.wareHouse:
                Part2_Warehouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part2_Warehouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.hardwareStore:
                Part2_HardwareStore.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part2_HardwareStore.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Chapel:
                Part2_Church.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part2_Church.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.steeldoor:
                Part2_Steeldoor.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part2_Steeldoor.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.skytown:
                Part3_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Domitory:
                Part3_Dormitory.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_Dormitory.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Storage:
                Part3_FarmTool.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_FarmTool.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.FarmRoom:
                Part3_FarmManagerRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_FarmManagerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.FarmManagerRoom_H:
                Part3_FarmManagerRoom_H.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_FarmManagerRoom_H.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.orchard:
                Part3_Orchard.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_Orchard.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Farm:
                Part3_Farm.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_Farm.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.SkytownWareHouse:
                Part3_wareHouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part3_wareHouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.factory:
                Part4_Main.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_Main.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.machineroom:
                Part4_Factory_Room.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_Factory_Room.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.pharmacy:
                Part4_Hostpital.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_Hostpital.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.factorymanagerroom:
                Part4_FactoryManagerRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_FactoryManagerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.restroom:
                Part4_RestRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_RestRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.mainfactoryroom:
                Part4_EngineerArea.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_EngineerArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.emergencyarea:
                Part4_EmergencyArea.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_EmergencyArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.powerroom:
                Part4_PowerRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_PowerRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.anchoroom:
                Part4_Anchor_Office.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_Anchor_Office.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.submarineroom:
                Part4_Submarine.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part4_Submarine.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.SearchRoom:
                Part5_SearchBar.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part5_SearchBar.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.PartyRoom:
                Part5_PartyRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part5_PartyRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Pool:
                Part5_Pool.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part5_Pool.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Prison:
                Part5_Prison.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part5_Prison.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Cliff:
                Part5_Handrail.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part5_Handrail.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Kitchen:
                Part5_Kitchen.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part5_Kitchen.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Passage:
                Part5_Vent.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part5_Vent.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;


            case GameManager.RoomPosition.residentialarea:
                Part6_1_ResidentialArea.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_1_ResidentialArea.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.School:
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.schooIn:
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Fountain:
                Part6_1_fountain.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_1_fountain.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;

            case GameManager.RoomPosition.ProfessorRoom:
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_1_School.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.sewer:
                Part6_1_Sewer.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_1_Sewer.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.EmergencyLadder:
                Part6_1_Park.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_1_Park.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;

            case GameManager.RoomPosition.Hallway_1:
                Part6_2_MemroyRoom_Hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_MemroyRoom_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Recodingroom:
                Part6_2_MemoryRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_MemoryRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Hallway_2:
                Part6_2_Wheelhouse_Hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_Wheelhouse_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.wheelhouse:
                Part6_2_Wheelhouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_Wheelhouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.hallway_3:
                Part6_2_Hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_Hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.Part6_steeldoor:
                Part6_2_Steeldoor.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_Steeldoor.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.hallway_4:
                Part6_2_LeaderRoom_hallway.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_LeaderRoom_hallway.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.leadersroom:
                Part6_2_LeaderRoom.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_LeaderRoom.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.LightHouseLadder:
                Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
            case GameManager.RoomPosition.LightHouse:
                Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().color = MainColor;
                Part6_2_LightHouse.transform.Find("Fill").GetComponent<Image>().fillAmount = 1;
                break;
        }


        if (isStart)
        {
            SetPanel();
        }
        
       
    }
    private void FixedUpdate()
    {
        CheckLeftRight();
    }
    public void CheckLeftRight()
    {
        if(simpleScrollSnap.SelectedPanel==0)
        {
            Left.SetActive(false);
        }
        else
        {
            Left.SetActive(true);
        }
        if(simpleScrollSnap.SelectedPanel ==6)
        {
            Right.SetActive(false);
        }
        else
        {
            Right.SetActive(true);
        }
    }
    IEnumerator SetPanelRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.port ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.ship ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.room ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.seawork ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.vent)
        {
            simpleScrollSnap.GoToPanel(0);
        }
        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.wareHouse ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.lampTown ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.hardwareStore ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.Chapel ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.steeldoor)
        {
            simpleScrollSnap.GoToPanel(1);
        }
        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.skytown ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.Domitory ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.FarmManagerRoom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.FarmRoom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.FarmManagerRoom_H ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.Farm ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.orchard ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.SkytownWareHouse ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.Storage)
        {
            simpleScrollSnap.GoToPanel(2);
        }

        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.factory ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.pharmacy ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.machineroom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.restroom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.factorymanagerroom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.mainfactoryroom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.emergencyarea ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.powerroom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.anchoroom ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.submarineroom)
        {
            simpleScrollSnap.GoToPanel(3);
        }

        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.SearchRoom ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.PartyRoom ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Pool ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Prison ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Cliff ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Kitchen ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Passage)
        {
            simpleScrollSnap.GoToPanel(4);
        }

        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.residentialarea ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.sewer ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.schooIn ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.School ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.ProfessorRoom ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Fountain ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.EmergencyLadder)
        {
            simpleScrollSnap.GoToPanel(5);
        }

        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.Hallway_1 ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Hallway_2 ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.hallway_3 ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.hallway_4 ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Recodingroom ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.wheelhouse ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Part6_steeldoor ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.leadersroom ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.LightHouse ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.LightHouseLadder)
        {
            simpleScrollSnap.GoToPanel(6);
        }
        CheckLeftRight();
    }
    void SetPanel()
    {
        StartCoroutine(SetPanelRoutine());
        

    }
    bool isStart = false;
    private void Start()
    {
        isStart = true;
        SetPanel();
    }
    private void OnDisable()
    {
        
        if (GameManager.Instance !=null)
        {
            
            if (GameManager.Instance.DroneTutorial ==1)
            {
                GameManager.Instance.DroneTutorial = 2;
                ES3.Save("DroneTutorial", GameManager.Instance.DroneTutorial);
                UIManager.Instance.CheckUI();                
                oldmanPrision.SetTime();
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
public class QuestMovePlayer : ObjectChekcer
{
    public bool isDown = false;
    public bool isRoom = true;
    public GameObject uiElement;
    public Transform movePosition;
    public enum moveType
    {
        StaffOnly,
        seawork_TO_warehouse,
        warehouse_TO_seawork,
        warehouse_TO_Lamptown,
        Lamptown_TO_warehouse,
        Lamptown_TO_TOP,
        TOP_TO_Lamptown,
        non,
        LampTown_TO_HardwareStore,
        HardwareStore_TO_LampTown,
        LampTown_TO_SteelDoor,
        SteelDoor_TO_LampTown,
        SteelDoor_TO_chapel,
        chapel_TO_SteelDoor,
        SKYTown_TO_Domitory,
        Domitory_TO_SKYTown,


        SKYtonw_TO_Storage,
        Storage_TO_SKYtown,
        SKYTown_TO_FarmRoom,
        FarmRoom_TO_SKYTown,

        SKYtown_TO_orchard,
        orchard_TO_SKYTown,

        orchard_TO_Farm,
        Farm_TO_orchard,

        Farm_TO_Warehouse,
        Warehouse_TO_Farm,

        Warehouse_TO_ManagerRoom,
        ManagerRoom_TO_Init,
        ManagerRoom_TO_WareHouse,

        Factory_TO_Machineroom,
        Machineroom_TO_Factory,

        Factory_TO_Pharmacy,
        Pharmacy_TO_Factory,


        MachineBottom_TO_MachineTop,
        MachineTop_TO_MachineBottom,

        MachineTop_TO_Factorymanagerroom,
        Factorymanagerroom_TO_FactoryTop,

        FactoryTop_TO_restroom,
        restroom_TO_FactoryTop,

        //이건 UI체크 한번 해봐야함
        FactoryTop_TO_Mainfactoryroom,
        MainFactoryroom_TO_FactoryTOP,
        MainFactoryRoom_TO_some,
        //

        Mainfactoryroom_TO_emergencyarea,
        emergencyarea_TO_Mainfactoryroom,

        Mainfactoryroom_TO_anchorroom,
        anchorroom_TO_Mainfactoryroom,

        Mainfactoryroom_TO_powerroom,
        powerroom_TO_Mainfactoryroom,


        anchorroom_TO_submarinerroom
    }

    public moveType type = moveType.warehouse_TO_seawork;
    private void Start()
    {
        OnEnterObjectEventHandler += QuestMover_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += QuestMover_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += QuestMover_OnClickObjectEventHandler;
    }
    public void Click()
    {
        if (GameManager.Instance.GameIndex >= 11)
        {
            switch (type)
            {
                case moveType.StaffOnly:
                    DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.StaffOnly),2.5f);
                    break;
                case moveType.seawork_TO_warehouse:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.random, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);
                    break;
                case moveType.warehouse_TO_seawork:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.random, movePosition, 1);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.seawork);
                    break;
                case moveType.warehouse_TO_Lamptown:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.LampTown, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
                    break;
                case moveType.Lamptown_TO_warehouse:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Warehouse, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);
                    break;
                case moveType.Lamptown_TO_TOP:
                    GameManager.Instance.Player.transform.position = movePosition.position;
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
                    break;
                case moveType.TOP_TO_Lamptown:
                    GameManager.Instance.Player.transform.position = movePosition.position;
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
                    break;
                case moveType.non:
                    GameManager.Instance.Player.transform.position = movePosition.position;
                    break;
                case moveType.LampTown_TO_HardwareStore:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.HardwareStor, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.hardwareStore);
                    break;
                case moveType.HardwareStore_TO_LampTown:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.LampTown, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
                    break;
                case moveType.LampTown_TO_SteelDoor:
                    if (GameManager.Instance.GameIndex >= 18)
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.steelDoor, movePosition, 2);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.steeldoor);
                    }
                    else
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.NotSuccess), 2.5f);
                    }

                    break;
                case moveType.SteelDoor_TO_LampTown:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.LampTown, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.lampTown);
                    break;
                case moveType.SteelDoor_TO_chapel:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.ChapelPos, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Chapel);
                    break;
                case moveType.chapel_TO_SteelDoor:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.steelDoor, movePosition, 2);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.steeldoor);
                    break;

                case moveType.SKYTown_TO_Domitory:
                    if(GameManager.Instance.styxData.fruitQuest == "unassigned")
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.NotSuccess), 2.5f);
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Domitory, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Domitory);
                    }
                    break;
                case moveType.Domitory_TO_SKYTown:
                    if (GameManager.Instance.styxData.fruitQuest == "unassigned")
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.NotSuccess), 2.5f);
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.skyTown, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
                    }
                    break;

                case moveType.SKYtonw_TO_Storage:
                    if (GameManager.Instance.styxData.fruitQuest == "unassigned")
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.NotSuccess), 2.5f);
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Storage, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Storage);
                    }                    
                    break;
                case moveType.Storage_TO_SKYtown:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.skyTown, movePosition, 3);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
                    break;


                case moveType.SKYTown_TO_FarmRoom:
                    if (GameManager.Instance.styxData.fruitQuest == "unassigned")
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.NotSuccess), 2.5f);
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.FarmRoom, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.FarmRoom);
                    }                    
                    break;
                case moveType.FarmRoom_TO_SKYTown:                   
                  
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.skyTown, movePosition, 3);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
                    break;

                case moveType.SKYtown_TO_orchard:
                    if (GameManager.Instance.styxData.fruitQuest == "unassigned")
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.NotSuccess), 2.5f);
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.orchard, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.orchard);
                    }                    
                    break;
                case moveType.orchard_TO_SKYTown:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.skyTown, movePosition, 3);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
                    break;

                case moveType.orchard_TO_Farm:
                    if (GameManager.Instance.data.wateringCan == 0)
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.needWaterCan), 2.5f);
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Farm, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Farm);
                    }
                    
                    break;
                case moveType.Farm_TO_orchard:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.orchard, movePosition, 3);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.orchard);
                    break;

                case moveType.Farm_TO_Warehouse:
                    if (GameManager.Instance.styxData.FireQuest == "unassigned")
                    {
                        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.CCTV), 2.5f);
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.SkytownWareHouse, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.SkytownWareHouse);
                    }                    
                    break;
                case moveType.Warehouse_TO_Farm:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.Farm, movePosition, 3);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.Farm);
                    break;

                case moveType.Warehouse_TO_ManagerRoom:
                    if(GameManager.Instance.styxData.FireQuest !="success")
                    {
                        DialogueManager.StartConversation("FireMonologue");
                    }
                    else
                    {
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.FarmManagerRoom, movePosition, 3);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.FarmManagerRoom);
                    }                    
                    break;
                case moveType.ManagerRoom_TO_Init:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.skyTown, movePosition, 3);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);
                    break;
                case moveType.ManagerRoom_TO_WareHouse:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.SkytownWareHouse, movePosition, 3);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.SkytownWareHouse);
                    break;


                case moveType.Factory_TO_Machineroom:
                    if(GameManager.Instance.data.FactoryBrooch ==0)
                    {
                        DialogueManager.StartConversation("Factorydoor");
                    }
                    else
                    {
                        //GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.machineroom, movePosition, 4);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
                    }
                    
                    break;
                case moveType.Machineroom_TO_Factory:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
                    break;
                case moveType.Factory_TO_Pharmacy:
                    //GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.pharmacy, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.pharmacy);
                    break;
                case moveType.Pharmacy_TO_Factory:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
                    break;

                case moveType.MachineBottom_TO_MachineTop:
                    //GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                    GameManager.Instance.Player.transform.position = movePosition.position;
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
                    break;
                case moveType.MachineTop_TO_MachineBottom:
                    //GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                    GameManager.Instance.Player.transform.position = movePosition.position;
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
                    break;
                case moveType.MachineTop_TO_Factorymanagerroom:                    
                    //GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factorymanagerroom, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factorymanagerroom);
                    break;
                case moveType.Factorymanagerroom_TO_FactoryTop:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
                    break;
                case moveType.FactoryTop_TO_restroom:
                    //GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.restroom, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.restroom);
                    break;
                case moveType.restroom_TO_FactoryTop:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.machineroom);
                    break;
                //여긴 한번더 확인
                case moveType.FactoryTop_TO_Mainfactoryroom:
                    if (GameManager.Instance.data.engineerBrooch == 0)
                    {
                        DialogueManager.StartConversation("MainFactorydoor");
                    }
                    else
                    {
                        //GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, movePosition, 4);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
                    }
                    
                    break;
                case moveType.MainFactoryroom_TO_FactoryTOP:
                    //UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factory, movePosition, 4);
                    //GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);
                    break;
                case moveType.MainFactoryRoom_TO_some:
                    //SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.Mainfactoryroom_TO_emergencyarea:
                    //GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.emergencyarea, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.emergencyarea);
                    break;
                case moveType.emergencyarea_TO_Mainfactoryroom:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
                    break;
                case moveType.Mainfactoryroom_TO_anchorroom:
                    if(GameManager.Instance.styxData.EngineerComputerQuest =="success")
                    {
                        //GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.anchoroom, movePosition, 4);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.anchoroom);
                    }
                    else
                    {
                        DialogueManager.StartConversation("CanNotUsed");
                    }
                    
                    break;
                case moveType.anchorroom_TO_Mainfactoryroom:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
                    break;
                case moveType.Mainfactoryroom_TO_powerroom:        
                    if(GameManager.Instance.data.isEscapeShip>0)
                    {
                        //GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.powerroom, movePosition, 4);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.powerroom);
                    }
                    else
                    {
                        DialogueManager.StartConversation("DoorLock");
                    }
                    
                    break;
                case moveType.powerroom_TO_Mainfactoryroom:
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.mainfactoryroom, movePosition, 4);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.mainfactoryroom);
                    break;
                case moveType.anchorroom_TO_submarinerroom:
                    //
                    if(GameManager.Instance.styxData.StartEscapeQuest =="success")
                    {
                        //GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
                        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.submarineroom, movePosition, 4);
                        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.submarineroom);
                    }
                    else
                    {
                        DialogueManager.StartConversation("DoorLock");
                    }
                    
                    break;
                


            }
        }        
    }

    private void QuestMover_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void QuestMover_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        
        if (GameManager.Instance.GameIndex >= 11)
        {
            switch (type)
            {
                
                case moveType.LampTown_TO_SteelDoor:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 0);
                    break;
                case moveType.SteelDoor_TO_LampTown:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 0);
                    break;

                case moveType.seawork_TO_warehouse:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 75, -40);
                    break;
                case moveType.warehouse_TO_seawork:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 75 ,10);
                    break;
                case moveType.warehouse_TO_Lamptown:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 0);
                    break;
                case moveType.LampTown_TO_HardwareStore:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 0);
                    break;
                case moveType.HardwareStore_TO_LampTown:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 0);
                    break;
                case moveType.Lamptown_TO_warehouse:                   
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);    
                    break;
                case moveType.Lamptown_TO_TOP:
                    if (isDown == false)
                    {
                        SetObject(languageController.Instance.GetText(languageController.ObjectType.up), uiElement, this.gameObject, 110, 0);
                    }
                    else
                    {
                        SetObject(languageController.Instance.GetText(languageController.ObjectType.down), uiElement, this.gameObject, 110, 0);
                    }
                    break;
                case moveType.TOP_TO_Lamptown:
                    if (isDown == false)
                    {
                        SetObject(languageController.Instance.GetText(languageController.ObjectType.up), uiElement, this.gameObject, 110, 0);
                    }
                    else
                    {
                        SetObject(languageController.Instance.GetText(languageController.ObjectType.down), uiElement, this.gameObject, 110, 0);
                    }
                    break;
                case moveType.non:
                    if (isDown == false)
                    {
                        SetObject(languageController.Instance.GetText(languageController.ObjectType.up), uiElement, this.gameObject, 110, 0);
                    }
                    else
                    {
                        SetObject(languageController.Instance.GetText(languageController.ObjectType.down), uiElement, this.gameObject, 110, 0);
                    }
                    break;
                case moveType.SteelDoor_TO_chapel:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.chapel_TO_SteelDoor:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;

                case moveType.SKYTown_TO_Domitory:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.Domitory_TO_SKYTown:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.StaffOnly:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.SKYtonw_TO_Storage:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.Storage_TO_SKYtown:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;


                case moveType.SKYTown_TO_FarmRoom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.FarmRoom_TO_SKYTown:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;

                case moveType.SKYtown_TO_orchard:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.orchard_TO_SKYTown:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;

                case moveType.orchard_TO_Farm:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.Farm_TO_orchard:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;

                case moveType.Farm_TO_Warehouse:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.Warehouse_TO_Farm:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;

                case moveType.Warehouse_TO_ManagerRoom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.ManagerRoom_TO_Init:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;
                case moveType.ManagerRoom_TO_WareHouse:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 110, 10);
                    break;


                case moveType.Factory_TO_Machineroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.Machineroom_TO_Factory:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 60, -50);
                    break;
                case moveType.Factory_TO_Pharmacy:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.Pharmacy_TO_Factory:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;

                case moveType.MachineBottom_TO_MachineTop:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.MachineTop_TO_MachineBottom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.MachineTop_TO_Factorymanagerroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.Factorymanagerroom_TO_FactoryTop:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.FactoryTop_TO_restroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.restroom_TO_FactoryTop:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                    //여긴 한번더 확인
                case moveType.FactoryTop_TO_Mainfactoryroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.MainFactoryroom_TO_FactoryTOP:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.MainFactoryRoom_TO_some:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.Mainfactoryroom_TO_emergencyarea:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.emergencyarea_TO_Mainfactoryroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.Mainfactoryroom_TO_anchorroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.anchorroom_TO_Mainfactoryroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.Mainfactoryroom_TO_powerroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.powerroom_TO_Mainfactoryroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;
                case moveType.anchorroom_TO_submarinerroom:
                    SetObject(languageController.Instance.GetText(languageController.ObjectType.move), uiElement, this.gameObject, 50, 10);
                    break;      
            }

        }
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }

  
}

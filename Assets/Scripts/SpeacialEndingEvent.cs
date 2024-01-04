using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class SpeacialEndingEvent : MonoBehaviour
{
    public GameObject CanNotPanel;
    public GameObject Ending;
    public GameObject EndingCard;
    public GameObject EventBlock;
    public Transform HugPos;
    public DialogueSystemTrigger FarmConversation;
    public GameObject OldMan;
    public GameObject OldMnaSon;

    public Transform FarmStart;
    public Transform FarmEnd;
    public GameObject PupOwner;
    public Transform SonStartPos;
    public Transform SonEndPos;
    public GameObject Son;

    public DialogueSystemTrigger LamptownDialogue;
    public GameObject LampTownMan;
    public Transform LamptownManInit;
    public Transform LamptownManEnd;
    public GameObject EventObject;
    public GameObject EventPlayer;

    public Transform EventStartPos;
    public Transform LampTownPos;
    bool setRain = false;
    private void Start()
    {
        EventBlock.GetComponent<DisablePanelAnimaition>().StartAnimEventHandler += SpeacialEndingEvent_StartAnimEventHandler;
    }

    private void SpeacialEndingEvent_StartAnimEventHandler()
    {
        
        StartCoroutine(EventStartRoutine());
    }

    public void CheckEffect(bool flag)
    {
        //if (flag == true)
        //{
        //    if (GameManager.Instance.cameraEffectController.isRain)
        //    {
        //        GameManager.Instance.cameraEffectController.SetRain(false);
        //        GameManager.Instance.RainChecker = true;
        //    }
        //    else
        //    {
        //        GameManager.Instance.RainChecker = false;
        //    }
        //}
        //else
        //{
        //    if (GameManager.Instance.RainChecker)
        //    {
        //        GameManager.Instance.cameraEffectController.SetRain(true);
        //        GameManager.Instance.RainChecker = false;
        //    }
        //}
    }
    public void EndEvent()
    {
        GameManager.Instance.SetCameraTarget(FarmEnd.gameObject, 0f);
        StartHugEvent();
    }
    public void EndPup()
    {
        //UIManager.Instance.SetPositionText(GameManager.RoomPosition.lampTown);        
        StartCoroutine(FarmEventRoutine());
    }
    IEnumerator FarmEventRoutine()
    {
        yield return new WaitForSeconds(2f);
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.Hidden_Farm);
        UIManager.Instance.Block.SetActive(true);
        yield return new WaitForSeconds(2f);
        PlayerAnim.Play("idle");
        UIManager.Instance.SetPositionText(GameManager.RoomPosition.Farm);
        EventPlayer.transform.position = FarmStart.position;
        UIManager.Instance.Block.GetComponent<DOTweenAnimation>().DOPlayBackwards();
        yield return new WaitForSeconds(1f);
        PlayerAnim.SetFloat("speed", 1);
        EventPlayer.transform.DOMove(FarmEnd.position, 7).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Block.SetActive(false);
        yield return new WaitForSeconds(6f);
        PlayerAnim.SetFloat("speed", 0);
        yield return new WaitForSeconds(1f);
        DialogueManager.StartConversation(FarmConversation.conversation, OldMan.transform);
        OldMan.GetComponent<Animator>().Play("idle");
        OldMnaSon.GetComponent<Animator>().Play("idle");
    }
    public void StartPupEvent()
    {
        PupOwner.GetComponent<Animator>().Play("_dd_motion_3");
    }
    public void StartHugEvent()
    {
        EventPlayer.transform.DOMove(HugPos.position, 2).SetEase(Ease.Linear).OnComplete(EventEndHug);
        PlayerAnim.SetFloat("speed", 1);
    }
    void EventEndHug()
    {
        PlayerAnim.SetFloat("speed", 0);
        OldMan.SetActive(false);
        PlayerAnim.Play("Event_Hug");
        StartCoroutine(EndEventSecen());
    }
    public void Test()
    {
        StartCoroutine(EndEventSecen());
    }
    IEnumerator EndEventSecen()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.Instance.Block.SetActive(true);
        Ending.SetActive(true);
        yield return new WaitForSeconds(6f);        
        EndingCard.SetActive(true);
        yield return new WaitForSeconds(1f);
        Ending.GetComponent<Animator>().Play("Back_ending");                
        yield return new WaitForSeconds(2);
        GameManager.Instance.SetPlayerCamera();
        UIManager.Instance.SetPositionText(GameManager.Instance.roomPosition);
        UIManager.Instance.SetBottomRect(isBottom);
        UIManager.Instance.SetTopMenuCanvas(1);        
        
        yield return new WaitForSeconds(5f);
        End();
        EndingCard.GetComponent<Animator>().Play("Back_ending");
        UIManager.Instance.MenuPanel.GetComponent<CanvasGroup>().alpha = 1;
        UIManager.Instance.MenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        UIManager.Instance.MemoryCardPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Block.GetComponent<DOTweenAnimation>().DOPlayBackwards();
        yield return new WaitForSeconds(1.5f);
        UIManager.Instance.Block.SetActive(false);
        EventObject.SetActive(false);
        UIManager.Instance.WindowPointer.SetActive(true);
    }
    public void EndSonEvent()
    {
        GameManager.Instance.SetCameraTarget(EventPlayer, 1f);
        Son.transform.localScale = new Vector3(4, 4, 4);
        Son.GetComponent<Animator>().Play("run");
        Son.transform.DOMove(SonStartPos.position, 3).SetEase(Ease.Linear);
    }
    public void StartSonEvent()
    {
        GameManager.Instance.SetCameraTarget(Son, 1f);
        StartCoroutine(SonRoutine());
    }
    IEnumerator SonRoutine()
    {
        yield return new WaitForSeconds(1f);
        Son.GetComponent<Animator>().Play("run");
        Son.transform.DOMove(SonEndPos.position, 3).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3f);
        Son.GetComponent<Animator>().Play("idle");
    }
    void CheckBGM()
    {
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.CreditBGM);
    }
    public void Drink()
    {
        PlayerAnim.Play("Event_Drink");
    }
    void End()
    {
        UIManager.Instance.SoundSetting();
        CheckEffect(false);
        LightSetting();
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    GameManager.RoomPosition beforRoom;
    bool isBottom = false;
    public void StartEndingEvnet()
    {
        if (GameManager.Instance.gameStatus != GameManager.GameStatus.NOTING)
        {
            CanNotPanel.SetActive(true);
            return;
        }
        UIManager.Instance.WindowPointer.SetActive(false);
        ES3.Save("isSpeacialEnding", true);
        GameManager.Instance.isSpeacialEnding = true;

        EventObject.SetActive(true);
        UIManager.Instance.SetTopMenuCanvas(0);
        
        EventBlock.SetActive(true);
        OldMan.SetActive(true);
        isBottom = UIManager.Instance.isBottom;
        OldMan.GetComponent<Animator>().Play("_dd_motion_13");
        OldMnaSon.GetComponent<Animator>().Play("_dd_motion_14");
        beforRoom = GameManager.Instance.roomPosition;
        UIManager.Instance.SetPositionText(GameManager.RoomPosition.lampTown);
        PupOwner.GetComponent<Animator>().Play("lamp_town_npc_pub");
        Son.transform.position = SonStartPos.position;
        Son.transform.localScale = new Vector3(-4, 4, 4);
        EventPlayer.transform.localScale = new Vector3(4, 4, 4);
        CheckBGM();
        UIManager.Instance.MenuPanel.GetComponent<CanvasGroup>().alpha = 0;
        UIManager.Instance.MenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        UIManager.Instance.MemoryCardPanel.SetActive(false);
        UIManager.Instance.MemoryCardObjectPanel.SetActive(false);
    //꺼질때 여기 비 확인
        CheckEffect(true);
        PlayerAnim = EventPlayer.GetComponent<Animator>();
        PlayerAnim.Play("idle");
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        UIManager.Instance.DragTutorial.SetActive(false);
        UIManager.Instance.SetBottomRect(false);
        GameManager.Instance.TurnLight(false);
        EventPlayer.transform.position = EventStartPos.position;
        GameManager.Instance.SetCameraTarget(EventStartPos.gameObject, 1f);
    }
    Animator PlayerAnim;
    IEnumerator EventStartRoutine()
    {
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.Hidden_Lamptown);
        yield return new WaitForSeconds(2f);
        Vector3 newPos = EventPlayer.transform.position;
        newPos.x = 52;
        EventPlayer.transform.DOMove(newPos, 3).SetEase(Ease.Linear);
        PlayerAnim.SetFloat("speed", 1);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Block.SetActive(true);
        yield return new WaitForSeconds(2f);
        PlayerAnim.SetFloat("speed", 0);
        EventPlayer.transform.position = LampTownPos.position;
        GameManager.Instance.SetCameraTarget(EventPlayer, 0.2f);
        UIManager.Instance.Block.GetComponent<DOTweenAnimation>().DOPlayBackwards();
        yield return new WaitForSeconds(1f);        
        newPos.x = 0;
        EventPlayer.transform.DOMove(newPos, 8).SetEase(Ease.Linear);
        PlayerAnim.SetFloat("speed", 1);
        StartCoroutine(EventLamp());
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Block.SetActive(false);
        yield return new WaitForSeconds(7f);
        PlayerAnim.SetFloat("speed", 0);
        DialogueManager.StartConversation(LamptownDialogue.conversation, PupOwner.transform);
    }
    IEnumerator EventLamp()
    {
        LampTownMan.transform.position = LamptownManInit.position;
        LampTownMan.transform.DOMove(LamptownManEnd.position, 5f).SetEase(Ease.Linear);
        LampTownMan.GetComponent<Animator>().Play("_dd_motion_7");
        yield return new WaitForSeconds(5f);
        LampTownMan.GetComponent<Animator>().Play("_dd_motion_6");
    }
    public void LightSetting()
    {
        switch (GameManager.Instance.roomPosition)
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
            case GameManager.RoomPosition.FarmManagerRoom_H:
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

            case GameManager.RoomPosition.SearchRoom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.PartyRoom:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.Pool:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.Prison:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.Cliff:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.Passage:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.Kitchen:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.residentialarea:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.School:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.Fountain:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.EmergencyLadder:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.Hallway_1:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.Recodingroom:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.Hallway_2:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.wheelhouse:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.hallway_3:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.steeldoor:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.Part6_steeldoor:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.hallway_4:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.leadersroom:
                GameManager.Instance.TurnLight(false);
                break;
            case GameManager.RoomPosition.schooIn:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.ProfessorRoom:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.sewer:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.LightHouse:
                GameManager.Instance.TurnLight(true);
                break;
            case GameManager.RoomPosition.LightHouseLadder:
                GameManager.Instance.TurnLight(false);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using DG.Tweening;
using UnityEngine.UI;
public class ChangeSceneNpc : MonoBehaviour
{
    public GameObject AnchorObject;
    public GameObject UIElement;

    public List<GameObject> ShipMembers;
    public Transform evnetPlayerPos;
    public GameObject Enemy;
    public GameObject CameraPos;
    public GameObject Blood;
    public DOTweenAnimation shipAnim;
    public enum NextPosType
    {
        ship,
        room,
        seawork
    }
    public GameObject RemotePos;
    private bool isStart = false;
    public NextPosType posType;
    void Start()
    {
        //systemTrigger = GetComponent<DialogueSystemTrigger>();        
    }
    public void OnEndConversation()
    {
        if(isStart)
        {
            switch(posType)
            {
                case NextPosType.ship:
                    TestCodeManager.Instance.startShip();
                    break;
                case NextPosType.room:
                    ShakeCamera();
                    break;                
            }
        }        
        if(bStartEvent)
        {
            ShipEventStart();
            bStartEvent = false;
        }
    }
    public void ShakeCamera()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        GetComponent<BoxCollider2D>().enabled = false;
        //UIManager.Instance.Part0Effect.SetActive(true);
        //GameManager.Instance.cinemachineCamera.transform.DOShakeRotation(1, new Vector3(1, 1, 1)).SetLoops(2);
        GameManager.Instance.cameraEffectController.SetEarthQuake(true);
        StartCoroutine(RoomStartRoutine());
        
    }

    bool isConversationStart = false;
    private void Instance_OnCompleteEventChangeEndHandler()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        UIManager.Instance.OnCompleteEventChangeEndHandler -= Instance_OnCompleteEventChangeEndHandler;
        isConversationStart = true;
        DialogueManager.StartConversation("shipMono");
    }

    private void Instance_OnCompleteEventChangeHandler()
    {
        for (int i = 0; i < ShipMembers.Count; i++)
        {
            ShipMembers[i].SetActive(false);
        }
        Enemy.SetActive(true);
        this.transform.localScale = new Vector3(-1, 1, 1);
        GetComponent<Animator>().Play("dead_idle");
        SoundsManager.Instance.PlayGunBGM();
        GameManager.Instance.SetCameraTarget(CameraPos, 0.2f);
        StartCoroutine(ChangeCameraRoutine());
        UIManager.Instance.OnCompleteEventChangeHandler -= Instance_OnCompleteEventChangeHandler;
    }
    
    IEnumerator ChangeCameraRoutine()
    {
        float value = 0.1f;
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.cameraEffectController.wideScreenH.enabled = true;
        for (int i = 0; i < 20; i++)
        {
            GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize -= value;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator RoomStartRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        UIManager.Instance.SetScenesChangeViewEnable_ShipEvent(languageController.SceneTextType.shipEvent, evnetPlayerPos);


        //TestCodeManager.Instance.RoomStart();        
        //UIManager.Instance.Part0Effect.SetActive(false);

    }

    public void SetIsOn(bool flag)
    {
        isStart = flag;
    }
    public void BrokenEvent()
    {
        GameManager.Instance.cameraEffectController.SetEarthQuake(true);
        shipAnim.DOKill();
        UIManager.Instance.OnCompleteEventChangeHandler += Instance_OnCompleteEventChangeHandler;
        UIManager.Instance.OnCompleteEventChangeEndHandler += Instance_OnCompleteEventChangeEndHandler;
        StartCoroutine(EndSharkeRoutine());
        GameManager.Instance.isPart0Event = true;
    }
    IEnumerator EndSharkeRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.cameraEffectController.SetEarthQuake(false);
    }
    bool bStartEvent = false;
    public void BrokenEventStart()
    {
        bStartEvent = true;
    }
    void ShipEventStart()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        ShipMembers[4].GetComponent<Animator>().Play("event");
        //ShipMembers[3].GetComponent<Animator>().Play("event");
        GameManager.Instance.SetCameraTarget(ShipMembers[2], 0.2f);
        ShipMembers[2].GetComponent<Animator>().Play("walking");
        ShipMembers[2].transform.DOMoveX(RemotePos.transform.position.x, 5.5f).SetEase(Ease.Linear).OnComplete(StartRemote);
    }
    void StartRemote()
    {
        ShipMembers[2].GetComponent<Animator>().Play("remote");
        StartCoroutine(EndRemoteRoutine());
    }
    IEnumerator EndRemoteRoutine()
    {
        AnchorObject.GetComponent<Animator>().Play("start");        
        yield return new WaitForSeconds(1.2f);
        GameManager.Instance.SetPlayerCamera(1f);
        ShipMembers[2].GetComponent<Animator>().Play("idle");
        //GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.quest);
        DialogueLua.SetQuestField("Part0Quest", "State", "active");
        UIManager.Instance.CheckQuestGuide();
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    // Update is called once per frame
    void StartEvent()
    {
        UIElement.SetActive(true);
        UIElement.GetComponent<UiTargetManager>().WorldObject = Enemy;
        UIElement.GetComponent<UiTargetManager>().y_Margin = 130;
        UIElement.GetComponent<UiTargetManager>().x_Margin = -70;
        
        StartCoroutine(Typing(UIElement.transform.Find("Text").GetComponent<Text>(),languageController.Instance.GetGunEventConversation(0),0.1f));
    }

    IEnumerator ChangeCameraRoutineOut()
    {
        float value = 0.1f;
        float yMarginValue = 3;
        //GameManager.Instance.cameraEffectController.wideScreenH.enabled = false;
        for (int i = 0; i < 20; i++)
        {
            GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize += value;
            UIElement.GetComponent<UiTargetManager>().y_Margin -= yMarginValue;
            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize = 5;
    }
    public void ShotGun()
    {
        StartCoroutine(GunShotRoutine());
        GetComponent<Animator>().Play("dead_motion");
        Blood.SetActive(true);
    }
    IEnumerator GunShotRoutine()
    {
        UIElement.SetActive(false);
        //총 쏘는 애니메이션
        //날라가는 애니메이션
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunBig);
        GameManager.Instance.cameraEffectController.ShipHit();
        yield return new WaitForSeconds(2.5f);
        //다시 Idle모션
        UIElement.SetActive(true);
        UIElement.GetComponent<UiTargetManager>().WorldObject = Enemy;
        UIElement.GetComponent<UiTargetManager>().y_Margin = 70;
        UIElement.GetComponent<UiTargetManager>().x_Margin = -70;

        for (int i = 0; i < languageController.Instance.GetGunEventConversation(2).Length; i++)
        {
            UIElement.transform.Find("Text").GetComponent<Text>().text = languageController.Instance.GetGunEventConversation(2).Substring(0, i + 1);
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.typing);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2.2f);
        UIElement.SetActive(false);
        yield return new WaitForSeconds(1f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunInit);
        yield return new WaitForSeconds(0.3f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunBig);
        GameManager.Instance.cameraEffectController.BulletHit(true);
        yield return new WaitForSeconds(0.2f);
        CameraPlay.FadeInOut(0.2f);
        yield return new WaitForSeconds(0.3f);
        CameraPlay.FadeInOut(0.2f);
        yield return new WaitForSeconds(0.3f);
        CameraPlay.FadeInOut(0.2f);
        yield return new WaitForSeconds(0.3f);
        CameraPlay.FadeInOut(0.2f);

        Debug.Log("감옥 시작");
        TestCodeManager.Instance.RoomStart();        
        UIManager.Instance.Part0Effect.SetActive(false);
    }
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.typing);
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(1.5f);
        UIElement.GetComponent<UiTargetManager>().WorldObject = this.gameObject;
        UIElement.GetComponent<UiTargetManager>().y_Margin = 130;
        UIElement.GetComponent<UiTargetManager>().x_Margin = -70;
        
        for (int i = 0; i < languageController.Instance.GetGunEventConversation(1).Length; i++)
        {
            typingText.text = languageController.Instance.GetGunEventConversation(1).Substring(0, i + 1);
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.typing);
            yield return new WaitForSeconds(speed);
            if(i ==3)
            {
                
                StartCoroutine(ChangeCameraRoutineOut());
                //여기서 총 을 올리는 애니메이션
                Enemy.GetComponent<Animator>().Play("gun");
                Enemy.transform.Find("effect").gameObject.SetActive(true);
                SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunInit);
            }
        }        
       

    }
    void Update()
    {
        if(isConversationStart)
        {
            if (DialogueManager.isConversationActive == false)
            {
                StartEvent();
                isConversationStart = false;
            }
        }
        
    }
}

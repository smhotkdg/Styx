using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class GuardGame_Controller : MonoBehaviour
{
    
    public GameObject Top;
    public GameObject Bottom;
    public GameObject Left;
    public GameObject Right;
    public GameObject GaurdTemp;
    public List<GameObject> EnemyList = new List<GameObject>();
    public List<GameObject> EnemyListDie = new List<GameObject>();
    public List<GameObject> BulletList;
    int MakeCount = 0;
    //int bulletCount = 20;
    int KillCount = 0;
    IEnumerator MakeRoutineEvent;
    bool isGameStart = false;

    Vector2 InitTop;
    Vector2 InitBottom;
    Vector2 InitLeft;
    Vector2 InitRight;
    private void Awake()
    {
        InitLeft = Left.transform.localPosition;
        InitRight = Right.transform.localPosition;
        InitTop = Top.transform.localPosition;
        InitBottom = Bottom.transform.localPosition;
    }
    public void StartGame()
    {
        shootCount = 0;
        KillCount = 0;
        MakeRoutineEvent = MakeRoutine();
        for (int i = 0; i < BulletList.Count; i++)
        {
            BulletList[i].SetActive(true);
        }
        isGameStart = true;
        MakeCount = 0;
        MakeTime = 1;
        //bulletCount = 20;
        StartCoroutine(MakeRoutineEvent);
    }
    float MakeTime = 1f;
    [SerializeField]
    float respwanDeltaTime = 0.03f;
    IEnumerator MakeRoutine()
    {
        if (MakeCount < 20 && isGameStart == true)
        {
            yield return new WaitForSeconds(MakeTime);
            if (isGameStart == true)
            {
                GameObject temp = Instantiate(GaurdTemp);
                temp.transform.SetParent(GaurdTemp.transform.parent);
                temp.transform.localScale = GaurdTemp.transform.localScale;
                temp.transform.localPosition = GaurdTemp.transform.localPosition;
                int rand = Random.Range(0, 4);

                temp.GetComponent<GuardGame_Guard>().SelectIndex = rand;

                temp.GetComponent<GuardGame_Guard>().SetUI();

                temp.GetComponent<GuardGame_Guard>().speed = 2 + (MakeCount * 0.01f);
                temp.SetActive(true);
                temp.GetComponent<Animator>().SetFloat("speed", 1);
                EnemyList.Add(temp);
                MakeCount++;
                //MakeTime -= respwanDeltaTime;
                StartCoroutine(MakeRoutine());
            }
        }

    }
    public void AllStop()
    {
        isGameStart = false;
        StopCoroutine(MakeRoutineEvent);
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].GetComponent<GuardGame_Guard>().bMove = false;
            EnemyList[i].GetComponent<GuardGame_Guard>().DisableUI();
            if (i != 0)
            {
                EnemyList[i].GetComponent<GuardGame_Guard>().setIdle();
            }
        }
    }

    public void EndGame_NotDestory()
    {      
        for (int i = 0; i < BulletList.Count; i++)
        {
            BulletList[i].SetActive(true);
        }
        Left.transform.localPosition = InitLeft;
        Right.transform.localPosition = InitRight;
        Top.transform.localPosition = InitTop;
        Bottom.transform.localPosition = InitBottom;
    }
    public void EndGame()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            Destroy(EnemyList[i]);
        }
        for(int i=0; i< EnemyListDie.Count; i++)
        {
            Destroy(EnemyListDie[i]);
        }
        EnemyListDie.Clear();
        EnemyList.Clear();
        for (int i = 0; i < BulletList.Count; i++)
        {
            BulletList[i].SetActive(true);
        }
        Left.transform.localPosition = InitLeft;
        Right.transform.localPosition = InitRight;
        Top.transform.localPosition = InitTop;
        Bottom.transform.localPosition = InitBottom;
    }
    public void CheckBullet()
    {
        //int Count = 20 - bulletCount;
        //for(int i =0; i< Count;i++)
        //{
        //    if(BulletList[i].activeSelf ==true)
        //    {
        //        BulletList[i].SetActive(false);
        //        Vector3 jumpVector = BulletList[i].transform.position;
        //        jumpVector.y = jumpVector.y + 30;
        //        BulletList[i].transform.DOJump(jumpVector, 2, 1, 0.3f);
        //        StartCoroutine(JumpEnd(i));
        //    }            
        //}

        //BulletList[shootCount].SetActive(false);
        Vector3 intPos = BulletList[shootCount].transform.position;
        Vector3 jumpVector = BulletList[shootCount].transform.localPosition;

        //BulletList[shootCount].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        BulletList[shootCount].GetComponent<Rigidbody2D>().gravityScale = 20;

        int xRand = Random.Range(-20, 30);
        int yRand = Random.Range(50, 100);
        jumpVector.x = jumpVector.x + xRand;
        jumpVector.y = jumpVector.y - yRand;
        int RandJumpPower = Random.Range(3, 6);
        BulletList[shootCount].transform.DOLocalJump(jumpVector, RandJumpPower, 1, 0.1f);
        
        StartCoroutine(JumpEnd(shootCount, intPos));
    }
    int shootCount;
    IEnumerator JumpEnd(int index,Vector3 pos)
    {
        yield return new WaitForSeconds(1.2f);
        BulletList[index].SetActive(false);
        //BulletList[index].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        BulletList[index].GetComponent<Rigidbody2D>().gravityScale = 0;
        BulletList[index].transform.position = pos;
    }
    public void Shoot(int index)
    {        
        if (isGameStart == false)
            return;
        //if (bulletCount <= 0)
        //{
        //    return;
        //}
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        //bulletCount--;
        GameManager.Instance.playerController.ShootGunHallway();
        //GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        if (EnemyList.Count >0)
        {
            if(EnemyList[0].GetComponent<GuardGame_Guard>().SelectIndex == index)
            {
                
                EnemyList[0].GetComponent<GuardGame_Guard>().Dead();
                EnemyListDie.Add(EnemyList[0]);
                EnemyList.RemoveAt(0);
                KillCount++;
                if (KillCount == 2)
                {
                    ChangeLeftRight_BottomTop();
                }
                if (KillCount == 5)
                {
                    RotateChange();
                }
                if(KillCount ==8)
                {
                    RotateChange2();
                }
                if(KillCount ==11)
                {
                    XChange();
                }
                if(KillCount == 14)
                {
                    XChange_2();
                }
                if (KillCount == 17)
                {
                    XChange_3();
                }
                if (KillCount == 20)
                //if (KillCount == 1)
                {
                    isGameStart = false;
                    
                    GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;                    
                    if (GameManager.Instance.data.isChoiceMember == 1)
                    {
                        UIManager.Instance.GunGameUI.SetActive(false);
                        GameManager.Instance.styxData.Part5_1EventCount = 23;
                    }
                    else
                    {
                        UIManager.Instance.GunGameUI_2.SetActive(false);
                    }
                    if (GameManager.Instance.data.isChoiceMember == 1)
                    {
                        DialogueLua.SetVariable("Part5_1EventCount", GameManager.Instance.styxData.Part5_1EventCount);
                        DialogueManager.StartConversation(UIManager.Instance.Part6_Cult.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
                                                    UIManager.Instance.Part6_Cult.transform);
                        UIManager.Instance.Part6_Cult.GetComponent<Animator>().Play("idle");
                    }
                    else
                    {
                        GameManager.Instance.styxData.Part5_2EventCount = 27;
                        DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);
                        DialogueManager.StartConversation(UIManager.Instance.Part6_2Hardware.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
                                                    UIManager.Instance.Part6_2Hardware.transform);
                        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().Play("idle");
                        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().Play("idle");
                    }                    
                    GameManager.Instance.playerController.SetForceIdle();
                    StartCoroutine(ChangeCameraPlus());
                    StartCoroutine(ChangeCameraPlus_ori());
                    AllStop();
                    EndGame_NotDestory();
                    Debug.Log("총쏘기 성공");
                }                
            }
        }
        CheckBullet();
        shootCount++;
    }
    IEnumerator ChangeCameraPlus_ori()
    {
        for (int i = 0; i < 50; i++)
        {
            GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize-= 0.05f;
            GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY -= 0.0005f;
            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = 0.53f;
        GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize = 5f;
    }
    IEnumerator ChangeCameraPlus()
    {
        //UIManager.Instance.GunGameUI.SetActive(true);
        for (int i = 0; i < 50; i++)
        {
            GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenX += 0.006f;
            yield return new WaitForSeconds(0.01f);
        }

        GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenX = 0.5f;                
    }
    void ChangeLeftRight_BottomTop()
    {
        Top.transform.DOLocalMove(InitBottom, 1f).SetEase(Ease.OutBack);
        Bottom.transform.DOLocalMove(InitTop, 1f).SetEase(Ease.OutBack);

        Left.transform.DOLocalMove(InitRight, 1f).SetEase(Ease.OutBack);
        Right.transform.DOLocalMove(InitLeft, 1f).SetEase(Ease.OutBack);
    }
    void RotateChange()
    {
        Top.transform.DOLocalMove(InitLeft, 1f).SetEase(Ease.OutBack);
        Bottom.transform.DOLocalMove(InitRight, 1f).SetEase(Ease.OutBack);

        Left.transform.DOLocalMove(InitBottom, 1f).SetEase(Ease.OutBack);
        Right.transform.DOLocalMove(InitTop, 1f).SetEase(Ease.OutBack);
    }
    void RotateChange2()
    {
        Top.transform.DOLocalMove(InitTop, 1f).SetEase(Ease.OutBack);
        Bottom.transform.DOLocalMove(InitBottom, 1f).SetEase(Ease.OutBack);

        Left.transform.DOLocalMove(InitLeft, 1f).SetEase(Ease.OutBack);
        Right.transform.DOLocalMove(InitRight, 1f).SetEase(Ease.OutBack);
    }
    void XChange()
    {
        Top.transform.DOLocalMove(InitLeft, 1f).SetEase(Ease.OutBack);
        Bottom.transform.DOLocalMove(InitRight, 1f).SetEase(Ease.OutBack);

        Left.transform.DOLocalMove(InitTop, 1f).SetEase(Ease.OutBack);
        Right.transform.DOLocalMove(InitBottom, 1f).SetEase(Ease.OutBack);
    }

    void XChange_2()
    {
        Top.transform.DOLocalMove(InitRight, 1f).SetEase(Ease.OutBack);
        Bottom.transform.DOLocalMove(InitLeft, 1f).SetEase(Ease.OutBack);

        Left.transform.DOLocalMove(InitBottom, 1f).SetEase(Ease.OutBack);
        Right.transform.DOLocalMove(InitTop, 1f).SetEase(Ease.OutBack);
    }

    void XChange_3()
    {
        Top.transform.DOLocalMove(InitTop, 1f).SetEase(Ease.OutBack);
        Bottom.transform.DOLocalMove(InitBottom, 1f).SetEase(Ease.OutBack);

        Left.transform.DOLocalMove(InitRight, 1f).SetEase(Ease.OutBack);
        Right.transform.DOLocalMove(InitLeft, 1f).SetEase(Ease.OutBack);
    }
}

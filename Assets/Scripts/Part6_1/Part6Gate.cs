using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Part6Gate : ObjectChekcer
{
    
    public GameObject GameUI;
    public GameObject uiElement;
    public Animator Door;
    private void OnEnable()
    {
        bClose = true;
    }
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        GameUI.GetComponent<SelectWordNumberGame>().OnFindEventHandler += Part6Gate_OnFindEventHandler;
    }

    private void Part6Gate_OnFindEventHandler(string number)
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        if(GameManager.Instance.data.isChoiceMember ==2)
        {
            if (number == "752")
            {
                Debug.Log("게이트 열기");
                bClose = true;
                StartCoroutine(GateRoutine2());
                GameUI.SetActive(false);
            }
        }
        else
        {
            if (number == "503")
            {
                Debug.Log("게이트 열기");
                StartCoroutine(GateRoutine());
                GameUI.SetActive(false);
            }
        }
    
    }
    IEnumerator GateRoutine2()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        Door.Play("open");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.DOOR);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.playerController.animator.SetFloat("speed", 1);
        if (GameManager.Instance.Player.transform.position.x > transform.position.x)
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        }
        GameManager.Instance.cinemachineCamera.m_Follow = null;
        GameManager.Instance.Player.transform.DOMove(transform.position, Vector2.Distance(GameManager.Instance.Player.transform.position, transform.position)).SetEase(Ease.Linear).OnComplete(MoveEndPlayer_2);

        UIManager.Instance.Part6_2Hardware.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_2LamptownManager.GetComponent<FollowObject>().isFollow = false;

        if (UIManager.Instance.Part6_2Hardware.transform.position.x > transform.position.x)
        {
            UIManager.Instance.Part6_2Hardware.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            UIManager.Instance.Part6_2Hardware.transform.localScale = new Vector3(-4, 4, 4);
        }

        if (UIManager.Instance.Part6_2LamptownManager.transform.position.x > transform.position.x)
        {
            UIManager.Instance.Part6_2LamptownManager.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            UIManager.Instance.Part6_2LamptownManager.transform.localScale = new Vector3(-4, 4, 4);
        }

        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_2Hardware.transform.DOMove(transform.position, 
            Vector2.Distance(UIManager.Instance.Part6_2Hardware.transform.position, transform.position)).SetEase(Ease.Linear).OnComplete(Moveend_1);

        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_2LamptownManager.transform.DOMove(transform.position,
            Vector2.Distance(UIManager.Instance.Part6_2LamptownManager.transform.position, transform.position)).SetEase(Ease.Linear).OnComplete(Moveend_2);
    }
    void Moveend_2()
    {
        UIManager.Instance.Part6_2LamptownManager.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_2LamptownManager.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1).OnComplete(Move_End3);
    }
    void Moveend_1()
    {
        UIManager.Instance.Part6_2Hardware.GetComponent<Animator>().SetFloat("speed", 0);
        UIManager.Instance.Part6_2Hardware.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
    }
    void MoveEndPlayer_2()
    {
        GameManager.Instance.playerController.animator.SetFloat("speed", 0);
        GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1).OnComplete(EndGate_2);
        
    }
    void Move_End3()
    {
        //Door.Play("close");
    }
    void EndGate_2()
    {        
        StartCoroutine(StartHallway2());
    }
    bool bClose = true;
    IEnumerator StartHallway2()
    {
        yield return new WaitForSeconds(1f);    
        //TestCodeManager.Instance.StartPart6_Hallway4();
        //여기서 이동~!
        while(bClose)
        {
            if (GameManager.Instance.Player.GetComponent<SpriteRenderer>().color.a < 0.1f && UIManager.Instance.Part6_2LamptownManager.GetComponent<SpriteRenderer>().color.a < 0.1f
                && UIManager.Instance.Part6_2Hardware.GetComponent<SpriteRenderer>().color.a < 0.1f)
            {
                bClose = false;
            }
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1f);
        Door.Play("close");
        yield return new WaitForSeconds(1f);
        TestCodeManager.Instance.StartPart6_2_Hallway4();
        yield return new WaitForSeconds(3f);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator GateRoutine()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        Door.Play("open");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.DOOR);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Part6_Cult.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_Ememy.GetComponent<FollowObject>().isFollow = false;

        if(UIManager.Instance.Part6_Ememy.transform.position.x > transform.position.x)
        {
            UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            UIManager.Instance.Part6_Ememy.transform.localScale = new Vector3(-4, 4, 4);
        }
        if (UIManager.Instance.Part6_Cult.transform.position.x > transform.position.x)
        {
            UIManager.Instance.Part6_Cult.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            UIManager.Instance.Part6_Cult.transform.localScale = new Vector3(-4, 4, 4);
        }

        UIManager.Instance.Part6_Cult.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_Cult.transform.DOMove(transform.position, Vector2.Distance(UIManager.Instance.Part6_Cult.transform.position, transform.position)).SetEase(Ease.Linear).OnComplete(MoveEndCult);        
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 1);
        UIManager.Instance.Part6_Ememy.transform.DOMove(transform.position, Vector2.Distance(UIManager.Instance.Part6_Ememy.transform.position, transform.position)).SetEase(Ease.Linear).OnComplete(MoveEndEnemy);        
            
    }
    IEnumerator StartPlayerRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.playerController.animator.SetFloat("speed", 1);
        if (GameManager.Instance.Player.transform.position.x > transform.position.x)
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        }
        GameManager.Instance.cinemachineCamera.m_Follow = null;
        GameManager.Instance.Player.transform.DOMove(transform.position, Vector2.Distance(GameManager.Instance.Player.transform.position, transform.position)).SetEase(Ease.Linear).OnComplete(MoveEndPlayer);
    }
    void MoveStartPlayer()
    {
        StartCoroutine(StartPlayerRoutine());
        
    }
    void MoveEndPlayer()
    {
        GameManager.Instance.playerController.animator.SetFloat("speed", 0);
        GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1).OnComplete(EndGate);
        GameManager.Instance.SetPlayerCamera();
    }
    void EndGate()
    {
        Door.Play("close");
        StartCoroutine(StartHallway());
    }
    bool bEndEmeny = false;
    IEnumerator StartHallway()
    {
        yield return new WaitForSeconds(2f);
        TestCodeManager.Instance.StartPart6_Hallway4();
        yield return new WaitForSeconds(3f);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
    public bool bEndCult = false;
    void MoveEndCult()
    {
        UIManager.Instance.Part6_Cult.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1);
        UIManager.Instance.Part6_Cult.GetComponent<Animator>().SetFloat("speed", 0);
        bEndCult = true;
        if(bEndCult==true && bEndEmeny)
        {
            MoveStartPlayer();
        }
    }
    void MoveEndEnemy()
    {
        UIManager.Instance.Part6_Ememy.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0),1);
        UIManager.Instance.Part6_Ememy.GetComponent<Animator>().SetFloat("speed", 0);
        bEndEmeny = true;
        if (bEndCult == true && bEndEmeny)
        {
            MoveStartPlayer();
        }
    }
    void Click()
    {
        if (AdManager.Instance.isShowPop == true)
        {
            if (AdManager.Instance.ShowPopAds())
            {
                return;
            }
        }
        GameUI.SetActive(true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {

        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();        
        SetObject(languageController.ObjectType.bed, uiElement, this.gameObject, 100);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

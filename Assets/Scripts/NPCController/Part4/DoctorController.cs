using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class DoctorController : MonoBehaviour
{
    public bool isRun = false;
    private Animator animator;
    private Vector2 initpos;
    public Transform PlayerPos;
    public frequencyGameManager frequencyGameManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
        initpos = transform.position;
        frequencyGameManager.OnCompleteEventHandler += FrequencyGameManager_OnCompleteEventHandler;
    }
    bool isMoveRinger = false;
    private void FrequencyGameManager_OnCompleteEventHandler()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        UIManager.Instance.setDialogue(this.gameObject, "어! 큰일이군",100,3);        
        isMoveRinger = true;
        animator.Play("walking");
        
    }

    
    public void SetInit()
    {
        transform.position = initpos;
        animator.Play("idle");
        isEvnet = false;
        isMove = false;
        GameManager.Instance.Player.transform.position = PlayerPos.position;
    }
    public void EndConversation()
    {
        if(isRun ==true)
        {
            DoctorEventStart();
            isRun = false;
        }
    }
    public void SetIsRun(bool isOn)
    {
        isRun = isOn;
    }
    [Button("이벤트 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DoctorEventStart()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
        StartCoroutine(DoctorEventRoutine());
    }
    bool isMove = false;
    IEnumerator DoctorEventRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        isMove = true;
        animator.Play("run");
    }
    bool isEvnet = false;
    private void Update()
    {
        if(isMove)
        {
            transform.position += new Vector3(-Time.deltaTime * 2f, 0);
            if(transform.localPosition.x < -5)
            {
                //땡땡 화면전환
                if(isEvnet ==false)
                {
                    ChangeScene();
                    isEvnet = true;
                }
                
            }
        }
        if(isMoveRinger)
        {
            transform.position += new Vector3(-Time.deltaTime * 1f, 0);
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
            if (transform.localPosition.x < -3)
            {
                isMoveRinger = false;
                GameManager.Instance.SetStatusNoting();
                GameManager.Instance.SetPlayerCamera();
                animator.Play("idle");
            }
        }
    }

    public void ChangeScene()
    {
        UIManager.Instance.SetScenesChangeViewEnable_DoctorEvent(languageController.SceneTextType.doctor, PlayerPos, 4,this.gameObject);

    }
}

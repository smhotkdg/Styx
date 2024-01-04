using SensorToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class FactoryManagerEvent_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueSystemTrigger dialogue;
    public RaySensor2D RaySensorFindPlayer;
    Animator animator;
    public Transform movePos;
    bool bMoveStart = false;
    
    public Vector2 initPos = new Vector2(0, 0);
    void Start()
    {
        initPos = transform.position;   
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        if (initPos.x != 0)
        {
            transform.position = initPos;
        }
    }
    public void EventStart()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        StartCoroutine(WalkRoutine());
    }
    IEnumerator WalkRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
        yield return new WaitForSeconds(1.5f);
        animator.SetFloat("speed", 1);
        
        bMoveStart = true;
    }
    private void Update()
    {
        if (bMoveStart == false)
            return;
        if (RaySensorFindPlayer.DetectedObjects.Count > 0)
        {
            //pCController.ForceConversation();            

            if (bMoveStart == true)
            {
                //animator.Play("idle");
                animator.SetFloat("speed", 0);
                bMoveStart = false;
                DialogueManager.StartConversation(dialogue.conversation, transform);
            }


        }

        transform.position += new Vector3(-Time.deltaTime, 0);
    }
    public void MoveFactoryManagerRoom()
    {
        UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.factorymanagerroom, movePos, 4);
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factorymanagerroom);
        this.gameObject.SetActive(false);
    }
}

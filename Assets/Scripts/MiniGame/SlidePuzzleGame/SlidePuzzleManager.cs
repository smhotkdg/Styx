using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using DG.Tweening;
public class SlidePuzzleManager : MonoBehaviour
{
    public InterfaceAnimManager DroneINterfaceAnim;
    public GameObject Drone;
    public List<PuzzleController> puzzleControllers;
    public OldmanPrision oldMan;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator.GetComponent<Animator>();
        for (int i =0; i < puzzleControllers.Count; i++)
        {
            puzzleControllers[i].onPuzzleEventHandler += SlidePuzzleManager_onPuzzleEventHandler;
        }
        
    }
    private void OnEnable()
    {
        animator.Play("DroneMakeAnim");
        //Drone.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 0.5f).SetEase(Ease.OutBack).From(true);
        
        
    }

    private void DroneINterfaceAnim_OnEndDisappear(InterfaceAnimManager _IAM)
    {
        DroneINterfaceAnim.OnEndDisappear -= DroneINterfaceAnim_OnEndDisappear;
        CompleteDroneUI();
        DroneINterfaceAnim.gameObject.SetActive(false);
    }

    private void SlidePuzzleManager_onPuzzleEventHandler()
    {
        CheckPuzzleEnd();
    }

    void CheckPuzzleEnd()
    {
        for(int i =0; i< puzzleControllers.Count; i++)
        {
            if(0 !=puzzleControllers[i].GetAngle())
            {
                //Debug.Log("아직 안됨");
                return;
            }
        }
        //드론 제작 완료

        //Drone.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 0.5f).SetEase(Ease.OutBack).From(true).OnComplete(CompleteTween);
        Drone.GetComponent<DOTweenAnimation>().DORestart();        
        animator.Play("DroneMakeAnimBack");
        StartCoroutine(MakeEndRoutine());
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.drone));


    }
    void CompleteTween()
    {
        StartCoroutine(MakeEndRoutine());     
    }
    IEnumerator MakeEndRoutine()
    {
        yield return new WaitForSeconds(0.7f);        
        DroneINterfaceAnim.gameObject.SetActive(true);
        DroneINterfaceAnim.startAppear();
        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.makeDronePanel.SetActive(false);
        DroneINterfaceAnim.OnEndDisappear += DroneINterfaceAnim_OnEndDisappear;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
    }
    public void CompleteDroneUI()
    {
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.drone);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
        TestCodeManager.Instance.DroneMake(false);
        if (oldMan.gameObject.activeSelf)
        {
            oldMan.EnableOldMan();
        }
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        Debug.Log("퍼즐 성공");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

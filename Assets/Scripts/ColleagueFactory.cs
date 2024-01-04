using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColleagueFactory : MonoBehaviour
{
    public GameObject Controller;
    public GameObject DoorObject;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.Find("NPCController").gameObject.SetActive(true);
        death = false;
        DoorObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if(death)
        {
            Controller.SetActive(false);
            return;
        }
        if(GameManager.Instance.data.isEscapeShip ==1)
        {
            Controller.SetActive(true);
        }
        else
        {
            Controller.SetActive(false);
        }
    }
    public void CheckEndConversation()
    {
        if(isGetPillQuest)
        {
            TestCodeManager.Instance.StartGetFillQuest(false);
            //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest), 2.5f);
            isGetPillQuest = false;
        }
        if(isSelectFarm)
        {
            isSelectFarm = false;
            if (GameManager.Instance.data.isStyxApp == false)
            {
                //if (GameManager.Instance.PartCoinList[3] == false)
                //{
                //    GameManager.Instance.buyCoinType = 3;
                //    UIManager.Instance.NeedCoinPanel.SetActive(true);
                //    return;
                //}
            }
          
            //농부동료 선택 고고고            
            //GetComponent<FollowObject>().isFollow = true;
            GameManager.Instance.Part5_1Start();
        }
        if(isDie)
        {
            isDie = false;
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            StartCoroutine(DieRoutine());
        }
    }
    bool isGetPillQuest = false;
    public void SetGetPillQuest()
    {
        isGetPillQuest = true;
    }
    public bool isSelectFarm = false;
    public void SelectFarmFriend()
    {
        isSelectFarm = true;
    }
    bool isDie = false;
    public void SetDie()
    {
        isDie = true;      
    }
    bool death = false;
    IEnumerator DieRoutine()
    {
        UIManager.Instance.SetBottomRect(false);
        GameManager.Instance.cameraEffectController.Zoom(0.6f,0.5f,15);
        animator.Play("drink");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.Drink);
        yield return new WaitForSeconds(4f);
        GameManager.Instance.cameraEffectController.Drunk(1.5f);
        UIManager.Instance.setDialogue(this.gameObject, languageController.Instance.GetColleagueDieText(0),100,2f);
        yield return new WaitForSeconds(3f);
        UIManager.Instance.setDialogue(this.gameObject, languageController.Instance.GetColleagueDieText(1),100,2f);
        yield return new WaitForSeconds(3f);
        animator.Play("dead");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.Body);
        death = true;

        yield return new WaitForSeconds(2f);
        DoorObject.SetActive(false);
        GameManager.Instance.StartPart4Ending_LamptownManager();
    }
}

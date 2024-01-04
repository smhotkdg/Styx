using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMachine : MonoBehaviour
{
    public Animator animatorWarning;
    public GameObject SearchMan;
    Vector2 InitPos;
    private void Start()
    {
        animatorWarning.Play("off");
        InitPos = SearchMan.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            GameManager.Instance.Player.GetComponent<PlayerController>().SetForceIdle();
            animatorWarning.Play("on");
            SearchMan.transform.localScale = new Vector3(-4, 4, 4);
            DialogueManager.StartConversation(SearchMan.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation, SearchMan.transform);
            GameManager.Instance.SetCameraTarget(SearchMan, 1f);
            Vector2 pos = SearchMan.transform.localPosition;
            pos.y = -2.92f;
            SearchMan.transform.localPosition = pos;
            SearchMan.GetComponent<Animator>().Play("Check_idle");
            this.GetComponent<BoxCollider2D>().enabled = false;
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.SearchroomAlarm);
        }
    }
    public void SetCameraSearchman()
    {

    }
    public void SetCameraPlayer()
    {

    }
    public void SetCameraFarmerFriend()
    {
        animatorWarning.Play("off");
        SearchMan.transform.position = InitPos;
        SearchMan.transform.localScale = new Vector3(4, 4, 4);
        SearchMan.GetComponent<Animator>().Play("idle");
        GameManager.Instance.SetCameraTarget(UIManager.Instance.Part5_1FarmFriend, 1f);
    }
    public void EndConversation()
    {
        GameManager.Instance.SetPlayerCamera(1f);
        StartCoroutine(EndConversationRoutine());
        
    }
    IEnumerator EndConversationRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
}

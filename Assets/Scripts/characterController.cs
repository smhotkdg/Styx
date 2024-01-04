using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    //private void OnApplicationPause(bool pause)
    //{
    //    if(pause ==true)
    //    {
    //        SavePos();
    //    }
    //}
    
    //private void Start()
    //{
    //    Vector3 newPos = new Vector3(0, 0, 0);
    //    if (SaveManager.Instance.LoadData("playerx") == null || SaveManager.Instance.LoadData("playery")==null||
    //        SaveManager.Instance.LoadData("playerz") ==null)
    //        return;
    //    newPos.x = (float)SaveManager.Instance.LoadData("playerx");
    //    newPos.y = (float)SaveManager.Instance.LoadData("playery");
    //    newPos.z = (float)SaveManager.Instance.LoadData("playerz");
    //    transform.position = newPos;
    //}
    //void SavePos()
    //{
    //    SaveManager.Instance.SaveData("playerx", transform.position.x);
    //    SaveManager.Instance.SaveData("playery", transform.position.y);
    //    SaveManager.Instance.SaveData("playerz", transform.position.z);
    //}
    private void OnApplicationQuit()
    {
        //SavePos();
    }
    public void PlayFootSound()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.normalFoot);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="QuestObject")
        {
            //Debug.Log("퀘스트 오브젝트");
            //GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "QuestObject")
        {
            //Debug.Log("퀘스트 오브젝트 스테이");
            //GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag =="QuestObject")
        {
            //Debug.Log("퀘스트 오브젝트 나감");
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        }
    }
}

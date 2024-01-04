using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class ChapelMasterController : MonoBehaviour
{
    public void SetStartData()
    {
        if (GameManager.Instance.styxData.strSteeldoorPasswordQuest == "unassigned")
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.CONVERSATION;
            DialogueManager.StartConversation("headmasterConverstaion_Solo");
            GameManager.Instance.SetCameraTarget(gameObject, 1f);
        }
    }
    bool bSafe = false;
    public void Setsafe()
    {
        bSafe = true;
    }
    public void EndConversation()
    {
        if(bSafe ==true)
        {
            //금고 창 띄우기
            UIManager.Instance.SelectNumberGame.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            bSafe = false;
        }
    }
    public void setEnableBox()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}

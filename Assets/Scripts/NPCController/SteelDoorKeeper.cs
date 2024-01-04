using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class SteelDoorKeeper : MonoBehaviour
{
    public Transform PupPos;
    public Transform InitPos;

    void Start()
    {
        
    }
    private void OnEnable()
    {        
        if (GameManager.Instance.styxData.steelKeeperPos ==true)
        {
            SetPopPos();
        }
        else
        {
            SetInitPos();
        }
        if(GameManager.Instance.styxData.steelManDrinkCount ==3)
        {
            Drunk();
        }
        else
        {
            SetIdle();
        }
    }
    public void Setdrinking()
    {
        GetComponent<Animator>().Play("drinking");
    }
    public void Drunk()
    {
        GetComponent<Animator>().Play("drunk");
    }
    public void SetIdle()
    {
        GetComponent<Animator>().Play("idle");
    }
    public void SetPopPos()
    {
        transform.position = PupPos.position;
        transform.localScale = new Vector3(4, 4, 4);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void SetInitPos()
    {
        transform.position = InitPos.position;
        transform.localScale = new Vector3(4, 4, 4);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void DrinkAnim()
    {

    }

    public bool SetManagerMove = false;
    public void SetMove()
    {
        SetManagerMove = true;
        
    }
    public void EnsConversation()
    {
        if(SetManagerMove ==true)
        {
            TestCodeManager.Instance.GetSteelDoorPasswordQuest_ManangerMove(true);
            SetManagerMove = false;
        }
        if(bGetPassword)
        {
            TestCodeManager.Instance.GetPart2SteelDoorPasswordQuest(true);
            bGetPassword = false;
        }
    }
    bool bGetPassword = false;
    public void GetPsssWord()
    {
        bGetPassword = true;
    }
  
}

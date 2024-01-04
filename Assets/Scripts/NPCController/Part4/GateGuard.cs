using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateGuard : MonoBehaviour
{
    //GuardComplete

    private void Start()
    {
        if(GameManager.Instance.GameIndex >=35)
        {
            transform.Find("Holder").gameObject.SetActive(false);
            GetComponent<DialogueSystemTrigger>().conversation = "LeftGuard";
        }
        else
        {
            transform.Find("Holder").gameObject.SetActive(true);
            GetComponent<DialogueSystemTrigger>().conversation = "GuardQuest";
        }
        
    }
    public void SetAccessCard()
    {
        TestCodeManager.Instance.GuardComplete(false);
        GetComponent<DialogueSystemTrigger>().conversation = "LeftGuard";
        transform.Find("Holder").gameObject.SetActive(false);
    }

}

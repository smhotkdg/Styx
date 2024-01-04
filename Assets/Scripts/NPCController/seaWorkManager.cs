using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System;

public class seaWorkManager : MonoBehaviour
{
    private DialogueSystemTrigger systemTrigger;    
    private void Start()
    {
        systemTrigger = GetComponent<DialogueSystemTrigger>();
        
    }
    public void OnEndConversataion()
    {
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        this.gameObject.SetActive(false);
    }
    public void StartConversation()
    {        
        DialogueManager.StartConversation(systemTrigger.conversation,transform);        
    } 
}

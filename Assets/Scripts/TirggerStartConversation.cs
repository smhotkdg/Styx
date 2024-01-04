using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirggerStartConversation : MonoBehaviour
{
    public string strTag;
    public DialogueSystemTrigger systemTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag ==strTag)
        {
            DialogueManager.StartConversation(systemTrigger.conversation,transform);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}

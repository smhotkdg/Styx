using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolInTrigger : MonoBehaviour
{
    bool bInitEvent = true;
    private void Start()
    {
        bInitEvent = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            if(bInitEvent)
            {                
                GameManager.Instance.playerController.SetForceIdle();
                DialogueManager.StartConversation(GetComponent<DialogueSystemTrigger>().conversation, transform);
                this.GetComponent<BoxCollider2D>().enabled = false;
                bInitEvent = false;
            }
        }
    }
    public void endConversation()
    {
        UIManager.Instance.Part6_1FarmFriend.GetComponent<FollowObject>().isFollow = false;
        UIManager.Instance.Part6_1FarmFriend.GetComponent<Animator>().SetFloat("speed", 0);
        this.gameObject.SetActive(false);
    }
}

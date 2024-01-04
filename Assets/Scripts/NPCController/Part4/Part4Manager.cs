using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4Manager : MonoBehaviour
{
    public GameObject Man;
    bool bStartQuest = false;
    BoxCollider2D box;
    //NPCController
    BoxCollider2D ManBox;
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        ManBox = Man.transform.Find("NPCController").gameObject.GetComponent<BoxCollider2D>();      
    }
    public void SetQuestEnd()
    {
        bStartQuest = true;
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.styxData.deliveryManQuest =="active")
        {
            box.enabled = false;            
        }
        else
        {
            box.enabled = true;            
        }
    }
    public void EndConversataion()
    {
        if(bStartQuest)
        {
            bStartQuest = false;
            TestCodeManager.Instance.DeliveryManQeustStart(false);
            ManBox.enabled = true;
        }
    }
    public void StartBarkMan()
    {
        UIManager.Instance.setDialogue(Man, "..........", 120, 1.5f);
    }
}

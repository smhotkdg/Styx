using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerQuestNPC_1 : MonoBehaviour
{
    bool isComputerQuest = false;
   
    Animator animator;
    
    public void SetComputerQuest()
    {
        isComputerQuest = true;
    }
    bool isQuestComplete = false;
    public void SetCompleteQuest()
    {
        isQuestComplete = true;
    }
  
    public void EndConversationI()
    {
        if(isComputerQuest)
        {
            TestCodeManager.Instance.ComputerQuestStart(false);
            isComputerQuest = false;        
        }
        if(isQuestComplete)
        {
            //
            TestCodeManager.Instance.ComputerQuestComplete(false);
            isQuestComplete = false;
        }
    }
    public void StartBroken()
    {
        GameManager.Instance.cameraEffectController.ShipHit();        
    }

    //-7.5 4.5

}

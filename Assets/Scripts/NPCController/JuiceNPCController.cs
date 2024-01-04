using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class JuiceNPCController : MonoBehaviour
{
    public enum JuiceType
    {
        npc,
        varietystore
    }
    public JuiceType juiceType = JuiceType.npc;

    private void OnEnable()
    {
        bJuice = false;
    }
    bool bJuice = false;
    public void isJuiceGame()
    {
        bJuice = true;
    }
    public void StartJuiceGame()
    {
        if(bJuice ==true)
        {
            UIManager.Instance.JuiceGamePanel.SetActive(true);
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_QUEST;
            UIManager.Instance.JuiceGamePanel.GetComponent<JuiceGameController>().OnFindJuiceHandler += JuiceNPCController_OnFindJuiceHandler;
            
            bJuice = false;
        }
    }


    private void JuiceNPCController_OnFindJuiceHandler()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler += CameraEffectController_OnCloseCompleteUIEventHandler;
        if (juiceType == JuiceType.npc)
        {            
            TestCodeManager.Instance.DeliveryQuestComplete_NPC1(true);            
            //DialogueManager.StartConversation("starWork_Good");
        }
        else if(juiceType == JuiceType.varietystore)
        {            
            TestCodeManager.Instance.DeliveryQuestComplete_NPCVarietyStore(true);
            //DialogueManager.StartConversation("varietystoreConversationGood");
        }
        
        UIManager.Instance.JuiceGamePanel.GetComponent<JuiceGameController>().OnFindJuiceHandler -= JuiceNPCController_OnFindJuiceHandler;
    }

    private void CameraEffectController_OnCloseCompleteUIEventHandler()
    {        
       
        StartCoroutine(ConversationRoutine());
        GameManager.Instance.cameraEffectController.OnCloseCompleteUIEventHandler -= CameraEffectController_OnCloseCompleteUIEventHandler;
    }
    IEnumerator ConversationRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        if (juiceType == JuiceType.npc)
        {
            DialogueManager.StartConversation("starWork_Good");
        }
        else if (juiceType == JuiceType.varietystore)
        {
            DialogueManager.StartConversation("varietystoreConversationGood");
        }
    }
}

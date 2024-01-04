using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmarcyRecipeController : MonoBehaviour
{
    public DialogueSystemTrigger systemTrigger;
    private void Start()
    {
        //systemTrigger = GetComponent<DialogueSystemTrigger>();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {            
            DialogueManager.StartConversation(systemTrigger.conversation, this.transform);
            GameManager.Instance.Player.GetComponent<PlayerController>().SetForceIdle();            
        }
    }
    public void EndConverstationEvent()
    {
        
        GameManager.Instance.data.PillRecipe = 1;
        GameManager.Instance.SaveNormalData();
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.PillRecepi);
        this.gameObject.SetActive(false);
        
    }
 
}

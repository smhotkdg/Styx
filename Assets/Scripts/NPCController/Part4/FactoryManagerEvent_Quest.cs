using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManagerEvent_Quest : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void EndConversationEvent()
    {        
        TestCodeManager.Instance.GetFactoryManagerQeust(false);
        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.quest),2.5f);
        //GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.quest);
        StartCoroutine(WalkRoutine());
    }
    bool bMoveStart = false;
    IEnumerator WalkRoutine()
    {        
        yield return new WaitForSeconds(1.5f);
        animator.SetFloat("speed", 1);
        //animator.Play("walking");
        bMoveStart = true;
    }
    private void Update()
    {
        if (bMoveStart == false)
            return;                  
        transform.position += new Vector3(-Time.deltaTime, 0);
        if(transform.position.x < -8f)
        {
            this.gameObject.SetActive(false);
        }
    }
   
}

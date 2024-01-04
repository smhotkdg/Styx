using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part6_Enemy : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public GameObject AnimObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            DialogueManager.StartConversation(GetComponent<DialogueSystemTrigger>().conversation, transform);
            GameManager.Instance.playerController.SetForceIdle();
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.VillainEvent);
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }
   
    public void EndConversation()
    {
        if(isAimGame)
        {
            isAimGame = false;
            AnimObject.SetActive(true);
            GameManager.Instance.playerController.GunStart_Motion();
            GameManager.Instance.cameraEffectController.SetSniper();
            StartCoroutine(DisableGunRoutine());
            //this.gameObject.SetActive(false);
        }
    }
    IEnumerator DisableGunRoutine()
    {
        GameManager.Instance.styxData.Part5_1EventCount = 16;
        DialogueLua.SetVariable("Part5_1EventCount", GameManager.Instance.styxData.Part5_1EventCount);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.cameraEffectController.UnSetSniper();
        yield return new WaitForSeconds(.5f);
        DialogueManager.StartConversation(UIManager.Instance.Part6_Cult.transform.Find("NPCController").gameObject.GetComponent<DialogueSystemTrigger>().conversation,
            UIManager.Instance.Part6_Cult.transform);
        yield return new WaitForSeconds(2f);
        AnimObject.SetActive(false);
    }
    bool isAimGame = false;
    public void AimGame()
    {
        isAimGame = true;
    }
    private void FixedUpdate()
    {
        GameManager.Instance.cameraEffectController.SetSniperValue(-variableJoystick.Horizontal/2, -variableJoystick.Vertical/2);   
    }
}

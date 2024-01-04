using PixelCrushers.DialogueSystem;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberPanelController : MonoBehaviour
{
    public Transform PrisonPos;
    private void OnEnable()
    {

        GameManager.Instance.Player.GetComponent<_2dxFX_GrayScale>().enabled = true;
        GameManager.Instance.cameraEffectController.wideScreenH.enabled = false;
        GameManager.Instance.cameraEffectController.SetGrayScale(false);
        GameManager.Instance.cameraEffectController.SetRain(false);        
    }
    private void OnDisable()
    {
        GameManager.Instance.Player.GetComponent<_2dxFX_GrayScale>().enabled = false;


    }
    public void SetGrayFalse()
    {
        
    }
    [Button("==테스트==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void EndEvent()
    {
        UIManager.Instance.SceneChangeMemory(languageController.SceneTextType.Prison, PrisonPos);
        GameManager.Instance.roomPosition = GameManager.RoomPosition.Prison;
        
        //Debug.Log("회상 종료");

    }

    public void CompleteView()
    {        
        GameManager.Instance.Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameManager.Instance.Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GameManager.Instance.Player.GetComponent<_2dxFX_GrayScale>().enabled = false;

        GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        
        GameManager.Instance.styxData.Part5_1EventCount = 8;
        DialogueLua.SetVariable("Part5_1EventCount", 8);
        GameManager.Instance.styxData.Part5_2EventCount = 7;
        DialogueLua.SetVariable("Part5_2EventCount", 7);

        this.gameObject.SetActive(false);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetForceIdle();
        //UIManager.Instance.SetPart5FarmerFriend(-2f);
    }
}


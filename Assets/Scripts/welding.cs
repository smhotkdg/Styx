using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class welding : MonoBehaviour
{
    public _2dxFX_DesintegrationFX _2DxFX_DesintegrationFX;
    public Text Prograss;

    private void OnEnable()
    {
        _2DxFX_DesintegrationFX.Desintegration = 1;
        SetSuccess = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Prograss.gameObject.SetActive(false);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
    }
    bool SetSuccess = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        float delay = Time.deltaTime / 10;
        if(_2DxFX_DesintegrationFX.Desintegration >0)
        {
            _2DxFX_DesintegrationFX.Desintegration -= delay;
        }
        else
        {
            _2DxFX_DesintegrationFX.Desintegration = 0;
            if(SetSuccess==false)
            {
                GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.part0);
                DialogueLua.SetQuestField("Part0Quest", "State", "success");
                UIManager.Instance.CheckQuestGuide();
                SetSuccess = true;
            }
            
        }
        Prograss.gameObject.SetActive(true);
        float Prograssfloat = (1 - _2DxFX_DesintegrationFX.Desintegration)*100;
        Prograss.text = Prograssfloat.ToString("N0") + " %";
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class CameraEffectController : MonoBehaviour
{
    public delegate void OnCloseCompleteUI();
    public event OnCloseCompleteUI OnCloseCompleteUIEventHandler;

    public delegate void OnCloseedCompleteUI();
    public event OnCloseedCompleteUI OnCloseCompleteedUIEventHandler;

    public GameObject CompleteGameUI;
    public CameraPlay_WidescreenH wideScreenH;
    public CameraFilterPack_3D_Matrix _Matrix;

    public QuestGetConroller questGetConroller;
    public void SetRain(bool flag)
    {
        GetComponent<CameraFilterPack_Atmosphere_Rain_Pro_3D>().enabled = flag;
        GetComponent<CameraFilterPack_Blur_Tilt_Shift_V>().enabled = flag;
    }
    public void SetEarthQuake(bool flag)
    {
        GetComponent<CameraFilterPack_FX_EarthQuake>().enabled = flag;
    }
    [Button("Bullet Hit", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void BulletHit(bool flag)
    {        
        if (flag)
        {            
            CameraPlay.BulletHole(0.65f, 0.7f, 5, 1);
            CameraPlay.BloodHit(new Color(0.7f,0,0), 5, 1);
            CameraPlay.EarthQuakeShake(0.7f);
            CameraPlay.Hit(2);
            CameraPlay.MangaFlash(0.5f, 0.5f, 1f, 1, new Color(0, 0, 0));
        }       
    }
    [Button("ShipHit", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ShipHit()
    {
        CameraPlay.EarthQuakeShake(0.7f);
        CameraPlay.Hit(2);
        CameraPlay.MangaFlash(0.5f, 0.5f, 1f, 1, new Color(0, 0, 0));
    }
    languageController.ObjectName tempName;
    public void SetCompleteGameUI(languageController.ObjectName objectName)
    {
        if(objectName == languageController.ObjectName.lever)
        {
            StartCoroutine(EndCompleteUI(objectName));
        }
        else
        {
            questGetConroller.gameObject.SetActive(true);
            questGetConroller.SetData(languageController.Instance.setAlert(objectName), UIManager.Instance.setItemIcon(objectName));
            questGetConroller.OnCloseQuestGetControllerEventHandler += QuestGetConroller_OnCloseQuestGetControllerEventHandler;
            
            tempName = objectName;
            
        }        
    }

    private void QuestGetConroller_OnCloseQuestGetControllerEventHandler()
    {
        if(tempName != languageController.ObjectName.EmergencyLever)
        {
            StartCoroutine(EndCompleteUI(tempName));
        }        
        if(tempName == languageController.ObjectName.Pens)
        {
            GameManager.Instance.startLeverEvent();
        }
        OnCloseCompleteUIEventHandler?.Invoke();
        questGetConroller.OnCloseQuestGetControllerEventHandler -= QuestGetConroller_OnCloseQuestGetControllerEventHandler;
    }

    IEnumerator EndCompleteUI(languageController.ObjectName objectName)
    {
        CompleteGameUI.SetActive(true);
        CompleteGameUI.GetComponent<Animator>().Play("QuestCompleteAnim");

        CompleteGameUI.GetComponent<QuestCompleteController>().SetData(objectName);                
        //GetComponent<CameraFilterPack_Distortion_ShockWave>().enabled = true;
        //GetComponent<CameraFilterPack_Distortion_ShockWave>().TimeX = 1;
        //yield return new WaitForSeconds(0.8f);
        //GetComponent<CameraFilterPack_Distortion_ShockWave>().TimeX = 0;
        //GetComponent<CameraFilterPack_Distortion_ShockWave>().enabled = false;
        //CameraPlay.Glitch(1f);
        yield return new WaitForSeconds(3.5f);
        CompleteGameUI.GetComponent<Animator>().Play("QuestCompleteAnimBack");        

    }
    public void Start_Matrix(bool flag = true)
    {
        CameraPlay.Glitch3(1.5f);
        if(flag)
        {
            _Matrix.enabled = true;
            _Matrix.Fade = 0;
            StartCoroutine(EnableMatrix());
        }
        else
        {            
            _Matrix.Fade = 0.3f;
            StartCoroutine(DisableMatrix());
        }
        
    }

    IEnumerator DisableMatrix()
    {
        for (int i = 0; i < 25; i++)
        {
            _Matrix.Fade -= 0.012f;
            yield return new WaitForSeconds(0.01f);
        }
        _Matrix.Fade = 0f;
        _Matrix.enabled = false;
        UIManager.Instance.TopObejct.SetActive(true);
    }

    IEnumerator EnableMatrix()
    {
        UIManager.Instance.TopObejct.SetActive(false);
        for (int i =0; i< 25; i++)
        {
            _Matrix.Fade += 0.012f;
            yield return new WaitForSeconds(0.01f);
        }
        _Matrix.Fade = 0.3f;
        
    }
    public void Drunk(float time)
    {
        StartCoroutine(DrunkRoutine(time));
    }
    IEnumerator DrunkRoutine(float time)
    {
        CameraPlay.Drunk_ON();
        yield return new WaitForSeconds(time);
        CameraPlay.Drunk_OFF();
    }
    public void LightEffect()
    {
        CameraPlay.EarthQuakeShake(1);
        StartCoroutine(LightEffectRoutine());
    }
    IEnumerator LightEffectRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        CameraPlay.FlashLight(0.1f);
        yield return new WaitForSeconds(0.1f);
        CameraPlay.FlashLight(0.1f);
        yield return new WaitForSeconds(0.1f);
        CameraPlay.FlashLight(0.1f);
    }
}

using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part6_2GunGame : MonoBehaviour
{

    public GameObject DoorObject;
    public Transform CamPos;
    void Start()
    {
        
    }
    public void SetInit()
    {
        StartCoroutine(CamInit());
    }
    IEnumerator CamInit()
    {
        GameManager.Instance.cameraEffectController.SetGlitch(3);
        GameManager.Instance.SetCameraTarget(CamPos.gameObject,2f);
        yield return new WaitForSeconds(2f);
        StartCoroutine(ChangeCameraPlus());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFailEnd()
    {
        //Debug.Log("총싸움 대화 끝");
        StartCoroutine(EnemyGunShoot());
    }
    IEnumerator EnemyGunShoot()
    {
        DoorObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Part6_2Enmey.GetComponent<Animator>().Play("GunShot_2");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(.2f);
        GameManager.Instance.cameraEffectController.SetEarthQuake(.2f);
        GameManager.Instance.playerController.Dead_2();
        yield return new WaitForSeconds(2f);
        TestCodeManager.Instance.StartPart6_2_HallWaywheelRoom();
        yield return new WaitForSeconds(3f);
        DoorObject.SetActive(true);
    }
    public void SetSuccessEnd()
    {
        //Debug.Log("총싸움 대화 끝");
        StartCoroutine(KillEnmeyRoutine());
        
    }
    IEnumerator KillEnmeyRoutine()
    {        
        yield return new WaitForSeconds(1f);
        GameManager.Instance.playerController.ShootGun();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.cameraEffectController.SetEarthQuake(.2f);
        UIManager.Instance.Part6_2Enmey.GetComponent<Animator>().Play("villain_Dead_dead");
        yield return new WaitForSeconds(2f);
        GameManager.Instance.styxData.Part5_2EventCount = 23;        
        DialogueLua.SetVariable("Part5_2EventCount", GameManager.Instance.styxData.Part5_2EventCount);
        GameManager.Instance.SetPlayerCamera(1f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeCameraPlusNormal());
        SoundsManager.Instance.ChangeBGM(SoundsManager.BGMType.Non);
    }

    IEnumerator ChangeCameraPlusNormal()
    {

        for (int i = 0; i < 50; i++)
        {
            GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize -= 0.06f;
            GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY -= 0.0006f;
            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = 0.53f;
        GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize = 5f;

        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;

    }
    IEnumerator ChangeCameraPlus()
    {
        
        for (int i = 0; i < 50; i++)
        {
            GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize += 0.06f;
            GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY += 0.0006f;
            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.cinemachineCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = 0.56f;
        GameManager.Instance.cinemachineCamera.m_Lens.OrthographicSize = 8f;

        UIManager.Instance.Part6_2GunGame.SetActive(true);
    }
}

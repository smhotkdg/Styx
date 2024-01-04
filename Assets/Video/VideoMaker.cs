using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class VideoMaker : MonoBehaviour
{
    public GameObject MoveObject;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    [Button("==카메라 줌==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Zoom()
    {
        StartCoroutine(ZoomRoutine());
    }
    IEnumerator ZoomRoutine()
    {
        virtualCamera.m_Lens.OrthographicSize = 5;
        for(int i =0; i< 500; i++)
        {
            virtualCamera.m_Lens.OrthographicSize -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        virtualCamera.m_Lens.OrthographicSize = 0;
    }
    [Button("==카메라 out줌==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ZoomOut()
    {
        StartCoroutine(ZoomRoutineOut());
    }
    IEnumerator ZoomRoutineOut()
    {
        virtualCamera.m_Lens.OrthographicSize = 0;
        for (int i = 0; i < 500; i++)
        {
            virtualCamera.m_Lens.OrthographicSize += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        virtualCamera.m_Lens.OrthographicSize = 5;
    }
    public GameObject Enmey;
    public Animator Player;
    public CameraEffectController effect;
    [Button("==Shoot==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Shoot()
    {
        StartCoroutine(ShootRoutine());
    }
    IEnumerator ShootRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        Player.Play("gun_gun_start");
        yield return new WaitForSeconds(0.5f);
        Player.Play("gun_shooting");
        yield return new WaitForSeconds(0.2f);
        effect.SetEarthQuake(0.3f);
        Enmey.GetComponent<Animator>().Play("villain_Dead_dead");
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EmergencyCameraController : MonoBehaviour
{
    public Camera subCamera;
    public DOTweenAnimation Event2;
    private void OnEnable()
    {
        StartEvent();
    }
    void StartEvent()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        subCamera.gameObject.SetActive(true);
        subCamera.orthographicSize = 5;
        subCamera.DOOrthoSize(1, 2f).OnComplete(completeTween);
    }
    void completeTween()
    {
        subCamera.GetComponent<CameraFilterPack_FX_EarthQuake>().enabled = true;
        StartCoroutine(DisablePanel());
    }
    IEnumerator DisablePanel()
    {
        yield return new WaitForSeconds(1f);
        subCamera.GetComponent<CameraFilterPack_FX_EarthQuake>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<DOTweenAnimation>().DOPlayBackwards();
        Event2.DOPlayBackwards();
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
}

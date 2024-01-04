using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
public class PictureGameManager : MonoBehaviour
{
    public List<PictureGameItem> PictureLIst;
    public GameObject Picture_P;
    public GameObject ChessObject;
    public BoxCollider2D boxCollider;
    private void Start()
    {
        for(int i =0; i< PictureLIst.Count; i++)
        {
            PictureLIst[i].OnClickObjectEventHandler += PictureGameManager_OnClickObjectEventHandler;
        }
    }
    private void OnDisable()
    {
        if (GameManager.Instance.Player.GetComponent<PlayerController>().FlashLight.activeSelf == false)
        {
            GameManager.Instance.SetPlayerWork(false);
        }
    }
    private void OnEnable()
    {
        if(GameManager.Instance.styxData.ChessQuestIndex ==0)
        {
            ChessObject.SetActive(true);
        }
        else
        {
            ChessObject.SetActive(false);
        }
        if(GameManager.Instance.Player.GetComponent<PlayerController>().FlashLight.activeSelf ==false)
        {
            GameManager.Instance.SetPlayerWork(true);
        }
    }
    private void PictureGameManager_OnClickObjectEventHandler()
    {
        for(int i =0; i< PictureLIst.Count; i++)
        {
            if (PictureLIst[i].isOk == false)
                return;
        }
        Debug.Log("그림 맞추기 성공");
        boxCollider.enabled = false;
        StartCoroutine(SucessRoutine());
    }
    IEnumerator SucessRoutine()
    {
        Picture_P.transform.DOShakeScale(0.5f, 0.1f);
        yield return new WaitForSeconds(0.8f);
        Vector3 MoveTop;
        MoveTop = PictureLIst[0].transform.localPosition;
        MoveTop.y += 300;
        PictureLIst[0].transform.DOLocalMove(MoveTop, 1.5f).SetEase(Ease.Linear);

        MoveTop = PictureLIst[1].transform.localPosition;
        MoveTop.y += 300;
        PictureLIst[1].transform.DOLocalMove(MoveTop, 1.5f).SetEase(Ease.Linear);

        MoveTop = PictureLIst[2].transform.localPosition;
        MoveTop.y -= 300;
        PictureLIst[2].transform.DOLocalMove(MoveTop, 1.5f).SetEase(Ease.Linear);

        MoveTop = PictureLIst[3].transform.localPosition;
        MoveTop.y -= 300;
        PictureLIst[3].transform.DOLocalMove(MoveTop, 1.5f).SetEase(Ease.Linear);
        
        //yield return new WaitForSeconds(0.5f);
        //this.gameObject.SetActive(false);
    }
    public void GetChess()
    {

        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Chess));
        DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Chess), 2.5f);
        TestCodeManager.Instance.GetChess();
        this.gameObject.SetActive(false);
    }
}

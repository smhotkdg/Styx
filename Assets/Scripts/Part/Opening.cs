using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Opening : MonoBehaviour
{
    public Animator Player;
    public Animator Enmey1;
    public Animator Enmey2;
    private void Start()
    {
        Player.transform.localPosition = new Vector3(-450, 15);
        Enmey1.transform.localPosition = new Vector3(-450, 15);
        Enmey2.transform.localPosition = new Vector3(-450, 15);
    }
    public void SetEnd()
    {
        GetComponent<Animator>().Play("OpeningOff");
        UIManager.Instance.Block.SetActive(true);
    }
    public void EndComplete()
    {                
        this.gameObject.SetActive(false);
    }
    public void StartRoom()
    {
        TestCodeManager.Instance.RoomStart();
        UIManager.Instance.TopMenu.SetActive(true);
        UIManager.Instance.TopQuest.SetActive(true);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.DOOR);
    }
    public void StartAnim()
    {
        Player.Play("run");
        Player.transform.DOLocalMove(new Vector3(0, 15, 0),3).SetEase(Ease.Linear).OnComplete(MoveMiddle);
    }
    void MoveMiddle()
    {
        Player.Play("event");
        StartCoroutine(EventEndRoutine());

    }
    IEnumerator EventEndRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        Player.Play("run");
        Player.transform.DOLocalMove(new Vector3(450, 15, 0), 3).SetEase(Ease.Linear).OnComplete(MoveEnd);
        Enmey1.SetFloat("speed", 1);
        Enmey2.SetFloat("speed", 1);
        Enmey1.transform.DOLocalMove(new Vector3(450, 15, 0), 6).SetEase(Ease.Linear);
        Enmey2.transform.DOLocalMove(new Vector3(450, 15, 0), 6).SetDelay(1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(4f);
        SetEnd();
    }
    void MoveEnd()
    {
        Player.Play("idle");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SteelDoorController : MonoBehaviour
{
    public Animator DoorAnimator;
    public GameObject Player;
    public Part2SteelDoorSelect part2SteelDoorSelect;
    private void OnEnable()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        Player.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        DoorAnimator.Play("init");
        part2SteelDoorSelect.OnSelectHandler += Part2SteelDoorSelect_OnSelectHandler;
    }

    private void Part2SteelDoorSelect_OnSelectHandler(bool flag)
    {
        if(flag)
        {
            StartCoroutine(EndAnimation());
        }
        else
        {
            Player.GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), 0.5f).SetEase(Ease.Linear);
            ClosePanel();
        }
    }

    public void SetOpen()
    {
        part2SteelDoorSelect.gameObject.SetActive(true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        Player.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1),1f).SetEase(Ease.Linear);
        DoorAnimator.Play("elevator_door_open");
        
    }
    IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(1f);
        Player.GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        DoorAnimator.Play("elevator_door_close");
        yield return new WaitForSeconds(1f);
        Debug.Log("파트3 시작");
        TestCodeManager.Instance.GoSkyTown();
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().Play("Back");
    }
    public void ClosePanel()
    {
        GetComponent<Animator>().Play("Back");
    }
    private void OnDisable()
    {
        part2SteelDoorSelect.OnSelectHandler -= Part2SteelDoorSelect_OnSelectHandler;
        if (GameManager.Instance!=null)
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
}

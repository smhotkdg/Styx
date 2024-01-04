using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RuningGamePanelController : MonoBehaviour
{
    public RuningGameController gameController;
    public GameObject Count;
    Text countText;
    private void Start()
    {
        countText = Count.transform.Find("Text").gameObject.GetComponent<Text>();
    }
    private void OnEnable()
    {
        Count.SetActive(true);
        bDisable = false;
        Count.transform.DOScale(new Vector3(0, 0, 0), 0.3f).From(false).SetEase(Ease.OutBack).OnComplete(DoCompleteCount_3);
    }
    void DoCompleteCount_3()
    {
        if (bDisable == true)
            return;
        StartCoroutine(Make_2Routine());
    }
    IEnumerator Make_2Routine()
    {
        yield return new WaitForSeconds(0.65f);
        Count.transform.DOScale(new Vector3(0, 0, 0), 0.3f).From(false).SetEase(Ease.OutBack).OnComplete(DoCompleteCount_2);
        countText.text = "2";
    }

    void DoCompleteCount_2()
    {
        if (bDisable == true)
            return;
        StartCoroutine(Make_1Routine());
    }
    IEnumerator Make_1Routine()
    {
        yield return new WaitForSeconds(0.65f);
        Count.transform.DOScale(new Vector3(0, 0, 0), 0.3f).From(false).SetEase(Ease.OutBack).OnComplete(DoCompleteCount_1);
        countText.text = "1";
    }
    void DoCompleteCount_1()
    {
        if (bDisable == true)
            return;
        StartCoroutine(Make_Routine());
    }
    IEnumerator Make_Routine()
    {
        yield return new WaitForSeconds(0.65f);
        Count.transform.DOScale(new Vector3(0, 0, 0), 0.3f).From(false).SetEase(Ease.OutBack).OnComplete(DoCompleteCount);
        countText.text = "START";
    }
    void DoCompleteCount()
    {
        if (bDisable == true)
            return;
        StartCoroutine(Make_Routine_end());
    }
    IEnumerator Make_Routine_end()
    {
        yield return new WaitForSeconds(0.30f);
        Count.SetActive(false);
        //start Game
        gameController.StartGame();
    }
    bool bDisable = false;
    private void OnDisable()
    {
        StopAllCoroutines();
        bDisable = true;
        countText.text = "3";
        Count.SetActive(false);
        
    }
}

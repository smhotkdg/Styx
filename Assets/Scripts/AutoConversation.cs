using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class AutoConversation : MonoBehaviour
{
    public GameObject ConverstationUI;
    public int ConverstationIndex;
    private Text MyText;
    private void Start()
    {
        MyText = ConverstationUI.transform.Find("Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            ConverstationUI.transform.Find("Text").GetComponent<DOTweenAnimation>().DOPause();
            ConverstationUI.SetActive(false);
            ConverstationUI.SetActive(true);
            
            MyText.text = languageController.Instance.GetAutoConversation(ConverstationIndex);
            ConverstationUI.GetComponent<UiTargetManager>().WorldObject = gameObject;
            bStay = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            ConverstationUI.SetActive(true);
            MyText.text = languageController.Instance.GetAutoConversation(ConverstationIndex);
            ConverstationUI.GetComponent<UiTargetManager>().WorldObject = gameObject;
            bStay = true;
        }
    }
    bool bStay = false;
    private void FixedUpdate()
    {
        if(bStay)
        {
            MyText.text = languageController.Instance.GetAutoConversation(ConverstationIndex);
        }        
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            ConverstationUI.GetComponent<DOTweenAnimation>().DOPlayBackwards();
            ConverstationUI.transform.Find("Text").GetComponent<DOTweenAnimation>().DOPlayBackwards();
            StartCoroutine(EndUI());
            bStay = false;
        }
    }
    IEnumerator EndUI()
    {
        yield return new WaitForSeconds(0.75f);
        ConverstationUI.SetActive(false);
    }
}

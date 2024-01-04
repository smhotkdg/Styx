using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SleepingJuiceController : MonoBehaviour
{
    public Image JuiceImage;
    public Animator DragAnim;
    public Text PercentText;
    int circleIndex;
    public delegate void OnComplete();
    public event OnComplete OnCompleteEventHandler;

    public delegate void OnDisableEvent();
    public event OnDisableEvent OnDisableEventHandler;
    private void OnEnable()
    {
        JuiceImage.fillAmount = 0;
        PercentText.text = "0 %";
        circleIndex = 0;
        bComplete = false;
    }
    public void DragJuice(bool flag)
    {
        if (flag)
            DragAnim.enabled = true;
        else
            DragAnim.enabled = false;
    }
    
    public void SetJuice()
    {
        if(isSet)
        {
            if (circleIndex >= 10)
                return;
            circleIndex++;
            SetText();
            //isSet = false;
            //StartCoroutine(SetIS());
        }
             
    }
    bool bComplete =false;
    private void OnDisable()
    {
        OnDisableEventHandler?.Invoke();
    }
    bool isSet = true;
    public void SetText()
    {
        int percent = circleIndex * 10;
        float imageIndex = ((float)circleIndex) / 10f;
        //JuiceImage.color = new Color(1, 1- imageIndex, 1- imageIndex, 1);
        //JuiceImage.fillAmount = imageIndex;
        JuiceImage.DOFillAmount(imageIndex, 1f);
        StartCoroutine(TextRoutine());
        
        if(circleIndex >=10)
        {
            Debug.Log("완료");
            bComplete = true;
            OnCompleteEventHandler?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator TextRoutine()
    {
        int percent = (circleIndex * 10) - 10;
        int increase = percent;
        for (int i =0; i< 10;i++)
        {
            yield return new WaitForSeconds(0.02f);            
            increase += 1;
            PercentText.text = increase + " %";
        }
        PercentText.text = (circleIndex*10) + " %";
    }


}

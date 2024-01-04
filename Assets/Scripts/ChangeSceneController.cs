using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Michsky.UI.Dark;
public class ChangeSceneController : MonoBehaviour
{
    public delegate void OnCompleteChange();
    public event OnCompleteChange OnCompleteChangeHandler;

    public delegate void OnCompleteChangeEnd();
    public event OnCompleteChangeEnd OnCompleteChangeEndHandler;

    Image image;
    public List<Image> ChildImageList;
    public List<Text> ChildTextList;
    public float delayTime = 1f;
    private void Start()
    {
        getImage();
    }
    void getImage()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }        
    }
    private void OnEnable()
    {
        transform.SetAsLastSibling();                
        getImage();
        image.raycastTarget = true; 
        image.color = new Color(0, 0, 0, 0);
        for(int i =0; i< ChildImageList.Count; i++)
        {
            //ChildImageList[i].color = new Color(0, 0, 0, 0);
            StartCoroutine(EnableImageRoutine(ChildImageList[i].GetComponent<_2dxFX_DesintegrationFX>(), ChildImageList[i]));
            //ChildImageList[i].DOColor(new Color(1, 1, 1, 1), 2f).SetEase(Ease.OutFlash);
        }
        for (int i = 0; i < ChildTextList.Count; i++)
        {
            ChildTextList[i].color = new Color(0, 0, 0,0);
            ChildTextList[i].DOColor(new Color(0, 0, 0, 1), 2f).SetEase(Ease.OutFlash);
        }
        image.DOColor(new Color(0, 0, 0, 1), 1f).SetEase(Ease.OutFlash);
        StartCoroutine(EndImageChange());
    }
    IEnumerator EndImageChange()
    {
        yield return new WaitForSeconds(1.5f);
        TextChangeRoutine();
        yield return new WaitForSeconds(1.0f);
        OnCompleteColor();
    }
    IEnumerator EnableImageRoutine(_2dxFX_DesintegrationFX uIDissolveEffect,Image image)
    {
        uIDissolveEffect.Desintegration = 1;
        //image.color = new Color(1, 1, 1, 1);
        while (true)
        {            
            yield return new WaitForSeconds(0.01f);
            uIDissolveEffect.Desintegration -= 0.01f;
            if (uIDissolveEffect.Desintegration <= 0)
            {
                uIDissolveEffect.Desintegration = 0;
                break;
            }
        }
        
    }
    void TextChangeRoutine()
    {
        for (int i = 0; i < ChildTextList.Count; i++)
        {
            ChildTextList[i].DOColor(new Color(0, 0, 0, 0), 1f).SetEase(Ease.InFlash).SetDelay(delayTime);
        }
    }
    void OnCompleteColor()
    {
        OnCompleteChangeHandler?.Invoke();
        for (int i = 0; i < ChildImageList.Count; i++)
        {
            //ChildImageList[i].DOColor(new Color(0, 0, 0, 0), 2f).SetEase(Ease.InFlash).SetDelay(delayTime);
            StartCoroutine(DIsablemageRoutine(ChildImageList[i].GetComponent<_2dxFX_DesintegrationFX>(),ChildImageList[i]));
        }
      
        image.DOColor(new Color(0, 0, 0, 0), 2f).SetEase(Ease.InFlash).OnComplete(OnEndCompleteColor);
        StartCoroutine(RaycastChange());
    }

    IEnumerator RaycastChange()
    {
        yield return new WaitForSeconds(1f);
        image.raycastTarget = false;
    }
    IEnumerator DIsablemageRoutine(_2dxFX_DesintegrationFX uIDissolveEffect,Image image)
    {
        uIDissolveEffect.Desintegration = 0;
        //image.color = new Color(1, 1, 1, 1);
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            uIDissolveEffect.Desintegration += 0.01f;
            if (uIDissolveEffect.Desintegration >= 1)
            {
                uIDissolveEffect.Desintegration = 1;
                break;
            }
        }
    }
    void OnEndCompleteColor()
    {
        OnCompleteChangeEndHandler?.Invoke();
        this.gameObject.SetActive(false);
    }
}

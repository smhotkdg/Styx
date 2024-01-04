using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SafeBox : MonoBehaviour
{
    public delegate void OnComplete();
    public event OnComplete OnCompleteHandler;
    // Start is called before the first frame update
    public GameObject NoramlBox;
    public GameObject OpenBox;
    public GameObject GamePanel;
    int coinCount = 0;
    private void OnEnable()
    {
        OpenBox.GetComponent<Animator>().enabled = true;
        OpenBox.SetActive(false);
        NoramlBox.SetActive(true);
        NoramlBox.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 0;
        coinCount = 0;
    }
    public void SetOpen()
    {
        GamePanel.GetComponent<Animator>().enabled = false;
        StartCoroutine(GamePanelRoutine());
    }
    IEnumerator GamePanelRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            GamePanel.transform.Find("hint").GetComponent<_2dxFX_DesintegrationFX>().Desintegration += 0.01f;
            GamePanel.transform.Find("hint/Title").GetComponent<_2dxFX_DesintegrationFX>().Desintegration += 0.01f;
            if (GamePanel.transform.Find("hint").GetComponent<_2dxFX_DesintegrationFX>().Desintegration >= 1 && 
                GamePanel.transform.Find("hint/Title").GetComponent<_2dxFX_DesintegrationFX>().Desintegration>=1)
            {
                CompleteTween();
                GamePanel.transform.Find("hint").GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
                GamePanel.transform.Find("hint/Title").GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
                break;
            }
        }
        GamePanel.SetActive(false);
        OpenBox.SetActive(true);
        NoramlBox.SetActive(false);
        
        GamePanel.GetComponent<Animator>().enabled = true;

    }
    public void Click(GameObject coin)
    {
        OpenBox.GetComponent<Animator>().enabled = false;
        
        StartCoroutine(CoinRoutine(coin));        
    }
    
    IEnumerator CoinRoutine(GameObject coin)
    {
        coin.GetComponent<Button>().interactable = false;        
        
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            coin.GetComponent<_2dxFX_DesintegrationFX>().Desintegration += 0.01f;
            if (coin.GetComponent<_2dxFX_DesintegrationFX>().Desintegration >= 1)
            {
                coin.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
                coinCount++;
                break;
            }
        }
        coin.GetComponent<Button>().interactable = true;
        if(coinCount>=2)
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);
                OpenBox.GetComponent<_2dxFX_DesintegrationFX>().Desintegration += 0.01f;
                if (OpenBox.GetComponent<_2dxFX_DesintegrationFX>().Desintegration >= 1)
                {
                    OpenBox.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
                    break;
                }
            }
            OnCompleteHandler?.Invoke();
        }
    }
    public void Open()
    {
        NoramlBox.transform.DOShakeScale(1,0.1f).SetEase(Ease.OutQuad);
        //NoramlBox.transform.GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), 1).SetDelay(1).SetEase(Ease.Linear).OnComplete(CompleteTween);
        StartCoroutine(OpenRoutine());
    }
    IEnumerator OpenRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            NoramlBox.GetComponent<_2dxFX_DesintegrationFX>().Desintegration += 0.01f;

            if (NoramlBox.GetComponent<_2dxFX_DesintegrationFX>().Desintegration >= 1)
            {
                CompleteTween();
                NoramlBox.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
                break;
            }
        }
    }
    void CompleteTween()
    {
        GamePanel.SetActive(true);
    }
}

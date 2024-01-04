
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class MemoryCardController : MonoBehaviour
{
    public Button bottomButton;
    public GameObject TextObject;
    public GameObject BackObject;
    

    public GameObject Card;
    public Text CardText;
    public Sprite spriteCard_1;
    public Sprite spriteCard_2;

    public _2dxFX_DesintegrationFX _2DxFX_DestroyedFX;
    private void OnEnable()
    {
        bottomButton.enabled = false;
        TextObject.SetActive(false);
        Card.SetActive(false);
        
        power = 0;
        bStart = false;
        _2DxFX_DestroyedFX.Desintegration = 0;
        //FrontObject.transform.localScale = new Vector3(1, 1, 1);
        Card.transform.localScale = new Vector3(1, 1, 1);
        //Card_2.transform.localScale = new Vector3(1, 1, 1);
        BackObject.transform.localScale = new Vector3(1, 1, 1);

        BackObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.6f).SetDelay(0.4f).SetEase(Ease.OutBack).From(false).OnComplete(OnCompleteTween);
        transform.SetAsLastSibling();
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
    }
    int cardIndex = 0;
    public void SetCard(int index)
    {
        cardIndex = index;
    }
    void StartAnim()
    {
        
    }
    bool bStart = false;
    void OnCompleteTween()
    {
        switch (cardIndex)
        {
            case 1:
                Card.GetComponent<Image>().sprite = spriteCard_1;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card1);
                break;
            case 2:
                Card.GetComponent<Image>().sprite = spriteCard_2;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card2);
                break;
            default:
                Card.GetComponent<Image>().sprite = spriteCard_1;
                break;
        }
        Card.SetActive(true);
        bottomButton.enabled = true;
        bStart = true;
    }
    float power = 1;
    private void Update()
    {
        if(bStart == true)
        {
            if (power < 0.8f)
            {
                power += Time.deltaTime;

                _2DxFX_DestroyedFX.Desintegration = power;                
            }
            else
            {
                //FrontObject.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.6f).From(false).SetEase(Ease.OutBack);
                Card.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.6f).From(false).SetEase(Ease.OutBack);
             
                TextObject.SetActive(true);
                _2DxFX_DestroyedFX.Desintegration = 1;
                bStart = false;
            }
        }
    }


    public void TapClose()
    {
        if(TextObject.activeSelf ==true)
        {
            this.gameObject.SetActive(false);
            //
            if(GameManager.Instance.GameIndex ==38)
            {
                //퀘스트 시작
                GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().StartFactoryQuest();
            }
        }
    }
    private void OnDisable()
    {
        if(GameManager.Instance!=null)
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
public class ScratchCardGameManager : MonoBehaviour
{
    public GameObject SearchImage;
    public enum CardObject
    {
        Spoons,
        BrokenPart
    }
    public CardObject cardObject = CardObject.Spoons;
    public List<Sprite> ImageList;
    public Image FindObjectImage;
    public ScratchCardAsset.EraseProgress eraseProgress;
    public ScratchCardAsset.ScratchCardManager cardManager;

    public Text PercentText;
    //여러가지 타입으로 들어올수있게 변경해야함
    //
    // Start is called before the first frame update
    void Start()
    {
        eraseProgress.OnProgress += EraseProgress_OnProgress;
    }
    bool bEnd = false;
    private void OnEnable()
    {
        bEnd = false;
        PercentText.text = "0 %";
        SearchImage.SetActive(true);
    }
    public void SetBackgroundImage(CardObject card)
    {
        cardObject = card;
        FindObjectImage.sprite = ImageList[(int)cardObject];
    }
    private void OnDisable()
    {
        cardManager.ResetScratchCard();
        eraseProgress.ResetProgress();
    }
    private void EraseProgress_OnProgress(float progress)
    {
        PercentText.text = (progress*100).ToString("N1") + " %";
        SearchImage.SetActive(false);
        if (progress > 0.75f && bEnd == false)
        {
            bEnd = true;
            cardManager.Card.FillInstantly();
            FindObjectImage.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.45f).From(true).SetEase(Ease.OutBounce).OnComplete(EndTween);
            //여기는 숟가락
            Debug.Log("Scratch Find!!");
            switch(cardObject)
            {
                case CardObject.Spoons:
                    //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Spoon));
                    GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Spoon);
                    DialogueLua.SetVariable("leverQuestItem_1", 1);
                    DialogueLua.SetVariable("isBed", false);
                    GameManager.Instance.data.spoon = 1;
                    break;
                case CardObject.BrokenPart:
                    //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Brokenparts));
                    GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Brokenparts);
                    DialogueLua.SetVariable("leverQuestItem_3", 1);
                    GameManager.Instance.data.Brokenparts = 1;
                    break;
            }            
        }        
    }
    void EndTween()
    {
        StartCoroutine(DisablePanelRoutine());
    }
    IEnumerator DisablePanelRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

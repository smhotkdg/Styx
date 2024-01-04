using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MemoryCardListPanelController : MonoBehaviour
{
    
    public GameObject EventObject;
    public GameObject ViewObject;
    public Image Card;
    public Text CardText;
    public Text EndingText;
    public Sprite DefaultMemoryCard;
    public Sprite MemorySpriteCard1;
    public Sprite MemorySpriteCard2;
    public Sprite MemorySpriteCard3;
    public Sprite MemorySpriteCard4;
    public Sprite MemorySpriteCard5;
    public Sprite MemorySpriteCard6;
    public Sprite MemorySpriteCard7;
    public Sprite MemorySpriteCard8;

    public Sprite DefaultEndingCard;
    public Sprite EndingSpriteCard1;
    public Sprite EndingSpriteCard2;
    public Sprite EndingSpriteCard3;
    public Sprite EndingSpriteCard4;
    public Sprite EndingSpriteCard5;
    public Sprite EndingSpriteCard6;
    public Sprite EndingSpriteCard7;
    public Sprite EndingSpriteCard8;


    public Sprite Ending_ImageSpriteCard1;
    public Sprite Ending_ImageSpriteCard2;
    public Sprite Ending_ImageSpriteCard3;
    public Sprite Ending_ImageSpriteCard4;
    public Sprite Ending_ImageSpriteCard5;
    public Sprite Ending_ImageSpriteCard6;
    public Sprite Ending_ImageSpriteCard7;
    public Sprite Ending_ImageSpriteCard8;


    public Image MemroyCard1;
    public Image MemroyCard2;
    public Image MemroyCard3;
    public Image MemroyCard4;
    public Image MemroyCard5;
    public Image MemroyCard6;
    public Image MemroyCard7;
    public Image MemroyCard8;

    public Image EndingCard1;
    public Image EndingCard2;
    public Image EndingCard3;
    public Image EndingCard4;
    public Image EndingCard5;
    public Image EndingCard6;
    public Image EndingCard7;
    public Image EndingCard8;

    public Image Ending_ImageCard1;
    public Image Ending_ImageCard2;
    public Image Ending_ImageCard3;
    public Image Ending_ImageCard4;
    public Image Ending_ImageCard5;
    public Image Ending_ImageCard6;
    public Image Ending_ImageCard7;
    public Image Ending_ImageCard8;

    private void OnEnable()
    {
        SetData();
        UIManager.Instance.MemroyCardTutorial.SetActive(false);
    }
    //public Image Memroy
    void SetData()
    {
        if (GameManager.Instance.data.memoryCard_1 == 0)
        {
            MemroyCard1.sprite = DefaultMemoryCard;
            MemroyCard1.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard1.sprite = MemorySpriteCard1;
            MemroyCard1.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.memoryCard_2 == 0)
        {
            MemroyCard2.sprite = DefaultMemoryCard;
            MemroyCard2.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard2.sprite = MemorySpriteCard2;
            MemroyCard2.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.memoryCard_3 == 0)
        {
            MemroyCard3.sprite = DefaultMemoryCard;
            MemroyCard3.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard3.sprite = MemorySpriteCard3;
            MemroyCard3.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.memoryCard_4 == 0)
        {
            MemroyCard4.sprite = DefaultMemoryCard;
            MemroyCard4.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard4.sprite = MemorySpriteCard4;
            MemroyCard4.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.memoryCard_5 == 0)
        {
            MemroyCard5.sprite = DefaultMemoryCard;
            MemroyCard5.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard5.sprite = MemorySpriteCard5;
            MemroyCard5.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.memoryCard_6 == 0)
        {
            MemroyCard6.sprite = DefaultMemoryCard;
            MemroyCard6.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard6.sprite = MemorySpriteCard6;
            MemroyCard6.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.memoryCard_7 == 0)
        {
            MemroyCard7.sprite = DefaultMemoryCard;
            MemroyCard7.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard7.sprite = MemorySpriteCard7;
            MemroyCard7.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.memoryCard_8 == 0)
        {
            MemroyCard8.sprite = DefaultMemoryCard;
            MemroyCard8.GetComponent<Button>().enabled = false;
        }
        else
        {
            MemroyCard8.sprite = MemorySpriteCard8;
            MemroyCard8.GetComponent<Button>().enabled = true;
        }


        if (GameManager.Instance.data.EndingList[0] == 0)
        {
            EndingCard1.sprite = DefaultEndingCard;
            EndingCard1.GetComponent<Button>().enabled = false;
            Ending_ImageCard1.sprite = DefaultEndingCard;
            Ending_ImageCard1.GetComponent<Button>().enabled = false;
        }
        else
        {
            EndingCard1.sprite = EndingSpriteCard1;
            EndingCard1.GetComponent<Button>().enabled = true;
            Ending_ImageCard1.sprite = Ending_ImageSpriteCard1;
            Ending_ImageCard1.GetComponent<Button>().enabled = true;
        }

        if (GameManager.Instance.data.EndingList[1] == 0)
        {
            EndingCard2.sprite = DefaultEndingCard;
            EndingCard2.GetComponent<Button>().enabled = false;
            Ending_ImageCard2.sprite = DefaultEndingCard;
            Ending_ImageCard2.GetComponent<Button>().enabled = false;
        }
        else
        {
            EndingCard2.sprite = EndingSpriteCard2;
            EndingCard2.GetComponent<Button>().enabled = true;
            Ending_ImageCard2.sprite = Ending_ImageSpriteCard2;
            Ending_ImageCard2.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.EndingList[2] == 0)
        {
            EndingCard3.sprite = DefaultEndingCard;
            EndingCard3.GetComponent<Button>().enabled = false;
            Ending_ImageCard3.sprite = DefaultEndingCard;
            Ending_ImageCard3.GetComponent<Button>().enabled = false;
        }
        else
        {
            EndingCard3.sprite = EndingSpriteCard3;
            EndingCard3.GetComponent<Button>().enabled = true;
            Ending_ImageCard3.sprite = Ending_ImageSpriteCard3;
            Ending_ImageCard3.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.EndingList[3] == 0)
        {
            EndingCard4.sprite = DefaultEndingCard;
            EndingCard4.GetComponent<Button>().enabled = false;
            Ending_ImageCard4.sprite = DefaultEndingCard;
            Ending_ImageCard4.GetComponent<Button>().enabled = false;
        }
        else
        {
            EndingCard4.sprite = EndingSpriteCard4;
            EndingCard4.GetComponent<Button>().enabled = true;
            Ending_ImageCard4.sprite = Ending_ImageSpriteCard4;
            Ending_ImageCard4.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.EndingList[4] == 0)
        {
            EndingCard5.sprite = DefaultEndingCard;
            EndingCard5.GetComponent<Button>().enabled = false;
            Ending_ImageCard5.sprite = DefaultEndingCard;
            Ending_ImageCard5.GetComponent<Button>().enabled = false;
        }
        else
        {
            EndingCard5.sprite = EndingSpriteCard5;
            EndingCard5.GetComponent<Button>().enabled = true;
            Ending_ImageCard5.sprite = Ending_ImageSpriteCard5;
            Ending_ImageCard5.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.EndingList[5] == 0)
        {
            EndingCard6.sprite = DefaultEndingCard;
            EndingCard6.GetComponent<Button>().enabled = false;
            Ending_ImageCard6.sprite = DefaultEndingCard;
            Ending_ImageCard6.GetComponent<Button>().enabled = false;
        }
        else
        {
            EndingCard6.sprite = EndingSpriteCard6;
            EndingCard6.GetComponent<Button>().enabled = true;
            Ending_ImageCard6.sprite = Ending_ImageSpriteCard6;
            Ending_ImageCard6.GetComponent<Button>().enabled = true;
        }
        if (GameManager.Instance.data.EndingList[6] == 0)
        {
            EndingCard7.sprite = DefaultEndingCard;
            EndingCard7.GetComponent<Button>().enabled = false;
            Ending_ImageCard7.sprite = DefaultEndingCard;
            Ending_ImageCard7.GetComponent<Button>().enabled = false;
        }
        else
        {
            EndingCard7.sprite = EndingSpriteCard7;
            EndingCard7.GetComponent<Button>().enabled = true;
            Ending_ImageCard7.sprite = Ending_ImageSpriteCard7;
            Ending_ImageCard7.GetComponent<Button>().enabled = true;
        }

        if (GameManager.Instance.data.EndingList[6] == 1)
        {
            if(GameManager.Instance.isSpeacialEnding)
            {
                EndingCard8.sprite = EndingSpriteCard8;
                EndingCard8.GetComponent<Button>().enabled = true;
                Ending_ImageCard8.sprite = Ending_ImageSpriteCard8;
                Ending_ImageCard8.GetComponent<Button>().enabled = true;
                EndingCard8.transform.Find("Show").gameObject.SetActive(false);
                Ending_ImageCard8.transform.Find("Show").gameObject.SetActive(false);
                //if (GameManager.Instance.data.EndingCard_8)
            }
            else
            {
                EndingCard8.sprite = DefaultEndingCard;                
                Ending_ImageCard8.sprite = DefaultEndingCard;
                EndingCard8.transform.Find("Show").gameObject.SetActive(true);
                Ending_ImageCard8.transform.Find("Show").gameObject.SetActive(true);
                EndingCard8.GetComponent<Button>().enabled = true;                
                Ending_ImageCard8.GetComponent<Button>().enabled = true;
            }            
        }
        else
        {

            EndingCard8.sprite = DefaultEndingCard;
            EndingCard8.GetComponent<Button>().enabled = false;
            Ending_ImageCard8.sprite = DefaultEndingCard;
            Ending_ImageCard8.GetComponent<Button>().enabled = false;
            EndingCard8.transform.Find("Show").gameObject.SetActive(false);
            Ending_ImageCard8.transform.Find("Show").gameObject.SetActive(false);
        }
    }
    public void ClickMemroyCard(int index)
    {
        EventObject.SetActive(false);
        ViewObject.SetActive(true);
        Card.gameObject.transform.localScale = new Vector3(0, 0, 0);
        switch (index)
        {
            case 1:
                Card.sprite = MemorySpriteCard1;
                Card.gameObject.transform.position = MemroyCard1.transform.position;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card1);
                break;
            case 2:
                Card.sprite = MemorySpriteCard2;
                Card.gameObject.transform.position = MemroyCard2.transform.position;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card2);
                break;
            case 3:
                Card.sprite = MemorySpriteCard3;
                Card.gameObject.transform.position = MemroyCard3.transform.position;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card3);
                break;                
            case 4:
                Card.sprite = MemorySpriteCard4;
                Card.gameObject.transform.position = MemroyCard4.transform.position;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card4);
                break;
            case 5:
                Card.sprite = MemorySpriteCard5;
                Card.gameObject.transform.position = MemroyCard5.transform.position;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card5);
                break;
            case 6:
                Card.sprite = MemorySpriteCard6;
                Card.gameObject.transform.position = MemroyCard6.transform.position;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card6);
                break;
            case 7:
                Card.sprite = MemorySpriteCard7;
                Card.gameObject.transform.position = MemroyCard7.transform.position;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card7);
                break;
            case 8:
                Card.sprite = MemorySpriteCard8;
                Card.gameObject.transform.position = MemroyCard8.transform.localPosition;
                CardText.text = languageController.Instance.GetCardText(languageController.CardType.Card8);
                break;
        }
        Card.gameObject.transform.DOLocalMove(new Vector3(0, 140), 0.7f);
        Card.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.7f);
        CardText.gameObject.SetActive(true);
        EndingText.gameObject.SetActive(false);

    }
    public void ClickEndingCard(int index)
    {
        EventObject.SetActive(false);
        ViewObject.SetActive(true);
        string Ending ="";
        Card.gameObject.transform.localScale = new Vector3(0, 0, 0);
        Ending = languageController.Instance.GetEndingTitle(index) +"\n\n";
        Ending += languageController.Instance.GetEndingTitle_story(index);
        EndingText.text = Ending;
        switch (index)
        {
            case 0:                
                Card.sprite = EndingSpriteCard1;
                Card.gameObject.transform.position = EndingCard1.transform.position;
                break;
            case 1:
                Card.sprite = EndingSpriteCard2;
                Card.gameObject.transform.position = EndingCard2.transform.position;
                break;
            case 2:
                Card.sprite = EndingSpriteCard3;
                Card.gameObject.transform.position = EndingCard3.transform.position;
                break;
            case 3:
                Card.sprite = EndingSpriteCard4;
                Card.gameObject.transform.position = EndingCard4.transform.position;
                break;
            case 4:
                Card.sprite = EndingSpriteCard5;
                Card.gameObject.transform.position = EndingCard5.transform.position;
                break;
            case 5:
                Card.sprite = EndingSpriteCard6;
                Card.gameObject.transform.position = EndingCard6.transform.position;
                break;
            case 6:
                Card.sprite = EndingSpriteCard7;
                Card.gameObject.transform.position = EndingCard7.transform.position;
                break;
            case 7:
                EventObject.SetActive(true);                
                if (GameManager.Instance.isSpeacialEnding)
                {
                    Card.sprite = EndingSpriteCard8;
                    Card.gameObject.transform.position = EndingCard8.transform.position;
                    EndingText.text = I2.Loc.LocalizationManager.GetTermTranslation("Ending_Specail_Card");
                }
                else
                {
                    Card.sprite = DefaultEndingCard;
                }
                break;
        }
        Card.gameObject.transform.DOLocalMove(new Vector3(0, 140), 0.7f);
        Card.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.7f);
        CardText.gameObject.SetActive(false);
        EndingText.gameObject.SetActive(true);
    }

    public void ClickEndingCard_Image(int index)
    {
        EventObject.SetActive(false);
        ViewObject.SetActive(true);
        string Ending = "";
        Card.gameObject.transform.localScale = new Vector3(0, 0, 0);
        Ending = languageController.Instance.GetEndingTitle(index) + "\n\n";
        
        
        switch (index)
        {
            case 0:
                Card.sprite = Ending_ImageSpriteCard1;
                Card.gameObject.transform.position = Ending_ImageCard1.transform.position;
                Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_2");
                break;
            case 1:
                Card.sprite = Ending_ImageSpriteCard2;
                Card.gameObject.transform.position = Ending_ImageCard2.transform.position;                
                Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_1");
                break;
            case 2:
                Card.sprite = Ending_ImageSpriteCard3;
                Card.gameObject.transform.position = Ending_ImageCard3.transform.position;
                Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_4");
                break;
            case 3:
                Card.sprite = Ending_ImageSpriteCard4;
                Card.gameObject.transform.position = Ending_ImageCard4.transform.position;
                Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_5");
                break;
            case 4:
                Card.sprite = Ending_ImageSpriteCard5;
                Card.gameObject.transform.position = Ending_ImageCard5.transform.position;
                Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_3");
                break;
            case 5:
                Card.sprite = Ending_ImageSpriteCard6;
                Card.gameObject.transform.position = Ending_ImageCard6.transform.position;
                Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_3");
                break;
            case 6:
                Card.sprite = Ending_ImageSpriteCard7;
                Card.gameObject.transform.position = Ending_ImageCard7.transform.position;
                Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_6");
                break;
            case 7:
                EventObject.SetActive(true);
                if (GameManager.Instance.isSpeacialEnding)
                {
                    Ending = "";
                    Card.sprite = Ending_ImageSpriteCard8;
                    Card.gameObject.transform.position = Ending_ImageCard7.transform.position;
                    Ending += I2.Loc.LocalizationManager.GetTermTranslation("Ending_Specail");
                }
                else
                {
                    Card.sprite = DefaultEndingCard;
                }
                break;
        }
        Card.gameObject.transform.DOLocalMove(new Vector3(0, 140), 0.7f);
        Card.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.7f);
        CardText.gameObject.SetActive(false);
        EndingText.text = Ending;
        EndingText.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        if(GameManager.Instance.MemoryCardTutorial ==0)
        {
            GameManager.Instance.MemoryCardTutorial = 2;
            ES3.Save("MemoryCardTutorial", GameManager.Instance.MemoryCardTutorial);
            
            //UIManager.Instance.SetWindowTutorial(5);
            UIManager.Instance.CheckUI();
        }
        
    }
}

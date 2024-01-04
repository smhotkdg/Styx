using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EndingCard : MonoBehaviour
{
    //게임 매니저용 
    public enum EndingType
    {
        EscapeFail, // 0 1 2 3 4 5, 7
        EscapeSuccess, // 0 1 2 3 4 5,6
        revolutionary_army_Kill, //0,1,2,3,4,8,9,11 //the pool
        revolutionary_army, //0,1,2,3,4,8,9,10
        headmaster_kill,//0,1,2,3,4,8,13,15 // the devil
        headmaster,//0,1,2,3,4,8,13,14 //the tower
        hidden, //0,1,2,3,4,8,910,12 //ace of wand
        non

    };
    public GameObject ButtonObject;
    public GameObject BG;
    public Sprite InitSprite;
    public List<Sprite> EndingCardList;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        GetComponent<Image>().sprite = InitSprite;
        GetComponent<Button>().interactable = false;
        GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
        BG.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
        StartCoroutine(DesintegrationRoutine_2(2f, this.gameObject));
        StartCoroutine(DesintegrationRoutine(2f, BG));

        GetComponent<DOTweenAnimation>().DOKill();
        GetComponent<Animator>().enabled = false;
        ButtonObject.SetActive(false);
        ButtonObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
        ButtonObject.transform.Find("Image").GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
    }
    public void SetBackward()
    {
        StartCoroutine(DesintegrationRoutine_Back(0.7f, this.gameObject));
        StartCoroutine(DesintegrationRoutine_Back(0.7f, BG));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetEndingCard()
    {        
        GetComponent<Image>().sprite = EndingCardList[(int)GameManager.Instance.endingType];
        GetComponent<Button>().interactable = false;
        GetComponent<DOTweenAnimation>().DOKill();
        ButtonObject.SetActive(true);
        StartCoroutine(DesintegrationRoutine_2(2f, ButtonObject));
        StartCoroutine(DesintegrationRoutine_2(2f, ButtonObject.transform.Find("Image").gameObject));
    }
    IEnumerator DesintegrationRoutine_Back(float time, GameObject inputObject)
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration += 0.01f;
            if (inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration >=1)
            {
                inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;                
                break;
            }

        }
    }
    IEnumerator DesintegrationRoutine_2(float time, GameObject inputObject)
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration -= 0.01f;
            if (inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration <= 0)
            {
                inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 0;        
                break;
            }

        }
    }
    IEnumerator DesintegrationRoutine(float time, GameObject inputObject)
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration -= 0.01f;
            if (inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration <= 0)
            {
                inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 0;
                GetComponent<Button>().interactable = true;
                GetComponent<DOTweenAnimation>().DORestart();
                break;
            }

        }
    }
}

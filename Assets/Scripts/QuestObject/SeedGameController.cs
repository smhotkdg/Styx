using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
public class SeedGameController : MonoBehaviour
{
    public GameObject Sowing;
    public GameObject Watering;
    public GameObject Harvest;

    public Image FillSowing;
    public Image FillWatering;

    public delegate void OnEndPanelEnvet();
    public event OnEndPanelEnvet onOnEndPanelEnvetHandler;


    public delegate void OnDisablePanel();
    public event OnDisablePanel OnDisablePanelEvent;

    public Text TutorialText;
    public Image SeaweedImage;
    public Image PrograssBar;
    int ClickCount = 0;
    bool bEnd = false;

    float sowingTime = 0;
    private void OnEnable()
    {
        sowingTime = 0;
        FillWatering.fillAmount = 0;
        FillSowing.fillAmount = 0;
    }
    public void SetView(SeedController.seedType seed, GameObject inputObj)
    {
        seaweedObject = inputObj;
        Sowing.SetActive(false);
        Watering.SetActive(false);
        Harvest.SetActive(false);
        sowingTime = 0;
        switch (seed)
        {
            case SeedController.seedType.sowing:
                Sowing.SetActive(true);
                break;
            case SeedController.seedType.watering:
                Watering.SetActive(true);
                break;
            case SeedController.seedType.harvest:
                TutorialText.gameObject.SetActive(true);
                PrograssBar.fillAmount = 0;
                startValue = 0;
                actualValue = 0;
                ClickCount = 0;
                SeaweedImage.gameObject.SetActive(true);
                SeaweedImage.transform.localScale = new Vector3(1, 1, 1);
                bEnd = false;
                Harvest.SetActive(true);
                break;
        }
    }
    bool bSowingStart = false;
    public void ClickSowing()
    {
        if (bSowingStart)
            return;
        sowingTime = 0;
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
        bSowingStart = true;
    }
    bool bWateringStart = false;
    public void ClickWatering()
    {
        if (bWateringStart)
            return;
        sowingTime = 0;
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
        bWateringStart = true;
    }
    private void Update()
    {
        if (bSowingStart)
        {
            sowingTime += Time.deltaTime;
            float deltaTime = sowingTime / 15;
            FillSowing.fillAmount = deltaTime;
            if(deltaTime >= 1)
            {
                bSowingStart = false;
                //DialogueManager.ShowAlert(languageController.Instance.GetSeedresult(languageController.ObjectName.sowing));
                GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.sowing);
                if(seaweedObject!=null)
                {
                    seaweedObject.GetComponent<SeedController>().type = SeedController.seedType.sowing;
                    GameManager.Instance.fullTimeFamerQuestItme_2++;
                    DialogueLua.SetVariable("fullTimeFamerQuestItme_2", GameManager.Instance.fullTimeFamerQuestItme_2);
                    onOnEndPanelEnvetHandler?.Invoke();
                }
                this.gameObject.SetActive(false);
            }            
        }
        if(bWateringStart)
        {
            sowingTime += Time.deltaTime;
            float deltaTime = sowingTime / 15;
            FillWatering.fillAmount = deltaTime;
            if (deltaTime >= 1)
            {
                bSowingStart = false;
                //DialogueManager.ShowAlert(languageController.Instance.GetSeedresult(languageController.ObjectName.watering));
                GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.watering);
                if (seaweedObject != null)
                {
                    seaweedObject.GetComponent<SeedController>().type = SeedController.seedType.watering;
                    GameManager.Instance.fullTimeFamerQuestItme_3++;
                    DialogueLua.SetVariable("fullTimeFamerQuestItme_3", GameManager.Instance.fullTimeFamerQuestItme_3);
                    onOnEndPanelEnvetHandler?.Invoke();
                }
                this.gameObject.SetActive(false);
            }
        }
    }
    public void ClickSeaweed()
    {
        SeaweedImage.transform.DOShakeScale(0.1f, 0.5f);
        TutorialText.gameObject.SetActive(false);
        ClickCount++;
        SetPrograss();
    }
    float actualValue = 0f; // the goal
    float startValue = 0f; // animation start value
    float displayValue = 0f; // value during animation
    public float timer = 0f;

    void SetPrograss()
    {
        actualValue += 0.1f;
        if (actualValue > 0.1f)
        {
            startValue = actualValue - 0.1f;
        }
        timer = 0;
    }
    GameObject seaweedObject;
    public void SetSeawood(GameObject seaweed)
    {
        seaweedObject = seaweed;
    }

    private void FixedUpdate()
    {
        if (bEnd == true)
        {
            return;
        }
        timer += Time.deltaTime;
        displayValue = Mathf.Lerp(startValue, actualValue, timer * 5);
        PrograssBar.fillAmount = displayValue;
        if (displayValue >= 1)
        {
            //해조류 수확
            //
            if(seaweedObject!=null)
            {
                seaweedObject.GetComponent<SeedController>().type = SeedController.seedType.harvest;

                GameManager.Instance.fullTimeFamerQuestItme_4++;
                DialogueLua.SetVariable("fullTimeFamerQuestItme_4", GameManager.Instance.fullTimeFamerQuestItme_4);
                onOnEndPanelEnvetHandler?.Invoke();
            }
            SeaweedImage.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.3f).SetEase(Ease.OutBounce).OnComplete(CompleteAnim);
            bEnd = true;
        }
    }
    void CompleteAnim()
    {
        SeaweedImage.gameObject.SetActive(false);
        GameManager.Instance.SetEffect(GameManager.EffectType.seed, SeaweedImage.transform.position);
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.harvestObject);
        StartCoroutine(EndRoutine());
        if (seaweedObject != null)
        {
            seaweedObject.GetComponent<FruitObjectController>().DisalbeRoutine();

        }
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
    }
    
    IEnumerator EndRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        bSowingStart = false;
        bWateringStart = false;
        if (GameManager.Instance !=null)
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
        }
        OnDisablePanelEvent?.Invoke();
    }
}

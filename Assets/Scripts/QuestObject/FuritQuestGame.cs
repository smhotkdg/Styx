using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PixelCrushers.DialogueSystem;

public class FuritQuestGame : MonoBehaviour
{
    public delegate void OnEndPanelEnvet();
    public event OnEndPanelEnvet onOnEndPanelEnvetHandler;

    public Text TutorialText;
    public Image SeaweedImage;
    public Image PrograssBar;
    int ClickCount = 0;
    bool bEnd = false;
    private void OnEnable()
    {
        TutorialText.gameObject.SetActive(true);
        PrograssBar.fillAmount = 0;
        startValue = 0;
        actualValue = 0;
        ClickCount = 0;
        SeaweedImage.gameObject.SetActive(true);
        SeaweedImage.transform.localScale = new Vector3(1, 1, 1);
        bEnd = false;

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
            GameManager.Instance.styxData.fruitCount += 1;
            TestCodeManager.Instance.CheckDialogueData();
            if(GameManager.Instance.styxData.fullTimeFamerQuest =="active")
            {
                GameManager.Instance.HarvestFruitCount++;
                DialogueLua.SetVariable("fullTimeFamerQuestItme_1", GameManager.Instance.HarvestFruitCount);
            }
                
            SeaweedImage.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.3f).SetEase(Ease.OutBounce).OnComplete(CompleteAnim);
            bEnd = true;
        }
    }
    void CompleteAnim()
    {
        SeaweedImage.gameObject.SetActive(false);
        GameManager.Instance.SetEffect(GameManager.EffectType.fruit, SeaweedImage.transform.position);
        StartCoroutine(EndRoutine());
        if (seaweedObject != null)
        {
            seaweedObject.GetComponent<FruitObjectController>().DisalbeRoutine();

        }
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.fruit);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
    }
    IEnumerator EndRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        onOnEndPanelEnvetHandler?.Invoke();
    }
}

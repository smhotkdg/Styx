using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class frequencyGameManager : MonoBehaviour
{
    public SickNPCController sickNPC;
    public GameObject Target;
    public Text NowFrequencyText;
    public Text FrequencyText;
    public Transform LineTransfrom;
    public bool isMove = false;
    float speed = 2;
    public _2dxFX_Ghost ghost;
    public int frequencyValue = 260;

    public Image LeverImage;
    public Sprite LeverEnable;
    public Sprite LeverDisable;

    public Image DisplayImage;
    public delegate void OnComplete();
    public event OnComplete OnCompleteEventHandler;
    // Start is called before the first frame update
    
    void Start()
    {
        
        NowFrequencyText.text = frequencyIndex.ToString();
        frequencyIndex = 0;
        
    }
    private void OnEnable()
    {        
        frequencyIndex = 0;
        
        NowFrequencyText.text = frequencyIndex.ToString();
        LeverImage.sprite = LeverDisable;
        DisplayImage.color = new Color(0.78f, 0, 0, 1);
        LeverImage.transform.localScale = new Vector3(1, 1, 1);        
        
        LineTransfrom.localPosition = new Vector3(-156,0,0);        
        
    }

    // Update is called once per frame
    void Update()
    {        
        float shininess = Mathf.PingPong(Time.time*speed, 1.0f);
        ghost._Alpha = shininess;
    }
    public void CheckSuccess(int dialCount)
    {
        
    }
    int frequencyIndex;
    int maxValue = 52;
    int remainCount;
    public void MoveDial(int dialCount)
    {
        remainCount = -1;
        if (frequencyIndex+dialCount >=maxValue)
        {
            remainCount = (frequencyIndex + dialCount) - maxValue;
            dialCount = maxValue - frequencyIndex;
            SetMove(dialCount,remainCount,0.25f);
            
        }
        else
        {
            frequencyIndex += dialCount;            
            SetMove(dialCount,-1,0.5f);
            StartCoroutine(increaseDialCount(dialCount));
        }
        
    }
    IEnumerator increaseDialCount(int count)
    {
        float startValue = (frequencyIndex -(count))*10;
        if(startValue <0)
        {
            startValue = 0;
        }
        float value = count;
        for (int i =0; i< 10;i++)
        {
            startValue += value;
            NowFrequencyText.text = (startValue).ToString();
            yield return new WaitForSeconds(0.05f);
        }
        NowFrequencyText.text = (frequencyIndex * 10).ToString();
    }
    void SetMove(int index,int reaminCount,float Time)
    {
         if(reaminCount >=0)
        {
            frequencyIndex = 0;
        }
        Vector3 moveVec = LineTransfrom.localPosition;
        float xValue = moveVec.x + (index * 6);
        moveVec.x = xValue;
        LineTransfrom.DOLocalMove(moveVec, Time).SetEase(Ease.Linear).OnComplete(OnCompleteTween);
       
    }
    void OnCompleteTween()
    {
        if(frequencyIndex ==0)
        {
            LineTransfrom.DOLocalMove(new Vector3(-156, 0,0), 0.25f).SetEase(Ease.Linear).OnComplete(OnCompleteInitPos);
            frequencyIndex = remainCount;
            StartCoroutine(increaseDialCount(remainCount));
            //CheckResult();
        }
        else
        {
            isMove = false;
            //CheckResult();
        }
    }
    void OnCompleteInitPos()
    {
        Vector3 moveVec = LineTransfrom.localPosition;
        float xValue = moveVec.x + (remainCount * 6);
        moveVec.x = xValue;
        LineTransfrom.DOLocalMove(moveVec, 0.5f).SetEase(Ease.Linear);
        isMove = false;        
    }
    public void CheckResult()
    {
        if(frequencyIndex*10 == frequencyValue)
        {
            Debug.Log("성공");
            sickNPC.isBronek = true;
            LeverImage.transform.DOShakeScale(0.5f, 0.1f);
            LeverImage.transform.localScale = new Vector3(1, -1, 1);
            //LeverImage.sprite = LeverEnable;
            DisplayImage.color = new Color(0, 0.78f, 0, 1);
            StartCoroutine(endRoutine());

            //TestCodeMvnager.Instance.GetRaido();
            GameManager.Instance.SetPlayerWork(false);            
            OnCompleteEventHandler?.Invoke();
            GameManager.Instance.data.RingerGameSuccess = true;
            
        }
        else
        {
            LeverImage.transform.DOShakeScale(0.5f, 0.1f);
        }
    }
    IEnumerator endRoutine()
    {
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Radio));
        yield return new WaitForSeconds(0.7f);
        GameManager.Instance.SetCameraTarget(Target, 0.5f);
        //UIManager.Instance.SetquestUpdate(QuestCheckerController.CheckerType.EscapeSub2);
        //GameManager.Instance.styxData.EscapeSubQuestNumber = 2;
        GameManager.Instance.SaveStyxData();
        this.gameObject.SetActive(false);
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.pacemaker);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Part5CctvGame : MonoBehaviour
{
    public bool isPart5_1 = true;
    public GameObject PlayerObject;
    public GameObject FrinedObjectObject;
    public Image FillImage;
    public Animator CCTVPlayer;
    public Animator CCTVFriend;
    public Animator CCTVGuard;
    public GameObject CCTVObject;
    public Text CCtvText;
    float time = 34;
    public Text ResultText;
    public string ResultString;
    public GameObject DeleteButton;
    public List<Image> ImageList;

    public delegate void OnCompleteQuest();
    public event OnCompleteQuest OnCompleteQuestEventHandler;
    IEnumerator cctvRoutine;
    private void OnEnable()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.CCTV);
        DeleteButton.SetActive(false);
        bTween = false;
        if(isPart5_1)
        {
            if(GameManager.Instance.data.language==0)
            {
                ResultText.text = "--";
            }
            else if(GameManager.Instance.data.language ==1)
            {
                ResultText.text = "------";
            }
            else if(GameManager.Instance.data.language==2)
            {
                ResultText.text = "------";
            }
            else
            {
                ResultText.text = "------";
            }
            
        }
        else
        {
            if (GameManager.Instance.data.language == 0)
            {
                ResultText.text = "---";
            }
            else if (GameManager.Instance.data.language == 1)
            {                
                ResultText.text = "------";
            }
            else if (GameManager.Instance.data.language == 2)
            {
                ResultText.text = "------";
            }
            else
            {
                ResultText.text = "------";
            }
            
        }
        
        ResultString = string.Empty;

        CCtvText.text = "88/06/14 11:21:"+time.ToString("N0");
        FillImage.fillAmount = 0;
        CCTVObject.SetActive(true);
        
        if(isPart5_1)
        {
            CCTVGuard.Play("idle");
        }
        else
        {
            CCTVGuard.gameObject.SetActive(false);
        }
        cctvRoutine = CCTVRoutine();
        StartCoroutine(cctvRoutine);
        FillImage.fillAmount = 0;
        FillImage.DOFillAmount(1, 6).SetEase(Ease.Linear).OnComplete(oncompleteFillFull);

        for(int i =0; i< ImageList.Count; i++)
        {
            ImageList[i].color = new Color32(200, 200, 200, 255);
        }
        if(isPart5_1)
        {
            if (GameManager.Instance.data.isShootPoolGuard)
            {
                PlayerObject.SetActive(true);
                FrinedObjectObject.SetActive(false);
                CCTVPlayer.Play("gun_gun_start");
            }
            else
            {
                PlayerObject.SetActive(false);
                FrinedObjectObject.SetActive(true);
                CCTVFriend.Play("gun_ready");
            }
        }
        else
        {
            CCTVFriend.Play("choke");
        }
      
    }
   
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        CCtvText.text = "88/06/14 11:21:" + time.ToString("N0");
    }
    void oncompleteFillFull()
    {
        time = 34;
        FillImage.fillAmount = 0;

        if(isPart5_1)
        {
            if (GameManager.Instance.data.isShootPoolGuard)
            {
                CCTVPlayer.Play("gun_gun_start");
            }
            else
            {
                CCTVFriend.Play("gun_ready");
            }

            CCTVGuard.Play("idle");
        }

        else
        {
            CCTVGuard.gameObject.SetActive(false);
            CCTVFriend.Play("choke");
        }
        if(isPart5_1)
        {
            if (this.gameObject.activeSelf)
            {
                StartCoroutine(CCTVRoutine());
                FillImage.DOFillAmount(1, 6).SetEase(Ease.Linear).OnComplete(oncompleteFillFull);
            }
        }
        if (this.gameObject.activeSelf)
        {            
            FillImage.DOFillAmount(1, 6).SetEase(Ease.Linear).OnComplete(oncompleteFillFull);
        }


    }
    IEnumerator CCTVRoutine()
    {
        yield return new WaitForSeconds(2f);
        if (isPart5_1)
        {

            if (GameManager.Instance.data.isShootPoolGuard)
            {
                CCTVPlayer.Play("gun_shooting");
                yield return new WaitForSeconds(0.2f);
                CCTVGuard.Play("dead");
            }
            else
            {
                CCTVFriend.Play("CCTV_gunShoot");
                yield return new WaitForSeconds(0.7f);
                CCTVGuard.Play("dead");
            }
        }
     
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    bool bTween = false;
    public void SelectNumber(Text inputText)
    {
        int removeCount = -1;
        if (inputText.transform.parent.GetComponent<Image>().color.b ==0)
        {
            removeCount = ResultString.LastIndexOf(inputText.text); 
        }
        
        if (removeCount < 0)
        {
            inputText.transform.parent.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
            ResultString += inputText.text;
        }
        else
        {
            inputText.transform.parent.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            ResultString = ResultString.Remove(removeCount, 1);

        }
        ResultText.text = ResultString;
        if (bTween == false)
        {
            bTween = true;
            ResultText.DOColor(new Color(1, 1, 1, 0.1f), 0.25f).From(false).SetLoops(3).OnComplete(EndTween);
        }
        //여기서 언어별로 변경
        //switch(GameManager.Instance.)
        if(isPart5_1)
        {
            if (ResultString.Length == 0)
            {
                if (GameManager.Instance.data.language == 0)
                {
                    ResultText.text = "--";
                }
                else if (GameManager.Instance.data.language == 1)
                {
                    ResultText.text = "------";
                }
                else if(GameManager.Instance.data.language ==2)
                {
                    ResultText.text = "------";
                }
                else
                {
                    ResultText.text = "------";
                }
                //ResultText.text = "--";
            }
            if (GameManager.Instance.data.language == 0)
            {
                if (ResultString == "비밀")
                {
                    //성공
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Secret");
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }
            else if(GameManager.Instance.data.language ==1)
            {
                if (ResultString == "secret")
                {
                    //성공
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Secret");
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }
            else if(GameManager.Instance.data.language ==2)
            {
                if (ResultString == "secret")
                {
                    //성공
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Secret");
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }
            else
            {
                if (ResultString == "secret")
                {
                    //성공
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Secret");
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }
         
        }
        else
        {
            if (ResultString.Length == 0)
            {
                //ResultText.text = "---";
                if (GameManager.Instance.data.language == 0)
                {
                    ResultText.text = "---";
                }
                else if (GameManager.Instance.data.language == 1)
                {
                    ResultText.text = "------";
                }
                else if (GameManager.Instance.data.language == 2)
                {
                    ResultText.text = "------";
                }
            }
            if(GameManager.Instance.data.language ==0)
            {
                if (ResultString == "그림자")
                {
                    //성공
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Shadow");
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }
            else if (GameManager.Instance.data.language == 1)
            {
                if (ResultString == "shadow")
                {
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Shadow");
                    //성공
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }
            else if (GameManager.Instance.data.language == 2)
            {
                if (ResultString == "shadow")
                {
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Shadow");
                    //성공
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }
            else
            {
                if (ResultString == "shadow")
                {
                    FirebaseNotificationContorller.Instance.LogEvent("Part_6_CCTV_Shadow");
                    //성공
                    DeleteButton.SetActive(true);
                    DeleteButton.GetComponent<Animator>().Play("DeleteButtonOn");
                }
                else
                {
                    if (DeleteButton.activeSelf == true)
                    {
                        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");
                    }
                }
            }

        }
      
    }
    public void SetDelete()
    {
        DeleteButton.GetComponent<Animator>().Play("DeleteButtonOff");

        CCTVObject.AddComponent<CameraPlay_Noise>();
        StartCoroutine(endRoutine());
    }
    private void OnDisable()
    {
        SoundsManager.Instance.StopSoundsFx(SoundsManager.SoundsType.CCTV);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        StopCoroutine(cctvRoutine);
        DOTween.Kill(FillImage);
    }
    IEnumerator endRoutine()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().Play("cctvOff");
        OnCompleteQuestEventHandler?.Invoke();
    }
    
    void EndTween()
    {
        bTween = false;
    }
}

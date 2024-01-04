using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProfessorClockGame : MonoBehaviour
{
    public _2dxFX_LightningBolt MainImage;
    public Image Hour1;
    public Image Hour2;

    public Image Min1;
    public Image Min2;

    public Image PM_AM;
    public List<Sprite> NumberList;
    public Sprite SpritePM;
    public Sprite SpriteAM;

    int defaultHour = 5;
    int defaultMin = 3;

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

    public GameObject FindUI;
    public GameObject ExitButton;
    
    bool isPM = false;

    int hour;
    int min;
    private void OnEnable()
    {
        isSuccess = false;
        MainImage.enabled = false;
        MainImage.gameObject.SetActive(true);
        ExitButton.SetActive(true);
        FindUI.SetActive(false);
        MainImage.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        FindUI.GetComponent<CanvasGroup>().alpha = 0;
        Hour1.GetComponent<_2dxFX_BurningFX>().enabled = false;
        Hour2.GetComponent<_2dxFX_BurningFX>().enabled = false;
        Min1.GetComponent<_2dxFX_BurningFX>().enabled = false;
        Min2.GetComponent<_2dxFX_BurningFX>().enabled = false;
        if (isPM)
        {
            PM_AM.sprite = SpritePM;
        }
        else
        {
            PM_AM.sprite = SpriteAM;
        }
        hour = defaultHour;
        min = defaultMin;
        StartCoroutine(EnableGameRoutine());
  
    }
    IEnumerator EnableGameRoutine()
    {
        btn1.enabled = false;
        btn2.enabled = false;
        btn3.enabled = false;
        btn4.enabled = false;

        for(int i=0; i< 20; i++)
        {
            int rand = Random.Range(0, NumberList.Count);
            Hour1.sprite = NumberList[rand];
            rand = Random.Range(0, NumberList.Count);
            Hour2.sprite = NumberList[rand];
            rand = Random.Range(0, NumberList.Count);
            Min1.sprite = NumberList[rand];
            rand = Random.Range(0, NumberList.Count);
            Min2.sprite = NumberList[rand];
            yield return new WaitForSeconds(0.05f);
        }


        btn1.enabled = true;
        btn2.enabled = true;
        btn3.enabled = true;
        btn4.enabled = true;
        Hour1.sprite = NumberList[0];
        Hour2.sprite = NumberList[5];

        Min1.sprite = NumberList[3];
        Min2.sprite = NumberList[0];
        
    }
    void CheckPM()
    {
        if (isPM)
        {
            PM_AM.sprite = SpritePM;
        }
        else
        {
            PM_AM.sprite = SpriteAM;
        }
    }

    public void CheckHour()
    {
        if(hour<10)
        {
            Hour1.sprite = NumberList[0];
            Hour2.sprite = NumberList[hour];
        }
        else
        {
            Hour1.sprite = NumberList[1];
            Hour2.sprite = NumberList[hour -10];
        }
        CheckPM();
    }
    public void CheckMin()
    {
        Min1.sprite = NumberList[min];
        Min2.sprite = NumberList[0];
        
    }

    public void SetHour(bool isPlus)
    {
        if(isPlus)
        {
            hour++;
            if (hour > 12)
            {
                hour = 1;                
            }
            if(hour >11)
            {
                isPM = !isPM;
            }
        }
        else
        {
            if(hour==12)
            {
                isPM = !isPM;
            }
            hour--;
            if (hour < 1)
            {
                hour = 12;
                
            }
        }     
        CheckHour();
        CheckResult();
    }
    public void SetMin(bool isPlus)
    {
        if(isPlus)
        {
            min++;
            if(min >= 6)
            {
                SetHour(true);
                min = 0;
            }
        }
        else
        {
            min--;
            if(min <0)
            {
                SetHour(false);
                min = 5;
            }
        }
        CheckMin();
        CheckResult();
    }
    bool isSuccess = false;
    public void CheckResult()
    {
        if(min==0 && isPM==true && hour ==2 && isSuccess==false)
        {
            btn1.enabled = false;
            btn2.enabled = false;
            btn3.enabled = false;
            btn4.enabled = false;
            MainImage.enabled = true;            
            isSuccess = true;
            StartCoroutine(EndRoutine());
        }
    }
    IEnumerator EndRoutine()
    {
        Hour1.GetComponent<_2dxFX_BurningFX>().enabled = true;
        Hour2.GetComponent<_2dxFX_BurningFX>().enabled = true;
        Min1.GetComponent<_2dxFX_BurningFX>().enabled = true;
        Min2.GetComponent<_2dxFX_BurningFX>().enabled = true;

        yield return new WaitForSeconds(0.5f);
        ExitButton.SetActive(false);
        FindUI.SetActive(true);
        for (int i=0; i< 25; i++)
        {
            MainImage.gameObject.GetComponent<CanvasGroup>().alpha -= 0.04f;
            FindUI.GetComponent<CanvasGroup>().alpha += 0.04f;
            yield return new WaitForSeconds(0.1f);
        }
        MainImage.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        FindUI.GetComponent<CanvasGroup>().alpha =1;
        MainImage.gameObject.SetActive(false);
    }
}

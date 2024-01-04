using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class TimerContorller : MonoBehaviour
{
    public Text TimeText;
    public enum TimerType
    {
        lampTownManger,
        Non
    }
    TimerType m_timerType;
    public void StartTimer(TimerType timerType)
    {
        m_timerType = timerType;
        switch (timerType)
        {
            case TimerType.lampTownManger:
                TimeText.text = getTime(GameManager.Instance.styxData.questTime);
                break;
        }
    }
    private void Update()
    {
        switch (m_timerType)
        {
            case TimerType.lampTownManger:
                if(DialogueLua.GetQuestField("warehouseManagerQuest","State").asString == "active")
                {
                    GameManager.Instance.styxData.questTime -= Time.deltaTime;
                    TimeText.text = getTime(GameManager.Instance.styxData.questTime);
                    if(GameManager.Instance.styxData.questTime <1)
                    {
                        TestCodeManager.Instance.isResetQuestData = true;
                        TestCodeManager.Instance.warehouseInitConversationEnd(true);
                        TestCodeManager.Instance.isResetQuestData = false;
                        //UIManager.Instance.CheckQuestGuide();
                    }
                }                
                break;
        }        
    }

    public string getTime(float inputTime)
    {
        string timestr = string.Empty;
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(inputTime);
        int timecount = 0;
        if (timeSpan.Days > 0)
        {
            timestr += timeSpan.Days + " : ";
            timecount++;
        }
        if (timeSpan.Hours > 0)
        {
            timestr += timeSpan.Hours + " : ";
            timecount++;
        }
        if (timeSpan.Minutes >= 0 && timecount != 2)
        {
            if(timeSpan.Minutes <10)
            {
                timestr += "0"+timeSpan.Minutes + " : ";
                if (timeSpan.Minutes==0)
                {
                    timestr = "00 : ";
                }
            }
            else
            {
                timestr += timeSpan.Minutes + " : ";
            }
            
            
            timecount++;
        }
        if (timeSpan.Seconds >= 0 && timecount != 2)
        {
            if (timeSpan.Seconds < 10)
            {
                
                if (timeSpan.Seconds == 0 && timeSpan.Minutes ==0)
                {
                    timestr = "00 : 00";
                }
                else if(timeSpan.Seconds ==0)
                {
                    timestr += "00";
                }
                else
                {
                    timestr += "0" + timeSpan.Seconds;
                }
            }
            else
            {
                timestr += timeSpan.Seconds;
            }
            
            timecount++;
        }
        return timestr;
    }
}

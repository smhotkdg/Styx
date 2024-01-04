using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoomTimer : MonoBehaviour
{
    public Text TimerText;
    // Start is called before the first frame update
    public float time = 5;
    public delegate void OnTimerEnd();
    public event OnTimerEnd OnTimerEndEvnetHandler;
    bool isEnd = false;
    private void OnEnable()
    {
        isEnd = true;
        time = 5;
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.CountDown);
        SetText();
    }
    private void OnDisable()
    {
        SoundsManager.Instance.StopSoundsFx(SoundsManager.SoundsType.CountDown);
    }
    public void StartTImer()
    {
        isEnd = false;
    }
    void SetText()
    {
        if(time <10)
        {
            TimerText.text = "0" + time.ToString("N2");
        }
        else
        {
            TimerText.text = time.ToString("N2");
        }        
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnd)
            return;
        time -= Time.deltaTime;
        if(time <=0)
        {
            time = 0;
            isEnd = true;
            OnTimerEndEvnetHandler?.Invoke();
        }
        SetText();
    }
}

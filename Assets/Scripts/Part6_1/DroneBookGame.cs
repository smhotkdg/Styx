using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DroneBookGame : MonoBehaviour
{
    public Image FillImage;
    public Text FillText;
    public GameObject Ok;
    public GameObject XObject;
    public delegate void Oncomplete(bool isComplete);
    public event Oncomplete OnCompleteEventHandler;
    public List<Text> TextList;
    float time;
    public float DefaultTime = 60;
    private void OnEnable()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.DronBGM);
        setInitData();
        XObject.SetActive(false);
        Ok.SetActive(false);
        FillImage.fillAmount = 1;
        time = DefaultTime;
        SetText();
        isEnd = false;
        GameManager.Instance.cameraEffectController.Start_Matrix(true);
    }
    private void OnDisable()
    {
        SoundsManager.Instance.StopSoundsFx(SoundsManager.SoundsType.DronBGM);
    }
    void setInitData()
    {
        int position = Random.Range(0, TextList.Count);
        for(int  i=0; i< TextList.Count; i++)
        {
            TextList[i].text = "5";
        }
        TextList[position].text = "2";
    }
    bool isEnd = false;
    private void Update()
    {
        if (isEnd == false)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                GetComponent<Animator>().Play("calendarUIOff");
                GameManager.Instance.cameraEffectController.Start_Matrix(false);
                OnCompleteEventHandler?.Invoke(false);
                isEnd = true;
                SetText();
            }
            SetText();
        }
    }
    void SetText()
    {
        FillText.text = time.ToString("N0");
        FillImage.fillAmount = time/ DefaultTime;
    }
    public void ClickGame(GameObject clickObject)
    {
        if(clickObject.GetComponent<Text>().text == "2")
        {
            Ok.SetActive(true);
            Ok.transform.localPosition = clickObject.transform.localPosition;
            OnCompleteEventHandler?.Invoke(true);
        }
        else
        {
            XObject.SetActive(true);
            XObject.transform.localPosition = clickObject.transform.localPosition;
            OnCompleteEventHandler?.Invoke(false);
        }
        GetComponent<Animator>().Play("calendarUIOff");
        GameManager.Instance.cameraEffectController.Start_Matrix(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SewerLight : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;

    public List<GameObject> ButtonList;
    public List<GameObject> LightList;
    private void OnEnable()
    {
        SetDisable();
    }
    void SetDisable()
    {
        for (int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].GetComponent<Image>().sprite = OffSprite;
        }
        for (int i = 0; i < LightList.Count; i++)
        {
            LightList[i].SetActive(false);
        }
    }
    private void Start()
    {
        LightList[0].transform.Find("Light").gameObject.GetComponent<FlashLightFindObject>().OnFindObjectEventHandler += SewerLight_OnFindObjectEventHandler;
        LightList[1].transform.Find("Light").gameObject.GetComponent<FlashLightFindObject>().OnFindObjectEventHandler += SewerLight_OnFindObjectEventHandler1;
        LightList[2].transform.Find("Light").gameObject.GetComponent<FlashLightFindObject>().OnFindObjectEventHandler += SewerLight_OnFindObjectEventHandler2;
        LightList[3].transform.Find("Light").gameObject.GetComponent<FlashLightFindObject>().OnFindObjectEventHandler += SewerLight_OnFindObjectEventHandler3; 
    }

    private void SewerLight_OnFindObjectEventHandler3(GameObject findObject)
    {
        BeforeObject = findObject;
    }

    private void SewerLight_OnFindObjectEventHandler2(GameObject findObject)
    {
        BeforeObject = findObject;
    }

    private void SewerLight_OnFindObjectEventHandler1(GameObject findObject)
    {
        BeforeObject = findObject;
    }

    private void SewerLight_OnFindObjectEventHandler(GameObject findObject)
    {
        BeforeObject = findObject;
    }

    public GameObject BeforeObject;
    public void ClickButton(int index)
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.FlashLIght);
        if (BeforeObject != null)
        {
            BeforeObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (LightList[index].activeSelf)
        {
            SetDisable();
            if (BeforeObject != null)
            {
                BeforeObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            SetDisable();
            ButtonList[index].GetComponent<Image>().sprite = OnSprite;
            LightList[index].SetActive(true);
            
        }
        
    }
   
}

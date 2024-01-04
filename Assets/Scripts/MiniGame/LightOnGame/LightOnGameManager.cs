using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class LightOnGameManager : MonoBehaviour
{
    public List<SwitchController> switchControllers;
    public List<GameObject> Lights;
    int LightCount=0;
    public GameObject errerLight;
    // Start is called before the first frame update
    void Start()
    {
        for(int i= 0; i< switchControllers.Count; i++)
        {
            switchControllers[i].OnCommitSwitchEventHandler += LightOnGameManager_OnCommitSwitchEventHandler;
        }
    }
    private void OnEnable()
    {
        LightCount = 0;
        for(int i =0; i < Lights.Count; i++)
        {
            Lights[i].SetActive(false);
        }
    }

    private void LightOnGameManager_OnCommitSwitchEventHandler(SwitchController switchController, int value)
    {
        if (LightCount + value == 10)
        {
            Debug.Log("스위치 성공!!");
            
        }

        if (LightCount + value > 10)
        {
            switchController.SetOn();
            DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Error), 2.5f);
            errerLight.SetActive(true);
            StartCoroutine(EndErrorLight());
            return;
        }
        if(value <0)
        {
            StartCoroutine(TrunOffLightRoutine(LightCount, value));
        }        
        else if (value > 0)
        {
            StartCoroutine(TrunOnLightRoutine(LightCount,value));
        }
        LightCount += value;
    }
    IEnumerator EndErrorLight()
    {
        yield return new WaitForSeconds(1.2f);
        errerLight.SetActive(false);
    }
    IEnumerator TrunOffLightRoutine(int initvalue,int value)
    {
        for (int i = initvalue; i >= initvalue+value; i--)
        {
            if (i >= 10)
                i = 9;
            if(Lights[i].activeSelf ==true)
            {
                Lights[i].SetActive(false);
                yield return new WaitForSeconds(0.15f);
            }            
        }
    }
    IEnumerator TrunOnLightRoutine(int initvalue,int value)
    {
        for (int i = initvalue; i < initvalue + value; i++)
        {            
            Lights[i].SetActive(true);
            yield return new WaitForSeconds(0.15f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

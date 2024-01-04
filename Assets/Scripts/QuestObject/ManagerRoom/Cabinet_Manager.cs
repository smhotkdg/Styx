using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cabinet_Manager : ObjectChekcer
{
    public GameObject uiElement;
    public GameObject ViewObject;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
    }
    bool bStartConverstation = false;
    void Click()
    {
        bStartConverstation = true;
        DialogueManager.StartConversation("cabinet");
    }
    private void Update()
    {
        if (GameManager.Instance.styxData.Part3_MainAccessCard == 1)
        {
            if(uiElement.activeSelf ==true)
            {
                DisableObject(uiElement);
                uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
            }
            return;
        }
            
        if (bStartConverstation)
        {
            if (DialogueManager.isConversationActive == false)
            {
                bStartConverstation = false;
                ViewObject.SetActive(true);
            }
        }
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        if (GameManager.Instance.styxData.Part3_MainAccessCard == 1)
            return;
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

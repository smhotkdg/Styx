using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Calendar_Manager : ObjectChekcer
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
        DialogueManager.StartConversation("calendar");
    }
    private void Update()
    {
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
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.bed), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
}

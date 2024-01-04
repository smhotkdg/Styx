using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
public class WagonDstController : ObjectChekcer
{
    public GameObject uiElement;

    // Start is called before the first frame update
    void Start()
    {
        OnEnterObjectEventHandler += WagonDstController_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += WagonDstController_OnExitObjectEventHandelr;
    }

    private void WagonDstController_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void WagonDstController_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.dstWagon), uiElement, this.gameObject, 0);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click()
    {        
        GameManager.Instance.Player.GetComponent<PlayerController>().SetPlayerWagon(false);
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.dstWagon));
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.dstWagon);
        DialogueLua.SetVariable("bCompleteOldFamer", true);
        UIManager.Instance.SetOldFamerQuest(false);
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

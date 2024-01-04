using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
public class CopperObject : ObjectChekcer
{
    public GameObject uiElement;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(GameManager.Instance.styxData.CopperWireIndex ==0)
        {
            OnEnterObjectEventHandler += CopperObject_OnEnterObjectEventHandler;
            OnExitObjectEventHandelr += CopperObject_OnExitObjectEventHandelr;
            //OnClickObjectEventHandler += CopperObject_OnClickObjectEventHandler;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }

    void Click()
    {
        Debug.Log("구리선 획득");
        TestCodeManager.Instance.GetCopper();
        spriteRenderer.enabled = false;
        DisableObject(uiElement);
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Copper));
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.Copper);
        //DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.Copper), 2.5f);
        this.gameObject.SetActive(false);
    } 

    private void CopperObject_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void CopperObject_OnEnterObjectEventHandler()
    {
        if(GameManager.Instance.styxData.CopperWireIndex ==0)
        {
            uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
            SetObject(languageController.Instance.GetText(languageController.ObjectType.get), uiElement, this.gameObject, 75);
            uiElement.GetComponent<Button>().onClick.AddListener(Click);
        }        
    }
    public void Check()
    {
        if(GameManager.Instance.styxData.strEnableCopperwire =="active")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void FixedUpdate()
    {
        Check();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

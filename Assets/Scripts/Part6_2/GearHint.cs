using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GearHint : ObjectChekcer
{
    BoxCollider2D boxCollider;
    public GameObject uiElement;
    public GameObject PObject;
    public List<GameObject> ViewObject;
    public int GearIndex;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        OnEnterObjectEventHandler += CopperObject_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += CopperObject_OnExitObjectEventHandelr;
    }

    void Click()
    {
        if (AdManager.Instance.isShowPop == true)
        {
            if (AdManager.Instance.ShowPopAds())
            {
                return;
            }
        }
        PObject.SetActive(true);
        for(int i =0; i< ViewObject.Count; i++)
        {
            ViewObject[i].SetActive(false);
        }
        ViewObject[GearIndex].SetActive(true);
        //DisableObject(uiElement);
        //uiElement.GetComponent<Button>().onClick.RemoveAllListeners();        
    }
    private void CopperObject_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void CopperObject_OnEnterObjectEventHandler()
    {
        if(spriteRenderer.enabled)
        {
            uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
            SetObject(languageController.ObjectType.bed, uiElement, this.gameObject, 75);
            uiElement.GetComponent<Button>().onClick.AddListener(Click);
        }
    }  
}
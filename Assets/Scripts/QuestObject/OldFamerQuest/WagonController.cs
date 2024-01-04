using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WagonController :ObjectChekcer
{    
    public GameObject uiElement;
    public GameObject Wagon;
    public GameObject DstObject;

    void Start()
    {
        OnEnterObjectEventHandler += WagonController_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += WagonController_OnExitObjectEventHandelr;
    }

    private void WagonController_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.wagon), uiElement, this.gameObject, 75);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }

    private void WagonController_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    public void Click()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GameManager.Instance.Player.GetComponent<PlayerController>().SetPlayerWagon(true);
        DstObject.SetActive(true);
        DstObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void SetWagon()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        UIManager.Instance.SetOldFamerQuest(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

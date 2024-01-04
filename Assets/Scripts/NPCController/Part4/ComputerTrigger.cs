using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComputerTrigger : ObjectChekcer
{
    public GameObject uiElement;
    public GameObject GamePanel;
    public GameObject Arrow;
    BoxCollider2D myboxColiider;
    void Start()
    {
        OnEnterObjectEventHandler += MachineTriiger_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += MachineTriiger_OnExitObjectEventHandelr;
        myboxColiider = GetComponent<BoxCollider2D>();
    }

    private void MachineTriiger_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void MachineTriiger_OnEnterObjectEventHandler()
    {
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.door), uiElement, this.gameObject, 110);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.styxData.EngineerComputerQuest == "active")
        {
            Arrow.SetActive(true);
            myboxColiider.enabled = true;
        }
        else
        {
            Arrow.SetActive(false);
            myboxColiider.enabled = false;
        }
    }

    void Click()
    {
        GamePanel.SetActive(true);
        GameManager.Instance.cameraEffectController.Start_Matrix(true);
        GameManager.Instance.SetPlayerWork(true);
    }
}

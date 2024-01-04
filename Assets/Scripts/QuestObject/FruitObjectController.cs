using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FruitObjectController : ObjectChekcer
{
    public GameObject uiElement;
    private void Start()
    {
        OnEnterObjectEventHandler += Bed_OnEnterObjectEventHandler;
        OnExitObjectEventHandelr += Bed_OnExitObjectEventHandelr;
        //OnClickObjectEventHandler += Bed_OnClickObjectEventHandler;
    }

    public void Click()
    {
        UIManager.Instance.FruitGamePanel.SetActive(true);
        UIManager.Instance.FruitGamePanel.GetComponent<FuritQuestGame>().SetSeawood(gameObject);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
    }

    private void Bed_OnExitObjectEventHandelr()
    {
        DisableObject(uiElement);
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Bed_OnEnterObjectEventHandler()
    {
        if (GameManager.Instance.Player.GetComponent<PlayerController>().isPlayWagon == true)
            return;
        uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
        SetObject(languageController.Instance.GetText(languageController.ObjectType.fruit), uiElement, this.gameObject, 75);
        uiElement.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void DisalbeRoutine()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(resetRoutine());
    }
    IEnumerator resetRoutine()
    {
        float rand = Random.Range(10, 15);
        yield return new WaitForSeconds(rand);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}

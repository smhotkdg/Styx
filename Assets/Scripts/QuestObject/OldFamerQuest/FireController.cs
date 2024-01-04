using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FireController : MonoBehaviour
{
    //public GameObject SingShotUI;
    public FireTarget fireTarget;
    public List<GameObject> FireObjects;
    public bool bStay = false;
    public GameObject UiElemnet;
    public GameObject EnableObject;
    public GameObject EnableObjectClose;
    public GameObject JoyStickUI;
    private void Start()
    {
        fireTarget.OnTargetHitEvent += FireTarget_OnTargetHitEvent;
        if(GameManager.Instance.styxData.FireQuest == "success")
        {
            for (int i = 0; i < FireObjects.Count; i++)
            {
                FireObjects[i].SetActive(true);
            }
        }
    }

    private void FireTarget_OnTargetHitEvent()
    {
        //SetCameraMove();
        //카메라 무브 x -7
        EnableObject.SetActive(false);
        EnableObjectClose.SetActive(false);
        StartCoroutine(FireStartRoutine());       
        //쇽쇽 쇽쇽
    }

    IEnumerator FireStartRoutine()
    {
        for (int i = 0; i < FireObjects.Count; i++)
        {
            FireObjects[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.cinemachineCamera.m_Follow = null;
        Vector3 TargetVector = GameManager.Instance.cinemachineCamera.transform.position;
        TargetVector.x = TargetVector.x - 6;
        GameManager.Instance.cinemachineCamera.transform.DOMove(TargetVector, 2f).SetEase(Ease.Linear).OnComplete(CompleteFireCamera);        
    }
    void CompleteFireCamera()
    {
        StartCoroutine(CameraRoutine());
        TestCodeManager.Instance.CompleteFireQuest(false);
        
    }
    IEnumerator CameraRoutine()
    {
        GameManager.Instance.SetPlayerCamera(1.5f);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SetFireEvent();
        yield return new WaitForSeconds(7.5f);
        JoyStickUI.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Instance.styxData.FireQuest == "success")
        {
            return;
        }
        if (collision.gameObject.tag =="player")
        {
            bStay = true;
            UiElemnet.SetActive(true);
            UiElemnet.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.GetText(languageController.ObjectType.fire);
            //ui.GetComponent<Button>().onClick.AddListener(Click);
            UiElemnet.GetComponent<UiTargetManager>().WorldObject = this.gameObject;
            UiElemnet.GetComponent<UiTargetManager>().y_Margin = 120;
            UiElemnet.GetComponent<UiTargetManager>().x_Margin = 40;
            UiElemnet.GetComponent<Button>().onClick.AddListener(Click);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="player")
        {
            bStay = false;
            UiElemnet.SetActive(false);
            UiElemnet.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }       
    void Click()
    {
        JoyStickUI.SetActive(false);
        EnableObject.SetActive(true);
        EnableObjectClose.SetActive(true);
        GameManager.Instance.SetCameraFire();
        //GameManager.Instance.SetPlayerCamera()
    }
    private void Update()
    {
        if (UiElemnet != null)
        {
            if(UIManager.Instance.CheckBottomUI()==false)
                UiElemnet.SetActive(UIManager.Instance.CheckBottomUI());
        }
    }
    
}

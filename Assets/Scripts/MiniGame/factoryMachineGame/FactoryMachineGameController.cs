using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FactoryMachineGameController : MonoBehaviour
{
    // Start is called before the first frame update
    //xPos = 450 , 
    //yPos = 100

    //x 235 ~ 165

    public BoxTrigger boxTrigger;
    public BoxTrigger ExitTrigger;
    public List<GameObject> BoxList;
    public List<GameObject> TempList = new List<GameObject>();
    void Start()
    {
        boxTrigger.OnEnterEvent += BoxTrigger_OnEnterEvent;
        boxTrigger.OnExitEnvent += BoxTrigger_OnExitEnvent;
        ExitTrigger.OnFailEvent += BoxTrigger_OnFailEvent;
        SelectCount = 0;
    }

    private void BoxTrigger_OnFailEvent()
    {
        bEnd = true;
        for (int i = 0; i < TempList.Count; i++)
        {
            if (TempList[i] != null)
            {
                Destroy(TempList[i]);
            }
        }
        TempList.Clear();
        Debug.Log("박스 실패!");
        transform.DOShakeScale(1f, 0.1f).OnComplete(CompleteTween);        
    }
    void CompleteTween()
    {
        GameManager.Instance.SetPlayerWork(false);
        this.gameObject.SetActive(false);
    }

    int SelectCount =0;
    bool bEnd = false;
    private void OnEnable()
    {
        bEnd = false;
        defaultSpeed = 100;
        defaultTime = 1;
        SelectCount = 0;
        StartCoroutine(GameStartRoutine());
        

    }
    int defaultSpeed = 100;
    float defaultTime = 1;
    IEnumerator GameStartRoutine()
    {
        if(bEnd==false)
        {
            int rand = Random.Range(0, 3);
            GameObject temp = Instantiate(BoxList[rand]);
            TempList.Add(temp);
            temp.transform.SetParent(BoxList[rand].transform.parent);
            temp.transform.localScale = new Vector3(1, 1, 1);
            temp.transform.localPosition = new Vector3(200, 25);
            temp.GetComponent<BoxMove>().Speed = defaultSpeed;
            temp.SetActive(true);
            temp.name = BoxList[rand].name;
            if (defaultSpeed < 200)
            {
                defaultSpeed += 10;
                defaultTime -= 0.05f;
            }
            yield return new WaitForSeconds(defaultTime);
            StartCoroutine(GameStartRoutine());
        }
    }

    private void BoxTrigger_OnExitEnvent(int name,GameObject _inputObject)
    {
        if(SelectIndex == name && SelectObject == _inputObject)
        {
            SelectIndex = -1;
            SelectObject = null;
        }        
    }

    private void BoxTrigger_OnEnterEvent(int name, GameObject selectObject)
    {
        SelectIndex = name;
        SelectObject = selectObject;
    }
    private void OnDisable()
    {
        for(int i =0; i< TempList.Count; i++)
        {
            if(TempList[i]!=null)
            {
                Destroy(TempList[i]);
            }
        }
        TempList.Clear();
    }
    public int SelectIndex = -1;
    public GameObject SelectObject = null;
    void BoxCompleteTween()
    {
        Destroy(SelectObject);
    }
    public void ButtonClick(int index)
    {
        if (SelectIndex == -1)
            return;
        if(index == SelectIndex)
        {
            SelectCount++;
            SelectObject.GetComponent<BoxMove>().SetDisable();
            
            if (SelectCount >= 20)
            {
                Debug.Log("박스 끝");
                GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.box);
                GameManager.Instance.SetPlayerWork(false);
                this.gameObject.SetActive(false);
                TestCodeManager.Instance.FactoryManagerQuest_MoveComplete(false);
            }
        }
        
    }
}

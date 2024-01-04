using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRouletteGameController : MonoBehaviour
{
    public GameObject CompletePanel;
    public bool bMove = false;
    public List<NumberController> numberControllers;
    public delegate void OnFind();
    public event OnFind OnFindEventHandler;
    public List<GameObject> TutorialList;
    // Start is called before the first frame update
    public List<GameObject> NumberList;
    public List<Vector3> initPos = new List<Vector3>();
    private void OnEnable()
    {
        for(int i=0; i< TutorialList.Count; i++)
        {
            TutorialList[i].SetActive(true);
        }        
        if(initPos.Count ==0)
        {
            SetPos();
        }
        else
        {
            for (int i = 0; i < NumberList.Count; i++)
            {
                NumberList[i].transform.localPosition = initPos[i];
            }
        }
       
    }
    void SetPos()
    {
        for (int i = 0; i < NumberList.Count; i++)
        {           
            initPos.Add(NumberList[i].transform.localPosition);
        }
    }
    void Start()
    {
        for(int i =0; i< numberControllers.Count; i++)
        {
            numberControllers[i].OnNumberCompleteEventHandler += NumberRouletteGameController_OnNumberCompleteEventHandler;
        }

    }

    private void NumberRouletteGameController_OnNumberCompleteEventHandler()
    {
        for (int i = 0; i < TutorialList.Count; i++)
        {
            TutorialList[i].SetActive(false);
        }
        for (int i = 0; i < numberControllers.Count; i++)
        {
            if(numberControllers[i].bComplete == false)
            {
                //Debug.Log("번호 찾기 실패");
                bMove = false;
                return;
            }
        }
        //CompletePanel.SetActive(true);
        Debug.Log("번호 찾기 성공");
        OnFindEventHandler?.Invoke();
        GetComponent<Animator>().Play("EmergencyLockGameOff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        
        if(GameManager.Instance!=null)
            GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);

    }
}

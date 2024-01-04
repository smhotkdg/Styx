using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EndingScrollManager : MonoBehaviour
{

    //EndingList 탈출 실패, 탈출 성공, 형명군 살인, 혁명군 해방, 교주 살인, 교주 해방 , 히든

    //현재 진행형
    // -엔딩을 한번이라도 본 경우
    // -엔딩을 한번도 안본경우
    public List<int> List_EscapeFail;
    public List<int> List_EscapeSuccess;
    public List<int> List_revolutionary_army_Kill;
    public List<int> List_revolutionary_army;
    public List<int> List_headmaster_kill;
    public List<int> List_headmaster;
    public List<int> List_hidden;


    public GameObject content;

    public List<GameObject> PartList;
    //part data 
    // Start is called before the first frame update
    Vector2 initContentPos;
    List<int> NowPosition = new List<int>();
    void Start()
    {
        initContentPos = content.transform.localPosition;
    }
    
    void setInit()
    {
        NowPosition.Clear();
        if(GameManager.Instance.roomPosition == GameManager.RoomPosition.underWater ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.port ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.ship)
        {
            NowPosition.Add(0);
        }

        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.room ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.seawork ||
            GameManager.Instance.roomPosition == GameManager.RoomPosition.vent)
        {
            NowPosition.Add(0);
            NowPosition.Add(1);
        }
        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.wareHouse ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.lampTown ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.steeldoor||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.hardwareStore ||
          GameManager.Instance.roomPosition == GameManager.RoomPosition.Chapel)          
        {
            NowPosition.Add(0);
            NowPosition.Add(1);
            NowPosition.Add(2);
        }
        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.skytown ||
        GameManager.Instance.roomPosition == GameManager.RoomPosition.Domitory ||
        GameManager.Instance.roomPosition == GameManager.RoomPosition.Storage ||
        GameManager.Instance.roomPosition == GameManager.RoomPosition.Farm ||
        GameManager.Instance.roomPosition == GameManager.RoomPosition.orchard||
        GameManager.Instance.roomPosition == GameManager.RoomPosition.Farm ||
        GameManager.Instance.roomPosition == GameManager.RoomPosition.SkytownWareHouse ||
        GameManager.Instance.roomPosition == GameManager.RoomPosition.FarmManagerRoom)
        {
            NowPosition.Add(0);
            NowPosition.Add(1);
            NowPosition.Add(2);
            NowPosition.Add(3);
        }

        if (GameManager.Instance.roomPosition == GameManager.RoomPosition.factory ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.pharmacy ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.machineroom ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.factorymanagerroom ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.restroom ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.mainfactoryroom ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.powerroom ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.anchoroom ||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.emergencyarea||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.submarineroom||
       GameManager.Instance.roomPosition == GameManager.RoomPosition.sea)
        {
            NowPosition.Add(0);
            NowPosition.Add(1);
            NowPosition.Add(2);
            NowPosition.Add(3);
            NowPosition.Add(4);
            if(GameManager.Instance.data.isEscapeShip==1)
            {
                NowPosition.Add(5);
            }
        }

    }
    private void OnDisable()
    {
        content.transform.localPosition = initContentPos;
    }
    private void OnEnable()
    {
        for (int i = 0; i < PartList.Count; i++)
        {
            PartList[i].SetActive(false);
        }
        setInit();
        
    }
    public struct EndingTotal
    {
        public bool isNow;
        public int postiion;
        public EndingTotal(bool _isNow,int _pos)
        {
            isNow = _isNow;
            postiion = _pos;
        }
        public void ChangeNow(bool _now)
        {
            isNow = _now;
        }
    }    
    void SetEndingData(List<int> _list,bool isNow)
    {
        List<int> tempList = new List<int>();
        for(int i =0; i< _list.Count; i++)
        {
            tempList.Add(_list[i]);
        }
        for (int k = 0; k < tempList.Count; k++)
        {
            for (int i = 0; i < TotalEndingList.Count; i++)
            {
                if (tempList[k] == TotalEndingList[i].postiion)
                {
                    tempList[k] = -100;
                    if (isNow == true)
                    {
                        EndingTotal endingTotal = new EndingTotal(true, TotalEndingList[i].postiion);
                        TotalEndingList.RemoveAt(i);
                        TotalEndingList.Insert(i, endingTotal);
                    }
                }
            }
        }
       

        for (int i =0; i< tempList.Count;i++)
        {
            if(tempList[i] != -100)
            {
                EndingTotal endingTotal = new EndingTotal(isNow, tempList[i]);
                TotalEndingList.Add(endingTotal);
            }            
        }

        
        //EndingTotal endingTotal = new EndingTotal(isNow, _list[i]);
             
    }
    [SerializeField]
    public List<EndingTotal> TotalEndingList = new List<EndingTotal>();
    public void SetNoneData()
    {
        CheckData(GameManager.EndingType.non);
    }
    [Button("==엔딩 테스트==", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CheckData(GameManager.EndingType index)
    {
        TotalEndingList.Clear();
        for (int i=0; i< GameManager.Instance.data.EndingList.Count; i++)
        {
            if(GameManager.Instance.data.EndingList[i]==1)
            {
                switch ((GameManager.EndingType)i)
                {
                    case GameManager.EndingType.EscapeFail:
                        SetEndingData(List_EscapeFail,false);                        
                        break;
                    case GameManager.EndingType.EscapeSuccess:
                        SetEndingData(List_EscapeSuccess, false);
                        break;
                    case GameManager.EndingType.headmaster:
                        SetEndingData(List_headmaster, false);
                        break;
                    case GameManager.EndingType.headmaster_kill:
                        SetEndingData(List_headmaster_kill, false);
                        break;
                    case GameManager.EndingType.revolutionary_army:
                        SetEndingData(List_revolutionary_army, false);
                        break;
                    case GameManager.EndingType.revolutionary_army_Kill:
                        SetEndingData(List_revolutionary_army_Kill, false);
                        break;
                    case GameManager.EndingType.hidden:
                        SetEndingData(List_hidden, false);
                        break;
                }
                
            }
        }
        SetEndingData(NowPosition, true);
        for (int i = 0; i < PartList.Count; i++)
        {
            PartList[i].SetActive(false);
        }
        switch (index)
        {
            case GameManager.EndingType.EscapeFail:
                SetEndingData(List_EscapeFail, true);
                
                break;
            case GameManager.EndingType.EscapeSuccess:
                SetEndingData(List_EscapeSuccess, true);
                
                break;
            case GameManager.EndingType.headmaster:
                SetEndingData(List_headmaster, true);
                
                break;
            case GameManager.EndingType.headmaster_kill:
                SetEndingData(List_headmaster_kill, true);
                
                break;
            case GameManager.EndingType.revolutionary_army:
                SetEndingData(List_revolutionary_army, true);
                
                break;
            case GameManager.EndingType.revolutionary_army_Kill:
                SetEndingData(List_revolutionary_army_Kill, true);
                
                break;
            case GameManager.EndingType.hidden:
                SetEndingData(List_hidden, true);
                
                break;
        }
        StartCoroutine(EndringRoutine(TotalEndingList));

        //StartCoroutine(EndringRoutine(index));
    }
    IEnumerator EndringRoutine(List<EndingTotal> index)
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < index.Count; i++)
        {
            PartList[index[i].postiion].SetActive(true);
            PartList[index[i].postiion].GetComponent<EndingPart>().SetView(index[i].isNow);
            yield return new WaitForSeconds(0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

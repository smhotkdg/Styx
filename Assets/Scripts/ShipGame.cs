using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGame : MonoBehaviour
{
    public List<GameObject> LifeList;
    public GameObject ShipObject;
    public VariableJoystick variableJoystick;
    public float speed = 1;
    public bool isStart = false;
    public GameObject Warning;
    public GameObject Missile;
    List<GameObject> WarningList = new List<GameObject>();
    List<GameObject> MissileList = new List<GameObject>();
    public GameObject BG;
    

    public delegate void CompleteGame(bool flag);
    public event CompleteGame CompleteGameEventHandler;
    // Start is called before the first frame update
    private void OnEnable()
    {        
        ShipObject.transform.localPosition = new Vector3(-4.85f, 0.45f, 0);
        //BG.transform.position = new Vector3(0, 0.7f, 0);
        
    }
    int warningIndex;
    int MissileIndex;
    void Start()
    {
        SetPool();
        warningIndex = 0;
        MissileIndex = 0;
        //SetMissile();
    }
    void SetPool()
    {
        Warning.SetActive(false);
        Missile.SetActive(false);
        for (int i =0; i< 10; i++)
        {
            GameObject Temp = Instantiate(Warning);
            GameObject tempMissile = Instantiate(Missile);
            Temp.transform.SetParent(Warning.transform.parent);
            tempMissile.transform.SetParent(Missile.transform.parent);
            tempMissile.GetComponent<MissileObject>().HitEventHandler += ShipGame_HitEventHandler;
            WarningList.Add(Temp);
            MissileList.Add(tempMissile);
        }
        
    }
    int LifeCount = 0;
    private void ShipGame_HitEventHandler()
    {
        if (LifeCount >=3)
            return;
        LifeList[LifeCount].SetActive(true);
        LifeCount++;
        //여기 테스트중
        if(LifeCount ==3)
        {
            //게임종료
            CompleteGameEventHandler?.Invoke(false);
        }
    }

    void MakeMissile(float time,Vector2 Pos)
    {
        if(warningIndex >= WarningList.Count)
        {
            warningIndex = 0;
        }

        WarningList[warningIndex].SetActive(true);
        WarningList[warningIndex].transform.position = Pos;
        Vector2 mPos = WarningList[warningIndex].transform.Find("StartPoint").gameObject.transform.position;
        StartCoroutine(MakeMissileRoutine(time, mPos, WarningList[warningIndex]));

        warningIndex++;
    }
    IEnumerator MakeMissileRoutine(float time,Vector2 pos,GameObject wObject)
    {
        yield return new WaitForSeconds(time);
        wObject.SetActive(false);
        if (MissileIndex >= MissileList.Count)
        {
            MissileIndex = 0;
        }

        MissileList[MissileIndex].SetActive(true);
        GameObject m = MissileList[MissileIndex];
        MissileList[MissileIndex].transform.position = pos;        

        MissileIndex++;
        yield return new WaitForSeconds(time*5);
        m.SetActive(false);

    }
    //-1.5 && +1.5 && equal
    //#1 -1.5
    //#2 +1.5
    //#3 eqaul
    //#4 -1.5 + eqaul
    //#5 +1.5 2sec -> eqaul 2sec -> -1.5
    //#6 eqaul -> 2sec +1.5 -1.5
    //게임 시작
    public void SetMissile()
    {
        
        StartCoroutine(MissleRoutine());
    }
    IEnumerator MissleRoutine()
    {
        Vector2 mPos = ShipObject.transform.position;
        yield return new WaitForSeconds(5f);
        mPos = ShipObject.transform.position;
        mPos.y = mPos.y - 1.5f;
        MakeMissile(2, mPos);
        yield return new WaitForSeconds(5f);
        mPos = ShipObject.transform.position;
        mPos.y = mPos.y + 1.5f;
        MakeMissile(2, mPos);

        yield return new WaitForSeconds(5f);
        mPos = ShipObject.transform.position;        
        MakeMissile(2, mPos);

        yield return new WaitForSeconds(5f);
        mPos = ShipObject.transform.position;
        MakeMissile(2, mPos);
        mPos.y = mPos.y - 1.5f;
        MakeMissile(2, mPos);

        yield return new WaitForSeconds(5f);
        mPos = ShipObject.transform.position;
        mPos.y = mPos.y + 1.5f;
        MakeMissile(2, mPos);
        yield return new WaitForSeconds(1f);
        mPos = ShipObject.transform.position;
        MakeMissile(2, mPos);
        yield return new WaitForSeconds(1f);
        mPos = ShipObject.transform.position;
        mPos.y = mPos.y - 1.5f;
        MakeMissile(2, mPos);

        yield return new WaitForSeconds(5f);
        mPos = ShipObject.transform.position;
        MakeMissile(2, mPos);
        yield return new WaitForSeconds(1f);
        mPos = ShipObject.transform.position;
        mPos.y = mPos.y + 1.5f;
        MakeMissile(2, mPos);        
        mPos = ShipObject.transform.position;
        mPos.y = mPos.y - 1.5f;
        MakeMissile(2, mPos);
        yield return new WaitForSeconds(5f);
        UIManager.Instance.SetScensChangeSubMarinEnding(languageController.SceneTextType.submarinEnding);
        
    }
    public void EnsConvarsation()
    {
        StartCoroutine(ConversationEnd());
    }
    IEnumerator ConversationEnd()
    {
        yield return new WaitForSeconds(4f);
        CompleteGameEventHandler?.Invoke(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(isStart)
        {
            Vector3 direction = new Vector3(0, 0, 0);


            direction = new Vector3((variableJoystick.Horizontal/100)*speed, (variableJoystick.Vertical / 100) * speed);

            ShipObject.transform.position += direction;
            //float moveSpeed = (Mathf.Abs(variableJoystick.Horizontal) + Mathf.Abs(variableJoystick.Vertical)) * speed;
        }            
        
    }
}


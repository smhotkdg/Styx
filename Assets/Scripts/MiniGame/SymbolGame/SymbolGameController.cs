using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SymbolGameController : MonoBehaviour
{
    public HintManager hintManager;
    public enum SymbolType
    {
        Red,
        Blue,
        Yellow,           
    }
    public SymbolType symbolType = SymbolType.Blue;
    public List<GameObject> SymbolList;
    public List<int> SelectList = new List<int>();
    public delegate void OnComplete(SymbolType type);
    public event OnComplete OnCompleteEventHandler;

    public delegate void OnClose();
    public event OnClose OnCloseEventHandler;
    public Button HintButton;
    // Start is called before the first frame update
    private void OnDisable()
    {
        OnCloseEventHandler?.Invoke();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        //HintButton.onClick.RemoveAllListeners();
        SelectList.Clear();
        
        CheckView();        
        bTween = false;
        //SetHint();
    }

    public void SetHint()
    {
        if (GameManager.Instance.data.isChoiceMember == 2)
        {
            switch (symbolType)
            {
                case SymbolType.Red:
                    hintManager.SetHint(14);
                    break;
                case SymbolType.Blue:
                    hintManager.SetHint(15);
                    break;
                case SymbolType.Yellow:
                    hintManager.SetHint(16);
                    break;
            }
        }
        else
        {
            switch (symbolType)
            {

                case SymbolType.Red:
                    hintManager.SetHint(10);
                    break;
                case SymbolType.Blue:
                    hintManager.SetHint(11);
                    break;
                case SymbolType.Yellow:
                    hintManager.SetHint(12);
                    break;
            }
        }
    }
    bool bTween = false;
    void EndTween()
    {
        bTween = false;
    }
    IEnumerator StartTween()
    {
        yield return new WaitForSeconds(1f);
        bTween = false;
    }
    void CheckView()
    {
        for(int i =0; i< SymbolList.Count;i++)
        {
            SymbolList[i].SetActive(false);
        }
        for(int i =0; i< SelectList.Count;i++)
        {
            if(SelectList[i] >=0)
            {
                SymbolList[SelectList[i]].SetActive(true);
                SymbolList[SelectList[i]].transform.SetAsFirstSibling();
            }            
        }
        if(bTween ==false)
        {
            for (int i = 0; i < SymbolList.Count; i++)
            {
                if(SymbolList[i].activeSelf)
                {
                    SymbolList[i].GetComponent<Image>().DOColor(new Color(1, 1, 1, 0.1f), 0.25f).From(false).SetLoops(3);
                }
            }
            StartCoroutine(StartTween());
            bTween = true;
        }
        
    }
    public void SelectSymbol(int index)
    {
        if (SelectList.Count > 3)
            return;
        for(int i =0; i<SelectList.Count; i++)
        {
            if(SelectList[i] == index)
            {
                return;
            }
        }
        SelectList.Add(index);
        CheckView();
    }
    void FindResult(SymbolType symbol)
    {
        if (GameManager.Instance.data.isChoiceMember == 2)
        {
            switch (symbolType)
            {

                case SymbolType.Red:
                    if (GetResult() == "109")
                    {
                        OnCompleteEventHandler?.Invoke(SymbolType.Red);
                    }
                    break;
                case SymbolType.Blue:
                    if (GetResult() == "573")
                    {
                        OnCompleteEventHandler?.Invoke(SymbolType.Blue);
                    }
                    break;
                case SymbolType.Yellow:
                    if (GetResult() == "841")
                    {
                        OnCompleteEventHandler?.Invoke(SymbolType.Yellow);
                    }
                    break;
            }
        }
        else
        {
            switch (symbolType)
            {

                case SymbolType.Red:
                    if (GetResult() == "614")
                    {
                        OnCompleteEventHandler?.Invoke(SymbolType.Red);
                    }
                    break;
                case SymbolType.Blue:
                    if (GetResult() == "415")
                    {
                        OnCompleteEventHandler?.Invoke(SymbolType.Blue);
                    }
                    break;
                case SymbolType.Yellow:
                    if (GetResult() == "310")
                    {
                        OnCompleteEventHandler?.Invoke(SymbolType.Yellow);
                    }
                    break;
            }
        }
        
    }
    string GetResult()
    {
        string temp = "";
        for(int i =0; i< SelectList.Count;i++)
        {
            temp += SelectList[i].ToString("N0");
        }
        return temp;
    }
    public void ConfrimNumber()
    {
        FindResult(symbolType);
    }

    public void DeleteNumber()
    {
        if(SelectList.Count >0)
        {
            SelectList.RemoveAt(SelectList.Count - 1);
            CheckView();
        }        
    }
}

using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JuiceGameController : MonoBehaviour
{
    public GameObject HintObject;
    //1번 1, 4,5
    //2번 2,1,3
    //3번 6,3,2
    //4번 6,5,4
    public List<GameObject> buttonList;
    public List<GameObject> OrderList;

    public delegate void OnFindJuice();
    public event OnFindJuice OnFindJuiceHandler;

    public delegate void OnNotFindJuice();
    public event OnNotFindJuice OnNotFindJuiceHandler;

    public List<bool> isSelectList = new List<bool>();
    void Start()
    {
        for(int i =0; i< buttonList.Count; i++)
        {
            isSelectList.Add(false);
        }
    }
    int orderCount;
    private void OnEnable()
    {
        randomButton();
        HintObject.SetActive(true);
    }
    void randomButton()
    {
        SelectItemList.Clear();
        for (int i =0; i< buttonList.Count; i++)
        {
            int rand = Random.Range(0, 5);
            buttonList[i].transform.SetSiblingIndex(rand);
            buttonList[i].transform.Find("Image").GetComponent<Image>().color = new Color(1, 1, 1, 1);            
            buttonList[i].GetComponent<Image>().color = new Color(0.78f, 0.78f, 0.78f, 1);
        }

        for (int i = 0; i < isSelectList.Count; i++)
        {
            isSelectList[i] = false;
        }

        int random = Random.Range(0, 4);
        for(int i =0; i< OrderList.Count; i++)
        {
            OrderList[i].SetActive(false);
        }
        orderCount = random;
        UIManager.Instance.DrinkIndex = orderCount;
        OrderList[random].SetActive(true);
    }
    private void OnDisable()
    {
        HintObject.SetActive(false);
        if (GameManager.Instance !=null)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        }
    }

    List<int> SelectItemList = new List<int>();
    public void SetItem(int index)
    {
        if(isSelectList[index-1]==false)
        {
            buttonList[index - 1].transform.Find("Image").GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            buttonList[index - 1].GetComponent<Image>().color = new Color(1f, 0.0f, 0.0f, 1);
            //buttonList[index - 1].GetComponent<Image>().enabled = false;
            isSelectList[index - 1] = true;
            SelectItemList.Add(index);
        }
        else
        {
            buttonList[index - 1].transform.Find("Image").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            buttonList[index - 1].GetComponent<Image>().color = new Color(0.78f, 0.78f, 0.78f, 1);
            //buttonList[index - 1].GetComponent<Image>().enabled = true;
            for (int i = 0; i < SelectItemList.Count; i++)
            {
                if(SelectItemList[i] == index)
                {
                    SelectItemList.RemoveAt(i);
                    isSelectList[index - 1] = false;
                    return;
                }
            }
        }        
    }
    public void CompleteCheck()
    {
        SelectItemList.Sort();
        //1번 1, 4,5
        //2번 2,1,3
        //3번 6,3,2
        //4번 6,5,4
        if (SelectItemList.Count ==3)
        {

            switch (orderCount)
            {
                case 0:
                    if (SelectItemList[0] == 1 && SelectItemList[1] == 4 && SelectItemList[2] == 5)
                    {
                        Debug.Log("제조성공");                        
                        OnFindJuiceHandler?.Invoke();
                        this.gameObject.SetActive(false);
                    }
                    break;
                case 1:
                    if (SelectItemList[0] == 1 && SelectItemList[1] == 2 && SelectItemList[2] == 3)
                    {
                        Debug.Log("제조성공");
                        OnFindJuiceHandler?.Invoke();
                        this.gameObject.SetActive(false);
                    }
                    break;
                case 2:
                    if (SelectItemList[0] == 2 && SelectItemList[1] == 3 && SelectItemList[2] == 6)
                    {
                        Debug.Log("제조성공");
                        OnFindJuiceHandler?.Invoke();
                        this.gameObject.SetActive(false);
                    }
                    break;
                case 3:
                    if (SelectItemList[0] == 4 && SelectItemList[1] == 5 && SelectItemList[2] == 6)
                    {
                        Debug.Log("제조성공");
                        OnFindJuiceHandler?.Invoke();
                        this.gameObject.SetActive(false);
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("음료 제조 실패");
            //OnNotFindJuiceHandler?.Invoke();
            //this.gameObject.SetActive(false);
            DialogueManager.ShowAlert(languageController.Instance.setAlert(languageController.ObjectName.juiceError), 2.5f);
            return;
        }
       
    }
}

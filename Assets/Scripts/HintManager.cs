using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HintManager : MonoBehaviour
{
    public GameObject HintObject;
    public GameObject AdsObejct;
    public List<GameObject> HintList;

    public CodeGameController CodeGame;
    public Text Code_InputText;
    public Text Code_ResultText;

    IEnumerator MatrixEnable()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.cameraEffectController._Matrix.enabled = true;
    }
    public void SetHint(int type)
    {
        GameManager.Instance.hintType= (GameManager.HintType)type;
        if(GameManager.Instance.hintType == GameManager.HintType.CodeGame)
        {
          
            GameManager.Instance.cameraEffectController._Matrix.enabled = false;
            StartCoroutine(MatrixEnable());
            //GameManager.Instance.cameraEffectController._Matrix.enabled = true;
            
        }
        if (GameManager.Instance.HintEnalbeList[type] == true)
        {
            AdsObejct.SetActive(true);
            AdsObejct.transform.Find("BG/HintObject").gameObject.SetActive(false);
            AdsObejct.transform.Find("BG/HintObject2").gameObject.SetActive(true);
        }
        else
        {
            if (GameManager.Instance.data.isStyxApp)
            {
                AdsObejct.SetActive(true);
                AdsObejct.transform.Find("BG/HintObject").gameObject.SetActive(false);
                AdsObejct.transform.Find("BG/HintObject2").gameObject.SetActive(true);
            }
            else
            {
                AdsObejct.SetActive(true);
                AdsObejct.transform.Find("BG/HintObject2").gameObject.SetActive(false);
                AdsObejct.transform.Find("BG/HintObject").gameObject.SetActive(true);
            }
        }      

    }
    public void ShowHint()
    {
        GameManager.Instance.RewardHint_Data();
        for (int i =0; i< HintList.Count; i++)
        {
            HintList[i].SetActive(false);
        }
     
        AdsObejct.SetActive(false);
        HintObject.SetActive(true);
        HintList[(int)GameManager.Instance.hintType].SetActive(true);
        if (GameManager.Instance.hintType == GameManager.HintType.CodeGame)
        {
            int number = CodeGame.ResultNumber * CodeGame.ResultNumber;
            Code_InputText.text = "EngineStart Need Number " + number;
            Code_ResultText.text = number.ToString();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

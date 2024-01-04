using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EndingPart : MonoBehaviour
{
    public GameObject ClearStarObejct;
    public List<GameObject> LineList;
    public Text TitleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetView(bool isClear)
    {
        for (int i = 0; i < LineList.Count; i++)
        {
            LineList[i].GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
        }
        this.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
        this.transform.Find("NotClear").gameObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
        TitleText.color = new Color(0, 0, 0, 0);
        StartCoroutine(DesintegrationRoutine(1, this.gameObject));
        StartCoroutine(DesintegrationRoutine(1, this.transform.Find("NotClear").gameObject));
        if (isClear)
        {
            ClearStarObejct.SetActive(true);
            ClearStarObejct.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 1;
            StartCoroutine(DesintegrationRoutine(2, ClearStarObejct));
        }
        StartCoroutine(LineRoutine(1));
        StartCoroutine(TextRoutine(1,TitleText));
    }
    IEnumerator TextRoutine(float time, Text text_object)
    {
        Color color = text_object.color;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            color.a += 0.01f;
            text_object.color = color;
            if (color.a >=0.78f)
            {
                color.a = 1;
                break;
            }

        }
    }
    IEnumerator LineRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        for(int i=0;i< LineList.Count; i++)
        {
            StartCoroutine(DesintegrationRoutine(1f, LineList[i]));
            yield return new WaitForSeconds(0.2f);
        }        
    }
    IEnumerator DesintegrationRoutine(float time, GameObject inputObject)
    {
        
        while(true)
        {
            yield return new WaitForSeconds(0.01f);
            inputObject.GetComponent< _2dxFX_DesintegrationFX>().Desintegration -= 0.01f;
            if(inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration<=0)
            {
                inputObject.GetComponent<_2dxFX_DesintegrationFX>().Desintegration = 0;
                break;
            }
            
        }
    }
}

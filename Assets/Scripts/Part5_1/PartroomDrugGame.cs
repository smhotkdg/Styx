using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartroomDrugGame : MonoBehaviour
{
    public bool isPart5_1 = true;
    public delegate void OnComplete(bool flag);
    public event OnComplete OnCompleteEventHander;
    public Image DrugImage;

    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public List<Image> SelectObjectList;
    public List<Image> SelectImageList;
    public List<int> SelectList = new List<int>();
    public List<Color> ColorList = new List<Color>();

    public Animator DragAnim;
    public GameObject CircularGame;
    public GameObject Game;
    int circleIndex = 0;
    public Text PercentText;
    public void DragJuice(bool flag)
    {
        if (flag)
            DragAnim.enabled = true;
        else
            DragAnim.enabled = false;
    }
    public void SetJuice()
    {
       
        if (circleIndex >= 10)
            return;
        circleIndex++;
        SetText();
        Color newColor = MakeColor;
        float colorValue = (float)circleIndex / 10;
        newColor.r = MakeColor.r * colorValue;
        newColor.g = MakeColor.g * colorValue;
        newColor.b = MakeColor.b * colorValue;
        newColor.a = 1;
        DrugImage.color = newColor;
    }
    public void SetText()
    {
        int percent = circleIndex * 10;
        float imageIndex = ((float)circleIndex) / 10f;
      
        //JuiceImage.DOFillAmount(imageIndex, 1f);
        StartCoroutine(TextRoutine());

        if (circleIndex >= 10)
        {
            if(isPart5_1)
            {
                if (SelectList.Count >= 5)
                {
                    if (SelectList[0] == 1 && SelectList[1] == 1 && SelectList[2] == 0 && SelectList[3] == 0 && SelectList[4] == 0 && SelectList[5] == 1)
                    {
                        //Debug.Log("완료");
                        OnCompleteEventHander?.Invoke(true);
                    }
                    else
                    {
                        //Debug.Log("실패");
                        OnCompleteEventHander?.Invoke(false);
                    }
                }
                else
                {
                    //Debug.Log("실패");
                    OnCompleteEventHander?.Invoke(false);
                }
                GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
                GetComponent<Animator>().Play("partyroomDrugOff");
            }
            else
            {
                if (SelectList.Count >= 5)
                {
                    if (SelectList[0] == 0 && SelectList[1] == 0 && SelectList[2] == 1 && SelectList[3] == 1 && SelectList[4] == 1 && SelectList[5] == 0)
                    {
                        //Debug.Log("완료");
                        OnCompleteEventHander?.Invoke(true);
                    }
                    else
                    {
                        //Debug.Log("실패");
                        OnCompleteEventHander?.Invoke(false);
                    }
                }
                else
                {
                    //Debug.Log("실패");
                    OnCompleteEventHander?.Invoke(false);
                }
                GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
                GetComponent<Animator>().Play("partyroomDrugOff");
            }
        }
    }

    IEnumerator TextRoutine()
    {
        int percent = (circleIndex * 10) - 10;
        int increase = percent;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.02f);
            increase += 1;
            PercentText.text = increase + " %";
        }
        PercentText.text = (circleIndex * 10) + " %";
    }
    private void OnEnable()
    {
        Game.SetActive(true);
        CircularGame.SetActive(false);
        circleIndex = 0;
        PercentText.text = "0 %";
        SelectList.Clear();
        for (int i = 0; i < SelectObjectList.Count; i++)
        {
            SelectList.Add(0);
        }
        InitData();
        DrugImage.color = new Color(1, 1, 1, 1);
        colors = new Color[0];
        MakeColor = new Color(1, 1, 1, 1);
    }
    private void Start()
    {

      
        ColorList.Add(color1);
        ColorList.Add(color2);
        ColorList.Add(color3);
        ColorList.Add(color4);
        ColorList.Add(color5);
        ColorList.Add(color6);
    }
    Color MakeColor;
    public void MakeDrug()
    {
        Game.SetActive(false);
        CircularGame.SetActive(true);
       
    }
    Color[] colors;
    public void InitData()
    {
        for(int i=0; i< SelectObjectList.Count; i++)
        {
            SelectObjectList[i].color = new Color(SelectObjectList[i].color.r, SelectObjectList[i].color.g, SelectObjectList[i].color.b, 1);
            SelectImageList[i].color = new Color(SelectImageList[i].color.r, SelectImageList[i].color.g, SelectImageList[i].color.b, 1);
            SelectList[i] = 0;
        }
        DragJuice(false);
    }
    public void ClickMerge(int i)
    {
        if(SelectObjectList[i].color.a ==1)
        {
            SelectObjectList[i].color = new Color(SelectObjectList[i].color.r, SelectObjectList[i].color.g, SelectObjectList[i].color.b, 0.25f);
            SelectImageList[i].color = new Color(SelectImageList[i].color.r, SelectImageList[i].color.g, SelectImageList[i].color.b, 0.25f);
            SelectList[i] = 1;
        }
        else
        {
            SelectObjectList[i].color = new Color(SelectObjectList[i].color.r, SelectObjectList[i].color.g, SelectObjectList[i].color.b, 1);
            SelectImageList[i].color = new Color(SelectImageList[i].color.r, SelectImageList[i].color.g, SelectImageList[i].color.b, 1);
            SelectList[i] = 0;
        }
        int selectCount = 0;
        
        for(int number =0; number < SelectList.Count; number++)
        {
            if(SelectList[number] ==1)
            {
                selectCount++;
            }
        }
        colors = new Color[selectCount];

        selectCount = 0;
        for (int number = 0; number < SelectList.Count; number++)
        {
            if (SelectList[number] == 1)
            {
                colors[selectCount] = ColorList[number];
                selectCount++;                
            }
        }

        if (colors.Length == 0)
        {
            DrugImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            MakeColor = CombineColors(colors);
        }

    }
    public Color CombineColors(params Color[] aColors)
    {
        Color result = new Color(0, 0, 0, 0);
        foreach (Color c in aColors)
        {
            result += c;
        }
        result /= aColors.Length;
        return result;
    }

    public Color TransformHSV(
        Color color,  // color to transform
        float H,          // hue shift (in degrees)
        float S,          // saturation multiplier (scalar)
        float V           // value multiplier (scalar)
        )
    {
        float VSU = V * S * Mathf.Cos(H * Mathf.PI / 180);
        float VSW = V * S * Mathf.Sin(H * Mathf.PI / 180);

        Color ret = new Color();
        ret.r = (.299f * V + .701f * VSU + .168f * VSW) * color.r
            + (.587f * V - .587f * VSU + .330f * VSW) * color.g
                + (.114f * V - .114f * VSU - .497f * VSW) * color.b;
        ret.g = (.299f * V - .299f * VSU - .328f * VSW) * color.r
            + (.587f * V + .413f * VSU + .035f * VSW) * color.g
                + (.114f * V - .114f * VSU + .292f * VSW) * color.b;
        ret.b = (.299f * V - .3f * VSU + 1.25f * VSW) * color.r
            + (.587f * V - .588f * VSU - 1.05f * VSW) * color.g
                + (.114f * V + .886f * VSU - .203f * VSW) * color.b;
        ret.a = 1f;
        if (ret.r < 0) { ret.r = 0; }
        if (ret.g < 0) { ret.g = 0; }
        if (ret.b < 0) { ret.b = 0; }
        return ret;
    }
}

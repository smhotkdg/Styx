using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;

    public Image FxImage;
    public Image BGMImage;
    private void OnEnable()
    {
        CheckSprite();
    }
    void CheckSprite()
    {
        if (GameManager.Instance.data.FX)
        {
            FxImage.sprite = onSprite;
        }
        else
        {
            FxImage.sprite = offSprite;
        }

        if (GameManager.Instance.data.BGM)
        {
            BGMImage.sprite = onSprite;
        }
        else
        {
            BGMImage.sprite = offSprite;
        }
    }
    public void TrunFX()
    {
        GameManager.Instance.data.FX = !GameManager.Instance.data.FX;
        CheckSprite();
        SoundsManager.Instance.CheckSetting();
    }
    public void TrunBGM()
    {
        GameManager.Instance.data.BGM = !GameManager.Instance.data.BGM;
        CheckSprite();
        SoundsManager.Instance.CheckSetting();
    }
}

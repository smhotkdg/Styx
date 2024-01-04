using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlashLIghtOnOff : MonoBehaviour
{
    public Text OnOffText;
    public Sprite OnSprite;
    public Sprite OffSprite;
    public Image m_image;
    public bool bTurn = false;
        
    private void Start()
    {
        if(ES3.KeyExists("bTurn"))
        {
            bTurn = ES3.Load<bool>("bTurn");
          
            if (bTurn)
            {                
                m_image.sprite = OnSprite;
                GameManager.Instance.Player.GetComponent<PlayerController>().SetFlashLight(true);
                OnOffText.text = "on";                
            }
            else
            {                
                m_image.sprite = OffSprite;
                GameManager.Instance.Player.GetComponent<PlayerController>().SetFlashLight(false);
                OnOffText.text = "off";
            }
        }
    }
    private void OnApplicationQuit()
    {        
        ES3.Save("bTurn", bTurn);
    }  
    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {            
            ES3.Save("bTurn", bTurn);
        }
    }
    public void Turn()
    {
        if(bTurn)
        {
            bTurn = false;
            m_image.sprite = OffSprite;
            GameManager.Instance.Player.GetComponent<PlayerController>().SetFlashLight(false);
            OnOffText.text = "off";
        }
        else
        {
            bTurn = true;
            m_image.sprite = OnSprite;
            GameManager.Instance.Player.GetComponent<PlayerController>().SetFlashLight(true);
            OnOffText.text = "on";
        }
    }
}

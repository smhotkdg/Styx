using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopPanelController : MonoBehaviour
{
    public GameObject InappButton;
    public GameObject CompleteBuyButton;
    public GameObject Bottom;
    public GameObject InfoPanel;
    public GameObject SpeacialOffer;
    public Text OfferTimer;
    private void OnEnable()
    {
        checkInapp();
    }
    public void checkInapp()
    {

        //if (GameManager.Instance.data.isStyxApp)
        //{
        //    if(CompleteBuyButton!=null)
        //        CompleteBuyButton.SetActive(true);
        //    if(InappButton!=null)
        //        InappButton.SetActive(false);            
        //}
        //else
        //{
        //    if (CompleteBuyButton != null)
        //        CompleteBuyButton.SetActive(false);
        //    if (InappButton != null)
        //        InappButton.SetActive(true);            
        //}

        //if(GameManager.Instance.data.isStyxApp)
        //{
        //    SpeacialOffer.SetActive(false);
        //}
        //else
        //{
        //    SpeacialOffer.SetActive(GameManager.Instance.isStartOffer);
        //}

    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.isStartOffer)
        {
            TimeSpan time = TimeSpan.FromSeconds(GameManager.Instance.speacialOfferTime);

            string str = time.ToString(@"hh\:mm\:ss");

            OfferTimer.text = str;
        }
        else
        {
            SpeacialOffer.SetActive(false);
        }
    }
}

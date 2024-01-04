using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EasyMobile;
public class AdManager : MonoBehaviour
{
    private static AdManager _instance = null;
    
    public static AdManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return null;
            }
            else
            {
                return _instance;
            }                
            
        }
    }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            //
            _instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        AdsSetting();
    }
    private void OnEnable()
    {
        if (ES3.KeyExists("AdsTime"))
        {
            m_time = ES3.Load<float>("AdsTime");
        }
    }

    public float m_time = 0;
    public bool isShowPop = false;

    private void FixedUpdate()
    {
        if (m_time >= 600)
        {
            isShowPop = true;
        }
        else
        {
            isShowPop = false;
            m_time += Time.deltaTime;
        }
    }
    private void OnDisable()
    {
        ES3.Save("AdsTime", m_time);
    }
    bool isStart;
    bool isReady;

    IronSourceClientImpl IronSourceClientImpl;

    bool binit = false;
    void AdsSetting()
    {
        if (!Advertising.IsInitialized())
        {
            Advertising.Initialize();
        }
        Advertising.GrantDataPrivacyConsent(AdNetwork.UnityAds);
        Advertising.RevokeDataPrivacyConsent(AdNetwork.UnityAds);
        //ConsentStatus moduleConsentUnity = Advertising.GetDataPrivacyConsent(AdNetwork.UnityAds);        
        //UnityAdsClient = Advertising.UnityAdsClient;
        IronSourceClientImpl = Advertising.IronSourceClient;
        Advertising.RewardedAdCompleted += Advertising_RewardedAdCompleted;
        Advertising.InterstitialAdCompleted += Advertising_InterstitialAdCompleted;

        //ShowBanner();
        binit = true;
    }


    bool isShowBanner = false;
    public void ShowBanner()
    {
        //if(GameManager.Instance ==null)
        //{
        //    return;
        //}
        //if (GameManager.Instance.data.isStyxApp)
        //{
        //    isShowBanner = true;
        //    return;
        //}        
        //UnityAdsClient.ShowBannerAd(BannerAdPosition.Bottom,BannerAdSize.SmartBanner);

        //if(isShowBanner ==false)
        //{
        //    StartCoroutine(BannerRoutine());
        //}
    }
    //IEnumerator BannerRoutine()
    //{
    //    yield return new WaitForSeconds(1f);
    //    ShowBanner();
    //}
    private void UnityAdsClient_BannerAdShownCallback(AdPlacement obj)
    {
        isShowBanner = true;

    }


    public void HideBanner()
    {
        if (binit == false)
            return;
        //UnityAdsClient.HideBannerAd();
        //StartCoroutine(HideRoutine());        
    }

    private void Advertising_RewardedInterstitialAdCompleted(RewardedInterstitialAdNetwork arg1, AdPlacement arg2)
    {
        SoundsManager.Instance.MuteAll(false);
        UIManager.Instance.AdsPopup.SetActive(false);
        //if (GameManager.Instance.speacialOfferTime > 1)
        //{
        //    GameManager.Instance.isStartOffer = true;
        //    ES3.Save("isStartOffer", GameManager.Instance.isStartOffer);
        //    //UIManager.Instance.SpecailOfferUI.SetActive(true);
        //    //UIManager.Instance.SpecailOfferButton.SetActive(true);
        //    UIManager.Instance.ShopPanel.GetComponent<ShopPanelController>().checkInapp();
        //}
    }

    private void Advertising_RewardedInterstitialAdSkipped(RewardedInterstitialAdNetwork arg1, AdPlacement arg2)
    {
        SoundsManager.Instance.MuteAll(false);
        UIManager.Instance.AdsPopup.SetActive(false);
    }

    private void Advertising_InterstitialAdCompleted(InterstitialAdNetwork arg1, AdPlacement arg2)
    {
        SoundsManager.Instance.MuteAll(false);
        UIManager.Instance.AdsPopup.SetActive(false);
        //if(GameManager.Instance.speacialOfferTime >1)
        //{
        //    GameManager.Instance.isStartOffer = true;
        //    ES3.Save("isStartOffer", GameManager.Instance.isStartOffer);
        //    UIManager.Instance.SpecailOfferUI.SetActive(true);
        //    UIManager.Instance.SpecailOfferButton.SetActive(true);
        //    UIManager.Instance.ShopPanel.GetComponent<ShopPanelController>().checkInapp();
        //}

    }

    private void Advertising_RewardedAdSkipped(RewardedAdNetwork arg1, AdPlacement arg2)
    {
        SoundsManager.Instance.MuteAll(false);
        UIManager.Instance.AdsPopup.SetActive(false);
    }

    private void Advertising_RewardedAdCompleted(RewardedAdNetwork arg1, AdPlacement arg2)
    {
        if (GameManager.Instance.adsType == GameManager.AdsType.FootCount)
        {
            GameManager.Instance.RewardAds();
        }
        else
        {
            GameManager.Instance.RewardHint();
        }
        //GameManager.Instance.RewardAds();
        SoundsManager.Instance.MuteAll(false);
        UIManager.Instance.AdsPopup.SetActive(false);
    }

    public bool ShowPopAds()
    {
        UIManager.Instance.ShowReview();
        return false;
    }
    IEnumerator AdsStart(int type)
    {
        yield return new WaitForSeconds(0.8f);
        if (type == 0)
        {
            if (Advertising.IsRewardedAdReady())
            {
                Advertising.ShowRewardedAd();
            }
        }
        else if (type == 1)
        {
            if (Advertising.IsRewardedAdReady())
            {
                Advertising.ShowRewardedAd();
            }
        }
        else
        {
            if (Advertising.IsRewardedAdReady())
            {
                Advertising.ShowRewardedAd();
            }
        }

        SoundsManager.Instance.MuteAll(true);
        m_time = 0;
        isShowPop = false;
    }

    public void TestUnityAds(int type)
    {
        if (type == 0)
        {
            if (Advertising.IsRewardedAdReady())
            {
                Advertising.ShowRewardedAd();
            }
        }
        else
        {
            if (Advertising.IsRewardedAdReady())
            {
                Advertising.ShowRewardedAd();
            }
        }

    }
    public void ShowAds()
    {
        if (GameManager.Instance.data.isStyxApp)
        {
            return;
        }
        if (Advertising.IsRewardedAdReady())
        {
            Advertising.ShowRewardedAd();
            SoundsManager.Instance.MuteAll(true);
        }
        else
        {
            UIManager.Instance.AdsNeedPanel.SetActive(true);
        }
    }
}


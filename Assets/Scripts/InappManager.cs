using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using UnityEngine.UI;

public class InappManager : MonoBehaviour
{
    //Start is called before the first frame update
    private static InappManager _instance = null;
    public ShopPanelController menuController;
    public GameObject AdsPanel;
    public GameObject NewStoryInapp;
    public NewStoryPanel storyPanel;
    public GameObject InappComplete_2;
    public Text inappCount;
    public static InappManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("cSingleton InappManager == null");
            return _instance;
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

            _instance = this;
        }
    }


    void Start()
    {
        InAppPurchasing.InitializePurchasing();
        InitData();
    }
    void InitData()
    {
        if (InAppPurchasing.IsInitialized() == true)
        {
            IAPProduct[] products = InAppPurchasing.GetAllIAPProducts();

            // Print all product names
            foreach (IAPProduct prod in products)
            {

                Debug.Log("Product name: " + prod.Name);
            }
        }
        else
        {
            InAppPurchasing.InitializePurchasing();
        }
    }

    //Subscribe to IAP purchase events
    void OnEnable()
    {
        InAppPurchasing.PurchaseCompleted += PurchaseCompletedHandler;
        InAppPurchasing.PurchaseFailed += InAppPurchasing_PurchaseFailed;

        InAppPurchasing.RestoreCompleted += InAppPurchasing_RestoreCompleted;
        InAppPurchasing.RestoreFailed += InAppPurchasing_RestoreFailed;
    }

    private void InAppPurchasing_PurchaseFailed(IAPProduct arg1, string arg2)
    {
        UIManager.Instance.InappProcess.SetActive(false);
        UIManager.Instance.BuyFailPanel.SetActive(true);
        //Debug.Log("The purchase of product " + product.Name + " has failed.");
    }

    private void InAppPurchasing_RestoreFailed()
    {
        UIManager.Instance.InappProcess.SetActive(false);
        UIManager.Instance.RestoreFailPanel.SetActive(true);
        //string tryagainstring = I2.Loc.LocalizationManager.GetTermData("text_ui_RestorationFail").Languages[GameManager.Instance.Language_Type];
        //UIManager.Instance.ShowNotification(tryagainstring);
    }
    public void TestInapp()
    {
        NewStoryInapp.SetActive(false);
        if (storyPanel.gameObject.activeSelf)
            storyPanel.CheckInapp();
        menuController.InfoPanel.SetActive(false);
        //menuController.Bottom.SetActive(true);
        AdsPanel.SetActive(false);
        UIManager.Instance.InappProcess.SetActive(false);
        UIManager.Instance.BuyCompletePanel.SetActive(true);
        //UIManager.Instance.RestoreCompletePanle.SetActive(true);
        GameManager.Instance.data.isStyxApp = true;
        GameManager.Instance.SaveData();
        //UIManager.Instance.SetFoot();
        //string tryagainstring = I2.Loc.LocalizationManager.GetTermData("text_ui_restorationSuccess").Languages[GameManager.Instance.Language_Type];
        //UIManager.Instance.ShowNotification(tryagainstring);
        menuController.checkInapp();
    }
    private void InAppPurchasing_RestoreCompleted()
    {
        NewStoryInapp.SetActive(false);
        if (storyPanel.gameObject.activeSelf)
            storyPanel.CheckInapp();
        menuController.InfoPanel.SetActive(false);
        //menuController.Bottom.SetActive(true);
        AdsPanel.SetActive(false);
        UIManager.Instance.InappProcess.SetActive(false);
        UIManager.Instance.BuyCompletePanel.SetActive(false);
        UIManager.Instance.RestoreCompletePanle.SetActive(true);
        GameManager.Instance.data.isStyxApp = true;
        GameManager.Instance.SaveData();
        //UIManager.Instance.SetFoot();
        //string tryagainstring = I2.Loc.LocalizationManager.GetTermData("text_ui_restorationSuccess").Languages[GameManager.Instance.Language_Type];
        //UIManager.Instance.ShowNotification(tryagainstring);
        menuController.checkInapp();
        AdManager.Instance.HideBanner();
        UIManager.Instance.SetCoin();
    }

    // Unsubscribe when the game object is disabled
    void OnDisable()
    {
        InAppPurchasing.PurchaseCompleted -= PurchaseCompletedHandler;
        InAppPurchasing.PurchaseFailed -= InAppPurchasing_PurchaseFailed;


        InAppPurchasing.RestoreCompleted -= InAppPurchasing_RestoreCompleted;
        InAppPurchasing.RestoreFailed -= InAppPurchasing_RestoreFailed;
    }

    public void Purchase()
    {
        if (GameManager.Instance.isBeta)
        {
            return;
        }
        UIManager.Instance.InappProcess.SetActive(true);
        InAppPurchasing.Purchase(EM_IAPConstants.Product_noads);
    }
    public void PurchaseCoin(int index)
    {
        UIManager.Instance.InappProcess.SetActive(true);
        //switch (index)
        //{
        //    case 0:
        //        InAppPurchasing.Purchase(EM_IAPConstants.Product_coin_1);
        //        break;
        //    case 1:
        //        InAppPurchasing.Purchase(EM_IAPConstants.Product_coin_2);
        //        break;
        //    case 2:
        //        InAppPurchasing.Purchase(EM_IAPConstants.Product_coin_3);
        //        break;
        //}

    }
    public void PurchaseSpeacialOffer()
    {
        UIManager.Instance.InappProcess.SetActive(true);
        //InAppPurchasing.Purchase(EM_IAPConstants.Product_noads_2);
    }
    // Successful purchase handler
    void PurchaseCompletedHandler(IAPProduct product)
    {
        // Compare product name to the generated name constants to determine which product was bought
        //Debug.Log("구매완료");
        UIManager.Instance.InappProcess.SetActive(false);
        switch (product.Name)
        {
            case EM_IAPConstants.Product_noads:
                NewStoryInapp.SetActive(false);
                if (storyPanel.gameObject.activeSelf == true)
                {
                    storyPanel.CheckInapp();
                }
                AdsPanel.SetActive(false);
                menuController.InfoPanel.SetActive(false);
                //menuController.Bottom.SetActive(true);
                GameManager.Instance.data.isStyxApp = true;
                GameManager.Instance.SaveData();
                //UIManager.Instance.SetFoot();
                UIManager.Instance.InappProcess.SetActive(false);
                UIManager.Instance.BuyCompletePanel.SetActive(true);
                switch (product.Name)
                {
                    case EM_IAPConstants.Product_noads:
                        break;
                }
                menuController.checkInapp();
                UIManager.Instance.SetCoin();
                AdManager.Instance.HideBanner();
                UIManager.Instance.SpecailOfferButton.SetActive(false);
                UIManager.Instance.SpecailOfferUI.GetComponent<EffectChecker>().CheckEffect(false);
                UIManager.Instance.SpecailOfferUI.SetActive(false);
                UIManager.Instance.CheckVIPInapp();
                GameManager.Instance.isStartOffer = false;
                break;         
        }
        UIManager.Instance.ShopPanel.SetActive(false);
    }


    public void RestorePurchases()
    {
        if (GameManager.Instance.isBeta)
        {
            return;
        }
#if UNITY_IOS
        if (InAppPurchasing.IsProductOwned(EM_IAPConstants.Product_noads))
        {
            UIManager.Instance.InappProcess.SetActive(true);
            InAppPurchasing.RestorePurchases();
        }
        else
        {
            UIManager.Instance.InappProcess.SetActive(false);
            UIManager.Instance.RestoreFailPanel.SetActive(true);
        }
#endif
#if UNITY_ANDROID
        if (InAppPurchasing.IsProductOwned(EM_IAPConstants.Product_noads))
        {
            menuController.InfoPanel.SetActive(false);
            menuController.Bottom.SetActive(true);
            AdsPanel.SetActive(false);
            UIManager.Instance.InappProcess.SetActive(false);
            UIManager.Instance.BuyCompletePanel.SetActive(false);
            UIManager.Instance.RestoreCompletePanle.SetActive(true);
            GameManager.Instance.data.isStyxApp = true;
            GameManager.Instance.SaveData();
            UIManager.Instance.SetFoot();
            //string tryagainstring = I2.Loc.LocalizationManager.GetTermData("text_ui_restorationSuccess").Languages[GameManager.Instance.Language_Type];
            //UIManager.Instance.ShowNotification(tryagainstring);
            menuController.checkInapp();
            AdManager.Instance.HideBanner();
            UIManager.Instance.SetCoin();
        }
        else
        {
            UIManager.Instance.InappProcess.SetActive(false);
            UIManager.Instance.RestoreFailPanel.SetActive(true);
        }
#endif
    }
    void Update()
    {

    }
}

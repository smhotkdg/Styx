using AppsFlyerSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsFlyerManager : MonoBehaviour
{
    void Start()
    {
#if UNITY_IOS
          AppsFlyer.initSDK("wDx4CyQXYDUKr3AB3MMpES", "1602798571");
          AppsFlyer.startSDK();
#elif UNITY_ANDROID
        AppsFlyer.initSDK("wDx4CyQXYDUKr3AB3MMpES", "");
        AppsFlyer.startSDK();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

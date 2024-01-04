#if !UNITY_IOS
using Google.Play.Review;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InappReview : MonoBehaviour
{
#if !UNITY_IOS
    ReviewManager m_ReviewManager;
    PlayReviewInfo m_ReviewInfo;
#endif
    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_IOS
        if (Application.platform == RuntimePlatform.Android)
        {
            m_ReviewManager = new ReviewManager();
        }
#endif
    }

    public void RequestReview()
    {
#if !UNITY_IOS
        if (Application.platform == RuntimePlatform.Android)
        {
            StartCoroutine(requireRate());
        }
#endif
#if UNITY_IOS
        UIManager.Instance.ReviewPanel.GetComponent<Animator>().Play("ReviewOff");
        UnityEngine.iOS.Device.RequestStoreReview();
#endif
    }
#if !UNITY_IOS
    private IEnumerator requireRate()
    {
        // Create instance of ReviewManager        
        // ...
        m_ReviewManager = new ReviewManager();
        var requestFlowOperation = m_ReviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.hoitstudio.styx");
            yield break;
        }
        m_ReviewInfo = requestFlowOperation.GetResult();
        var launchFlowOperation = m_ReviewManager.LaunchReviewFlow(m_ReviewInfo);
        yield return launchFlowOperation;
        m_ReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.hoitstudio.styx");
            yield break;
        }
        UIManager.Instance.ReviewPanel.GetComponent<Animator>().Play("ReviewOff");
        ES3.Save("styxReview", true);
        GameManager.Instance.isReview = true;
    }
#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireEventPanelController : MonoBehaviour
{
    public delegate void OnEnd();
    public event OnEnd OnEndEventHandler;

    public List<GameObject> EventConversationList;
    public List<Text> EventConversationTextList;

    public GameObject window;
    public GameObject windowCamera;
    bool isDisable = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnEnable()
    {
        
        isStop = false;
        window.transform.localScale = new Vector3(1, 1, 1);
        windowCamera.transform.localScale = new Vector3(1, 1, 1);
        count = 0;
        for(int i =0; i< EventConversationList.Count; i++)
        {
            EventConversationList[i].SetActive(false);
        }
        StartCoroutine(ConversationRoutine());
    }
    int count = 0;
    IEnumerator ConversationRoutine()
    {
        float dealyTime = Random.Range(0.5f, 1.2f);
        yield return new WaitForSeconds(dealyTime);
        if(isStop ==false && count <4)
        {            
            int rand = Random.Range(0, 3);
            EventConversationList[count].SetActive(true);
            EventConversationTextList[count].text = languageController.Instance.GetFireEvent(count);
            count++;
            StartCoroutine(ConversationRoutine());
        }
    }
    bool isStop = false;
    private void OnDisable()
    {
        isStop = true;        
        StopAllCoroutines();
    }

    // Update is called once per frame
  
}

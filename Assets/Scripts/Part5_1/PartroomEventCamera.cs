using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PartroomEventCamera : MonoBehaviour
{
    public delegate void onCompleteEvent();
    public event onCompleteEvent onCompleteEventHandler;
    public GameObject CameraObject;
    public GameObject EventObject;
    public DOTweenAnimation Event;
    public List<GameObject> ConversationList;
    private void OnEnable()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        CameraObject.SetActive(true);
        StartCoroutine(eventRoutine());
        for(int i =0; i< ConversationList.Count;i++)
        {
            ConversationList[i].SetActive(false);
        }
    }
    IEnumerator eventRoutine()
    {
        yield return new WaitForSeconds(1f);
        EventObject.GetComponent<Animator>().Play("drink");
        yield return new WaitForSeconds(1f);
        CameraObject.AddComponent<CameraPlay_Drunk>();
        EventObject.GetComponent<Animator>().Play("drink");
        yield return new WaitForSeconds(1f);
        ConversationList[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        
        EventObject.GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(1.5f);
        ConversationList[1].SetActive(true);
        ConversationList[3].SetActive(false);
        yield return new WaitForSeconds(0.7f);
        ConversationList[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        ConversationList[0].SetActive(true);        
        yield return new WaitForSeconds(2f);
        GetComponent<DOTweenAnimation>().DOPlayBackwards();
        Event.DOPlayBackwards();
        yield return new WaitForSeconds(1f);
        onCompleteEventHandler?.Invoke();
        gameObject.SetActive(false);
        this.gameObject.SetActive(false);        
    }
    private void OnDisable()
    {
        CameraObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using SensorToolkit;

public class SearchNPC_part5 : MonoBehaviour
{
    public delegate void OnFind(GameObject findParent);
    public event OnFind OnFindEventHandler;
    public Transform StartPos;
    public Transform EndPos;
    public Animator animator;
    public float speed;
    public RaySensor2D raySensor2D;
    private float journeyLength;
    private float startTime;
    private GameObject Light;

    Vector2 initscale;
    private void Awake()
    {
        initscale = transform.localScale;
    }
    public void SetInit()
    {
        startTime = Time.time;
        raySensor2D.enabled = true;
        
        float rand = Random.Range(1, 10);
        
        transform.position = StartPos.position;
        journeyLength = Vector3.Distance(transform.position, EndPos.position);
        transform.localScale = initscale;
    }
    public void StartGame()
    {
        isPasue = false;
    }
    void onCompleteEnd()
    {
        float rand = Random.Range(1, 10);              
    }    
    bool isPasue = true;

    public void AllResume()
    {
        isPasue = false;
        raySensor2D.enabled = true;        
        animator.SetFloat("speed", 1);
    }
    public void AllPause()
    {
        isPasue = true;
        raySensor2D.enabled = false;
        Vector2 nowPos = transform.position;        
        transform.position = nowPos;
        animator.SetFloat("speed", 0);
    }
    bool bStart = true;
    float horizontal_index;
    
    private void FixedUpdate()
    {
        if (GameManager.Instance.HintEnalbeList[22])
        {
            raySensor2D.enabled = false;
            Light.SetActive(false);
        }
        else
        {
            raySensor2D.enabled = true;
            Light.SetActive(true);
        }
      
        if (raySensor2D.DetectedObjects.Count>0)
        {
            if (raySensor2D.DetectedObjects[0].gameObject.name == "Player")
            {
                if (GameManager.Instance.playerController.bHide == false)
                {
                    //Debug.Log("너 걸림");
                    if(GameManager.Instance.gameStatus == GameManager.GameStatus.NOTING)
                    {
                        OnFindEventHandler?.Invoke(this.gameObject);
                    }
                    
                }
            }
        }
        //else
        {
            if(isPasue ==false)
            {                
                if(bStart)
                {
                    animator.SetFloat("speed", 1);
                    horizontal_index = transform.position.x - EndPos.transform.position.x;
                    transform.position = Vector2.MoveTowards(transform.position, EndPos.transform.position, 1 * Time.deltaTime);

                    if (Mathf.Abs(transform.position.x - EndPos.transform.position.x) < 0.1f)
                    {
                        animator.SetFloat("speed", 0);
                        int rand = Random.Range(1, 100);
                        //if(rand ==10)
                        {
                            bStart = false;
                        }
                        
                    }                  
                }
                else
                {
                    animator.SetFloat("speed", 1);
                    horizontal_index = transform.position.x - StartPos.transform.position.x;
                    transform.position = Vector2.MoveTowards(transform.position, StartPos.transform.position, 1 * Time.deltaTime);

                    if (Mathf.Abs(transform.position.x - StartPos.transform.position.x) < 0.1f)
                    {
                        animator.SetFloat("speed", 0);
                        int rand = Random.Range(1, 100);
                        //if (rand == 10)
                        {
                            bStart = true;
                        }
                    }
                }
                if (horizontal_index != 0)
                {
                    if (horizontal_index > 0)
                    {
                        transform.localScale = new Vector3(1 * 4, 1 * 4, 1 * 4);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1 * 4, 1 * 4, 1 * 4);
                    }
                }
            }
            else
            {
                animator.SetFloat("speed", 0);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("speed", 0);
        Light = transform.Find("SensorLight 0").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

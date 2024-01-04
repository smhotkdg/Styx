using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
using Sirenix.OdinInspector;
public class MoveNPC : MonoBehaviour
{
    public bool isWorking = false;
    private Animator animator;
    private splineMove move;
    Vector2 InitPos;
    bool isStop = false;
    // Start is called before the first frame update
    [Button("멈춤", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Stop()
    {
        isStop = true;
        bMove = true;
        animator.SetFloat("speed", 0);
        move.startPoint = 0;
        transform.position = InitPos;
        move.Stop();
    }
    [Button("다시 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void reStart()
    {
        isStop = false;
        bMove = false;
        if(move==null)
            move = GetComponent<splineMove>();
        move.StartMove();
    }
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        move = GetComponent<splineMove>();
        InitPos = transform.position;


    }
    private void OnDisable()
    {
        Stop();
    }
    private void OnEnable()
    {
        isStop = false;
        StartCoroutine(CheckFlip());
        reStart();
    }
    IEnumerator CheckFlip()
    {
      
        prePos = transform.position;
        yield return new WaitForSeconds(0.05f);
        if(prePos.x<= transform.position.x )
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        else
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
        StartCoroutine(CheckFlip());
    }
 
    private void OnAnimatorMove()
    {
        if (bMove == false)
        {
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }
            animator.SetFloat("speed", 1);
        }
            
        else
        {
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }
            animator.SetFloat("speed", 0);
        }
     
    }
    bool bWorking = false;
    bool bMove = false;
    public void SetWorking()
    {
        if(isWorking==false)
        {
            return;
        }
        if (bWorking ==false)
        {
            animator.SetFloat("speed", 0);
            move.Stop();
            animator.SetBool("isWorking", true);
            if(this.gameObject.activeSelf ==true)
            {
                StartCoroutine(EndWorkingRoutine());
            }            
            bWorking = true;
            bMove = true;
        }
       
    }
    IEnumerator EndWorkingRoutine()
    {       
        float rand = Random.Range(3, 10);
        yield return new WaitForSeconds(rand);
        if (this.gameObject.activeSelf == true)
        {
            animator.SetBool("isWorking", false);
            move.StartMove();
            bMove = false;
            yield return new WaitForSeconds(1);
            bWorking = false;
        }
    }
    Vector2 prePos;
   
}

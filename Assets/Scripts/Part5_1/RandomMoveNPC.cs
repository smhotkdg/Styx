using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RandomMoveNPC : MonoBehaviour
{
    public bool isEvent = false;
    public float Minx;
    public float Maxx;
    Animator animator;
    public float speed = 1;
    public bool forcePause = false;
    // Start is called before the first frame update
    public delegate void OnCompleteMove();
    public event OnCompleteMove OnCompleteMoveEventHandler;
    void Start()
    {
        animator = GetComponent<Animator>();
        //StartCoroutine(CheckMoveRoutine());
    }
    public float moveRand = 0;
    public bool bMove = false;
    public Vector2 moveVector;
 
    // Update is called once per frame
    void Update()
    {
        if(bMove)
        {
            Vector2 newVector = transform.localPosition;
            if (moveRand > transform.localPosition.x)
            {
                newVector.x += speed * Time.deltaTime;
            }
            else
            {
                newVector.x -= speed * Time.deltaTime;
            }
            if (moveRand > transform.localPosition.x)
            {
                transform.localScale = new Vector3(-4, 4, 4);
            }
            else
            {
                transform.localScale = new Vector3(4, 4, 4);
            }
            animator.Play("walking");
            transform.localPosition = newVector;
            if (Mathf.Abs(transform.localPosition.x - moveVector.x) < 0.1f)
            {
                bMove = false;
                animator.Play("idle");
                OnCompleteMoveEventHandler?.Invoke();
            }
        }
      
    }
    private void FixedUpdate()
    {
        if (forcePause)
            return;
        if (bMove ==false)
        {
            int randomRange = Random.Range(150, 500);
            int rand = Random.Range(1, randomRange);
            if (rand == 5)
            {
                moveRand = Random.Range(Minx, Maxx);
                moveVector.x = moveRand;
                moveVector.y = transform.localPosition.y;
                if (moveRand > transform.localPosition.x)
                {
                    transform.localScale = new Vector3(-4, 4, 4);
                }
                else
                {
                    transform.localScale = new Vector3(4, 4, 4);
                }
                float randTime = Random.Range(1, 10);
                //yield return new WaitForSeconds(randTime);
                bMove = true;
            }
        }
    }
}

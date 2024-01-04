using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public bool dirfectFlip = false;
    public bool isFlip = false;
    public bool isSetMargin = false;
    public GameObject FollowTarget;
    public bool isFollow = false;
    public float Margin = 1.5f;
    public float moveSpeed = 1;
    Animator animator;
    public bool isPlayer = false;

    
    public delegate void onDistnaceZero();
    public event onDistnaceZero onDistanceZeroEventHandler;
    public void SetFollow(bool bFollow)
    {
        isFollow = bFollow;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(dirfectFlip)
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().OnFlipEventHandler += FollowObject_OnFlipEventHandler;
        }
    }

    private void FollowObject_OnFlipEventHandler(bool flag)
    {
        Vector2 newPos = GameManager.Instance.Player.transform.localPosition;

        if (isFollow)
        {
            if (flag == false)
            {
                if (isFlip == false)
                {
                    transform.localScale = new Vector3(1 * 4, 1 * 4, 1 * 4);
                }
                else
                {
                    transform.localScale = new Vector3(-1 * 4, 1 * 4, 1 * 4);                    
                    newPos.x += 0.9f;
                    transform.position = newPos;
                    animator.SetFloat("speed", 1);
                }

            }
            else
            {
                if (isFlip == false)
                {
                    transform.localScale = new Vector3(-1 * 4, 1 * 4, 1 * 4);
                }
                else
                {
                    transform.localScale = new Vector3(1 * 4, 1 * 4, 1 * 4);
                    newPos.x -= 0.9f;
                    transform.position = newPos;
                    animator.SetFloat("speed", 1);
                }
            }
        }
      
    }
    public float MinPower = 5;
    float horizontal_index;
    private void FixedUpdate()
    {
        if (isFollow)
        {
            
            if(GameManager.Instance.isJoyStick)
            {
                moveSpeed = GameManager.Instance.playerController.NowSpeed / 2f * GameManager.Instance.playerController.MovePower;

                if (moveSpeed <= 0)
                {
                    moveSpeed = 0.1f;
                }
            }
            else
            {
                moveSpeed = 1;
            }

            if (isPlayer ==false)
            {
                if (Mathf.Abs(transform.position.x - FollowTarget.transform.position.x) <= Margin)
                {
                    if (animator.GetFloat("speed") > 0)
                    {
                        onDistanceZeroEventHandler?.Invoke();
                    }
                    if(FollowTarget.GetComponent<Animator>()!=null)
                    {
                        if(FollowTarget.GetComponent<Animator>().GetFloat("speed")<=0)
                        {
                            animator.SetFloat("speed", 0);
                            animator.SetBool("isRun", false);
                        }
                    }
                    else
                    {
                        animator.SetFloat("speed", 0);
                        animator.SetBool("isRun", false);
                    }
                    
                    
                    
                    Vector3 vector = new Vector3(transform.position.x, transform.position.y, 0);
                    transform.position = vector;

                    if (Mathf.Abs(transform.position.x - FollowTarget.transform.position.x) > 5 || Mathf.Abs(transform.position.y - FollowTarget.transform.position.y) > 5)
                    {
                        transform.position = new Vector3(FollowTarget.transform.position.x - 2, FollowTarget.transform.position.y, 0);
                    }
                    return;
                }
                else
                {
                    animator.SetFloat("speed", 1);
                    animator.SetBool("isRun", GameManager.Instance.playerController.GetRun());
                }
                transform.position = Vector2.MoveTowards(transform.position, FollowTarget.transform.position, moveSpeed * Time.deltaTime);

                horizontal_index = transform.position.x - FollowTarget.transform.position.x;

                if(isSetMargin)
                {
                    if (Mathf.Abs(transform.position.x - FollowTarget.transform.position.x) > 5 || Mathf.Abs(transform.position.y - FollowTarget.transform.position.y) > 5)
                    {
                        transform.position = new Vector3(FollowTarget.transform.position.x - 2, FollowTarget.transform.position.y, 0);
                    }
                }
                if(dirfectFlip ==false)
                {
                    CheckFlip();
                }
                
            }
            else{
                
                if (Mathf.Abs(transform.position.x - FollowTarget.transform.localPosition.x) <= Margin)
                {
                    if (animator.GetFloat("speed") > 0)
                    {
                        onDistanceZeroEventHandler?.Invoke();
                    }
                    animator.SetFloat("speed", 0);
                    animator.SetBool("isRun", false);
                    Vector3 vector = new Vector3(transform.position.x, transform.position.y, 0);
                    transform.position = vector;

                    if (Mathf.Abs(transform.position.x - FollowTarget.transform.localPosition.x) > 5 || Mathf.Abs(transform.position.y - FollowTarget.transform.localPosition.y) > 5)
                    {
                        transform.position = new Vector3(FollowTarget.transform.localPosition.x - 2, FollowTarget.transform.localPosition.y, 0);
                    }
                    return;
                }
                else
                {                    
                    animator.SetFloat("speed", 1);
                    animator.SetBool("isRun", GameManager.Instance.playerController.GetRun());
                }
                transform.position = Vector2.MoveTowards(transform.position, FollowTarget.transform.localPosition, moveSpeed * Time.deltaTime);

                horizontal_index = transform.position.x - FollowTarget.transform.localPosition.x;

                if(isSetMargin)
                {
                    if (Mathf.Abs(transform.position.x - FollowTarget.transform.localPosition.x) > 5 || Mathf.Abs(transform.position.y - FollowTarget.transform.localPosition.y) > 5)
                    {
                        transform.position = new Vector3(FollowTarget.transform.localPosition.x - 2, FollowTarget.transform.localPosition.y, 0);
                    }
                }

                if(dirfectFlip==false)
                {
                    CheckFlip();
                }
                
            }
        }
    }
    void CheckFlip()
    {
        if (isFollow)
        {
            if (horizontal_index != 0)
            {
                if (horizontal_index > 0)
                {
                    if(isFlip ==false)
                    {
                        transform.localScale = new Vector3(1 * 4, 1 * 4, 1 * 4);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1 * 4, 1 * 4, 1 * 4);
                    }
                    
                }
                else
                {
                    if (isFlip == false)
                    {
                        transform.localScale = new Vector3(-1 * 4, 1 * 4, 1 * 4);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1 * 4, 1 * 4, 1 * 4);
                    }
                        
                }
            }
        }
   
    }
}

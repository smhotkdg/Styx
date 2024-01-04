using UnityEngine;
using PixelCrushers.DialogueSystem;
public class PlayerController : MonoBehaviour
{
    public bool bWater = false;
    float ScaleFactar = 1;
    [SerializeField]
    public bool isHorizontal = true;
    public float speed;
    public GameObject FlashLight;
    public VariableJoystick variableJoystick;
    public Animator animator;
    Rigidbody2D rigidbody;
    public GameObject Wagon;
    public bool isFollowAnchor = false;
    public GameObject anchor;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
        ScaleFactar =Mathf.Abs(transform.localScale.x);

        if(GameManager.Instance.roomPosition == GameManager.RoomPosition.vent)
        {
            SetCrawlIdle();
            
        }
        else
        {            
            SetIdle();
        }
        
    }
    public bool isPlayWagon = false;
    public void Swiming()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.Play("swiming_idle");
    }
   
    public void JumpAnimation()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.Play("jump");
    }
    public void SetPlayerWagon(bool flag)
    {
        isPlayWagon = flag;
        if (flag ==true)
        {
            Wagon.SetActive(true);
            if (animator == null)
                animator = GetComponent<Animator>();
            animator.Play("idle_farm");
        }
        else
        {
            Wagon.SetActive(false);
            if (animator == null)
                animator = GetComponent<Animator>();
            animator.Play("idle");
        }
        
    }
    
    public void SetFlashLight(bool flag)
    {
        if(flag)
        {
            if (animator == null)
                animator = GetComponent<Animator>();
            animator.Play("flashlight_idle");
            FlashLight.SetActive(true);
        }
        else
        {
            if (animator == null)
                animator = GetComponent<Animator>();
            if (isPlayWagon == false)
                animator.Play("idle");
            else
                animator.Play("idle_farm");
            FlashLight.SetActive(false);
            FlashLight.transform.Find("Light").gameObject.GetComponent<FlashLightFindObject>().CheckDisable();
        }
    }
    public void SetWorkingMotion(bool flag)
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetBool("isworking", flag);
    }
    public void SetRun(bool flag)
    {
        if(animator==null)
            animator = GetComponent<Animator>();
        animator.SetBool("isRun", flag);
    }
    public void SetIdle()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.Play("idle");
    }
    public void setFireShot()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.Play("slingShot");
    }
    public void setFire()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.Play("throwInit");
    }
    public void SetCrawlIdle()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.Play("crawl_idle");
    }
    public void SetMoveCrawl()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetBool("bCrawl", true);
        bCrawl = true;
    }
    bool bCrawl = false;
    public void EndCrawl()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetBool("bCrawl", false);
        bCrawl = false;
    }
    
    public void MoveCrawl()
    {
         
    }
    [SerializeField]
    bool isGround = false;
    public bool bJump = false;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag=="ground")
        {
            isGround = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag =="ground")
        {
            isGround =true;
        }
        else
        {
            isGround = false;
        }
    }
    public void Jump()
    {
        if(isGround ==true && bJump ==true)
        {
            rigidbody.AddForce(new Vector2(0, 4f), ForceMode2D.Impulse);
        }
        
    }
    float horizontal_index;
    public float Margin = 1.5f;
    public void FixedUpdate()
    {
        if (isFollowAnchor)
        {
            if (Mathf.Abs(transform.position.x - anchor.transform.position.x) <= Margin)
            {
                animator.SetFloat("speed", 0);
                Vector3 vector = new Vector3(transform.position.x, transform.position.y, 0);
                transform.position = vector;

                if (Mathf.Abs(transform.position.x - anchor.transform.position.x) > 5 || Mathf.Abs(transform.position.y - anchor.transform.position.y) > 5)
                {
                    transform.position = new Vector3(anchor.transform.position.x - 2, anchor.transform.position.y, 0);
                }
                return;
            }
            else
            {
                animator.SetFloat("speed", 1);
            }
            transform.position = Vector2.MoveTowards(transform.position, anchor.transform.position, 1 * Time.deltaTime);

            horizontal_index = transform.position.x - anchor.transform.position.x;


            if (Mathf.Abs(transform.position.x - anchor.transform.position.x) > 5 || Mathf.Abs(transform.position.y - anchor.transform.position.y) > 5)
            {
                transform.position = new Vector3(anchor.transform.position.x - 2, anchor.transform.position.y, 0);
            }
            CheckFlip();
            //CheckDestination();
        }
        else
        {
            if (bCrawl == true)
            {
                Vector3 directionCrawl = new Vector3(0, 0, 0);
                directionCrawl = new Vector3(0.01f, 0);
                Vector3 dstPos = transform.position + directionCrawl;
                Vector3.Lerp(transform.position, dstPos, 2.5f);
                transform.position = dstPos;
            }
            if (DialogueManager.isConversationActive == true || GameManager.Instance.gameStatus != GameManager.GameStatus.NOTING)
            {
                return;
            }
            Vector3 direction = new Vector3(0, 0, 0);
            if (isHorizontal)
            {
                direction = new Vector3((variableJoystick.Horizontal / 100) * speed, 0);
            }
            else
            {
                direction = new Vector3((variableJoystick.Horizontal / 100) * speed, (variableJoystick.Vertical / 100) * speed);
            }


            transform.position += direction;
            float moveSpeed = (Mathf.Abs(variableJoystick.Horizontal) + Mathf.Abs(variableJoystick.Vertical)) * speed;

            CheckFlip();
            animator.SetFloat("speed", moveSpeed);
        }

        
      
    }
    void CheckFlip()
    {
        if(isFollowAnchor)
        {
            if (horizontal_index != 0)
            {
                if (horizontal_index > 0)
                {
                    transform.localScale = new Vector3(1 * ScaleFactar, 1 * ScaleFactar, 1 * ScaleFactar);                    
                }
                else
                {
                    transform.localScale = new Vector3(-1 * ScaleFactar, 1 * ScaleFactar, 1 * ScaleFactar);
                }
            }
        }
        else
        {
            if (variableJoystick.Horizontal != 0)
            {
                if (variableJoystick.Horizontal > 0)
                {
                    transform.localScale = new Vector3(-1 * ScaleFactar, 1 * ScaleFactar, 1 * ScaleFactar);
                }
                else
                {
                    transform.localScale = new Vector3(1 * ScaleFactar, 1 * ScaleFactar, 1 * ScaleFactar);
                }
            }
        }
      
    }
}
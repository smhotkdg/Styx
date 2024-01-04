using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGame_Guard : MonoBehaviour
{
    public GuardGame_Controller _Controller;
    
    Animator animator;
    public bool bMove = true;
    public float speed = 5;
    public int SelectIndex = -1;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("run");
    }
    GameObject UiTarget;
    public void SetUI()
    {
        if (GameManager.Instance.data.isChoiceMember == 1)
        {
            UiTarget = UIManager.Instance.GetGunIconUI(this.gameObject, SelectIndex);
        }
        else
        {
            UiTarget = UIManager.Instance.GetGunIconUI_2(this.gameObject, SelectIndex);
        }
            
        UiTarget.SetActive(true);
    } 
    public void setIdle()
    {
        animator.Play("idle");
    }
    public void DisableUI()
    {
        if (UiTarget != null)
        {
            Destroy(UiTarget);
        }
    }
    private void FixedUpdate()
    {
        if(bMove)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Animator>().SetFloat("speed", 0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Finish")
        {
            _Controller.AllStop();
            animator.Play("shooting");
            
            bMove = false;
            StartCoroutine(PlayerDead());
        }
    }
    IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(0.2f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.playerController.Dead_2();
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        yield return new WaitForSeconds(1.5f);
        if(GameManager.Instance.data.isChoiceMember ==1)
        {
            UIManager.Instance.GunGameUI.SetActive(false);
        }
        else
        {
            UIManager.Instance.GunGameUI_2.SetActive(false);
        }
        
        _Controller.EndGame();
        if(GameManager.Instance.data.isChoiceMember ==1)
        {
            TestCodeManager.Instance.StartPart6_Hallway4(true);
        }
        else
        {
            TestCodeManager.Instance.StartPart6_2_Hallway4(true);
        }
        
    }
    public void Dead()
    {
        bMove = false;
        animator.Play("dead");
        GameManager.Instance.cameraEffectController.SetEarthQuake(0.2f);
        transform.localScale = new Vector3(-4, 4, 4);
        if (UiTarget != null)
        {
            Destroy(UiTarget);
        }        
    }
}

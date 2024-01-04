using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CliffGame : MonoBehaviour
{

    public Image Fill;
    
    public float m_moveFactor = 0;

    private void OnEnable()
    {
        m_moveFactor = 0;
        Fill.fillAmount = 0;
        bDie = false;
        StartCoroutine(ChangeFillRoutine());
        GameManager.Instance.Player.GetComponent<PlayerController>().onMoveEventHandler += CliffGame_onMoveEventHandler;
    }
    private void OnDisable()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().onMoveEventHandler -= CliffGame_onMoveEventHandler;
    }
    private void Start()
    {       
        
    }

    private void CliffGame_onMoveEventHandler(float moveFactor)
    {
        if (float.IsNaN(moveFactor)==false&& moveFactor != 0)
        {
            m_moveFactor += Mathf.Pow(40, moveFactor);
            CheckFill();
        }
        //Debug.Log(moveFactor);
    }

    IEnumerator ChangeFillRoutine()
    {
        yield return new WaitForSeconds(0.01f);
        if (m_moveFactor > 0)
        {
            m_moveFactor -=3f;
            if (m_moveFactor < 0)
            {
                m_moveFactor = 0;
            }
        }     
        CheckFill();
        StartCoroutine(ChangeFillRoutine());
    }
    bool bDie = false;
    void CheckFill()
    {
        float percent = m_moveFactor / 3000;
        Fill.fillAmount = percent;      
        if(percent >0.9f && bDie ==false)
        {
            bDie = true;
            SetDie();
        }     
    }
    void SetDie()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().animator.Play("fall");

        GameManager.Instance.SetCliffDie();
        this.gameObject.SetActive(false);
        
    }
}

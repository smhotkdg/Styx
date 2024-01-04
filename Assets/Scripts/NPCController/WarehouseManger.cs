using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
public class WarehouseManger : MonoBehaviour
{
    public Transform InitPos;
    public RaySensor2D RaySensorFindPlayer;
    public RaySensor2D RaySensorFindDoor;
    NPCController pCController;
    Animator animator;
    private void Start()
    {
        pCController = GetComponent<NPCController>();
        animator = GetComponent<Animator>();
    }
    bool bMoveStart = false;
    public void MoveStart()
    {
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
        StartCoroutine(WalkRoutine());
    }
    private void OnDisable()
    {
        bMoveStart = false;
        bMoveBack = false;
        bMoveOrigin = false;
    }
    IEnumerator WalkRoutine()
    {
        yield return new WaitForSeconds(1f);
        animator.Play("walking");
        bMoveStart = true;   
    }
    IEnumerator WalkRoutine_End()
    {
        yield return new WaitForSeconds(1f);
        animator.Play("walking");
        bMoveStart = true;
        yield return new WaitForSeconds(4f);
        animator.Play("idle");
        transform.position = InitPos.position;
        bMoveStart = false;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.localScale = new Vector3(-4, 4, 4);
    }
    private void Update()
    {
        if (bMoveStart == false)
            return;
        if(bMoveBack ==false)
        {
            if (RaySensorFindPlayer.DetectedObjects.Count > 0)
            {
                if(!bMoveOrigin)
                {
                    pCController.ForceConversation();
                    animator.Play("idle");
                    bMoveStart = false;
                }
             
            }
        }
        else
        {
            if (RaySensorFindDoor.DetectedObjects.Count > 0)
            {
                if (!bMoveOrigin)
                {
                    animator.Play("idle");
                    bMoveStart = false;
                    GameManager.Instance.SetPlayerCamera();
                    TestCodeManager.Instance.warehouseInitConversationEnd(false);
                    transform.localScale = new Vector3(4, 4, 4);
                }
            }

        }
        if(bMoveBack == false)
        {
            transform.position += new Vector3(-Time.deltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime, 0);
        }
        
    }
    bool bMoveBack = false;
    public void MoveBack()
    {
        bMoveBack = true;
    }
    public void MoveBackStart()
    {
        if(bMoveBack ==true)
        {
            transform.localScale = new Vector3(-4, 4, 4);
            GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
            //GameManager.Instance.SetPlayerCamera();
            StartCoroutine(WalkRoutine());
        }
            
    }
    bool bMoveOrigin = false;
    public void setMoveOrigin()
    {
        bMoveOrigin = true;
    }
    public void EndMoveStart()
    {
        if(bMoveOrigin ==true)
        {
            bMoveStart = true;
            transform.localScale = new Vector3(4, 4, 4);
            StartCoroutine(WalkRoutine_End());
            GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }
    public void EndConverstaion_Sugar()
    {
        if(bSugarGame ==true)
        {
            bSugarGame = false;
            UIManager.Instance.SugarFindGame.SetActive(true);
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            pCController.uiElement.SetActive(false);
            GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(true);
        }
    }
    bool bSugarGame = false;
    public void SugarGameStart()
    {
        bSugarGame = true;
    }

}

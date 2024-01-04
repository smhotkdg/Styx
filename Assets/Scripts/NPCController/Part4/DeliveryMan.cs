using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeliveryMan : MonoBehaviour
{
    
    public bool isStartMove = false;
    public GameObject MoveObejct;
    public float speed = 1;
    public BoxCollider2D conversation1box;
    public BoxCollider2D conversation2box;
    public Animator animator;

    public List<BoxCollider2D> boxList;    
    void Start()
    {
        
        if (GameManager.Instance.styxData.deliveryManQuest == "active")
        {
            conversation1box.enabled = true;
            conversation2box.enabled = false;
        }
        else
        {
            conversation1box.enabled = false;
            conversation2box.enabled = false;
        }
        if (GameManager.Instance.styxData.deliveryManQuest == "success" || GameManager.Instance.styxData.deliveryManQuest == "grantable")
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(true);
        }
    }
    public void SetMove()
    {
        isStartMove = true;
        conversation1box.enabled = false;
        conversation2box.enabled = false;

        for (int i =0; i< boxList.Count; i++)
        {
            boxList[i].enabled = false;
        }
        
    }
    float horizontal_index;
    private void FixedUpdate()
    {
        if(isStartMove)
        {
            if(Mathf.Abs(MoveObejct.transform.position.x - GameManager.Instance.Player.transform.position.x) <=1)
            {
                animator.Play("idle");
                return;
            }
            else
            {
                animator.Play("walking");
            }
            MoveObejct.transform.position = Vector2.MoveTowards(MoveObejct.transform.position, GameManager.Instance.Player.transform.position, speed * Time.deltaTime);

            horizontal_index = MoveObejct.transform.position.x - GameManager.Instance.Player.transform.position.x;

            CheckFlip();
            CheckDestination();
        }
    
    }
    void CheckDestination()
    {
        if(transform.parent.position.x <-7.25f)
        {
            conversation1box.enabled = false;
            conversation2box.enabled = true;
        }
    }
    public void EndEvent()
    {
        isStartMove = false;
        conversation1box.enabled = false;
        conversation2box.enabled = false;

        for (int i = 0; i < boxList.Count; i++)
        {
            boxList[i].enabled = true;
        }
        transform.parent.gameObject.SetActive(false);
    }
 
    void CheckFlip()
    {
        if (horizontal_index != 0)
        {
            if (horizontal_index> 0)
            {
                transform.parent.localScale = new Vector3(1 * 4, 1 * 4, 1 * 4);
            }
            else
            {
                transform.parent.localScale = new Vector3(-1 * 4, 1 * 4, 1 * 4);
            }
        }
    }
}

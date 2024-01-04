using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTownPoilceController : MonoBehaviour
{
    public Transform initPos;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPos.position;
    }
    private void OnEnable()
    {
        transform.position = initPos.position;
        animator.Play("walking");
        attackCount = 0;
        bMove = true;
    }
    bool bMove = true;
    GameObject drinkNpc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "DrinkManNPC")
        {
            bMove = false;
            drinkNpc = collision.gameObject;
            animator.Play("attack");
        }
    }
    private void Update()
    {
        //주정뱅이로 이동
        if(bMove ==true)
        {
            transform.position += new Vector3(-Time.deltaTime, 0);
        }
        
    }
    int attackCount = 0;
    public void Attack()
    {
        int rand = Random.Range(0, 3);
        if(rand ==0)
        {
            UIManager.Instance.setDialogue(gameObject, "또 난리구만!", 100, 0.5f);
            UIManager.Instance.setDialogue(drinkNpc, "으악!", 100, 0.5f);
        }
        else if(rand ==1)
        {
            UIManager.Instance.setDialogue(gameObject, "멍청한놈!", 100, 0.5f);
            UIManager.Instance.setDialogue(drinkNpc, "왜이래요!", 100, 0.5f);
        }
        else
        {
            UIManager.Instance.setDialogue(gameObject, "어서가!", 100, 0.5f);
            UIManager.Instance.setDialogue(drinkNpc, "알겠다구요!", 100, 0.5f);
        }
        
        attackCount++;
        if(attackCount >=5)
        {
            animator.Play("walking");
            drinkNpc.GetComponent<Animator>().Play("walking");
            drinkNpc.GetComponent<DrinkManController>().bMove = true;
            drinkNpc.GetComponent<DrinkManController>().DisableRoutineStart();
            bMove = true;
            
        }
    }

}

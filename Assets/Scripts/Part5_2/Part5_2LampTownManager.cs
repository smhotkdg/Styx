using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part5_2LampTownManager : MonoBehaviour
{
    public bool isEvent = true;
    public GameObject PoolGuard;
    public Part5_2Hardware Hardware;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetChoke()
    {        
        //PoolGuard.transform.localScale = new Vector3(-4, 4, 4);
        if(isEvent)
        {
            PoolGuard.SetActive(true);
            PoolGuard.GetComponent<Animator>().Play("dead_2");
            Hardware.setEndManagerEvnet();
        }
        else
        {
            PoolGuard.SetActive(true);
            PoolGuard.GetComponent<Animator>().Play("dead_2");
        }
        
    }
    public void StartChoke()
    {
        transform.localScale = new Vector3(4, 4, 4);
        animator.Play("choke");
        PoolGuard.SetActive(false);
    }      
}

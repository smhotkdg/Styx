using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public bool isExit = false;
    public delegate void OnEnter(int name, GameObject selectObject);
    public event OnEnter OnEnterEvent;

    public delegate void OnExit(int name,GameObject selectObject);
    public event OnExit OnExitEnvent;

    public delegate void OnFail();
    public event OnFail OnFailEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isExit)
        {
            OnFailEvent?.Invoke();
        }
        else
        {
            OnEnterEvent?.Invoke(int.Parse(collision.name), collision.gameObject);
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExitEnvent?.Invoke(int.Parse(collision.name),collision.gameObject);
    }
}

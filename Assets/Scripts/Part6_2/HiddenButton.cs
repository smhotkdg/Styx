using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenButton : MonoBehaviour
{
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.data.Letter >0)
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

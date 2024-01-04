using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCreditPanel : MonoBehaviour
{
    public GameObject Content;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        initPos = Content.transform.localPosition;
    }
    Vector2 initPos;
    private void OnEnable()
    {
        Content.transform.localPosition = initPos;
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector2 moveVec = Content.transform.localPosition;
        if (moveVec.y >=5000)
        {
            
        }
        else
        {
            moveVec.y += Time.deltaTime * speed;
            Content.transform.localPosition = moveVec;
        }       
        
    }
}

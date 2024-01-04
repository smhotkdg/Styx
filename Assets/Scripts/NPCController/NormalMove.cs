using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMove : MonoBehaviour
{
    public Transform LeftMax;
    public Transform RightMax;
    public bool MoveRight = true;
    // Start is called before the first frame update
    void Start()
    {
        if(MoveRight)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        else
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(MoveRight)
        {          
            transform.position += new Vector3(Time.deltaTime, 0);
            if (RightMax.position.x < transform.position.x)
            {
                MoveRight = false;
                transform.localScale = new Vector3(4, 4, 4);
            }
        }
        else
        {           
            transform.position += new Vector3(-Time.deltaTime, 0);
            if (LeftMax.position.x > transform.position.x)
            {
                MoveRight = true;
                transform.localScale = new Vector3(-4, 4, 4);
            }
        }
    }
}

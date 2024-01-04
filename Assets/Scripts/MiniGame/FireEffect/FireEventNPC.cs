using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireEventNPC : MonoBehaviour
{
    public bool isMove = true;
    // Start is called before the first frame update
    public GameObject UiElment;
    Vector3 initPos =  new Vector3();
    float speed = 1;
    void Start()
    {
        float randspeed = Random.Range(0, 1.5f);
        speed = speed + randspeed;
        initPos = transform.position;        
    }
    private void OnDisable()
    {
        transform.position = initPos;
        speed = 1;
    }

    private void Update()
    {
        if(isMove)
        {
            transform.position += new Vector3(-(Time.deltaTime* speed), 0);
        }        
    }  
}

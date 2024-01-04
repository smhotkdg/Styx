using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineRoomBox : MonoBehaviour
{
    float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(Speed * -Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="BoxExit")
        {
            this.gameObject.SetActive(false);
        }
    }
}

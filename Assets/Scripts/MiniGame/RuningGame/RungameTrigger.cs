using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RungameTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            Debug.Log("죽음");
        }
    }
}

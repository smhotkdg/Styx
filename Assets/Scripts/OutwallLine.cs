using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutwallLine : MonoBehaviour
{
    public bool bIn = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Edge")
        {
            bIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Edge")
        {
            bIn = false;
        }
    }
}

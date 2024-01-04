using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetector_part5 : MonoBehaviour
{
    public KitchenDetector kitchenDetector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            kitchenDetector.AllPause();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            kitchenDetector.AllResume();
        }
    }
}

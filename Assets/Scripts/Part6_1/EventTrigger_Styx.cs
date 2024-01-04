using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger_Styx : MonoBehaviour
{
    string Tag = "player";

    public enum eventType
    {
        Part6Event,
        Part6_2Event,
    }
    public eventType m_eventType = eventType.Part6Event;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag ==Tag)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            switch(m_eventType)
            {
                case eventType.Part6Event:
                    UIManager.Instance.StartPart6Event();
                    break;
                case eventType.Part6_2Event:
                    UIManager.Instance.StartPart6_2Event();
                    break;
            }
        }
    }
}

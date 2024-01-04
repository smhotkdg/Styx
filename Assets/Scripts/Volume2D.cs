using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume2D : MonoBehaviour
{    
    public AudioSource audioSource;
    public float minDist = 1;
    public float maxDist = 3;

    void Update()
    {
        if (GameManager.Instance == null)
            return;
        if(GameManager.Instance.roomPosition == GameManager.RoomPosition.FarmRoom
            || GameManager.Instance.roomPosition == GameManager.RoomPosition.orchard
            || GameManager.Instance.roomPosition == GameManager.RoomPosition.Farm)

        {
            float dist = Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position);

            if (dist < minDist)
            {
                audioSource.volume = 1;
            }
            else if (dist > maxDist)
            {
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = 1 - ((dist - minDist) / (maxDist - minDist));
            }
        }
        else
        {
            audioSource.volume = 0;
        }
      
    }
}
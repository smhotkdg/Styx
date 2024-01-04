using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTarget : MonoBehaviour
{
    public event OnTargetHitDelegate OnTargetHitEvent;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Projectile")
        {  
            
            OnTargetHitEvent?.Invoke();
            
        }
    }   
}

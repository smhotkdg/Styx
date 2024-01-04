using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrag : MonoBehaviour
{
    public void SetRandom(string panelId)
    {
        string ObjectID = gameObject.name;
        AIManager.AIDragDrop(ObjectID, panelId);                
    }
}

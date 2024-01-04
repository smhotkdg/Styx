using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerManagerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool bDisableObject = false;
    public void EndConversation()
    {
        if(bDisableObject ==true)
        {
            TestCodeManager.Instance.fruitQuestStart(true);
            bDisableObject = false;
        }
    }
    public void SetDisableObject()
    {
        bDisableObject = true;
    }
}

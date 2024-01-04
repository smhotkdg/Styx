using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class SkyTownGateKeeper : MonoBehaviour
{
    bool isUp = false;
    public void SetIsUP()
    {
        isUp = true;
    }
    private void Update()
    {
        if(DialogueManager.isConversationActive==false)
        {
            if(isUp)
            {
                isUp = false;
                TestCodeManager.Instance.StartPart4();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBuildingOwner : MonoBehaviour
{
    BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.styxData.strManagerQuset == "unassigned")
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
        }
    }

    public void StartRaidoEvent()
    {
        if(bRadio ==true)
        {
            UIManager.Instance.RadioGame.SetActive(true);
            bRadio = false;
        }
    }
    bool bRadio = false;
    public void EnableRadioEvent()
    {
        bRadio = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickNPCController : MonoBehaviour
{
    public bool isOn = false;
    public SpriteRenderer sprite;
    public Animator rigner;
    public bool isBronek = false;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(isOn)
        {
            if(GameManager.Instance.styxData.FactorydoctorQuest =="success")
            {
                sprite.enabled = true;
                if(isBronek==false)
                    rigner.Play("on");
                else
                {
                    rigner.Play("broken");
                }
            }
            else
            {
                sprite.enabled = false;
            }
        }
        else
        {
            if (GameManager.Instance.styxData.FactorydoctorQuest == "success")
            {
                sprite.enabled = false;
            }
            else
            {
                if (isBronek == false)
                    rigner.Play("on");
                else
                {
                    rigner.Play("broken");
                }
                sprite.enabled = true;
            }
        }
    }
}

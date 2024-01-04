using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class VentCrawlGameController : MonoBehaviour
{
    public Text NodeText;
    bool bLeft = true;

    private void OnEnable()
    {
        MakeRand();
    }
    void MakeRand()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            NodeText.text = "L";
            bLeft = true;
        }
        else
        {
            NodeText.text = "R";
            bLeft = false;
        }
    }

    public void LeftButton()
    {
        if(bLeft ==true)
        {
            //성공
            movePlyaer();
            MakeRand();
        }
    }
    public void RightButton()
    {
        if(bLeft ==false)
        {
            //성공
            movePlyaer();
            MakeRand();
        }
    }
    void movePlyaer()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().SetMoveCrawl();
    }
}

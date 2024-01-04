using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusUI : MonoBehaviour
{
    public bool isWork = true;
    private void OnEnable()
    {
        if(isWork)
        {
            GameManager.Instance.SetPlayerWork(true);
        }
        
        //GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
    }
    private void OnDisable()
    {
        if(isWork)
        {
            if(GameManager.Instance!=null)
                GameManager.Instance.SetPlayerWork(false);
        }        
        //GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmFriendEvent : MonoBehaviour
{
    bool isMove = false;
    float Speed = 1;
    
    public void SetDontEescape()
    {
        //1탈출
        //2 탈출안함
        GameManager.Instance.data.isEscapeShip = 2;
        GameManager.Instance.SaveNormalData();
    }
    public void SetEscape()
    {
        GameManager.Instance.data.isEscapeShip = 1;
        GameManager.Instance.SaveNormalData();
    }
    public void EndConversation()
    {       
        if(GameManager.Instance.data.isEscapeShip==1)
        {
            //탈출한다.
            TestCodeManager.Instance.StartEscapeQuest(false);
        }
        else
        {
            //탈출하지 않는다.
        }
        transform.localScale = new Vector3(4, 4, 4);
        GetComponent<Animator>().Play("move");
        isMove = true;
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }

    private void Update()
    {        
        if (isMove)
        {            
            transform.position += new Vector3(Speed * -Time.deltaTime, 0);
            if(transform.position.x < -5.5f)
            {
                isMove = false;
                this.gameObject.SetActive(false);
            }
        }      
    }
}

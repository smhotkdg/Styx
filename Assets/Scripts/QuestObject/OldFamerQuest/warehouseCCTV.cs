using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warehouseCCTV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.styxData.AccesscardQuest =="success")
        {
            transform.localScale=new Vector3(-4,4,4);
        }
        else
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
    }
}

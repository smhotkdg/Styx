using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameManger : MonoBehaviour
{
    public List<ButtonGameController> buttonGameControllers;
    // Start is called before the first frame update
    public delegate void OnFind();
    public event OnFind OnFindEventHandler;
    void Start()
    {
        for(int i =0; i< buttonGameControllers.Count; i++)
        {            
            int randDisable = Random.Range(1, 6);
            int rand = 0;
            buttonGameControllers[i].OnFindEventHandler += ButtonGameManger_OnFindEventHandler;
            for (int k = 0; k < randDisable; k++)
            {
                if (buttonGameControllers[i].DisablebuttonGameControllers.Count == 0)
                {
                    rand = Random.Range(0, buttonGameControllers.Count);
                    buttonGameControllers[i].DisablebuttonGameControllers.Add(buttonGameControllers[i]);
                    buttonGameControllers[i].DisablebuttonGameControllers.Add(buttonGameControllers[rand]);
                    buttonGameControllers[i].bDisable = true;
                    buttonGameControllers[i].OnSomeDIsableEventHandler += ButtonGameManger_OnSomeDIsableEventHandler;
                }
                
            }

            
        }
    }

    private void ButtonGameManger_OnSomeDIsableEventHandler(GameObject obj)
    {        
        for (int i = 0; i < buttonGameControllers.Count; i++)
        {
            if (buttonGameControllers[i].bFind == true && buttonGameControllers[i].gameObject != obj)
            {
                int rand = Random.Range(0, 3);
                if(rand < 2)
                {
                    buttonGameControllers[i].EnableObject();
                }
            }                
        }
        
    }

    private void OnEnable()
    {
        bComplete = false;
        bEnd = false;
        for (int i = 0; i < buttonGameControllers.Count; i++)
        {
            buttonGameControllers[i].EnableAll();
        }
    }
    public void ResetButton()
    {
        bComplete = false;
        bEnd = false;
        for (int i = 0; i < buttonGameControllers.Count; i++)
        {
            buttonGameControllers[i].EnableAll();
        }
    }

    private void ButtonGameManger_OnFindEventHandler()
    {
        for(int i=0; i< buttonGameControllers.Count; i++)
        {
            if (buttonGameControllers[i].bFind == false)
                return;
        }
        bComplete = true;
        completeSometing();
        
    }
    bool bComplete = false;
    bool bEnd = false;
    void completeSometing()
    {
        if(bComplete ==true)
        {
            if(bEnd == false)
            {
                Debug.Log("해결!");
                OnFindEventHandler?.Invoke();
                bEnd = true;
            }            
            bComplete = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
}

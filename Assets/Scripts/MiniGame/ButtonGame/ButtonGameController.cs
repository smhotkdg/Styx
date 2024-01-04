using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonGameController : MonoBehaviour
{
    public List<ButtonGameController> DisablebuttonGameControllers;
    public delegate void OnFind();
    public event OnFind OnFindEventHandler;


    public delegate void OnSomeDIsable(GameObject obj);
    public event OnSomeDIsable OnSomeDIsableEventHandler;

    Button button;
    Image image;
    bool bSelect = false;
    public bool bDisable = false;
    private void Start()
    {
        button = GetComponent<Button>();
        image = button.image;
        button.onClick.AddListener(SelectButton);
    }
    public void SelectButton()
    {
        if(bDisable ==false)
        {
            if (bSelect == false)
            {
                for (int i = 0; i < DisablebuttonGameControllers.Count; i++)
                {
                    DisablebuttonGameControllers[i].DisableObject();
                }
                bSelect = true;
            }
            else
            {
                for (int i = 0; i < DisablebuttonGameControllers.Count; i++)
                {
                    DisablebuttonGameControllers[i].EnableObject();
                }

                bSelect = false;
            }
        }
        else
        {
            if (bSelect == false)
            {
                for (int i = 0; i < DisablebuttonGameControllers.Count; i++)
                {                    
                    OnSomeDIsableEventHandler?.Invoke(this.gameObject);
                    DisableObject();
                }
                bSelect = true;
            }
            else
            {
                for (int i = 0; i < DisablebuttonGameControllers.Count; i++)
                {
                    EnableObject();
                }

                bSelect = false;
            }
        }
       
      
    }
    public void EnableAll()
    {
        for (int i = 0; i < DisablebuttonGameControllers.Count; i++)
        {
            DisablebuttonGameControllers[i].EnableObject();
        }

        bSelect = false;
        bFind = false;
        if (image != null)
            image.color = new Color(1, 1, 1, 1);
    }
    public bool bFind = false;
    public void DisableObject()
    {
        image.color = new Color(1, 0, 0, 1);
        //button.interactable = false;
        bFind = true;
        OnFindEventHandler?.Invoke();
        bSelect = true;
    }
    public void EnableObject()
    {
        bFind = false;
        bSelect = false;
        if (image !=null)
            image.color = new Color(1, 1, 1, 1);
        //button.interactable = true;
    }
}

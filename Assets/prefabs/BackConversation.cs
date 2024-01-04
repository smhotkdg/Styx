using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackConversation : MonoBehaviour
{
    Button myButton;
    Backtracker backtracker;
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(Click);
        backtracker = GameObject.Find("DialogueManager").gameObject.GetComponent<Backtracker>();
    }
    void Click()
    {
        backtracker.Backtrack(false);
    }

   
}

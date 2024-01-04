using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeGameController : MonoBehaviour
{
    public SelectWordNumberGame SelectWordNumberGame;
    public TextAnimatorPlayer textAnimatorPlayer;
    public TextAnimatorPlayer textAnimatorPlayer_Input;
    public TextAnimatorPlayer textAnimatorPlayer_Result;

    public TextMeshProUGUI Input1;
    public TextMeshProUGUI Input2;
    public TextMeshProUGUI Input3;

    [TextArea(3, 50), SerializeField]
    string textToShow = " ";
    [TextArea(3, 50), SerializeField]
    string textToShowInput = " ";

    [TextArea(3, 50), SerializeField]
    string result = " ";

    public GameObject ButtonObj1;
    public GameObject ButtonObj2;
    public GameObject ExitObject;
    string OriInput = "1";
    string OriTopText = "1";
    bool bComplete = false;

    private void OnEnable()
    {
        ButtonObj1.SetActive(false);
        ButtonObj2.SetActive(false);
        ExitObject.SetActive(false);
        Input1.text = "";
        Input2.text = "";
        Input3.text = "";
        ShowText();
        if(OriInput!="1")
        {
            textToShowInput = OriInput;
        }
        if(OriTopText !="1")
        {
            textToShow = OriTopText;
        }
        SelectWordNumberGame.OnFindEventHandler += SelectWordNumberGame_OnFindEventHandler;
    }
    private void OnDisable()
    {
        SelectWordNumberGame.OnFindEventHandler -= SelectWordNumberGame_OnFindEventHandler;
    }
    private void Start()
    {
        
        OriInput = textToShowInput;
        OriTopText = textToShow;        
    }

    private void SelectWordNumberGame_OnFindEventHandler(string number)
    {        
        textToShowInput = OriInput;
        textToShowInput += " " + number;
        if (number =="19")
        {
            ButtonObj1.SetActive(false);
            ButtonObj2.SetActive(false);
            ExitObject.SetActive(false);
            textToShowInput += "\nLaunching Engine on localhost....\nCompleted Engine Start...";
            bComplete = true;
        }
        else
        {
            if(number.Length >4)
            {
                textToShowInput += "\nError\nInvalid Number";
            }
            else
            {
                textToShowInput += "\nError\nInvalid Number : 'result :" + int.Parse(number) * int.Parse(number) + " '\nEngineStart need number 361";
            }
            
        }
        

        ShowInput();
    }

    public void ShowText()
    {
        textAnimatorPlayer.ShowText(textToShow);
    }
    public void ShowInput()
    {        
        textAnimatorPlayer_Input.ShowText(textToShowInput);       
    }
    public void Result()
    {       
        GameManager.Instance.SetMatrix(false);
        GameManager.Instance.cameraEffectController.SetCompleteGameUI(languageController.ObjectName.engineerComputer);
    }

    public void SetComplete()
    {
        if(bComplete)
        {
            textToShowInput = " ";
            textToShow = " ";
            textAnimatorPlayer_Result.ShowText(result);
            ShowText();
            ShowInput();
            bComplete = false;
        }
        else
        {
            if(Input2.text == "input =")
            {
                ButtonObj1.SetActive(true);
                ButtonObj2.SetActive(true);
                ExitObject.SetActive(true);
            }
        }
    }
}

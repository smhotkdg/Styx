using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UItargetTutorial : MonoBehaviour
{
    public GameObject UITarget;
    public bool isQuest = false;
    public Image Icon;    
    public Text Info;


    private void OnEnable()
    {
        if(isQuest)
        {
            Info.text = languageController.Instance.GetItme(languageController.ObjectName.part0);
            Icon.sprite = UIManager.Instance.setItemIcon(languageController.ObjectName.part0);
        }        
    }
    private void FixedUpdate()
    {
        if(UITarget !=null)
        {
            transform.position = UITarget.transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestCompleteController : MonoBehaviour
{
    public Image Icon;
    public Text MissionText;

    public delegate void OnDisableEvent();
    public event OnDisableEvent OnDisableEventEventHandler;
    public void SetData(languageController.ObjectName objectName)
    {
        MissionText.text = languageController.Instance.setAlert(objectName);
        Icon.sprite = UIManager.Instance.setItemIcon(objectName);
    }
    private void OnDisable()
    {
        OnDisableEventEventHandler?.Invoke();
    }
}

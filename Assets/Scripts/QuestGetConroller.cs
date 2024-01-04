using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestGetConroller : MonoBehaviour
{
    public Text ItemName;
    public Image ItemIcon;

    public delegate void OnCloseQuestGetController();
    public event OnCloseQuestGetController OnCloseQuestGetControllerEventHandler;

    private void OnDisable()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        OnCloseQuestGetControllerEventHandler?.Invoke();
    }   
    private void OnEnable()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        transform.SetAsLastSibling();
    }
    public void SetData(string Name,Sprite Icon)
    {
        ItemName.text = Name;
        ItemIcon.sprite = Icon;
    }
}

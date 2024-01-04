using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class QuestUpdate : MonoBehaviour
{
    public Image Icon;
    public Text Title;
    public void SetQuest(QuestCheckerController.CheckerType checkerType)
    {
        switch(checkerType)
        {
            case QuestCheckerController.CheckerType.AnchorConversation:
                Title.text = languageController.Instance.GetItme(languageController.ObjectName.AnchorConversation);
                break;
            case QuestCheckerController.CheckerType.EmergencyQuest:
                Title.text = languageController.Instance.GetItme(languageController.ObjectName.EmergencyQuest);
                break;
            case QuestCheckerController.CheckerType.EscapeSub1:
                Title.text = languageController.Instance.GetItme(languageController.ObjectName.EscapeSub1);
                break;
            case QuestCheckerController.CheckerType.EscapeSub2:
                Title.text = languageController.Instance.GetItme(languageController.ObjectName.EscapeSub2);
                break;
            case QuestCheckerController.CheckerType.EscapeSub3:
                Title.text = languageController.Instance.GetItme(languageController.ObjectName.EscapeSub3);
                break;
        }        
        Icon.sprite = UIManager.Instance.GetQuestSprite(checkerType);
        StartCoroutine(endRoutine());
    }
    IEnumerator endRoutine()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().Play("QuestUpdateBack");
        //GetComponent<DOTweenAnimation>().DOPlayBackwards();        
        //this.gameObject.SetActive(false);
    }
}

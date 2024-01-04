using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
public class NPCController : MonoBehaviour
{
    public bool isOnce = false;
    public GameObject uiElement;
    public npcType NpcType = npcType.Small;

    private DialogueSystemTrigger systemTrigger;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public enum npcType
    {
        Small,
        medium,
        Big        
    }
    public bool bStay = false;

    private void Start()
    {
        systemTrigger = GetComponent<DialogueSystemTrigger>();
        if (uiElement != null)
            uiElement.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.tag == "player")
        {
            if (GameManager.Instance.Player.GetComponent<PlayerController>().isPlayWagon == true)
            {
                return;
            }
            if (uiElement != null)
            {
                uiElement.SetActive(true);
                uiElement.GetComponent<UiTargetManager>().WorldObject = this.gameObject;
                uiElement.GetComponent<UiTargetManager>().y_Margin = 125;
                if (NpcType == npcType.Big)
                {
                    uiElement.GetComponent<UiTargetManager>().y_Margin = 125;
                }
                else if(NpcType == npcType.medium)
                {
                    uiElement.GetComponent<UiTargetManager>().y_Margin = 110;
                }
                else if (NpcType == npcType.Small)
                {
                    uiElement.GetComponent<UiTargetManager>().y_Margin = 90;
                }

                uiElement.GetComponent<Button>().onClick.AddListener(StartConverstation);
                uiElement.transform.Find("Text").gameObject.GetComponent<Text>().text = languageController.Instance.getTextConversation();
            }

            bStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (uiElement != null)
            {
                uiElement.GetComponent<Button>().onClick.RemoveAllListeners();
                uiElement.SetActive(false);
            }

            bStay = false;
        }
    }
 
    private void FixedUpdate()
    {
        if(GameManager.Instance.Player.GetComponent<PlayerController>().isPlayWagon ==true)
        {
            if (uiElement != null)
            {
                uiElement.SetActive(false);
            }

            return;
        }
        if (bStay == true)
        {
            if (uiElement != null)
            {
                if (DialogueManager.isConversationActive == false)
                {
                    if (GameManager.Instance.gameStatus == GameManager.GameStatus.NOTING)
                    {
                        if (isOnce)
                            return;
                        uiElement.SetActive(true);
                        uiElement.SetActive(UIManager.Instance.CheckBottomUI());
                    }
                        
                }
                if (GameManager.Instance.gameStatus != GameManager.GameStatus.NOTING)
                {
                    uiElement.SetActive(false);
                }                
            }
        }

    }

    public void StartConverstation()
    {
        if (GameManager.Instance.gameStatus == GameManager.GameStatus.NOTING)
        {

            uiElement.SetActive(false);
            DialogueManager.StartConversation(systemTrigger.conversation, transform);

            GameManager.Instance.DiscountActionCount();
            GameManager.Instance.gameStatus = GameManager.GameStatus.CONVERSATION;
        }
    }
    public void ForceConversation()
    {
        uiElement.SetActive(false);
        DialogueManager.StartConversation(systemTrigger.conversation, transform);
    }
    public void EndConversation()
    {     
        if(GameManager.Instance.gameStatus != GameManager.GameStatus.DO_FORCE)
        {
            GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        }            
    }    
}

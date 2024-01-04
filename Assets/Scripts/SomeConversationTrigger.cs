using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeConversationTrigger : MonoBehaviour
{
    public List<GameObject> ConversationList;
    public List<int> ConversationIndexList;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(EnableTextRoutine());
            
        }
    }
    IEnumerator EnableTextRoutine()
    {
        for (int i = 0; i < ConversationList.Count; i++)
        {            
            ConversationList[i].SetActive(true);
            UIManager.Instance.setDialogue(ConversationList[i], languageController.Instance.CliffConversation(ConversationIndexList[i]), 0, 3f);
            yield return new WaitForSeconds(1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Sirenix.OdinInspector;
public class MemoryCard : MonoBehaviour
{
    public GameObject cardObject;
    public MemoryCardController cardController;    
    bool isStart = false;
    [Button("테스트 메모리카드", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetTest()
    {
        cardController.SetCard(1);
        cardObject.SetActive(true);
    }
    
    public void SetMemonryCard(int index)
    {
        switch(index)
        {
            case 1:
                //기억카드 물속에 가라앉다.
                GameManager.Instance.data.memoryCard_1 = 1;
                GameManager.Instance.SaveData();
                cardController.SetCard(1);
                break;
            case 2:
                //기억카드 we'll meet again
                GameManager.Instance.data.memoryCard_2 = 1;
                GameManager.Instance.SaveData();
                cardController.SetCard(2);
                break;
            case 3:
                GameManager.Instance.data.memoryCard_3 = 1;
                GameManager.Instance.SaveData();
                //기억카드 하늘이 보이는 곳
                break;
            case 4:
                GameManager.Instance.data.memoryCard_4 = 1;
                GameManager.Instance.SaveData();
                cardController.SetCard(4);
                //땅에 대한 기억
                break;
        }
        isStart = true;
    }
    private void FixedUpdate()
    {
        if(isStart ==true)
        {
            if(DialogueManager.isConversationActive ==false)
            {
                Debug.Log("기억 카드 획득");
                cardObject.SetActive(true);
                isStart = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using PixelCrushers.DialogueSystem;

public class Factorysickperson : MonoBehaviour
{
    public List<MoveNPC> moveNPCs;
    public GameObject MoveNPC;
    private Animator animator;
    bool isEvnet = true;
    [Button("이벤트 시작", ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartSickEvent()
    {
        if (isEvnet == false)
            return;
        isEvnet = false;
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_SOMETHING;
        GameManager.Instance.SetCameraTarget(this.gameObject, 1f);
        for(int i =0; i< moveNPCs.Count; i++)
        {
            moveNPCs[i].Stop();
        }        
        StartCoroutine(SickRoutine());
        
    }
    
    //-0.25f
    bool bStartNPC = false;
    IEnumerator SickRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.Instance.setDialogue(this.gameObject, "으으윽...",130,1);
        yield return new WaitForSeconds(1.5f);
        animator.Play("sick");
        bStartNPC = true;
        MoveNPC.transform.localScale = new Vector3(-4, 4, 4);
        MoveNPC.GetComponent<Animator>().Play("forcewalking");
    }
    public void SickEventEnd()
    {
        for (int i = 0; i < moveNPCs.Count; i++)
        {
            moveNPCs[i].reStart();
        }
        animator.Play("idle");
        MoveNPC.GetComponent<Animator>().Play("idle");
        MoveNPC.transform.Find("NPCController").gameObject.SetActive(false);
        isEvnet = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //SickEventEnd();
        isEvnet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.styxData.FactorydoctorQuest =="active")
        {
            animator.Play("sick");
        }     
        if(bStartNPC)
        {
            MoveNPC.transform.position += new Vector3(Time.deltaTime*2f, 0);
            if (MoveNPC.transform.position.x > -0.5f)
            {
                bStartNPC = false;
                MoveNPC.GetComponent<Animator>().Play("idle");
                UIManager.Instance.setDialogue(MoveNPC, "아니 무슨일이야!",130,1);
                StartCoroutine(EventMiddleRoutine());
            }
        }        
    }
    IEnumerator EventMiddleRoutine()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SetPlayerCamera(1f);
        yield return new WaitForSeconds(1f);
        MoveNPC.transform.Find("NPCController").gameObject.SetActive(true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
    public void EndNPCConversation()
    {
        GameManager.Instance.styxData.FactorydoctorQuest = "active";
        DialogueLua.SetQuestField("FactorydoctorQuest", "State", GameManager.Instance.styxData.FactorydoctorQuest);
        UIManager.Instance.CheckQuestGuide();
    }
}

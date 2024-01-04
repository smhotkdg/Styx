using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class DrinkManController : MonoBehaviour
{
    public Transform initPos;
    public GameObject PopOwner;
    public GameObject Police;
    public bool bMove = false;
    private void OnEnable()
    {
        bMove = false;
        transform.position = initPos.position;
    }
    public void startConverstation()
    {
        StartCoroutine(ConversationRoutine());
    }
    public IEnumerator ConversationRoutine()
    {        
        float rand = Random.Range(3, 10);
        yield return new WaitForSeconds(rand);
        int textRand = Random.Range(0, 3);
        if(textRand ==0)
        {
            UIManager.Instance.setDialogue(gameObject, "으아아아아아아아!",100, 3);
        }
        else if(textRand ==1)
        {
            UIManager.Instance.setDialogue(gameObject, "술 더 가져와!",100, 3);
        }
        else if(textRand ==2)
        {
            UIManager.Instance.setDialogue(gameObject, "난 천재다!",100, 3);
        }
        else
        {
            UIManager.Instance.setDialogue(gameObject, "호로롱!", 100,3);
        }
        
        StartCoroutine(ConversationRoutine());
    }
    // Update is called once per frame
    void Update()
    {
        if (bMove == true)
        {
            transform.position += new Vector3(-Time.deltaTime, 0);
        }
    }
    public void DisableRoutineStart()
    {
        StartCoroutine(DisableRoutine());
    }
    IEnumerator DisableRoutine()
    {
        yield return new WaitForSeconds(8f);
        Police.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void StartDrinkmanEvent()
    {
        DialogueManager.StartConversation("drunkard_PopOwner");
        GameManager.Instance.SetCameraTarget(PopOwner, 0.5f);
    }
    public void SetCameraDrinkMan()
    {
        GameManager.Instance.SetCameraTarget(this.gameObject, 0.5f);
    }
    public void SetCameraPopOwner()
    {
        GameManager.Instance.SetCameraTarget(PopOwner, 0.5f);
    }
    public void SetCameraPolice()
    {
        GameManager.Instance.SetCameraTarget(Police, 0.5f);
    }
    public void SetCameraPlayer()
    {
        GameManager.Instance.SetCameraTarget(GameManager.Instance.Player, 0.5f);
    }
    public void MoveStart()
    {

    }
    public void EnablePolice()
    {
        Police.SetActive(true);
    }
    public void RandomDrinkMent()
    {                
        int textRand = Random.Range(0, 3);
        if (textRand == 0)
        {
            UIManager.Instance.setDialogue(gameObject, "으아아아!", 100, 1.5f);
        }
        else if (textRand == 1)
        {
            UIManager.Instance.setDialogue(gameObject, "술 더 가져와!", 100, 1.5f);
        }
        else if (textRand == 2)
        {
            UIManager.Instance.setDialogue(gameObject, "내가 누군지알어?!", 100, 1.5f);
        }
        else
        {
            UIManager.Instance.setDialogue(gameObject, "나가 마!", 100, 1.5f);
        }
    }

}

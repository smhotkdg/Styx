using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDetector : MonoBehaviour
{
    public List<GameObject> NPCList;
    // Start is called before the first frame update
    void Start()
    {
        //SetInit();
        for (int i = 0; i < NPCList.Count; i++)
        {
            NPCList[i].GetComponent<SearchNPC_part5>().OnFindEventHandler += KitchenDetector_OnFindEventHandler;
        }
    }
    bool isFind = false;
    private void KitchenDetector_OnFindEventHandler(GameObject findParent)
    {
        if(isFind==false)
        {
            isFind = true;
            GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
            GameManager.Instance.playerController.SetForceIdle();
            for (int i = 0; i < NPCList.Count; i++)
            {
                NPCList[i].GetComponent<SearchNPC_part5>().AllPause();
            }
            GameManager.Instance.SetCameraTarget(findParent,0.5f);
            StartCoroutine(EndRoutine());
            UIManager.Instance.FIndEffect.GetComponent<UiTargetManager>().y_Margin = 130;
            UIManager.Instance.FIndEffect.GetComponent<UiTargetManager>().x_Margin = 0;
            UIManager.Instance.FIndEffect.GetComponent<UiTargetManager>().WorldObject = findParent;
        }
    }
    public void AllPause()
    {
        for (int i = 0; i < NPCList.Count; i++)
        {
            NPCList[i].GetComponent<SearchNPC_part5>().AllPause();
        }
    }
    public void AllResume()
    {
        for (int i = 0; i < NPCList.Count; i++)
        {
            NPCList[i].GetComponent<SearchNPC_part5>().AllResume();
        }
    }
    IEnumerator EndRoutine()
    {
        yield return new WaitForSeconds(.5f);
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.KitchenAlarm);
        GameManager.Instance.cameraEffectController.SetEarthQuake(1f);
        UIManager.Instance.FIndEffect.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        if(GameManager.Instance.GameIndex <900)
        {
            TestCodeManager.Instance.StartPart5_1StartKitchen(true);
        }
        else
        {
            TestCodeManager.Instance.StartPart5_2StartKitchen(true);
        }
        
    }
    public void SetInit()
    {
        for(int i =0; i< NPCList.Count; i++)
        {
            NPCList[i].GetComponent<SearchNPC_part5>().SetInit();
        }
        isFind = false;
    }
    public void StartGame()
    {
        for (int i = 0; i < NPCList.Count; i++)
        {
            NPCList[i].GetComponent<SearchNPC_part5>().StartGame();
        }
    }
    public void OnFind()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

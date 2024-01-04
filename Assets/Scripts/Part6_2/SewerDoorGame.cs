using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class SewerDoorGame : MonoBehaviour
{
    public SewerLight sewerLight;
    public GameObject SewerLightObject;
    public GameObject GameUI;
    public GameObject EndUI;
    public GameObject Door;
    List<int> GearCount = new List<int>();
    public List<GameObject> GearList;
    private void Start()
    {
        GearCount.Add(0);
        GearCount.Add(0);
        GearCount.Add(0);
        GearCount.Add(0);
    }
    private void OnEnable()
    {
        SewerLightObject.SetActive(false);
        GameUI.SetActive(true);
        GameUI.GetComponent<CanvasGroup>().alpha = 1;
        EndUI.GetComponent<CanvasGroup>().alpha = 0;
        EndUI.SetActive(false);
    }
    public void SetGear(int index)
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.GearClick);
        GearCount[index]++;
        if(GearCount[index]>=10)
        {
            GearCount[index] = 0;            
        }
        GearList[index].transform.Find("Text").GetComponent<Text>().text = GearCount[index].ToString("N0");
        GearList[index].transform.DORotate(new Vector3(0, 0, GearList[index].transform.eulerAngles.z - 45), 0.2f).SetEase(Ease.Linear);
        //8467
        CheckComplete();
    }
    void CheckComplete()
    {
        if(GearCount[0] == 8 && GearCount[1] == 4 && GearCount[2]==6 && GearCount[3]==7)
        {
            Debug.Log("하수구 성공~!");
            SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.SwearUnLock);
            GameUI.GetComponent<CanvasGroup>().DOFade(0, 1).OnComplete(CompleteFade);
            GameManager.Instance.cameraEffectController.SetEarthQuake(1f);
            StartCoroutine(AnimationRoutine());
            EndUI.SetActive(true);
            EndUI.GetComponent<CanvasGroup>().DOFade(1, 1);            
        }

    }
    IEnumerator AnimationRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Door.GetComponent<Animator>().Play("1");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.SewerOpen);
    }
    void CompleteFade()
    {
        GameUI.SetActive(false);
    }
    public void StartNextPart()
    {
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.DOOR);
        for (int i =0; i<  sewerLight.LightList.Count;i++)
        {
            sewerLight.LightList[i].SetActive(false);
        }
        TestCodeManager.Instance.StartPart6_2_EmergencyLadder();
        this.GetComponent<Animator>().Play("SewerOff");
    }
}

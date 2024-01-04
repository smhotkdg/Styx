using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemroyEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform movePosition;

    public GameObject EffectShip;
    public GameObject UnderWater;
    public bool isPart5 = false;
    void Start()
    {
        
    }
    public void StartMove()
    {
        UnderWater.SetActive(true);
        EffectShip.SetActive(false);
        UIManager.Instance.Part5_1FarmFriend.GetComponent<FollowObject>().isFollow = false;
        GameManager.Instance.Player.GetComponent<PlayerController>().isHorizontal = false;
        if(isPart5)
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.underWater, movePosition, 5);
        }
        else
        {
            UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.underWater, movePosition, 7);
        }
        
        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.underWater);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

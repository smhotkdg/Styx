using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FunkyCode;

public class SchoolGame : MonoBehaviour
{
    public List<Light2D> LightList;
    public List<GameObject> DoorObject;

    public Transform movePosition;
    public void Start()
    {
        MakeRandLight();
        TotalCount = 0;
    }
    int roomCount = -1;
    public int TotalCount = 0;
    void MakeRandLight()
    {
        int rand = Random.Range(0, LightList.Count);
        for(int i=0; i< LightList.Count; i++)
        {
            LightList[i].color = new Color(1, 1, 1, 1);
        }
        LightList[rand].color = new Color(0.78f, 0, 0, 1);
        roomCount = rand;
    }
    public void MoveDoor(int index)
    {
        while(true)
        {
            int rand = Random.Range(0, DoorObject.Count);
            if(rand != index)
            {              
                if(roomCount == index)
                {
                    Debug.Log("호로롱");
                    MakeRandLight();
                    TotalCount++;
                }
                else
                {
                    MakeRandLight();
                    TotalCount = 0;
                }

                if (TotalCount >= 3)
                {
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.ProfessorRoom, movePosition, 6);
                    GameManager.Instance.ChangeRoom(GameManager.RoomPosition.ProfessorRoom);
                }
                else
                {
                    StartCoroutine(MovePlayerRoutine(rand));
                }
                return;
            }
        }
    }
    IEnumerator MovePlayerRoutine(int rand)
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1f);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Player.transform.DOMove(DoorObject[rand].transform.position, Vector2.Distance(GameManager.Instance.Player.transform.position, DoorObject[rand].transform.position)).SetEase(Ease.Linear).OnComplete(OnCompleteMovePlayer);
        
    }
    void OnCompleteMovePlayer()
    {
        StartCoroutine(MoveEnd());
    }
    IEnumerator MoveEnd()
    {
        yield return new WaitForSeconds(.2f);
        GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 1f);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
    }
}

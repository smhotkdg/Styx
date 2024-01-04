using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuningGameController : MonoBehaviour
{
    public Transform playerPosition;
    public RepeatSprite repeatSprite;
    public List<GameObject> RuningGameObjects;
    public Transform StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        InitData();
        
    }
    void InitData()
    {
        GameManager.Instance.Player.transform.position = StartPosition.transform.position;
        //GameManager.Instance.SetCamearTarget(null);
        Vector3 pos = GameManager.Instance.Player.transform.position;
        pos.z = GameManager.Instance.cinemachineCamera.transform.position.z;
        GameManager.Instance.cinemachineCamera.transform.position = pos;

        UIManager.Instance.RunGamePanel.SetActive(true);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetRun(true);
        for (int i = 0; i < RuningGameObjects.Count; i++)
        {
            RuningGameObjects[i].SetActive(false);
        }
    }
    private void OnEnable()
    {
        InitData();
        bStartGame = false;
        objectIndex = 0;
    }
    private void OnDisable()
    {
        //if(GameManager.Instance !=null)
        //    GameManager.Instance.SetCamearTarget(GameManager.Instance.Player.transform);
        for (int i = 0; i < RuningGameObjects.Count; i++)
        {
            RuningGameObjects[i].SetActive(false);
        }
        bStartGame = false;
        objectIndex = 0;
        GameManager.Instance.Player.GetComponent<PlayerController>().bJump = false;
    }
    // Update is called once per frame
    bool bStartGame = false;
    public void StartGame()
    {
        GameManager.Instance.SetCamearTarget(null);
        
        repeatSprite.StartGame();
        GameManager.Instance.Player.GetComponent<PlayerController>().bJump = true;
        StartCoroutine(MakeObjectRoutine());
    }
    int objectIndex = 0;
    IEnumerator MakeObjectRoutine()
    {
        int makeRand = Random.Range(2, 4);
        yield return new WaitForSeconds(makeRand);
        if (objectIndex >= RuningGameObjects.Count)
        {
            objectIndex = 0;
        }    
        RuningGameObjects[objectIndex].SetActive(true);
        RuningGameObjects[objectIndex].transform.position = playerPosition.transform.position;
        StartCoroutine(falseRoutine(objectIndex));
        objectIndex++;
        
        StartCoroutine(MakeObjectRoutine());
    }
    IEnumerator falseRoutine(int index)
    {
        yield return new WaitForSeconds(5f);
        RuningGameObjects[index].SetActive(false);
    }
    void Update()
    {
        Vector3 TargetPos = GameManager.Instance.Player.transform.position;
        TargetPos.x = TargetPos.x + 3.5f;
        playerPosition.transform.position = TargetPos;
    }
    
}

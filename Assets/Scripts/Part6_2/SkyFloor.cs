using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFloor : MonoBehaviour
{
    public bool isLadder = false;
    public Transform EndPos;
    bool isEnter = false;
    private void Start()
    {
        isEnter = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (isEnter == false)
            {
                GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
                if (isLadder ==false)
                {                    
                    StartMovePlayer();
                    isEnter = true;
                }
                else
                {
                    GameManager.Instance.roomPosition = GameManager.RoomPosition.LightHouse;
                    UIManager.Instance.SetScenesChangeViewEnable(languageController.SceneTextType.LightHouse, EndPos, 8);
                }
                
            }
        }
    }
    void StartMovePlayer()
    {
        GameManager.Instance.gameStatus = GameManager.GameStatus.DO_FORCE;
        StartCoroutine(PlayerMoveRoutine());
    }
    IEnumerator PlayerMoveRoutine()
    {
        GameManager.Instance.playerController.animator.SetFloat("speed", 0);
        GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), 1);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Player.transform.DOMove(EndPos.position, 2).SetEase(Ease.Linear);
        GameManager.Instance.Player.transform.localScale = new Vector3(-4, 4, 4);
        GameManager.Instance.playerController.SetForceIdle();
        yield return new WaitForSeconds(2f);
        GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 1);
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().isTrigger = false;
        GameManager.Instance.playerController.SetRatationFreeze();
        GameManager.Instance.playerController.OnlyVertical = false;
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;

    }
}

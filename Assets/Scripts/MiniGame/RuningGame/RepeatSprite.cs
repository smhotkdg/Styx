using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatSprite : MonoBehaviour
{
    public float scrollSpeed = -2f;
    Vector2 startPos;
    bool bStartGame = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }
    private void OnDisable()
    {
        deltaTime = 0;
        bStartGame = false;
    }
    private void OnEnable()
    {
        deltaTime = 0;
        bEnd = false;
    }
    // Update is called once per frame

    public void StartGame()
    {
    }
    float deltaTime = 0;
    bool bEnd = false;
    void Update()
    {
        if (bEnd == true)
            return;
        deltaTime += Time.deltaTime;
        float newPos = Mathf.Repeat(deltaTime * scrollSpeed, 120);
        //Debug.Log(newPos);
        if(Mathf.Round(newPos) ==0)
        {
            Debug.Log("끝");
            GameManager.Instance.Player.GetComponent<PlayerController>().SetRun(false);
            bEnd = true;
        }
        transform.position = startPos + Vector2.right * newPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PuzzleController : MonoBehaviour
{
    public delegate void PuzzleEvent();
    public event PuzzleEvent onPuzzleEventHandler;

    Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(ClickPuzzle);
    }
    private void OnDisable()
    {
        bStart = false;
    }
    private void OnEnable()
    {
        MakeRandom();
    }
    void MakeRandom()
    {
        int rand = Random.Range(0, 4);
        switch(rand)
        {
            case 0:                
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case 1:                
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case 2:
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
            case 3:
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                break;
        }
    }
    bool bStart = false;
    void ClickPuzzle()
    {
        if(bStart ==true)
        {
            return;
        }
        bStart = true;
        float rotatez = GameManager.Instance.WrapAngle(transform.rotation.eulerAngles.z);
        rotatez -= 90;      
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotatez));
        transform.DORotate(new Vector3(0, 0, transform.rotation.eulerAngles.z+90), 0.2f).SetEase(Ease.Linear).OnComplete(rotateEnd);
        
    }
    public int GetAngle()
    {
        float rotatez = GameManager.Instance.WrapAngle(transform.rotation.eulerAngles.z);
        return Mathf.RoundToInt(rotatez);
    }
    void rotateEnd()
    {
        bStart = false;
        onPuzzleEventHandler?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

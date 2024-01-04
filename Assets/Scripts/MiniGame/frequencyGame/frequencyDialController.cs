using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class frequencyDialController : MonoBehaviour
{
    public frequencyGameManager frequencyGameManager;
    public int DIalCount;
    public void SetDial()
    {
        if(frequencyGameManager.isMove== false)
        {            
            transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z - 45), 0.2f).SetEase(Ease.Linear).OnComplete(OnCompleteTween);
            frequencyGameManager.MoveDial(DIalCount);
            frequencyGameManager.isMove = true;
        }
        
    }
    private void OnEnable()
    {
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
    void OnCompleteTween()
    {       
        
        frequencyGameManager.CheckSuccess(DIalCount);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

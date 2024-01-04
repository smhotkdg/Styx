using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class BoxMove : MonoBehaviour
{
    public float Speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(Speed * - Time.deltaTime, 0);
    }
    public void SetDisable()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Speed = 0;
        Vector3 jumpVector = transform.position;
        jumpVector.y = jumpVector.y + 30;
        transform.DOJump(jumpVector,2,1,0.3f);
        transform.DOScale(0, 0.3f).SetDelay(0.1f).OnComplete(completeTween);
    }
    void completeTween()
    {
        Destroy(this.gameObject);
    }
}

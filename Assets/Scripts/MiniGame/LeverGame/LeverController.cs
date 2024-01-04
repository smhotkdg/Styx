using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
public class LeverController : MonoBehaviour
{
    //Midle Pos = 105 -50 rotate z = -45
    //end Pos = 160 -150 rotate z = -90
    // Start is called before the first frame update
    public BoxCollider2D boxCollider;
    public Image FilImage;
    public GameObject CameraPos1;
    public GameObject CameraPos2;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        bFinshLever = false;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 70));
        FilImage.fillAmount = 0;
    }
    bool bFinshLever = false;   
  
    public void ClickGame()
    {        
        float rotatez =GameManager.Instance.WrapAngle(transform.rotation.eulerAngles.z);
        rotatez -= 1;
        if (rotatez <= -70)
        {
            boxCollider.enabled = false;
            //TestCodeManager.Instance.Part1CompleteLeverQuest(false);
            GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
            Debug.Log("레버 성공!!");
            FilImage.fillAmount = 1;
            bFinshLever = true;
            boxCollider.enabled = false;
            GameManager.Instance.LeverEvent();
            this.gameObject.transform.parent.parent.gameObject.SetActive(false);
            //StartCoroutine(LeverGameEndRoutine());
            return;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotatez));
        SetPrograss(rotatez);
    }
    void SetPrograss(float ratateValue)
    {
        FilImage.fillAmount = Mathf.Abs(ratateValue-70) / 140;
    }
    private void FixedUpdate()
    {
        if (bFinshLever == true)
            return;
        float rotatez = GameManager.Instance.WrapAngle(transform.rotation.eulerAngles.z);
        if (rotatez >=70)
        {            
            return;
        }
        rotatez += 0.05f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotatez));
        SetPrograss(rotatez);
    }
    IEnumerator LeverGameEndRoutine()
    {
        //DialogueLua.SetQuestField("leverQuest", "State", "success");
        //GameManager.Instance.PartList[1].GetComponent<Part1Manager>().SetLever();
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetWorkingMotion(false);
        this.gameObject.transform.parent.parent.gameObject.SetActive(false);        
    }


}

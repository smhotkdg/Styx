using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunGame_UI : MonoBehaviour
{
    public DialogueSystemTrigger failConversation;
    public DialogueSystemTrigger SuccessConversation;
    public Text TimerText;
    public Image TimeFillUI;
    public GameObject Bullet;
    public GameObject Target;

    public GameObject LifePlayer;
    public GameObject LifeEnmey;
    bool isStartGame = false;
    public float BulletSpeed = 2;
    bool bLeft = true;
    float DefaultTime = 5;
    float time = 0;
    public int EnmeyLife = 3;
    public int PlayerLife = 3;
    private void OnEnable()
    {
        time = DefaultTime;
        EnmeyLife = 3;
        PlayerLife = 3;
        LifePlayer.SetActive(true);
        LifeEnmey.SetActive(true);
        isStartGame = true;        
        CheckLifeUI();
    }
    public void SetText()
    {
        TimerText.text = "0" + time.ToString("N2");
        TimeFillUI.fillAmount = 1 - (time / DefaultTime);
    }
    void ChangeTarget()
    {
        int rand = Random.Range(-180, 180);
        Vector3 targetPos = Target.transform.localPosition;
        targetPos.x = rand;
        //Target.transform.localPosition = targetPos;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isStartGame)
        {
            return;
        }
        //if(time >0)
        //{
        //    time -= Time.deltaTime;
        //}
        //else
        //{
        //    time = 0;
        //    isStartGame = false;
        //    StartCoroutine(FailShootRoutine());
        //}
        SetText();
        if(bLeft)
        {
            Bullet.transform.localPosition += new Vector3(-BulletSpeed * Time.deltaTime, 0);
            if(Bullet.transform.localPosition.x < -200)
            {
                bLeft = false;
                Bullet.transform.localScale = new Vector3(1, -1, 1);
                ChangeTarget();
            }

        }
        else
        {
            Bullet.transform.localPosition += new Vector3(BulletSpeed * Time.deltaTime, 0);
            if (Bullet.transform.localPosition.x >200)
            {
                bLeft = true;
                ChangeTarget();
                Bullet.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        if(GameManager.Instance.HintEnalbeList[23])
        {
            Target.transform.position = Bullet.transform.position;
        }
    }

    IEnumerator ShoopSuccessRoutine()
    {
        GameManager.Instance.playerController.ShootGun();
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(0.2f);
        UIManager.Instance.Part6_2Enmey.GetComponent<Animator>().Play("Damage");
        GameManager.Instance.cameraEffectController.SetEarthQuake(.2f);        
        EnmeyLife--;
        if(EnmeyLife==0)
        {
            CheckLifeUI();
            UIManager.Instance.Part6_2Enmey.GetComponent<Animator>().Play("Idle_injuryIdle");
            yield return new WaitForSeconds(1.5f);
            DialogueManager.StartConversation(SuccessConversation.conversation, SuccessConversation.transform);
            LifePlayer.SetActive(false);
            LifeEnmey.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            time = DefaultTime;
            isStartGame = true;
        }
        CheckLifeUI();
    }
    public void Shoot()
    {
        if (isStartGame == false)
            return;
        isStartGame = false;
        //Debug.Log(Vector2.Distance(Bullet.transform.localPosition, Target.transform.localPosition));
        if(Vector2.Distance(Bullet.transform.localPosition, Target.transform.localPosition) < 42)
        {
            //Debug.Log("성공스~");
            //UIManager.Instance.Part6_2Enmey.GetComponent<Animator>().Play("Damage");
            //UIManager.Instance.Part6_2Enmey.GetComponent<Animator>().Play("GunShot_2");
            //Idle_injuryIdle
            //villain_Dead_dead
            StartCoroutine(ShoopSuccessRoutine());            
        }
        else
        {
            //Debug.Log("총 맞음");
            StartCoroutine(FailShootRoutine());
            //GameManager.Instance.playerController.animator.Play("Damage");
            //injury_idle
            //Die
            
        }
    }

    IEnumerator FailShootRoutine()
    {
        UIManager.Instance.Part6_2Enmey.GetComponent<Animator>().Play("GunShot_2");
        SoundsManager.Instance.PlaySoundsFx(SoundsManager.SoundsType.gunShot);
        yield return new WaitForSeconds(.2f);        
        GameManager.Instance.cameraEffectController.SetEarthQuake(.2f);
        GameManager.Instance.playerController.animator.Play("Damage");        
        PlayerLife--;
        if(PlayerLife==0)
        {
            CheckLifeUI();
            yield return new WaitForSeconds(.5f);
            GameManager.Instance.playerController.animator.Play("injury_idle");
            yield return new WaitForSeconds(1.5f);
            DialogueManager.StartConversation(failConversation.conversation, failConversation.transform);
            LifePlayer.SetActive(false);
            LifeEnmey.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            time = DefaultTime;
            isStartGame = true;
        }
        CheckLifeUI();
    }
    void CheckLifeUI()
    {
        if(PlayerLife == 3)
        {
            LifePlayer.transform.Find("1").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
            LifePlayer.transform.Find("2").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
            LifePlayer.transform.Find("3").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
        }
        else if(PlayerLife == 2)
        {
            LifePlayer.transform.Find("1").gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            LifePlayer.transform.Find("2").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
            LifePlayer.transform.Find("3").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
        }
        else if(PlayerLife ==1)
        {
            LifePlayer.transform.Find("1").gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            LifePlayer.transform.Find("2").gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            LifePlayer.transform.Find("3").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
        }
        else
        {
            LifePlayer.SetActive(false);
            //EventStart
        }



        if (EnmeyLife == 3)
        {
            LifeEnmey.transform.Find("1").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
            LifeEnmey.transform.Find("2").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
            LifeEnmey.transform.Find("3").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
        }
        else if (EnmeyLife == 2)
        {
            LifeEnmey.transform.Find("1").gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            LifeEnmey.transform.Find("2").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
            LifeEnmey.transform.Find("3").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
        }
        else if (EnmeyLife == 1)
        {
            LifeEnmey.transform.Find("1").gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            LifeEnmey.transform.Find("2").gameObject.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            LifeEnmey.transform.Find("3").gameObject.GetComponent<Image>().color = new Color32(200, 0, 0, 255);
        }
        else
        {
            LifeEnmey.SetActive(false);
            //EventStart
        }    
    }
}


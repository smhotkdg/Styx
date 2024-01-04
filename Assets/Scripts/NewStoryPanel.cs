using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class NewStoryPanel : MonoBehaviour
{
    public Text NewStoryText; 
    public List<GameObject> NewStoryPart;
    public GameObject NewStoryConfrimPanel;
    public Text NewStory_PanelText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        NewStoryText.color = new Color(0, 0, 0, 0);
        for (int i = 0; i < NewStoryPart.Count; i++)
        {
            NewStoryPart[i].SetActive(false);
        }
   
        StartCoroutine(SetEnableRoutine());
    }
    IEnumerator SetEnableRoutine()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < NewStoryPart.Count; i++)
        {
            NewStoryPart[i].SetActive(true);
            NewStoryPart[i].GetComponent<EndingPart>().SetView(false);
            yield return new WaitForSeconds(0.3f);
            if(i ==2)
            {
                StartCoroutine(TextRoutine(2f, NewStoryText));
            }
        }
        
    }
    IEnumerator TextRoutine(float time, Text text_object)
    {
        Color color = text_object.color;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            color.a += 0.01f;
            text_object.color = color;
            if (color.a >= 0.78f)
            {
                color.a = 1;
                break;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public int SelectIndex = 0;
    public void SetNewStory(int index)
    {
        NewStory_PanelText.text = languageController.Instance.GetNewPostionText(index);
       
        NewStoryConfrimPanel.SetActive(true);
        SelectIndex = index;
    }
    public void NewGameStart()
    {
        GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 1f);
        GameManager.Instance.Player.GetComponent<PlayerController>().isFollowAnchor = false;
        GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().isStartMove = false;
        GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        
        switch (SelectIndex)
        {
            case 0:
                //선착장
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.port);
                GameManager.Instance.data.spoon = 0;
                GameManager.Instance.data.stringline = 0;
                GameManager.Instance.data.Brokenparts = 0;
                GameManager.Instance.data.Letter = 0;
                GameManager.Instance.data.ChurchPass = 0;
                GameManager.Instance.data.FarmPass = 0;
                GameManager.Instance.data.wateringCan = 0;
                GameManager.Instance.data.Map = 0;
                GameManager.Instance.data.Accesscard = 0;
                GameManager.Instance.data.FactoryBrooch = 0;
                GameManager.Instance.data.engineerBrooch = 0;
                GameManager.Instance.data.slpeepingJuice = 0;
                GameManager.Instance.data.Juice = 0;
                GameManager.Instance.data.sleepingpill = 0;
                GameManager.Instance.data.SubmarinKey = 0;
                GameManager.Instance.data.FulltimeFamer = 0;
                GameManager.Instance.data.Drug = 0;
                GameManager.Instance.data.isEscapeShip = 0;
                GameManager.Instance.data.Lamptownbrooch = 0;
                GameManager.Instance.ResetQuestData();
                //GameManager.Instance.GameIndex = 0;

                TestCodeManager.Instance.StartMarina();
                break;
            case 1:
                //강제노역소
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.room);
                GameManager.Instance.data.spoon = 0;
                GameManager.Instance.data.stringline = 0;
                GameManager.Instance.data.Brokenparts = 0;
                GameManager.Instance.data.Letter = 0;
                GameManager.Instance.data.ChurchPass = 0;
                GameManager.Instance.data.FarmPass = 0;
                GameManager.Instance.data.wateringCan = 0;
                GameManager.Instance.data.Map = 0;
                GameManager.Instance.data.Accesscard = 0;
                GameManager.Instance.data.FactoryBrooch = 0;
                GameManager.Instance.data.engineerBrooch = 0;
                GameManager.Instance.data.slpeepingJuice = 0;
                GameManager.Instance.data.Juice = 0;
                GameManager.Instance.data.sleepingpill = 0;
                GameManager.Instance.data.SubmarinKey = 0;
                GameManager.Instance.data.FulltimeFamer = 0;
                GameManager.Instance.data.Drug = 0;
                GameManager.Instance.data.isEscapeShip = 0;
                GameManager.Instance.data.Lamptownbrooch = 0;
                
                TestCodeManager.Instance.RoomStart();
                break;
            case 2:
                //램프타운
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.wareHouse);               
                GameManager.Instance.data.Letter = 0;
                GameManager.Instance.data.ChurchPass = 0;
                GameManager.Instance.data.FarmPass = 0;
                GameManager.Instance.data.wateringCan = 0;
                GameManager.Instance.data.Map = 0;
                GameManager.Instance.data.Accesscard = 0;
                GameManager.Instance.data.FactoryBrooch = 0;
                GameManager.Instance.data.engineerBrooch = 0;
                GameManager.Instance.data.slpeepingJuice = 0;
                GameManager.Instance.data.Juice = 0;
                GameManager.Instance.data.sleepingpill = 0;
                GameManager.Instance.data.SubmarinKey = 0;
                GameManager.Instance.data.FulltimeFamer = 0;
                GameManager.Instance.data.Drug = 0;
                GameManager.Instance.data.isEscapeShip = 0;

                GameManager.Instance.GameIndex = 11;
                TestCodeManager.Instance.WareHouse();
                break;
            case 3:
                //스카이타운
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.skytown);

                GameManager.Instance.data.ChurchPass = 1;
                GameManager.Instance.data.FarmPass = 1;
                GameManager.Instance.data.wateringCan = 0;
                GameManager.Instance.data.Map = 0;
                GameManager.Instance.data.Accesscard = 0;
                GameManager.Instance.data.FactoryBrooch = 0;
                GameManager.Instance.data.engineerBrooch = 0;
                GameManager.Instance.data.slpeepingJuice = 0;
                GameManager.Instance.data.Juice = 0;
                GameManager.Instance.data.sleepingpill = 0;
                GameManager.Instance.data.SubmarinKey = 0;
                GameManager.Instance.data.FulltimeFamer = 0;
                GameManager.Instance.data.Drug = 0;
                GameManager.Instance.data.isEscapeShip = 0;

                TestCodeManager.Instance.GoSkyTown();
                
                break;
            case 4:
                //공장
                GameManager.Instance.ChangeRoom(GameManager.RoomPosition.factory);

                GameManager.Instance.data.ChurchPass = 1;
                GameManager.Instance.data.FarmPass = 1;
                GameManager.Instance.data.wateringCan = 1;
                GameManager.Instance.data.Map = 1;
                GameManager.Instance.data.Accesscard = 1;
                GameManager.Instance.data.FactoryBrooch = 0;
                GameManager.Instance.data.engineerBrooch = 0;
                GameManager.Instance.data.slpeepingJuice = 0;
                GameManager.Instance.data.Juice = 0;
                GameManager.Instance.data.sleepingpill = 0;
                GameManager.Instance.data.SubmarinKey = 0;
                GameManager.Instance.data.FulltimeFamer = 0;
                GameManager.Instance.data.Drug = 0;
                GameManager.Instance.data.isEscapeShip = 0;

                TestCodeManager.Instance.StartPart4(); 
                
                break;
        }
        this.gameObject.SetActive(false);
        //GameManager.Instance.SaveData();
        //GameManager.Instance.LoadData();
        //SceneManager.LoadScene("Styx");
    }
}

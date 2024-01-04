using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnding : MonoBehaviour
{
    private void OnEnable()
    {
        for(int i =0; i< GameManager.Instance.PartCoinList.Count; i++)
        {
            GameManager.Instance.PartCoinList[i] = false;
        }
        for(int i =0;i < GameManager.Instance.QuestCoinList.Count; i++)
        {
            GameManager.Instance.QuestCoinList[i] = 0;
        }
        for (int i = 0; i < GameManager.Instance.RoomCome.Count; i++)
        {
            GameManager.Instance.RoomCome[i] = 0;
        }
        GameManager.Instance.DroneTutorial = 0;
        GameManager.Instance.BagTutorial = 0;
        //GameManager.Instance.Player.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 1f);
        GameManager.Instance.Player.GetComponent<PlayerController>().isFollowAnchor = false;
        GameManager.Instance.FactoryManager.GetComponent<FactoryManagerController>().isStartMove = false;
        //GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        GameManager.Instance.gameStatus = GameManager.GameStatus.NOTING;
        GameManager.Instance.styxData.Part5_1EventCount = 0;
        GameManager.Instance.styxData.Part5_2EventCount = 0;
        GameManager.Instance.data.DroneBook = 0;
        GameManager.Instance.ResetQuestData();
        GameManager.Instance.data.isShootPoolGuard = false;
        GameManager.Instance.data.isDeadGateKeeper = false;
        GameManager.Instance.data.isBindGateKeeper = false;

        GameManager.Instance.ChangeRoom(GameManager.RoomPosition.port);
        GameManager.Instance.data.spoon = 0;
        GameManager.Instance.data.stringline = 0;
        GameManager.Instance.data.Brokenparts = 0;
        //GameManager.Instance.data.Letter = 0;
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
        GameManager.Instance.data.FactoryPill = 0;
        GameManager.Instance.data.isChoiceMember = 0;
        GameManager.Instance.data.SubmarinKey = 0;
        GameManager.Instance.data.FulltimeFamer = 0;
        GameManager.Instance.data.Drug = 0;
        GameManager.Instance.data.isEscapeShip = 0;
        //GameManager.Instance.data.Lamptownbrooch = 0;
        GameManager.Instance.data.PillRecipe = 0;
        GameManager.Instance.ResetQuestData();

        //GameManager.Instance.GameIndex = 0;
        TestCodeManager.Instance.isResetQuestData = true;
        GameManager.Instance.ResetQuestData();
        //GameManager.Instance.ChangeCamera(GameManager.Instance.Player, true);
        GameManager.Instance.GameIndex = 0;
        GameManager.Instance.SaveData();
    }
}

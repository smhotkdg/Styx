using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class InventoryController : MonoBehaviour
{
    public enum ItemType
    {
        Spoon,
        stringLine,
        Brokenparts,                
        Letter,
        ChurchPass,
        FarmPass,
        Lamptownbrooch,
        wateringCan,
        Map,
        Accesscard,
        factorybrooch,
        engineerBrooch,
        sleepingpill,
        slpeepingJuice,
        SubmarinKey,
        Juice,
        fulltimeFamer

    }
    public List<InventoryItem> InventoryItems;

    private void OnEnable()
    {
        SetData();
    }
    void Update()
    {

        if (Input.GetKey("escape"))
            gameObject.SetActive(false);

    }
    public void SetData()
    {
        transform.SetAsLastSibling();
        for (int i =0; i< InventoryItems.Count; i++)
        {
            InventoryItems[i].SetDisable();
            InventoryItems[i].gameObject.SetActive(false);
            InventoryItems[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
            InventoryItems[i].InventoryText.color = new Color(0, 0, 0, 0);
            InventoryItems[i].InventoryImage.color = new Color(0, 0, 0, 0);
        }
        int inventoryCount = 0;
        if(GameManager.Instance.data.spoon !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.Spoon);
            inventoryCount++;
        }
        if (GameManager.Instance.data.stringline != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.stringLine);
            inventoryCount++;
        }
        if (GameManager.Instance.data.Brokenparts != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.Brokenparts);
            inventoryCount++;
        }
        if (GameManager.Instance.data.Letter !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.Letter);
            
            inventoryCount++;
        }
        if (GameManager.Instance.data.ChurchPass != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.ChurchPass);
            inventoryCount++;
        }
        if (GameManager.Instance.data.FarmPass != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.FarmPass);
            inventoryCount++;
        }
        if (GameManager.Instance.data.Lamptownbrooch != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.Lamptownbrooch);
            inventoryCount++;
        }
        if(GameManager.Instance.data.wateringCan !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.wateringCan);
            inventoryCount++;
        }
        if(GameManager.Instance.data.Map !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.Map);
            inventoryCount++;
        }
        if(GameManager.Instance.data.Accesscard !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.Accesscard);
            inventoryCount++;
        }
        if(GameManager.Instance.data.FactoryBrooch !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.factorybrooch);
            inventoryCount++;
        }
        if(GameManager.Instance.data.engineerBrooch !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.engineerBrooch);
            inventoryCount++;
        }
        if(GameManager.Instance.data.sleepingpill !=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.sleepingpill);
            inventoryCount++;
        }
        if (GameManager.Instance.data.slpeepingJuice != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.slpeepingJuice);
            inventoryCount++;
        }
        if (GameManager.Instance.data.SubmarinKey != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.SubmarinKey);
            inventoryCount++;
        }
        if (GameManager.Instance.data.Juice != 0)
        {
            InventoryItems[inventoryCount].setData(ItemType.Juice);
            inventoryCount++;
        }
        if(GameManager.Instance.data.FulltimeFamer!=0)
        {
            InventoryItems[inventoryCount].setData(ItemType.fulltimeFamer);
            inventoryCount++;
        }
        StartCoroutine(InventoryItemViewRoutine(inventoryCount));
       
    }
    IEnumerator InventoryItemViewRoutine(int totalCount)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < totalCount; i++)
        {
            InventoryItems[i].gameObject.SetActive(true);
            InventoryItems[i].GetComponent<Image>().DOColor(new Color(0, 0, 0, 1), 1f);
            InventoryItems[i].InventoryText.DOColor(new Color(0.78f, 0.78f, 0.78f,1), 1f);
            InventoryItems[i].InventoryImage.DOColor(new Color(1, 1, 1, 1), 1f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    public Text InventoryText;
    public Image InventoryImage;
    public GameObject InfoPanel;
    public GameObject MapPanel;
    InventoryController.ItemType item;
    public void GetInfo()
    {
        if(InventoryImage.gameObject.activeSelf ==true)
        {
            if(item != InventoryController.ItemType.Map)
            {
                InfoPanel.SetActive(true);
                InfoPanel.GetComponent<InventoryInfoPanel>().SetData(item);
            }
            else
            {
                MapPanel.SetActive(true);
            }
            
        }
    }
    public void SetDisable()
    {
        InventoryImage.gameObject.SetActive(false);
        InventoryText.gameObject.SetActive(false);
    }
    public void setData(InventoryController.ItemType itemType)
    {
        item = itemType;
        InventoryImage.gameObject.SetActive(true);
        InventoryText.gameObject.SetActive(true);
        InventoryText.text = languageController.Instance.GetInventoryItemName(itemType);
        InventoryImage.sprite = UIManager.Instance.GetInventorySprite(itemType);      
    }
}

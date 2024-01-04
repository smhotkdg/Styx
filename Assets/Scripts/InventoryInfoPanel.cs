using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryInfoPanel : MonoBehaviour
{
    public GameObject PClose;
    public Text TopText;
    public Text BottomText;

    private void OnEnable()
    {
        PClose.SetActive(false);
    }
    private void OnDisable()
    {
        PClose.SetActive(true);
    }
    public void SetData(InventoryController.ItemType itemType)
    {
        TopText.text = languageController.Instance.GetInventoryItemName(itemType);
        BottomText.text = languageController.Instance.GetInventoryItemInfo(itemType);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public Text itemCount;

    ItemCollect item;

    public void AddItem(ItemCollect newItem)
    {
        item = newItem;
        // Image of item
        icon.sprite = item.icon;
        icon.enabled = true;
        // How many are in inventory
        itemCount.text = item.count.ToString();
        itemCount.enabled = true;
    }

    // Remove item(s) and reset slot
    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        itemCount.enabled = false;
    }

    // Check if slot is empty
    public bool CheckSlot()
    {
        return !icon.enabled;
    }

    // Get item in slot
    public ItemCollect GetItem()
    {
        return item;
    }

    // Update count
    public void ChangeCount(int quant)
    {
        item.count += quant;
        itemCount.text = item.count.ToString();
    }

}

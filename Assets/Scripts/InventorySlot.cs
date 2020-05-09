using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public Button removeButton;

    public Text itemCount;

    ItemCollect item;

    int count = 0;

    public void AddItem(ItemCollect newItem)
    {
        item = newItem;
        // Image of item
        icon.sprite = item.icon;
        icon.enabled = true;
        // How many are in inventory
        count += 1;
        itemCount.text = count.ToString();
        itemCount.enabled = true;

        removeButton.interactable = true;
    }

    // Remove item(s) and reset slot
    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        count = 0;
        itemCount.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        ClearSlot();
    }

    public void UseItem()
    {
        if(count > 0)
        {
            ChangeCount(-1);
            // UseItem
            item.UseItem();
            if (count == 0)
                ClearSlot();
        }
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
        count += quant;
        itemCount.text = count.ToString();
    }

}

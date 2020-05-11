using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{

    // Gameobject with game manager script
    GameObject initObj;
    
    // manager script
    public GameManager gmScr;
    
    // journal open/close button
    public GameObject J_OpenClose;

    // Parent of all slots
    public Transform itemsParent;

    // Start is called before the first frame update
    void Start()
    {
        initObj = GameObject.FindGameObjectWithTag("Init");
        gmScr = initObj.GetComponent<GameManager>();
        // set state of button
        J_OpenClose.SetActive(gmScr.journal);

        gmScr.slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    // Function so other scripts can easily get at the game manager script
    public GameManager GetManager()
    {
        return gmScr;
    }
    
    // Processes picked up items
    public void processItem(string name, ItemCollect item=null)
    {
        switch (name)
        {
            // Found Journal
            case "Journal":
                gmScr.journal = true;
                J_OpenClose.SetActive(true);
                break;
            // All other items at the moment
            default:
                UpdateUI(item);
                break;
        }
    }

    void UpdateUI(ItemCollect item)
    {
        // Loop through all slots
        for (int i = 0; i < gmScr.slots.Length; i++)
        {
            // Variable for easier referencing
            InventorySlot slot = gmScr.slots[i];
            // Item already in a slot
            if (!slot.CheckSlot() && slot.GetItem().Identity == item.Identity)
            {
                slot.ChangeCount(1);
                return;
            }
            // Empty slot
            else if (slot.CheckSlot())
            {
                slot.AddItem(item);
                return;
            }
        }
        // All slots full
        item.gameObject.SetActive(true);
        // TODO add inventory full message
    }

}
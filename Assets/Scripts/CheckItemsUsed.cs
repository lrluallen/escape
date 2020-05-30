using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemsUsed : MonoBehaviour
{
    /* 
    This script checks if each itemsToCheck exists at least somewhere in the game,
    to ensure the player has used their items correctly
    */

    public ItemCollect[] itemsToCheck; // Items we're checking if used correctly
    public ItemCollect[] itemsInScene; // The version of the item in the scene (before being picked up)

    GameManager gmScr;
    CountdownTimer timer;
    bool play = true;
    bool playerEntered;
    bool lose = false;


    // Update is called once per frame
    void Update()
    {
        if(playerEntered && !lose)
        {
            // Loop through all slots
            for (int i = 0; i < gmScr.slots.Length; ++i)
            {
                // Variable for easier referencing
                InventorySlot slot = gmScr.slots[i];
                // Loop through all items to be checked
                for (int j = 0; j < itemsToCheck.Length; ++j)
                {
                    // Item is in a slot
                    if (!slot.CheckSlot() && slot.GetItem().Identity == itemsToCheck[j].Identity)
                    {
                        // Item is in inventory
                        Debug.Log("Item is in inventory");
                        return;
                    }
                }
            }
            // Loop through all items from scene to be considered
            for (int i = 0; i < itemsInScene.Length; ++i)
            {
                // Loop through all items to be checked
                for (int j = 0; j < itemsToCheck.Length; ++j)
                {
                    // Check that item is the one we are looking for, and that it is active
                    if (itemsToCheck[j].Identity == itemsInScene[i].Identity && itemsInScene[i].isActiveAndEnabled)
                    {
                        // Item is in scene
                        Debug.Log("Item is in scene");
                        return;
                    }
                }
            }
            // Items were used incorrectly
            Debug.Log("You Lose");
            lose = true;
        }

        // End game
        if (lose)
        {
            play = timer.EndLevel(play);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Get scripts from player
            gmScr = other.GetComponent<ItemHandler>().GetManager();
            timer = other.GetComponent<CountdownTimer>();
            playerEntered = true;
        }
    }
}

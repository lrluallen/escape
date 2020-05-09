using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    // Manager Script
    gameManager gmscr;
    // Item name
    public string Identity;
    // Item image
    public Sprite icon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Pick up object
            gameObject.SetActive(false);
            // Get gameManager script from player
            gmscr = other.GetComponent<ItemHandler>().GetManager();
            // Process the item
            other.GetComponent<ItemHandler>().processItem(Identity, this);
            
        }
    }

    public void UseItem()
    {
        // Check if player is in build area
        if (gmscr.isin)
        {
            print("Using item: " + Identity);
            gmscr.builder.removeItem(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    // Manager Script
    GameManager gmscr;
    // Item name
    public string Identity;
    // Source to play the sound
    public AudioSource soundSource;
    // Sounds
    public AudioClip pickUp;
    public AudioClip useWrong;
    // Item image
    public Sprite icon;
    // Don't Disable item when picked up?
    public bool disableOnCollect = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Pick up object
            if(disableOnCollect)
                gameObject.SetActive(false);
            // Get gameManager script from player
            gmscr = other.GetComponent<ItemHandler>().GetManager();
            // Process the item
            other.GetComponent<ItemHandler>().processItem(Identity, this);
            if(pickUp)
                soundSource.PlayOneShot(pickUp, 1);
            
        }
    }

    public void UseItem()
    {
        // Check if player is in build area
        if (gmscr.isin)
        {
            //Debug.Log("Using item: " + Identity);
            if (!gmscr.builder.RemoveItem(this) && useWrong) // Remove item from build recipe
                soundSource.PlayOneShot(useWrong, 1); // incorrect use sound
        }
        else
        {
            if(useWrong)
                soundSource.PlayOneShot(useWrong, 1); // incorrect use sound
        }
    }
}

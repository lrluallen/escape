﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip buildComplete;
    public AudioClip useRight;
    public List<ItemCollect> recipe;
    public GameObject[] targets;


    GameManager gmScr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gmScr = other.GetComponent<ItemHandler>().GetManager();
            gmScr.isin = true;
            gmScr.builder = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gmScr = other.GetComponent<ItemHandler>().GetManager();
            gmScr.isin = false;
            gmScr.builder = null;
        }
    }

    // Remove item from recipe
    public bool RemoveItem(ItemCollect item)
    {
        bool success = false;
        for (int i = 0; i < recipe.Count; ++i)
        {
            Debug.Log("Looking at: " + recipe[i]);
            if (recipe[i].Identity == item.Identity)
            {
                recipe.Remove(recipe[i]);
                Debug.Log("Removed: " + item.Identity);
                if(useRight)
                    soundSource.PlayOneShot(useRight, 1);
                success = true;
                break;
            }
        }
        if (recipe.Count == 0)
            ToggleItems();
        return success;
    }

    // Recipe has been fulfilled, so 'build' object
    void ToggleItems()
    {
        for (int i = 0; i < targets.Length; ++i)
            targets[i].SetActive(!targets[i].activeSelf);
        if (buildComplete) // Check if a sound is supplied
            soundSource.PlayOneShot(buildComplete, 1); // Build complete sound
        // Turn self off after item is built
        gmScr.isin = false;
        gmScr.builder = null;
        gameObject.SetActive(false);
    }
}
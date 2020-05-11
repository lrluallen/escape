﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public List<ItemCollect> recipe;
    public GameObject prefab;

    gameManager gmScr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gmScr = other.GetComponent<ItemHandler>().GetManager();
            gmScr.isin = true;
            gmScr.builder = this;
        }
    }

    private void Start()
    {
        prefab.SetActive(false);
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
    public void removeItem(ItemCollect item)
    {
        for (int i = 0; i < recipe.Count; ++i)
        {
            print("Looking at: " + recipe[i]);
            if (recipe[i].Identity == item.Identity)
            {
                recipe.Remove(recipe[i]);
                print("Removed: " + item.Identity);
                break;
            }
        }
        if (recipe.Count == 0)
            buildPrefab();
    }

    // Recipe has been fulfilled, so 'build' object
    void buildPrefab()
    {
        prefab.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
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

    private void Start()
    {
        for(int i = 0; i < targets.Length; ++i)
            targets[i].SetActive(false);
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
            Debug.Log("Looking at: " + recipe[i]);
            if (recipe[i].Identity == item.Identity)
            {
                recipe.Remove(recipe[i]);
                Debug.Log("Removed: " + item.Identity);
                break;
            }
        }
        if (recipe.Count == 0)
            buildPrefab();
    }

    // Recipe has been fulfilled, so 'build' object
    void buildPrefab()
    {
        for (int i = 0; i < targets.Length; ++i)
            targets[i].SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    /*
    This script takes a recipe, checks if the player 
    correctly fills the recipe, and builds
    the targets
    */

    public AudioSource soundSource;
    public AudioClip buildComplete; // Build is done
    public AudioClip useRight; // item was in recipe
    public List<ItemCollect> recipe; // items required to build
    public GameObject[] targets; // things to be built
    public bool stepBuild = false; // build for each recipe item given vs build all at end
    int index = 0; 
    public int stepSize = 1; // how many items to be built per correct item use


    GameManager gmScr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // get GameManager
            gmScr = other.GetComponent<ItemHandler>().GetManager();
            // Update manager to know we are in a build, and which one
            gmScr.isin = true;
            gmScr.builder = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gmScr = other.GetComponent<ItemHandler>().GetManager();
            // Update manager that player is no longer in a build
            gmScr.isin = false;
            gmScr.builder = null;
        }
    }

    // Remove item from recipe
    public bool RemoveItem(ItemCollect item)
    {
        // At least one item was removed
        bool success = false;
        // Loop through the recipe
        for (int i = 0; i < recipe.Count; ++i)
        {
            // Check if item is in recipe
            Debug.Log("Looking at: " + recipe[i]);
            if (recipe[i].Identity == item.Identity)
            {
                // Remove the item from the recipe
                recipe.Remove(recipe[i]);
                Debug.Log("Removed: " + item.Identity);
                // Play sound
                if (useRight)
                    soundSource.PlayOneShot(useRight, 1);
                // A item was removed
                success = true;
                break;
            }
        }
        if (stepBuild && success)
        {
            // 'Build' step amount of items
            index = ToggleStep(index);
        }

        if (recipe.Count == 0)
        {
            // 'Build' all unbuilt items
            ToggleItems(index);
        }
        return success;
    }

    // Recipe has been fulfilled, so 'build' object
    void ToggleItems(int index)
    {
        // Loop through all items in targets and swap their active status
        for (int i = index; i < targets.Length; ++i)
            targets[i].SetActive(!targets[i].activeSelf);
        // Turn off this build
        DisableBuild();

    }

    // Step Build
    int ToggleStep(int index)
    {
        int length = index + stepSize;
        // Loop through all targets to be 'built'
        for (; index < length; ++index)
        {
            //'build' targets by swapping their active status
            targets[index].SetActive(!targets[index].activeSelf);
        }
        return index;
    }

    void DisableBuild()
    {
        if (buildComplete) // Check if a sound is supplied
            soundSource.PlayOneShot(buildComplete, 1); // Build complete sound
        // Turn self off after item is built
        gmScr.isin = false;
        gmScr.builder = null;
        gameObject.SetActive(false);
    }
}
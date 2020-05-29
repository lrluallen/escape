using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float fadeDuration = 1f;
    public CanvasGroup flewTheCoopSuccessImage;
    public float displayImageDuration = 1f;
    float timerThing;

    public CountdownTimer timer; 
    // Journal entry text
    public TextAsset[] entries;
    
    // Is journal unlocked
    public bool journal = false;
    bool jState;
    
    // Current index of unlocked for page being read
    public int currIndex = 0;
    
    // Which entries have been unlocked
    public List<int> unlocked = new List<int>();
    List<int> uState;

    // Inventory cap
    public int inCap = 9;

    // Inventory
    public InventorySlot[] slots;

    // Checks if player is in build area
    public bool isin = false;

    // Build area player is in
    public Build builder;

    private void Awake()
    {
        // First entry is always unlocked, the rest start locked
        unlocked.Add(0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // Call at start of each level to update restart point
    public void UpdateState()
    {
        jState = journal;
        uState = new List<int>(unlocked);
    }

    // Called at the end of the level to reset progress
    private void ClearProgress()
    {
        //journal = jState; (If we change to per level restart)
        journal = false;
        unlocked = new List<int>(uState);
        currIndex = 0;
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        ClearProgress();
        // End Game Image Displayed in GameEnd script!
        Restart();
        

    }

    /*
    public void FoundJournal()
    {
        
    }
    */

    public void Restart()
    {

        SceneManager.LoadScene("StartScene"); // Give user option to choose to play again instead of loading them right back into the game

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public CountdownTimer timer; 
    // Journal entry text
    public TextAsset[] entries;
    
    // Is journal unlocked
    public bool journal = false;
    
    // Current index of unlocked for page being read
    public int currIndex = 0;
    
    // Which entries have been unlocked
    public List<int> unlocked = new List<int>();

    // Inventory cap
    public int inCap = 9;

    // Inventory
    public InventorySlot[] slots;

    public bool gameHasEnded = false; 
    
    private void Awake()
    {
        // First entry is always unlocked, the rest start locked
        unlocked.Add(0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            /*
            if (timer.currentSeconds < 0f)
            {
                // Load the Ending Screen
            }
            */
            gameHasEnded = true;
            Debug.Log("Game Over");
            Restart();
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}

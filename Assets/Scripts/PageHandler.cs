using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PageHandler : MonoBehaviour
{
    public Text J_Text;
    public GameObject nextB;
    public GameObject prevB;

    GameManager gmScr;
    int index;
    int page;

    // Start is called before the first frame update
    void Start()
    {
        gmScr = gameObject.GetComponent<ItemHandler>().GetManager();
        index = gmScr.currIndex;
        page = gmScr.unlocked[index];
        J_Text.text = gmScr.entries[page].text;
        CheckButtons();

    }

    // Turns to next or previous page
    public void PageTurn(int dir)
    {
        // Increment page and check if it exists
        index += dir;
        if (index >= 0 && index < gmScr.unlocked.Count)
        {
            page = gmScr.unlocked[index];
            J_Text.text = gmScr.entries[page].text;
        // Incremented page didn't exist
        }
        else
        index -= dir;
        gmScr.currIndex = index;
        CheckButtons();
    }

    // Checks to see if pages have been unlocked
    // And enabled buttons to turn to them if so
    public void CheckButtons()
    {
        // Always have a prev unless on first page
        if (page > 0)
            prevB.SetActive(true);
        else
            prevB.SetActive(false);
        // Check if there is at least one more page
        if (page < gmScr.unlocked[gmScr.unlocked.Count - 1])
            nextB.SetActive(true);
        else
            nextB.SetActive(false);
        // Update index in case an earlier page was found
        index = gmScr.unlocked.IndexOf(page);
    }
}

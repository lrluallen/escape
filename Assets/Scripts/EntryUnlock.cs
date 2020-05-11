using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryUnlock : MonoBehaviour
{

    public int entryNum;
    bool locked = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && locked)
        {
            GameManager gmScr = other.GetComponent<ItemHandler>().GetManager();
            if (gmScr.journal)
            {
                // Can only unlock entry once
                locked = false;
                // Change from indexing starting at 1, to starting at 0
                entryNum = entryNum - 1;
                // Loop through all unlocked entries
                int len = gmScr.unlocked.Count;
                for (int i = 0; i < len; ++i)
                {
                    // Found where the entry belongs
                    if (entryNum < gmScr.unlocked[i])
                    {
                        // Insert entry
                        gmScr.unlocked.Insert(i, entryNum);
                        other.GetComponent<PageHandler>().CheckButtons();
                        return;
                    }
                }
                // Entry belongs at end
                gmScr.unlocked.Add(entryNum);
                other.GetComponent<PageHandler>().CheckButtons();
            }

        }
    }
}

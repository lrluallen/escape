using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryUnlock : MonoBehaviour
{

    public int entryNum;
    bool locked = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<ItemHandler>().gmScr.journal && locked)
        {
            print("Unlocking entry");
            other.GetComponent<ItemHandler>().gmScr.unlocked[entryNum] = true;
            locked = false;
        }
    }
}

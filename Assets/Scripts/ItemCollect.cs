﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    // Item name
    public string Identity;
    // Item image
    public Sprite icon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Pick up object
            gameObject.SetActive(false);
            other.GetComponent<ItemHandler>().processItem(Identity, this);
            
        }
    }
}

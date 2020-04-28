using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    // Item name
    public string Identity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<ItemHandler>().processItem(Identity);
            gameObject.SetActive(false);
        }
    }
}

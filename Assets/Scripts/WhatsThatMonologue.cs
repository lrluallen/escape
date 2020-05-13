using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhatsThatMonologue : MonoBehaviour
{
    public GameObject monologueObject4; // JournalActivateText
    // Start is called before the first frame update
    void Start()
    {
        monologueObject4.SetActive(false);
        // Bottle script destroys bottle text object, so no need to deactivate anything in start

    }
    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            monologueObject4.SetActive(true); // Show tent / fire script
        }
    }

    void OnTriggerExit(Collider player)
    {
        monologueObject4.SetActive(false); // Show tent / fire script
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        
        Destroy(gameObject);

    }
}

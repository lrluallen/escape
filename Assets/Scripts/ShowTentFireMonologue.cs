﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTentFireMonologue : MonoBehaviour
{
    public GameObject monologueObject2;
    // Start is called before the first frame update
    void Start()
    {
       monologueObject2.SetActive(false);
        // Bottle script destroys bottle text object, so no need to deactivate anything in start

    }
    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        //monologueObject2.SetActive(true); //activate
        if (player.gameObject.tag == "Player")
        {

            //StartCoroutine("WaitForSec");
            monologueObject2.SetActive(true); // Show tent / fire script
            //StartCoroutine("WaitForSec");
            //monologueObject2.SetActive(false);
        }
    }

    void OnTriggerExit(Collider player)
    {
        monologueObject2.SetActive(false);
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(monologueObject2);
        Destroy(gameObject);

    }
}

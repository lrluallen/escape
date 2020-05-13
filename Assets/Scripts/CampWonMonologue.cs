using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CampWonMonologue : MonoBehaviour
{
    public GameObject monologueImage; // JournalActivateText
    public GameObject monologueObject5;
    // Start is called before the first frame update
    void Start()
    {
        monologueObject5.SetActive(false);
        monologueImage.SetActive(false);
        // Bottle script destroys bottle text object, so no need to deactivate anything in start

    }
    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            //monologueObject.SetActive(true);
            //StartCoroutine("WaitForSec");
            monologueImage.SetActive(true);
            monologueObject5.SetActive(true);
            
        }
    }

    void OnTriggerExit(Collider player)
    {
        SceneManager.LoadScene("CaveScene");
    }
}


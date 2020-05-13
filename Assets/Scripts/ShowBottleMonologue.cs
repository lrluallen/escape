using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBottleMonologue : MonoBehaviour
{
    public GameObject monologueObject; 
    // Start is called before the first frame update
    void Start()
    {
        //monologueObject.SetActive(false);
        // Tested deactivated and it works, so now we just keep our default active :)

    }
    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            //monologueObject.SetActive(true);
            //StartCoroutine("WaitForSec");
            monologueObject.SetActive(false);
            Destroy(monologueObject);
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        
      
    }
}

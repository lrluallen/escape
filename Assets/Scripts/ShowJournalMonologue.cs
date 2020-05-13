using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowJournalMonologue : MonoBehaviour
{
    public GameObject monologueObject3; // JournalActivateText
    // Start is called before the first frame update
    void Start()
    {
        monologueObject3.SetActive(false);
        // Bottle script destroys bottle text object, so no need to deactivate anything in start

    }
    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            monologueObject3.SetActive(true); // Show tent / fire script
        }
    }

    void OnTriggerExit(Collider player)
    {
        monologueObject3.SetActive(false);
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(monologueObject3);
        Destroy(gameObject);

    }
}

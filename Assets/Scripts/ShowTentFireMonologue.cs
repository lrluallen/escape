using System.Collections;
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
        if (player.gameObject.tag == "Player")
        {
            monologueObject2.SetActive(true); // Show tent / fire script
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(monologueObject2);
        Destroy(gameObject);

    }
}

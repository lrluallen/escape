using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnEnter : MonoBehaviour
{
    bool dead = false;
    bool play = true;
    CountdownTimer timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timer = other.gameObject.GetComponent<CountdownTimer>();
            dead = true;
        }
    }
    private void Update()
    {
        if(dead)
            play = timer.EndLevel(play);
    }
}

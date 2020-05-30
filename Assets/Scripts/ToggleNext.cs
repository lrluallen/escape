using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNext : MonoBehaviour
{
    public GameObject[] targets;
    // Set when you want toggles to happen
    public bool onEnter = true;
    public bool onExit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (onEnter && other.tag == "Player")
        {
            Toggle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (onExit && other.tag == "Player")
        {
            Toggle();
        }
    }

    void Toggle()
    {
        for (int i = 0; i < targets.Length; ++i)
            // Toggle active status
            targets[i].SetActive(!targets[i].activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNext : MonoBehaviour
{
    public GameObject[] targets;
    public bool onEnter;
    public bool onExit;

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
            targets[i].SetActive(!targets[i].activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_preload : MonoBehaviour
{
    private void Awake()
    {
        GameObject check = GameObject.Find("__init");
        if(check == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
}

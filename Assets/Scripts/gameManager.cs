using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public TextAsset[] entries;

    public bool journal = false;
    public int currPage = 0;
    public List<bool> unlocked = new List<bool>();

    private void Awake()
    {
        unlocked.Add(true);
        for (int i = 1; i < entries.Length; ++i)
        {
            unlocked.Add(false);
        }
            
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}

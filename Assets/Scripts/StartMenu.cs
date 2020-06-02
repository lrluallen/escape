using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // have to add 2 to skip loading the StartScreen in the Build Menu 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4); // have to add 2 to skip loading the StartScreen in the Build Menu 

    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartScene");
    }
  
}

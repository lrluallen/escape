using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused) // game is paused, so call resume
            {
                Resume();
            }
            else // Game is not paused yet, so call pause
            {
                Pause();
            }
        }


    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);// take away oause menu
        Time.timeScale = 1f; // resume game time
        GameIsPaused = false; // take away pause menu UI

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);// show pause menu
        Time.timeScale = 0f; // freeze gametime
        GameIsPaused = true; // show game is paused
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game Now... So long, and thanks for all the fish!");
        Application.Quit();
    }

}

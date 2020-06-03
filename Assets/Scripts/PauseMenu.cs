using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Text sensitivityText;
    public int increment = 5;

    GameObject playerObj;
    GameManager gmScr;
    MouseLook mouse;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        gmScr = playerObj.GetComponent<ItemHandler>().GetManager();
        mouse = playerObj.transform.GetChild(1).GetComponent<MouseLook>();
        sensitivityText.text = "Mouse Sensitivity: " + gmScr.sensitivity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
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

    public void ReduceSensitivity()
    {
        if(gmScr.sensitivity > 0)
        {
            gmScr.sensitivity -= increment;
            sensitivityText.text = "Mouse Sensitivity: " + gmScr.sensitivity.ToString();
        }
    }

    public void AddSensitivity()
    {
        gmScr.sensitivity += increment;
        sensitivityText.text = "Mouse Sensitivity: " + gmScr.sensitivity.ToString();
    }

    public void Resume()
    {
        if (mouse.moveState)
            Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);// take away oause menu
        Time.timeScale = 1f; // resume game time
        GameIsPaused = false; // take away pause menu UI

    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
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

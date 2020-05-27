﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float currentSeconds = 0f;
    public float startingSeconds = 300f;
    public Text countdownText;
    public int mLeft;
    string Mins;

    public float timer;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f; 

    // manager script
    GameManager gmScr;
    public CanvasGroup endScreenImageCanvasGroup; 
    // Start is called before the first frame update
    void Start()
    {
        endScreenImageCanvasGroup.alpha = 0; // Don't show fail screen right away
        gmScr = gameObject.GetComponent<ItemHandler>().GetManager();
        currentSeconds = startingSeconds;


    }

    // Update is called once per frame
    void Update()
    {
        if (currentSeconds <= 0f) //don't let it drop negative
        {
            currentSeconds = 0f; //don't let it drop negative
            // Want to end game here
            //FindObjectOfType<GameManager>().EndGame();
            //endScreenImage.SetActive(true);

            //gmScr.EndGame(); // WILL DISPLAY ENDING SCENE AND RESTART LEVEL
            EndCampLevel();
        }

        else if (currentSeconds <= 20f) // display the warning for 20 seconds
        {
            currentSeconds -= 1f * Time.deltaTime; // calcualte current seconds
            countdownText.text = "HURRY! YOU HAVE " + currentSeconds.ToString("0") + " SECONDS LEFT!\n"; //display the 20 second warning first

        }



        else // currentSeconds > 20f
        {
            // else, just calcualte the current seconds 
            currentSeconds -= 1f * Time.deltaTime;
            // How many minutes left, +1 since <1 == 1 minute left generally 
            mLeft = ((int)currentSeconds / 60) + 1;

            if (mLeft <= 0)
            {
                countdownText.text = "YOU HAVE LESS THAN ONE MINUTE LEFT!\n";
            }
           
            // Check if Minute should be plural or not
            Mins = mLeft <= 1 ? " MINUTE LEFT!" : " MINUTES LEFT!"; // Ohhhh look at the ternary operator...
            countdownText.text = "YOU HAVE " + mLeft.ToString("0") + Mins;

        }
        void EndCampLevel()
        {
            timer += Time.deltaTime;
            endScreenImageCanvasGroup.alpha = timer / fadeDuration;
            if (timer > fadeDuration + displayImageDuration)
            {
                SceneManager.LoadScene("StartScene");

            }

        }

    }
}

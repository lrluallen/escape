using System.Collections;
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

    // manager script
    GameManager gmScr;

    // Start is called before the first frame update
    void Start()
    {
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
            FindObjectOfType<GameManager>().EndGame();
            gmScr.EndGame(); // WILL DISPLAY ENDING SCENE AND RESTART LEVEL
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

    }
}

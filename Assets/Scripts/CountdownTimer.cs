using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float currentSeconds = 25f;
    public float startingSeconds = 25f;
    public Text countdownText;
    public int mLeft;
    string Mins;

    // manager script
    gameManager gmScr;

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
            countdownText.text = currentSeconds.ToString("0") + "\nYOU'VE FAILED TO FLY THE COOP!\n";
            gmScr.EndGame();
        }
        

        if (currentSeconds <= 21f) // display the warning for 20 seconds
        {
            currentSeconds -= 1f * Time.deltaTime; // calcualte current seconds
            countdownText.text = "\nHURRY! YOU HAVE " + "00:" + currentSeconds.ToString("0") + " LEFT!\n"; //display the 20 second warning first

        }

        else // currentSeconds > 21f
        {
            // else, just calcualte the current seconds 
            currentSeconds -= 1f * Time.deltaTime;
            // How many minutes left, +1 since <1 == 1 minute left generally 
            mLeft = ((int)currentSeconds / 60) + 1;
           
            // Check if Minute should be plural or not
            Mins = mLeft <= 1 ? " MINUTE LEFT!" : " MINUTES LEFT!"; // Ohhhh look at the ternary operator...
            countdownText.text = "\nYOU HAVE " + mLeft.ToString("0") + Mins;

        }

    }
}

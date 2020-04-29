using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float currentSeconds = 0f;
    public float startingSeconds = 300f;
    public Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentSeconds = startingSeconds;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSeconds <= 0f) //don't let it drop negative
        {
            currentSeconds = 0f;
            countdownText.text = currentSeconds.ToString("0") + "\nYOU'VE MET WITH A TERRIBLE FATE\nHAVEN'T YOU?";
        }

        else if (currentSeconds > 0f && currentSeconds < 10f) //don't let it drop to below 10 seconds without a padding zero
        {
            currentSeconds -= 1f * Time.deltaTime;
            countdownText.text = "0" + currentSeconds.ToString() + "\nYOU BETTER RUNNNNN!";
        }

        else
        {
            // else, just calcualte the current seconds 
            currentSeconds -= 1f * Time.deltaTime;
            // How many minutes left, +1 since <1 == 1 minute left generally 
            int mLeft = ((int) currentSeconds / 60) + 1;
            string Mins;
            // Check if Minute should be plural or not
            Mins = mLeft <= 1 ? " MINUTE LEFT!" : " MINUTES LEFT!"; //
            countdownText.text = currentSeconds.ToString("0") + "\nYOU HAVE " + mLeft.ToString() + Mins;
            
        }

    }
}

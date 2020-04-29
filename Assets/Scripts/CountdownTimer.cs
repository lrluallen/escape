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
        if (currentSeconds < 0f) //don't let it drop negative
        {
            currentSeconds = 0f;
            countdownText.text = currentSeconds.ToString("0") + "\nYOU HAVE FIVE MINUTES!";
        }

        if (currentSeconds < 10f) //don't let it drop to below 10 seconds eithout a padding zero
        {
            currentSeconds -= 1f * Time.deltaTime;
            countdownText.text = "0" + currentSeconds.ToString();
        }

        else
        {
            // else, just calcualte the current seconds 
            currentSeconds -= 1f * Time.deltaTime;
            countdownText.text = currentSeconds.ToString("0") + "\nYOU HAVE FIVE MINUTES!";
            
        }
        countdownText.text = currentSeconds.ToString("0") + "\nYOU HAVE FIVE MINUTES!";

    }
}

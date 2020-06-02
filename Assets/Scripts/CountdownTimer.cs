using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip loseSound;
    public float currentSeconds = 0f;
    public float startingSeconds = 300f;
    public float maskSeconds = 300f;
    public Text countdownText;
    public Text timeTakenText;
    public int mLeft;
    string Mins;

    public float timer;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    bool playSound = true;
    float speedTime = 0;

    // manager script
    GameManager gmScr;
    public CanvasGroup endScreenImageCanvasGroup; 
    // Start is called before the first frame update
    void Start()
    {
        endScreenImageCanvasGroup.alpha = 0; // Don't show fail screen right away
        endScreenImageCanvasGroup.interactable = false;
        endScreenImageCanvasGroup.blocksRaycasts = false; // Won't block UI buttons
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
            playSound = EndLevel(playSound);
        }

        else if (currentSeconds <= 30f) // display the warning for 30 seconds
        {
            currentSeconds -= 1f * Time.deltaTime; // calcualte current seconds
            countdownText.text = "HURRY! YOU HAVE " + currentSeconds.ToString("0") + " SECONDS LEFT!\n"; //display the 20 second warning first

        }



        else // currentSeconds > 30f
        {
            // else, just calcualte the current seconds 
            currentSeconds -= 1f * Time.deltaTime;
            
            // How many minutes left, +1 since <1 == 1 minute left generally 
            mLeft = ((int)currentSeconds / 60) + 1;

            // Check if Minute should be plural or not
            Mins = mLeft <= 1 ? " MINUTE LEFT!" : " MINUTES LEFT!"; // Ohhhh look at the ternary operator...
            countdownText.text = "YOU HAVE " + mLeft.ToString() + Mins;

        }
        timeTakenText.text = string.Format("Time Taken: {0:D2}:{1:D2}", (int)speedTime / 60, (int)speedTime % 60);
        speedTime += 1f * Time.deltaTime;
        
    }

    public bool EndLevel(bool play)
    {
        if (play) // play lose sound
        {
            if (loseSound)
                soundSource.PlayOneShot(loseSound, 1);
            play = false;
        }
        endScreenImageCanvasGroup.interactable = true;
        endScreenImageCanvasGroup.blocksRaycasts = true; // Image can block UI now
        timer += Time.deltaTime;
        endScreenImageCanvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration)
        {
            gmScr.ClearProgress(); // Reset progress
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload this level
        }
        return play;
    }

    public void UpdateScores()
    {
        //Debug.Log("updating score");
        gmScr.speeds[gmScr.currentLevel] = Mathf.Min((int)speedTime, gmScr.speeds[gmScr.currentLevel]);
        gmScr.currentLevel = (gmScr.currentLevel + 1) % gmScr.levelCount;
    }

    public void FoundMask()
    {
        currentSeconds = maskSeconds;
    }
}

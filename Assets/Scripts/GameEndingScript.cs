using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingScript : MonoBehaviour
{
    public float fadeDuration = 1f; // fade duration is initialized to one second
    public GameObject player; // to see if we collided
                              /* public bool foundJournal = false; This condition should be met to ensure our player can't just skip the level without the journal in the final build */
    public CanvasGroup BackgroundImageCanvasGroup; // Image to fade in
    public string sceneToLoad; // Scene to be loaded
    public bool finalLevel = false; // If this is the final level (and journal should be reset)
    float timer;
    public float displayImageDuration = 1f; // How long the image displays
    bool gameEnded = false;
    CountdownTimer timeScr; // For updating high(low) score
    GameManager gmScr; // For resetting journal on final level

    private void Awake()
    {
        // Make sure image doesn't mess up inventory buttons
        BackgroundImageCanvasGroup.blocksRaycasts = false;
        BackgroundImageCanvasGroup.interactable = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Get scripts from player character
            timeScr = player.GetComponent<CountdownTimer>();
            gmScr = player.GetComponent<ItemHandler>().GetManager();
            // Make image block inventory now/be interactable
            BackgroundImageCanvasGroup.blocksRaycasts = true;
            BackgroundImageCanvasGroup.interactable = true;
            gameEnded = true;
        }

    }

    public void Update()
    {
        if (gameEnded)
            EndLevel();
    }

    void EndLevel()
    {
        // Update high(low) scores
        timeScr.UpdateScores();
        timer += Time.deltaTime;
        BackgroundImageCanvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration)
        {
            if (finalLevel)
                gmScr.ClearProgress(); // Reset Journal
            SceneManager.LoadScene(sceneToLoad); // Load next scene

        }

    }
}
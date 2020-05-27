using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingCave : MonoBehaviour
{
    public float fadeDuration = 1f; // fade duration is initialized to one second
    public GameObject player; // to see if we collided
                              /* public bool foundJournal = false; This condition should be met to ensure our player can't just skip the level without the journal in the final build */
    bool isPlayerAtRock = false;
    public CanvasGroup caveExitBackgroundImageCanvasGroup;
    float timer;
    public float displayImageDuration = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtRock = true;

        }

    }

    void Update()
    {
        if (isPlayerAtRock)
        {
            EndLevel();

        }


    }

    void EndLevel()
    {
        timer += Time.deltaTime;
        caveExitBackgroundImageCanvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration)
        {
            SceneManager.LoadScene("OceanScene");

        }
        

    }
}

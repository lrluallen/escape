using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text speedsText;
    GameObject initObj;
    GameManager gmScr;

    // Start is called before the first frame update
    void Start()
    {
        initObj = GameObject.FindGameObjectWithTag("Init");
        gmScr = initObj.GetComponent<GameManager>();
        string speedVals = "Top Speeds:\n";
        for (int i = 0; i < gmScr.speeds.Length; ++i)
        {
            speedVals += string.Format("Level {0} | {1:D2}:{2:D2} |\n", i, gmScr.speeds[i]/60, gmScr.speeds[i] % 60);
        }
        speedsText.text = speedVals;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

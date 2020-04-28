using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{

    // Gameobject with game manager script
    GameObject initObj;
    // manager script
    gameManager gmScr;
    // journal open/close button
    public GameObject J_OpenClose;
    // Start is called before the first frame update
    void Start()
    {
        initObj = GameObject.FindGameObjectWithTag("Init");
        gmScr = initObj.GetComponent<gameManager>();
        // set state of button
        J_OpenClose.SetActive(gmScr.journal);
    }

    // Function so other scripts can easily get at the game manager script
    public gameManager GetManager()
    {
        return gmScr;
    }
    
    // Processes picked up items
    public void processItem(string item)
    {
        switch (item)
        {
            case "Journal":
                gmScr.journal = true;
                J_OpenClose.SetActive(true);
                break;
            default:
                break;
        }
    }

}

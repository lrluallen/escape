using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{

    GameObject initObj;
    public gameManager gmScr;
    public GameObject J_OpenClose;
    // Start is called before the first frame update
    void Start()
    {
        initObj = GameObject.FindGameObjectWithTag("Init");
        gmScr = initObj.GetComponent<gameManager>();
        J_OpenClose.SetActive(gmScr.journal);
    }

    // Update is called once per frame
    void Update()
    {
        if (gmScr.journal)
        {
            J_OpenClose.SetActive(true);
        }
    }
    public void processItem(string item, int index=0)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PageHandler : MonoBehaviour
{
    public Text pTxt;
    public TextAsset entry;
    public GameObject nextB;
    public GameObject prevB;

    GameObject initObj;
    gameManager mScr;
    int page;
    int length;

    // Start is called before the first frame update
    void Start()
    {
        initObj = GameObject.FindGameObjectWithTag("Init");
        mScr = initObj.GetComponent<gameManager>();
        page = mScr.currPage;
        pTxt.text = mScr.entries[page].text;
        length = mScr.entries.Length;
        CheckButtons();

    }

    public void FixedUpdate()
    {
        CheckButtons();
    }

    public void PageTurn(int dir)
    {
        page += dir;
        if (page >= 0 && page < length && mScr.unlocked[page])
            pTxt.text = mScr.entries[page].text;
        else
            page -= dir;
        mScr.currPage = page;
        CheckButtons();
    }

    void CheckButtons()
    {
        if (page + 1 < length && mScr.unlocked[page + 1])
            nextB.SetActive(true);
        else
            nextB.SetActive(false);
        if (page > 0 && mScr.unlocked[page - 1])
            prevB.SetActive(true);
        else
            prevB.SetActive(false);

    }
}

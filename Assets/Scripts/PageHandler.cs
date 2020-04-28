using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PageHandler : MonoBehaviour
{
    public Text J_Text;
    public GameObject nextB;
    public GameObject prevB;

    GameObject initObj;
    gameManager gmScr;
    int page;
    int length;

    // Start is called before the first frame update
    void Start()
    {
        initObj = GameObject.FindGameObjectWithTag("Init");
        gmScr = initObj.GetComponent<gameManager>();
        page = gmScr.currPage;
        J_Text.text = gmScr.entries[page].text;
        length = gmScr.entries.Length;
        CheckButtons();

    }

    public void FixedUpdate()
    {
        CheckButtons();
    }

    public void PageTurn(int dir)
    {
        page += dir;
        if (page >= 0 && page < length && gmScr.unlocked[page])
            J_Text.text = gmScr.entries[page].text;
        else
            page -= dir;
        gmScr.currPage = page;
        CheckButtons();
    }

    void CheckButtons()
    {
        if (page + 1 < length && gmScr.unlocked[page + 1])
            nextB.SetActive(true);
        else
            nextB.SetActive(false);
        if (page > 0 && gmScr.unlocked[page - 1])
            prevB.SetActive(true);
        else
            prevB.SetActive(false);

    }
}

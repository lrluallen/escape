using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasControl : MonoBehaviour
{
    public CanvasGroup[] groups;
    int length;

    public void Awake()
    {
        // Make sure all canvas start invisible
        length = groups.Length;
        for (int i = 0; i < length; ++i)
        {
            groups[i].alpha = 0f;
            groups[i].interactable = false;
            groups[i].blocksRaycasts = false;
        }
    }

    public void ToggleHandler(CanvasGroup cGrp)
    {
        // Toggle desired group, and make sure rest are off
        for (int i = 0; i < length; ++i)
        {
            if (groups[i].alpha == 1 || groups[i] == cGrp)
            {
                ToggleGroup(groups[i]);
            }
        }
    }

    void ToggleGroup(CanvasGroup cGrp)
    {
        cGrp.alpha = (cGrp.alpha + 1) % 2;
        cGrp.interactable = !cGrp.interactable;
        cGrp.blocksRaycasts = !cGrp.blocksRaycasts;
    }
}

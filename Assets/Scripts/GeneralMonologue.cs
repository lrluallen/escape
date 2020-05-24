using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralMonologue : MonoBehaviour
{
    public Text monologueTextField;
    public bool persists;
    //[TextArea(int minLines, int maxLines)];
    [TextArea(10,15)]
    public string text;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            monologueTextField.text = text;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!persists)
                monologueTextField.text = "";
        }

    }
}

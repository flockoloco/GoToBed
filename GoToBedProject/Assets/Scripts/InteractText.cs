using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractText : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject parentObject;
    public void ChangeText(string text)
    {
        parentObject.SetActive(true);
        textBox.text = text;
        //maybe add keys
    }
    public void ChangeText(bool activate )
    {
       
            parentObject.SetActive(activate);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private bool cycleDone = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!cycleDone) text.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            DisableText();
        }
    }


    public void GrabAHat()
    {
        text.text = "Grab a hat.";       
    }

    public void PutTheHatOnYourHead()
    {
        text.text = "Put the hat on your head.";        
    }

    public void DisableText()
    {
        text.enabled = false;
    }

    public void EndOfCycle()
    {
        cycleDone = true;
        DisableText();
    }







}

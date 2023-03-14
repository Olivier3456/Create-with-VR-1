using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = false;
        }
    }


    public void GrabAHat()
    {
        text.text = "text.text = Grab a hat.";
        Debug.Log("Grab a hat.");
    }

    public void PutTheHatOnYourHead()
    {
        text.text = "Put the hat on your head.";
        Debug.Log("text.text = Put the hat on your head.");
    }

    





}

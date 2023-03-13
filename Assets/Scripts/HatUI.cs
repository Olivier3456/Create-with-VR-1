using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    

    public void GrabAHat()
    {
        text.text = "Grab a hat.";
    }

    public void PutTheHatOnYourHead()
    {
        text.text = "Put the hat on your head.";
    }

    public void NoText()
    {
        text.text = "";
    }

   
}

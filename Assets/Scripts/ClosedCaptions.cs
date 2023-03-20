using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class ClosedCaptions : MonoBehaviour
{
    [SerializeField] private float[] timeIn;
    [SerializeField] private float[] timeOut;
    [SerializeField] private string[] caption;

    [SerializeField] private TextMeshProUGUI captionsText;

    [SerializeField] VideoPlayer videoPlayer;

    private int index = 0;

    private double time;

    void Update()
    {
        time = videoPlayer.time;

        if (time > timeIn[index]) captionsText.text = caption[index];
        if (time > timeOut[index])
        {
            captionsText.text = "";          

            if (index >= caption.Length - 1) index = 0;
            else index++;
        }
    }
}

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

    private bool indexChanged = false;

    void Update()
    {
        if (videoPlayer.time > timeIn[index] && videoPlayer.time < timeOut[index])
        {
            captionsText.text = caption[index];
            indexChanged = false;
        }
        else if (videoPlayer.time >= timeOut[index])
        {
            captionsText.text = "";

            if (!indexChanged)
            {
                if (index >= caption.Length - 1) index = 0;
                else index++;
                indexChanged = true;
            }
        }

        if (!videoPlayer.isPlaying) captionsText.text = "";
    }
}

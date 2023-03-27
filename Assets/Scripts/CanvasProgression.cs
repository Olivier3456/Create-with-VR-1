using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasProgression : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI boxesText;
    [SerializeField] private TextMeshProUGUI timeText;

    private int _deliveredBoxes = 0;
    private float _startTime = 0;

    private bool _gameStarted = false;

    
    void Update()
    {
        if (_gameStarted)
        {
            float t = Time.time - _startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");

            if (t >= 60)
            {
                timeText.text = minutes + "m " + seconds + "s";
            }
            else
            {
                timeText.text = "Time: " + seconds + "s";
            }

        }
    }


    public void StartGame()
    {
        _gameStarted = true;
        _startTime = Time.time;
    }



    public void AddBoxToDeliveredBoxesCount(Collider collider)
    {
        collider.gameObject.tag = "Finish";
        _deliveredBoxes++;
        boxesText.text = _deliveredBoxes + "/10";
    }
}

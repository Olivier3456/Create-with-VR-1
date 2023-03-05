using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private Transform hoursHand;
    [SerializeField] private Transform minutesHand;
    [SerializeField] private Transform secondsHand;

    private int hour;
    private int minute;
    private int second;

    void Start()
    {
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        
        secondsHand.Rotate(secondsHand.right, second * 6);
        minutesHand.Rotate(minutesHand.right, minute * 6);       
        hoursHand.Rotate(hoursHand.right, hour * 30);
    }



    void Update()
    {
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
               

        Quaternion rotation = Quaternion.identity;

        rotation.eulerAngles = new Vector3(second * 6, 0, 0);
        secondsHand.rotation = rotation;

        rotation.eulerAngles = new Vector3(minute * 6, 0, 0);
        minutesHand.rotation = rotation;

        rotation.eulerAngles = new Vector3(hour * 30, 0, 0);
        hoursHand.rotation = rotation;       
    }
}

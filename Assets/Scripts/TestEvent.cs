using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestEvent : MonoBehaviour
{
    event Action<int> OnActionedInt;
    event Action<int, bool, string[]> otherEvent;
   

    void Start()
    {
        OnActionedInt?.Invoke(5);
        otherEvent?.Invoke(45, true, new string[2]);
        
    }

}

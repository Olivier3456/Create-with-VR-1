using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class RotatePiedestal : MonoBehaviour
{    
    public void Rotation(float value)
    {
        GameObject[] objectsToRotate = GameObject.FindGameObjectsWithTag("ObjectToRotate");
        Quaternion newRotation = Quaternion.Euler(0f, value, 0f);
        if (objectsToRotate.Length > 0) objectsToRotate[0].transform.rotation = newRotation;
    }
}

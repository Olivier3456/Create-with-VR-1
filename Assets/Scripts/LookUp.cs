using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUp : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(transform.up);
    }
}

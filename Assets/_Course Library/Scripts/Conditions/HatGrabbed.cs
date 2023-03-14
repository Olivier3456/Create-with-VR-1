using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HatGrabbed : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable hatXRGrab;

    [SerializeField] UnityEvent grabbed;


    // Don't forget to call this method in the Select Exited event of the XR Grab Interactable component of the door!!!!
    public void Grabbed(SelectEnterEventArgs interactor)
    {
        if (interactor.interactorObject.transform.name == "LeftHand Controller"
         || interactor.interactorObject.transform.name == "RightHand Controller")
        {
            grabbed.Invoke();
        }
    }
}

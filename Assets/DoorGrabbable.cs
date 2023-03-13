using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorGrabbable : MonoBehaviour
{
    [SerializeField] private Transform handler;

    [SerializeField] private XRGrabInteractable doorXRGrab;

    [SerializeField] private float maxDistance = 0.1f;

    private Transform handGrabbing;


    // Don't forget to call this method in the Select Exited event of the XR Grab Interactable component of the door!!!!
    public void Grabbed(SelectEnterEventArgs interactor)
    {
        handGrabbing = interactor.interactorObject.transform;
    }


    private void Update()
    {
        if (handGrabbing != null && Vector3.Distance(handler.position, handGrabbing.position) > maxDistance)      // Drops the handle if the hand moves too far away.
        {
            doorXRGrab.enabled = false;
            doorXRGrab.enabled = true;
            handGrabbing = null;   
        }
    }
}

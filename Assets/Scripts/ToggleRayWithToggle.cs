using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleRayWithToggle : ToggleRay
{
    public void ToggleRay()
    {
        isSwitched = !isSwitched;
        rayInteractor.enabled = isSwitched;
        directInteractor.enabled = !isSwitched;
    }
}

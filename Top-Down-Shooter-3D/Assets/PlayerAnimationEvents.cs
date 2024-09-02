using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private WeaponVisualController visualController;

    private void Awake()
    {
        visualController = GetComponentInParent<WeaponVisualController>();
    }

    public void ReloadIsOver()
    {
        visualController.ReturnRigWeightToOne();

        // refill bullets;
    }

    public void ReturnRig()
    { 
        visualController.ReturnRigWeightToOne();
        visualController.ReturnLeftHandIKWeightToOne();
    }

    public void WeaponGrabIsOver()
    {
        visualController.SetBusyGrabbingMethodTo(false);
    }
}

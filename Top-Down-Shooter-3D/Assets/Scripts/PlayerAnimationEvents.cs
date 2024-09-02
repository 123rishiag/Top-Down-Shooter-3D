using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private PlayerWeaponVisuals visualController;

    private void Awake()
    {
        visualController = GetComponentInParent<PlayerWeaponVisuals>();
    }

    public void ReloadIsOver()
    {
        visualController.MaximizeRigWeight();

        // refill bullets;
    }

    public void ReturnRig()
    { 
        visualController.MaximizeRigWeight();
        visualController.MaximizeLeftHandIKWeight();
    }

    public void WeaponGrabIsOver()
    {
        visualController.SetBusyGrabbingMethodTo(false);
    }
}

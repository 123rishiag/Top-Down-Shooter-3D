using UnityEngine;

public class WeaponVisualController : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private Transform[] gunTransforms;

    [SerializeField] private Transform pistol;
    [SerializeField] private Transform revolver;
    [SerializeField] private Transform autoRifle;
    [SerializeField] private Transform shotgun;
    [SerializeField] private Transform sniperRifle;

    private Transform currentGun;

    [Header("Left Hand IK")]
    [SerializeField] private Transform leftHandTarget;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        SwitchOnGun(pistol);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchOnGun(pistol);
            SwitchAnimationLayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchOnGun(revolver);
            SwitchAnimationLayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchOnGun(autoRifle);
            SwitchAnimationLayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchOnGun(shotgun);
            SwitchAnimationLayer(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchOnGun(sniperRifle);
            SwitchAnimationLayer(3);
        }
    }

    private void SwitchOnGun(Transform gunTransform)
    {
        SwitchOffGuns();
        gunTransform.gameObject.SetActive(true);
        currentGun = gunTransform;
        AttachLeftHand();
    }

    private void SwitchOffGuns()
    {
        for (int i = 0; i < gunTransforms.Length; i++)
        {
            gunTransforms[i].gameObject.SetActive(false);
        }
    }

    private void AttachLeftHand()
    {
        Transform targetTransform = currentGun.GetComponentInChildren<LeftHandTargetTransform>().transform;

        leftHandTarget.localPosition = targetTransform.localPosition;
        leftHandTarget.localRotation = targetTransform.localRotation;
    }

    private void SwitchAnimationLayer(int layerIndex)
    {
        for (int i = 1; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(layerIndex, 1);
    }
}

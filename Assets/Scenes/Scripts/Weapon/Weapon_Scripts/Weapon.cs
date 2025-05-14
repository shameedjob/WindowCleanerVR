using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    [Header("Setup")]
    public GameObject projectilePrefab;
    public Transform muzzlePoint;

    [Header("Input")]
    [Tooltip("Drag your RightHand Trigger action here")]
    public InputActionProperty triggerAction;

    void OnEnable()
    {
        triggerAction.action.Enable();
    }

    void OnDisable()
    {
        triggerAction.action.Disable();
    }

    void Update()
    {
        var action = triggerAction.action;

        // 1) Fire once on the frame the trigger is first pressed
        if (action.triggered)
        {
            Fire();
        }

        // 2) Detect holding the trigger (value > 0.1f)
        float t = action.ReadValue<float>();
        bool isHeld = t > 0.1f;

        if (isHeld)
        {
            // you can put any "while held" logic here
            // e.g. animate UI, wind up a charge shot, etc.
        }
    }

    void Fire()
    {
        // instantiate at the muzzle, pointing down its local +Z
        var proj = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);

        if (proj.TryGetComponent<Rigidbody>(out var rb))
            rb.linearVelocity = muzzlePoint.forward * 20f;
    }
}

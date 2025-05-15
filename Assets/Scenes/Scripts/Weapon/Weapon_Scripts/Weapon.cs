using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzlePoint;
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
        // 'triggered' is true only on the frame the trigger crosses its press threshold
        if (triggerAction.action.triggered)
            Fire();
    }

    void Fire()
    {
        GameObject projObj = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
        Projectile proj = projObj.GetComponent<Projectile>();
        if (proj != null)
            proj.SetDirection(muzzlePoint.forward);
    }
}

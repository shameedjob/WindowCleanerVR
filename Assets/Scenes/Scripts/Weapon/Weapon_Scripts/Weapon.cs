using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzlePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // swap for your VR trigger
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

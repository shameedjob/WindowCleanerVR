using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzlePoint;
    public SimpleTimer timer;

    void Start()
    {
        timer.StartTimer();
    }

    void Update()
    {
    }

    public void Fire()
    {
        GameObject projObj = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
        Projectile proj = projObj.GetComponent<Projectile>();
        if (proj != null)
            proj.SetDirection(muzzlePoint.forward);
    }
}

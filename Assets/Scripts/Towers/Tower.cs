using UnityEngine;

public class Tower : MonoBehaviour
{
    public float towerRange = 5f;
    public float towerFireRate = .5f;
    public float projectileDamage = 1f;
    public float projectileSpeed = 30f;
    public float projectileLifespan = 10f;
    public float projectileSize = 0.1f;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;

    private float towerFireCooldown = 0f;
    private Transform target;

    void Update() {
        towerFireCooldown -= Time.deltaTime;

        if (towerFireCooldown <= 0f)
        {
            Shoot();
            towerFireCooldown = 1f / towerFireRate;
        }
    }

    void Shoot() {
        GameObject projectilleGO = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectile = projectilleGO.GetComponent<Projectile>();

        if (projectile != null) {
            projectile.SetSize(projectileSize);
            projectile.damage = projectileDamage;
            projectile.speed = projectileSpeed;
            projectile.lifespan = projectileLifespan;
            
            Vector3 direction = projectileSpawnPoint.forward;
            projectile.SetDirection(direction);
        }
    }
}

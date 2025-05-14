using UnityEngine;

public class Tower : MonoBehaviour
{
    public float towerRange = 10f;
    public float towerFireRate = .5f;
    public float projectileDamage = 1f;
    public float projectileSpeed = 30f;
    public float projectileLifespan = 100f;
    public float projectileSize = 0.1f;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public GameObject turretUI;
    public AudioSource src;
    public AudioClip shoot1, shoot2, shoot3, shoot4;

    private float towerFireCooldown = 0f;
    private Transform target;
    private AudioClip[] shootSounds;

    void Awake() {
        shootSounds = new AudioClip[] { shoot1, shoot2, shoot3, shoot4 };

        if (turretUI != null) {
            turretUI.SetActive(false);
        }
    }

    void Update() {
        towerFireCooldown -= Time.deltaTime;

        if (target != null) {
            RotateTowardsTarget();
        }

        if (towerFireCooldown <= 0f)
        {
            GetTarget();

            if (target != null) {
                Shoot();
            }

            towerFireCooldown = 1f / towerFireRate;
        }
    }

    void GetTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject nearestEnemy = null;
        float closestDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies) {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist < closestDist && dist <= towerRange) {
                closestDist = dist;
                nearestEnemy = enemy;
            }
        }

        target = nearestEnemy?.transform;        
    }

    void RotateTowardsTarget() {
        Vector3 direction = target.position - transform.position;

        // direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 100f); // You can adjust the speed here
    }

    void Shoot() {
        GameObject projectilleGO = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectile = projectilleGO.GetComponent<Projectile>();

        // Update the projectile parameters
        projectile.SetSize(projectileSize);
        projectile.damage = projectileDamage;
        projectile.speed = projectileSpeed;
        projectile.lifespan = projectileLifespan;
        
        Vector3 directionToTarget = (target.position - projectileSpawnPoint.position).normalized;
        projectile.SetDirection(directionToTarget);

        PlayShootSound();
    }

    void PlayShootSound() {
        int index = Random.Range(0, shootSounds.Length);
        
        src.clip = shootSounds[index];
        
        src.Play();
    }

    public void OnTurretTouched() {
        if (turretUI != null) {
            turretUI.SetActive(true);
        }
    }

    public void UpgradeDamage() => projectileDamage += 1f;
    public void UpgradeFireRate() => towerFireRate += 0.2f;
    public void UpgradeBulletSpeed() => projectileSpeed += 1f;
    public void UpgradeBulletLifespan() => projectileLifespan += 5f;
    public void UpgradeRange() => towerRange += 2f;
}

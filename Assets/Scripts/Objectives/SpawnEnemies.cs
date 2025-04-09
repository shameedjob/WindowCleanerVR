using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float enemySpeed = 3f;
    public float enemyHealth = 5f;
    public float spawnRate = .2f;
    public GameObject enemyPrefab;

    private float spawnCooldown = 0f;

    void Update() {
        spawnCooldown -= Time.deltaTime;

        if (spawnCooldown <= 0f) {
            SpawnEnemy();

            spawnCooldown = 1f / spawnRate;
        }
    }

    void SpawnEnemy() {
        GameObject enemyGO = Instantiate(enemyPrefab, transform.position, transform.rotation);
        Enemy enemy = enemyGO.GetComponent<Enemy>();

        // Update enemy parameters
        enemy.speed = enemySpeed;
        enemy.health = enemyHealth;

    }
}

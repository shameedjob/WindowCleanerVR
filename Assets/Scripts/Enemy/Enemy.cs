using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public float health = 5f;

    private EnemyNavMesh navMesh;

    void Awake() {
        navMesh = GetComponent<EnemyNavMesh>();
    }

    void Start() {
        navMesh.SetSpeed(speed);
    }

    public void TakeDamage(float damage) {
        health -= damage;

        if (health <= 0f) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

}

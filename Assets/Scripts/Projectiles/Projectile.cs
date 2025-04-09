using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    public float damage = 1f;
    public float lifespan = 1f;

    private Vector3 direction;

    void Awake() {
        Destroy(gameObject, lifespan);
    }

    void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        // Do an action towards enemy on contact
        if (collision.gameObject.CompareTag("enemy")) {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            // enemy.TakeDamage(damage);
        }

        Die();
    }

    public void SetDirection(Vector3 newDirection) {
        direction = newDirection.normalized;
    }

    public void SetSize(float size) {
        transform.localScale = Vector3.one * size;
    }   

    public void Die() {
        Destroy(gameObject);
    }
}

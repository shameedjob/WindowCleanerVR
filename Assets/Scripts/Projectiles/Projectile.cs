using UnityEditor.Experimental.GraphView;
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
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }

    public void SetSize(float size) {
        transform.localScale = Vector3.one * size;
    }   

    public void SetDirection(Vector3 newDirection) {
        direction = newDirection.normalized;
    }
}

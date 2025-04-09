using UnityEngine;

public class ReachedGoal : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Die();

            // This means the unit made it to the end and needs to damage player
        }
    }
}

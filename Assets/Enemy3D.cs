using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public AudioClip killSound;
    public float speed = 2.5f; 
    // public float health = 1f;

    void Update()
    {
        var direction  = new Vector3(0, 25, 0) - transform.position;
        if (direction.magnitude > 45){
            transform.position += direction.normalized*Time.deltaTime*speed;
        }
    }

    // public void TakeDamage(float damage) {
    //     health -= damage;

    //     if (health <= 0f) {
    //         Kill();
    //     }
    // }

    public void Kill(){

        Destroy(gameObject);

        // Play the kill sound at the object's position.
        if (killSound != null)
        {
            AudioSource.PlayClipAtPoint(killSound, transform.position);
        }
    }
}

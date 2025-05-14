using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public float speed = 2.5f;
    public AudioClip killSound;

    // Update is called once per frame
    void Update()
    {
        var closest  = LevelManager.instance.ClosestPosition(transform.position);
        var direction = closest - transform.position;
        transform.position += direction.normalized*Time.deltaTime*speed;
    }

    public void Kill(){

        Destroy(gameObject);
        if (killSound != null)
        {
            AudioSource.PlayClipAtPoint(killSound, transform.position);
        }
    }
}

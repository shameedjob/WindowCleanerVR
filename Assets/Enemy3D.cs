using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public float speed = 2.5f;
    public AudioClip killSound;

    // Update is called once per frame
    void Update()
    {
        var direction  = new Vector3(0, 25, 0) - transform.position;
        if (direction.magnitude > 30){
            transform.position += direction.normalized*Time.deltaTime*speed;
        }
    }

    public void Kill(){

        Destroy(gameObject);
        if (killSound != null)
        {
            AudioSource.PlayClipAtPoint(killSound, transform.position);
        }
    }
}

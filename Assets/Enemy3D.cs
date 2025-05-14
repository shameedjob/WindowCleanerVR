using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public float speed = 2.5f;
    public float health = 10;
    public int attackValue = 5;
    public SimpleTimer attackTimer;
    public AudioClip killSound;


    public void Start()
    {
        attackTimer.StartTimer();            
    }
    // Update is called once per frame
    void Update()
    {
        var closest  = LevelManager.instance.ClosestPosition(transform.position);
        var direction = closest - transform.position;
        transform.position += direction.normalized*Time.deltaTime*speed;
        transform.LookAt(closest);
        if (Vector3.Distance(closest, transform.position)<3){
            if(attackTimer.Finished()){
                Attack();
            }
        }
    }

    public void Attack(){
        LevelManager.instance.TakeDamage(attackValue);
    }

    public void Kill(){

        Destroy(gameObject);
        if (killSound != null)
        {
            AudioSource.PlayClipAtPoint(killSound, transform.position);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet")){
            health -= other.GetComponent<Projectile>().damage;
        }

        if (health == 0){
            Die();
        }
    }

    void Die(){
        //DO SOMETHING;
        Destroy(gameObject);
    }
}

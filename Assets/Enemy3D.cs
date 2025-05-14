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
        if (Vector3.Distance(closest, transform.position)<2.0){
            if(attackTimer.Finished()){
                Attack();
            }
        }
        else{
            transform.position += direction.normalized*Time.deltaTime*speed;
            transform.LookAt(closest);
        }
    }

    public void Attack(){
        LevelManager.instance.TakeDamage(attackValue);
        GetComponent<Animator>().SetTrigger("Attack");
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
            attackTimer.StartTimer();
            GetComponent<Animator>().SetTrigger("Damage");
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

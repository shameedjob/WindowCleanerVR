using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public float speed = 2.5f;
    public float health = 10;
    public GameObject deatheffect;
    public int attackValue = 5;
    public SimpleTimer attackTimer;
    public AudioClip killSound;

    public SimpleTimer damageTimer;
    bool grabbed = false;
    public void Start()
    {
        damageTimer = new SimpleTimer(1.0f, true);
        attackTimer.StartTimer();            
    }
    // Update is called once per frame
    void Update()
    {
        if(grabbed){
            if (damageTimer.Finished()){
                Damage(2);
            }
            return;
        }
        var closest  = LevelManager.instance.ClosestPosition(transform.position);
        var direction = closest - transform.position;
        
        if (Vector3.Distance(closest, transform.position)<2.0){
            if(attackTimer.Finished()){
                Attack();
            }
        }
        else{
            GetComponent<Rigidbody>().linearVelocity = Vector3.Lerp(GetComponent<Rigidbody>().linearVelocity, direction.normalized*speed, Time.deltaTime);
            // transform.position += direction.normalized*Time.deltaTime*speed;
            transform.LookAt(closest);
        }
    }

    public void Attack(){
        LevelManager.instance.TakeDamage(attackValue);
        GetComponent<Animator>().SetTrigger("Attack");
    }

    void Damage(int amount)
    {
        health -= amount;
        attackTimer.StartTimer();
        GetComponent<Animator>().SetTrigger("Damage");
        

        if (health == 0){
            Die();
        }
    }

    void Die(){
        if (killSound != null)
        {
            AudioSource.PlayClipAtPoint(killSound, transform.position);
        }
        //DO SOMETHING;
        var eff = Instantiate(deatheffect);
        eff.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void Grab(){
        grabbed = true;
        Damage(1);
    }

    public void Release(){
        grabbed = false;
        Damage(1);
    }
}

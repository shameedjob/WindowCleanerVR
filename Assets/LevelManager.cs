using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;
    public int score = 0;

    public HealthBar healthBar;

    // public List<Collider> buildings;
    public static LevelManager instance;

    void Start()
    {
        instance = this;
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);  
    }

    public Vector3 ClosestPosition(Vector3 source){
        var point = Vector3.zero;
        // print(source);
        var buildings = new List<Collider>();
        for(int i = 0; i < transform.childCount; i++){
            if(transform.GetChild(i).GetComponent<Collider>()){
                var n_p = transform.GetChild(i).GetComponent<Collider>().ClosestPoint(source);
                if (point == Vector3.zero){
                    point = n_p;
                }
                else if (Vector3.Distance(source, n_p) < Vector3.Distance(source, point)){
                    point = n_p;
                }
            }
        }
        return point;
    }

    public void TakeDamage(int damage_amount){
        currentHealth -= damage_amount;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Die();
        }
    }

    public void Die(){
        LevelSelectManager.instance.SelectLevel(0);
    }
}

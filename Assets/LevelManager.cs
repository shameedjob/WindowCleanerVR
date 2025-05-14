using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    // public List<Collider> buildings;
    public static LevelManager instance;

    void Start()
    {
        instance = this;
        print("HI");
        print(name);
    }

    public Vector3 ClosestPosition(Vector3 source){
        var point = Vector3.zero;
        print(instance.name);
        // print(source);
        var buildings = new List<Collider>();
        for(int i = 0; i < transform.childCount; i++){
            print(i);
            if(transform.GetChild(i).GetComponent<Collider>()){
                print("HERE");
                var n_p = transform.GetChild(i).GetComponent<Collider>().ClosestPoint(source);
                print(n_p);
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

    public float health = 100;

    public int score = 0;

    public void TakeDamage(int damage_amount){
        health -= damage_amount;

        if(health <= 0){
            Die();
        }
    }

    public void Die(){
        LevelSelectManager.instance.SelectLevel(0);
    }
}

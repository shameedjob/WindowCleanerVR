using UnityEngine;

public class EnemyControllerLiberty : MonoBehaviour
{
    public GameObject enemyObject;
    float a = 0;
    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        if (a > 5.0){
            a = 0;
            SummonEnemyLiberty();
        }
    }

    void SummonEnemyLiberty() 
    {
        var newEnemy = GameObject.Instantiate(enemyObject);
        Vector3 position;
        
        do {
            position = new Vector3(
                Random.Range(-50f, 50f),
                Random.Range(0f, 120f),
                Random.Range(-50f, 50f)
            );
        } 
        while (IsInExcludedZone(position));
        
        newEnemy.transform.position = position;
    }

    bool IsInExcludedZone(Vector3 pos)
    {
        return pos.x > -25f && pos.x < 25f && 
            pos.y > 0f && pos.y < 10f && 
            pos.z > -25f && pos.z < 25f;
    }

}
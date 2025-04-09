using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyObject;
    float a = 0;
    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        if (a > 5.0){
            a = 0;
            SummonEnemy();
        }
    }

    void SummonEnemy(){
        var newEnemy = GameObject.Instantiate(enemyObject);
        var r = 2*Mathf.PI*Random.value;
        var randomPosition = new Vector3( Mathf.Sin(r)*100, 30, Mathf.Cos(r)*100);
        newEnemy.transform.position = randomPosition;
    }
}

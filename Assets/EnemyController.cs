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
        Vector3 buildingBPosition = new Vector3(112f, 50, 0.331085f);
        var newEnemy = GameObject.Instantiate(enemyObject);
        float spawnRadius = 130f;
        // Generate a random angle (in radians) around the circle
        float r = 2 * Mathf.PI * Random.value;
        // Calculate the position offset using sin and cos, then add to Building B's position.
        Vector3 randomPosition = buildingBPosition + new Vector3(Mathf.Sin(r) * spawnRadius, 0f, Mathf.Cos(r) * spawnRadius);

        newEnemy.transform.position = randomPosition;
    }
}

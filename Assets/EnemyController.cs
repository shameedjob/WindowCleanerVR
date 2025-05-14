using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyObject;
    float a = 0;
    public Vector3 buildingBPosition = new Vector3(0, 25, 0);

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
        var points = TrackController.instance.GetTrackPoints();
        var sel = (int)(points.Length * Random.value);
        var ratio = Random.value;
        var point_a = points[sel];
        point_a += new Vector3(point_a.x, 0, point_a.z);
        var point_b = points[(sel+1)%points.Length];
        point_b += new Vector3(point_b.x, 0, point_b.z);
        var spawn_point = point_a*ratio  + point_b*(1-ratio);
        spawn_point += Vector3.up*(Random.value-0.5f)*5f;
        newEnemy.transform.position = spawn_point;
        
    
        // Generate a random angle (in radians) around the circle
        // float r = 2 * Mathf.PI * Random.value;
        // Calculate the position offset using sin and cos, then add to Building B's position.
        // Vector3 randomPosition = buildingBPosition + new Vector3(Mathf.Sin(r) * spawnRadius, 0f, Mathf.Cos(r) * spawnRadius);

    }
}

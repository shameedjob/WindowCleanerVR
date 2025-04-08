using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private Transform goalTransform;
    private NavMeshAgent navMeshAgent;

    void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();

        GameObject goalObject = GameObject.FindGameObjectWithTag("goal");

        goalTransform = goalObject.transform;
    }

    void Update() {
        navMeshAgent.destination = goalTransform.position;
    }

    public void SetSpeed(float newSpeed) {
        navMeshAgent.speed = newSpeed;
    }
}

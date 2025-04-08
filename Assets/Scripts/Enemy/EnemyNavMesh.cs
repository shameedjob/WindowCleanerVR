using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        navMeshAgent.destination = movePositionTransform.position;
    }

    public void SetSpeed(float newSpeed) {
        navMeshAgent.speed = newSpeed;
    }
}

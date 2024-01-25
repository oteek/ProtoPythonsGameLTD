using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float stoppingDistance = 2f; // Distance at which the enemy stops following the player
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (player != null && navMeshAgent != null)
        {
            // Set the destination for the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(player.position);

            // Adjust stopping distance based on your preferences
            navMeshAgent.stoppingDistance = stoppingDistance;
        }
    }
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Sheep : MonoBehaviour
{
    public float Speed;
    public float VisionRadius;
    public float DisperseDistance;
    public float SheepHuddleDistance;

    private NavMeshAgent navAgent;
    private SheepState state;

    public enum SheepState
    {
        Idle,
        Dispersing, // Running away from a position
        Flocking    // Gravitating towards other sheep
    }

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        state = SheepState.Idle;
    }

    void Update()
    {
        switch (state)
        {
            case SheepState.Idle:
                // Check for possible flocking
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, VisionRadius);
                foreach (Collider col in hitColliders)
                {

                }
                break;
            case SheepState.Dispersing:
            case SheepState.Flocking:
                if (navStopped())
                {
                    state = SheepState.Idle; // Done
                }
                break;
        }
    }

    private bool navStopped()
    {
        if (!navAgent.pathPending)
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.magnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void DisperseFromPosition(Vector3 targetPos) // scalar has to be between 0 and 1
    {
        Vector3 disp = transform.position - targetPos;

        if (disp.magnitude < VisionRadius)
        {
            Vector3 dir = disp.normalized;
            float distance = (disp.magnitude / VisionRadius) * DisperseDistance;

            navAgent.destination = transform.position + (dir * distance);
        }

        state = SheepState.Dispersing;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
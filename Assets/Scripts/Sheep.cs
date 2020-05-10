using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Sheep : MonoBehaviour
{
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
                int layerMask = 1 << 8; // Sheep only
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, VisionRadius, layerMask);

                if (hitColliders.Length > 0)
                {
                    int closest = -1;
                    float minDist = -1;
                    int i = 0;

                    while (i < hitColliders.Length)
                    {
                        float dist = (hitColliders[i].transform.position - transform.position).magnitude;
                        if (closest == -1 || dist < minDist)
                        {
                            if (dist > SheepHuddleDistance)
                            {
                                minDist = dist;
                                closest = i;
                            }
                        }
                        i++;
                    }
                    if (closest != -1)
                    {
                        navAgent.destination = hitColliders[closest].transform.position;
                        Debug.Log(transform.position + " " + hitColliders[closest].transform.position);
                        state = SheepState.Flocking;
                    }
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
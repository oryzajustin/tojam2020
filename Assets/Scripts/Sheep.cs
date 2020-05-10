using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float Speed;
    private Vector3 runDir;
    private float runSpeed;
    private bool dispersing;

    // Start is called before the first frame update
    void Start()
    {
        runDir = new Vector3(0, 0, 0);
        dispersing = false;
    }

    void Update()
    {
        if (dispersing)
        {
            
        }
        else
        {

        }

    }

    public void DisperseInDirection(Vector3 direction, float scalar)
    {
        runDir = direction.normalized;
        runSpeed = Speed * scalar;
    }
}

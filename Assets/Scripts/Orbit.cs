using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] float orbit_speed;
    void Update()
    {
        transform.RotateAround(pivot.position, Vector3.up, orbit_speed * Time.deltaTime);
    }
}

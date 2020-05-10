using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celestial : MonoBehaviour
{
    [SerializeField] float orbit_speed;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(0, 50, 0), Vector3.right, orbit_speed * Time.deltaTime);
    }
}

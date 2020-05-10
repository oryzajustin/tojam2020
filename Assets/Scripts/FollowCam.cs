using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Target for the camera to follow")]
    public Transform target;
    [Header("Distance from target")]
    [SerializeField] float distance_from_target;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        this.transform.position = target.position - transform.forward * distance_from_target;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    private CharacterController controller;

    [Space]
    [SerializeField] float walk_speed;
    [SerializeField] float run_speed;
    [SerializeField] float turn_smooth_time;

    private float turn_smooth_velocity;
    [SerializeField] float speed_smooth_time;
    private float speed_smooth_velocity;
    private float curr_speed;

    private float speed;
    private float animation_speed_percent;

    private Transform camera_transform;

    private Animator animator;

    private float gravity = -12f;
    private float velocity_y;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        camera_transform = Camera.main.transform;
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // controller input
        Vector2 input_direction = input.normalized; // normalize the direction vector to prevent fast diagonal movement
        if (input_direction != Vector2.zero) // rotate the player model towards the input direction
        {
            float target_rotation = Mathf.Atan2(input_direction.x, input_direction.y) * Mathf.Rad2Deg + camera_transform.eulerAngles.y;
            this.transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(this.transform.eulerAngles.y, target_rotation, ref turn_smooth_velocity, speed_smooth_time);
        }

        float target_speed = walk_speed * input_direction.magnitude; // the speed we want to reach

        curr_speed = Mathf.SmoothDamp(curr_speed, target_speed, ref speed_smooth_velocity, speed_smooth_time); // damp to the target speed from our current speed

        velocity_y += gravity * Time.deltaTime; // account gravity

        Vector3 velocity = this.transform.forward * curr_speed + Vector3.up * velocity_y; // velocity

        controller.Move(velocity * Time.deltaTime);

        //animation_speed_percent = (is_running ? 1f : 0.5f) * input_direction.magnitude; // handles the animation speed percent
        animation_speed_percent = 0.5f * input_direction.magnitude; // handles the animation speed percent
        // Debug.Log(animation_speed_percent);
        animator.SetFloat("speedPercent", animation_speed_percent, speed_smooth_time, Time.deltaTime); // dampen the animation to the target animation


    }
}

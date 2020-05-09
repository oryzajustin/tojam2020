using UnityEngine;
using Unity.Entities;

public class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MoveData move_data, in PlayerInputData player_input_data) => 
        {
            // flag checks for input on keyboard
            bool up_pressed = Input.GetKey(player_input_data.up_key);
            bool left_pressed = Input.GetKey(player_input_data.left_key);
            bool right_pressed = Input.GetKey(player_input_data.right_key);
            bool down_pressed = Input.GetKey(player_input_data.down_key);

            // set the direction based on key pressed
            move_data.direction.x = (left_pressed) ? 1 : 0; // left
            move_data.direction.x -= (right_pressed) ? 1 : 0; // right
            move_data.direction.z = (up_pressed) ? 1 : 0; // up
            move_data.direction.z -= (down_pressed) ? 1 : 0; // down
        }).Run(); // main thread
    }
}

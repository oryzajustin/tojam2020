using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerRotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rotation, in Translation position, in MoveData move_data) => 
        {
            if (!move_data.direction.Equals(float3.zero)) // if we are moving
            {
                quaternion target_rotation = quaternion.LookRotation(move_data.direction, math.up()); // target rotation
                rotation.Value = math.slerp(rotation.Value, target_rotation, move_data.turnSpeed); // manipulate the game object transform's rotation value using the turn speed
            }
        }).Schedule(); // worker thread
    }
}

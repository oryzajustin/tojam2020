using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;

public class PlayerMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float delta_time = Time.DeltaTime; // can't access Time.DeltaTime on worker thread (contingency)

        Entities.ForEach((ref MoveData move_data, ref Translation position) => 
        {
            float3 normalized_direction = math.normalizesafe(move_data.direction); // normalize the direction vector for diagonal speed
            position.Value += normalized_direction * move_data.speed * delta_time; // increment the position's value to achieve movement
        }).Run(); // main thread
    }
}

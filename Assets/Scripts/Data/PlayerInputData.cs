using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct PlayerInputData : IComponentData
{
    public KeyCode up_key, right_key, left_key, down_key; // vars for holding directional key codes i.e. (W, A, S, D)
}

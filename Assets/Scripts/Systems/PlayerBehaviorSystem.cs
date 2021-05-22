using UnityEngine;
using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;

public class PlayerBehaviorSystem : SystemBase
{

  // called every frame.
  protected override void OnUpdate()
  {
    Entities.WithoutBurst().ForEach((
      ref PlayerComponent player,
      ref Translation translation,
      ref Rotation rotation
    ) =>
    {
      float[] inputs = GetInput();
      float movementX = inputs[0];
      float movementY = inputs[1];
      float time = Time.DeltaTime;

      float angle = GetAngle(movementX, time);
      float movementSpeed = GetMovementSpeed(movementY, time);

      player.RotationAngle += angle;

      float3 targetDirection = GetTargetDirection(player.RotationAngle);

      rotation.Value = quaternion.LookRotation(targetDirection, math.up());
      translation.Value += targetDirection * player.Speed * movementSpeed;
    }).Run();
  }

  float[] GetInput()
  {
    float[] inputs = { Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") };
    return inputs;
  }

  float GetAngle(float movementX, float time)
  {
    return movementX * time;
  }

  float GetMovementSpeed(float movementY, float time)
  {
    return movementY * time;
  }

  float3 GetTargetDirection(float angle)
  {
    return new float3(math.sin(angle), 0, math.cos(angle));
  }

}

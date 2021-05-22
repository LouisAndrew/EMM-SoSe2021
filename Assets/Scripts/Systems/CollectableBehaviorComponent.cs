using UnityEngine;
using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;

public class CollectableBehaviorSystem : SystemBase
{
  protected override void OnUpdate()
  {
    int score = 0;
    Entities.WithoutBurst().ForEach((ref CollectedComponent collectedComponent, ref Rotation rotation) =>
    {
      PrintLog(ref rotation.Value);
      if (collectedComponent.IsCollected)
      {
        score++;
      }
    }).Run();
  }

  private void PrintLog(ref quaternion i)
  {
    Debug.Log(i.value);
  }

}
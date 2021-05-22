using UnityEngine;
using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;

public class CollectableBehaviorSystem : SystemBase
{
  private BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

  protected override void OnCreate()
  {
    base.OnCreate();
    m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
  }

  protected override void OnUpdate()
  {
    var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer();

    Entity playerEntity = GetEntityQuery(typeof(PlayerComponent)).GetSingletonEntity();
    float3 playerPos = EntityManager.GetComponentData<Translation>(playerEntity).Value;
    float collisionDistance = 0.5f;



    Entities.WithoutBurst().ForEach((ref Translation translation, ref Entity entity, ref CollectedComponent collectedComponent) =>
    {
      // collision detection
      float3 collectablePos = translation.Value;
      float distance = Unity.Mathematics.math.distance(playerPos, collectablePos);
      if (
         distance <= collisionDistance
      )
      {
        collectedComponent.IsCollected = true;
      }

      if (collectedComponent.IsCollected)
      {
        UpdateScore();
        commandBuffer.DestroyEntity(entity);
      }
    }).Run();
  }

  void UpdateScore()
  {
    Entity scoreEntity = GetEntityQuery(typeof(ScoreComponent)).GetSingletonEntity();
    int curentScore = EntityManager.GetComponentData<ScoreComponent>(scoreEntity).CurrentScore;
    EntityManager.SetComponentData(scoreEntity, new ScoreComponent
    {
      CurrentScore = curentScore + 1
    });
  }
}
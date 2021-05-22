using UnityEngine;
using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;

public class SpawnCollectableSystem : SystemBase
{

  private float _minX = -5f;
  private float _maxX = 5f;
  private float _minY = -5f;
  private float _maxY = 5f;
  [SerializeField]
  private float _floorTop = 0.5f;


  private struct Pos
  {
    public float max;
    public float min;
  }

  BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
  protected override void OnCreate()
  {
    m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
  }


  // called every frame.
  protected override void OnUpdate()
  {
    var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();

    Pos posX = new Pos { max = _maxX, min = _minX };
    Pos posY = new Pos { max = _maxY, min = _minY };
    float floorTop = _floorTop;
    Unity.Mathematics.Random random = new Unity.Mathematics.Random { state = (uint)1 };

    Entities.WithBurst(Unity.Burst.FloatMode.Default, Unity.Burst.FloatPrecision.Standard).ForEach((Entity entity, int entityInQueryIndex, in SpawnCollectableComponent spawnComponent) =>
    {
      for (int i = 0; i < spawnComponent.CollectableCount; i++)
      {
        Entity entityInstance = commandBuffer.Instantiate(entityInQueryIndex, spawnComponent.CollectablePrefab);
        float coordinateX = random.NextFloat(posX.min, posX.max);
        float coordinateY = random.NextFloat(posY.min, posY.max);
        float3 pos = new float3(coordinateX, floorTop, coordinateY);

        commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new Translation
        {
          Value = pos
        });
        commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new CollectedComponent
        {
          IsCollected = false
        });
      }

      commandBuffer.DestroyEntity(entityInQueryIndex, entity);
    }).ScheduleParallel();

    m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
  }
}

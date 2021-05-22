using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpawnCollectableComponent : IComponentData
{
  public int CollectableCount;
  public Entity CollectablePrefab;
}


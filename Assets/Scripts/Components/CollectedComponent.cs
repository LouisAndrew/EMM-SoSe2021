using Unity.Entities;

[GenerateAuthoringComponent]
public struct CollectedComponent : IComponentData
{
  public bool IsCollected;
}

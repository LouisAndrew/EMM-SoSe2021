using Unity.Entities;
using UnityEngine.UI;

[GenerateAuthoringComponent]
public struct ScoreComponent : IComponentData
{
  // public int MaxScore;
  public int CurrentScore;
}

using UnityEngine;
using Unity.Entities;
using UnityEngine.UI;

public class ScoreSystem : SystemBase
{
  int _currentScore;

  protected override void OnCreate()
  {
    base.OnCreate();
    // UpdateUI(0);
  }

  // called every frame.
  protected override void OnUpdate()
  {
    Entity scoreEntity = GetEntityQuery(typeof(ScoreComponent)).GetSingletonEntity();
    int currentScore = EntityManager.GetComponentData<ScoreComponent>(scoreEntity).CurrentScore;
    if (_currentScore != currentScore)
    {
      UpdateUI(currentScore);
    }
  }

  private void UpdateUI(int score)
  {
    _currentScore = score;
    GameObject obj = GameObject.FindWithTag("ScoreCount");
    if (obj)
    {
      Text scoreCount = obj.GetComponent<Text>();
      scoreCount.text = _currentScore.ToString();
    }
  }
}

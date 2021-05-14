using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
  [SerializeField] private Transform myPrefab;
  [SerializeField] private int _numberOfApples = 1;

  private float _minX = -5f;
  private float _maxX = 5f;
  private float _minY = -5f;
  private float _maxY = 5f;

  [SerializeField]
  private float _floorTop = 0.5f; // 0.2 to simulate "floating" effect
  [SerializeField]
  private Transform parent = null;

  void Start()
  {
    ArrayList vectors = new ArrayList();
    int i = 1;
    while (i <= _numberOfApples)
    {
      float coordinateX = UnityEngine.Random.Range(_minX, _maxX);
      float coordinateY = UnityEngine.Random.Range(_minY, _maxY);
      Vector3 coordinate = new Vector3(coordinateX, _floorTop, coordinateY);
      if (!vectors.Contains(coordinate))
      {
        Transform obj = Instantiate(myPrefab, coordinate, new Quaternion());
        if (parent != null)
        {
          obj.parent = parent;
        }
        i++;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
  }
}

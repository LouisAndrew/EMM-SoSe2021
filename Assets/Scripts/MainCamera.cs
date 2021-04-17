using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

  [SerializeField] private Transform target;
  [SerializeField] private float _offsetZ = 10f;

  // Update is called once per frame
  void Update()
  {
    Vector3 offsetVector = new Vector3(0, 5f, _offsetZ * -1);
    Quaternion playerRotation = target.rotation;

    Vector3 offsetRotated = playerRotation * offsetVector;
    transform.position = target.position + offsetRotated;
    transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation * Quaternion.Euler(60, 0, 0), 0.5f);
  }
}

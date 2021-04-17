using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [SerializeField] private float _speed = .5f;
  [SerializeField] private float _rotationSpeed = .25f;
  [SerializeField] private float _baseAngle = 10;
  void Start()
  {
  }

  void Update()
  {
    float moveHorizontal = Input.GetAxis("Horizontal"); // forward / back
    float moveVertical = Input.GetAxis("Vertical"); // rotation

    float angle = moveHorizontal * _baseAngle * _rotationSpeed * Time.deltaTime;
    float direction = moveVertical * _speed * Time.deltaTime;

    transform.position += transform.forward * direction;

    Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
    transform.rotation *= Quaternion.LookRotation(targetDirection);
  }
}

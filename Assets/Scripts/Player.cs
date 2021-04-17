using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [SerializeField] private float _speed = 1f;
  [SerializeField] private float _rotationSpeed = .5f;
  [SerializeField] private float _baseAngle = 10;
  private int score = 0;
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

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Collectable"))
    {
      Debug.Log("entering collectable");
      incrementScore();
      GameObject.Destroy(other.gameObject);
    }
  }

  void incrementScore()
  {
    score++;
    Debug.Log("Score: " + score);
  }
}

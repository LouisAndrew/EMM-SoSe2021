using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [SerializeField] private float _speed = 1f;
  [SerializeField] private float _rotationSpeed = .5f;
  [SerializeField] private float _baseAngle = 10;
  [SerializeField] private bool useAr = false;

  public float arMovementStep = 0.5f;
  public float horizontalMovement = 0;
  public float verticalMovement = 0;
  private int score = 0;
  void Start()
  {

  }

  void Update()
  {
    float moveHorizontal = useAr ? horizontalMovement : Input.GetAxis("Horizontal");
    float moveVertical = useAr ? verticalMovement : Input.GetAxis("Vertical");

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

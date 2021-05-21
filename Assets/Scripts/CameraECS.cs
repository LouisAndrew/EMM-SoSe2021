using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CameraECS : MonoBehaviour
{
  private EntityManager manager;
  [SerializeField]
  private float _offsetZ = 2;

  void Start()
  {
    manager = World.DefaultGameObjectInjectionWorld.EntityManager;
  }
  // Update is called once per frame
  void Update()
  {

    Entity playerEntity = manager.CreateEntityQuery(typeof(PlayerComponent)).GetSingletonEntity();
    quaternion playerRotation = manager.GetComponentData<Rotation>(playerEntity).Value;
    float3 playerPos = manager.GetComponentData<Translation>(playerEntity).Value;

    float3 offsetVector = new float3(0, 5f, _offsetZ * -1);
    float3 offsetRotated = math.mul(playerRotation, offsetVector);

    float3 pos = playerPos + offsetRotated;
    quaternion r = Quaternion.Slerp(transform.rotation, playerRotation * Quaternion.Euler(60, 0, 0), 0.5f);

    transform.position = pos;
    transform.rotation = r;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CustomVFX : MonoBehaviour
{
  private VisualEffect visEffect;
  private Transform parent;

  // Start is called before the first frame update
  void Start()
  {
    visEffect = GetComponent<VisualEffect>();
    parent = transform.parent;
    if (parent.transform.parent.CompareTag("BaseObject"))
    {
      visEffect.Stop();
    }
  }

  // Update is called once per frame
  void Update()
  {
    visEffect.SetVector3("Position", parent.transform.position);
  }
}

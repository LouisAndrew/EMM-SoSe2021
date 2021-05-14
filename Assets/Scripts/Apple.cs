using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Apple : MonoBehaviour
{

  private bool _isMovingUp = true;
  [SerializeField] private float _maxY = 0.05f;
  [SerializeField] private float _minY = -0.05f;
  [SerializeField] private float _speed = .05f;
  private float _defaultPos = .5f; // apple default height (see Object.cs)
  private bool _shouldTranslate = false; // sets if the object should be translated
                                         // There's an apple underneath `Floor` object, so we don't want to also translate it

  private VisualEffect vfx;

  void Start()
  {
    Transform parent = this.transform.parent;

    Transform collectableEffect = parent.Find("CollectablesEffect");
    if (collectableEffect)
    {
      vfx = collectableEffect.GetComponent<VisualEffect>();
    }

  }

  void Update()
  {

    float posY = transform.position.y;

    // check if the object should be translated 
    if (posY == _defaultPos)
    {
      _shouldTranslate = true;
    }

    if (_shouldTranslate)
    {
      if (posY >= _maxY + _defaultPos)
      {
        _isMovingUp = false;
      }
      else if (posY <= _minY + _defaultPos)
      {
        _isMovingUp = true;
      }

      float direction = _isMovingUp ? 1 : -1;
      transform.position += new Vector3(0, _speed * direction * Time.deltaTime, 0);
    }
  }

  public void StopEffect()
  {
    if (vfx) { vfx.Stop(); }

  }
}

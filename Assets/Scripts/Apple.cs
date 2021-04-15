using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    
    [SerializeField] private float _angle = 30f;
    [SerializeField] private float _multiplicator = 0.05f;
    private bool _isGoingUp = true;
    [SerializeField] private float _defaultPos = 1f; // Object.cs

    void Start()
    {
        // _defaultAngle = UnityEngine.Random.Range(0f, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * _angle, 0f), Space.World); // rotate angle per second.

        if (_defaultPos >= 1.5f) 
        {
            _isGoingUp = false;
        }
        
        if (_defaultPos <= 0.5f) {
            _isGoingUp = true;
        }
        float translateValue;
        if (_isGoingUp) {
            translateValue = 1;
        } else {
            translateValue = -1;
        }
        _defaultPos += translateValue * _multiplicator;

        // Debug.Log(_defaultPos);
        Debug.Log( translateValue * translateValue);

        transform.Translate(new Vector3(0f, Time.deltaTime * translateValue * translateValue, 0f));
    }
}

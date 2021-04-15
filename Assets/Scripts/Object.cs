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

    private float _floorTop = 1f; // 0.5 -> top of the floor. + 0.5 to simulate "floating" effect

    void Start()
    {
        int i = 0;
        while (i <= _numberOfApples) {
            float coordinateX = UnityEngine.Random.Range(_minX, _maxX);
            float coordinateY = UnityEngine.Random.Range(_minY, _maxY);
            Instantiate(myPrefab, new Vector3(coordinateX, _floorTop, coordinateY), new Quaternion());
            i++;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

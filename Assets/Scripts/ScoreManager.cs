using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
  [SerializeField] private Text _scoreCount;
  // Start is called before the first frame update
  void Start()
  {
    _scoreCount.text = "0";
  }

  // Update is called once per frame
  void Update()
  {

  }
}

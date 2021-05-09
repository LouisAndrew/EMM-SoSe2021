using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
  [SerializeField]
  private Transform Menu;

  private bool isMenuShowed = false;
  void Start()
  {
    togglePauseMenu();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      isMenuShowed = !isMenuShowed;
      togglePauseMenu();
    }
  }

  private void togglePauseMenu()
  {
    Menu.gameObject.SetActive(isMenuShowed);
  }
}

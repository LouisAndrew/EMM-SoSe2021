using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  [SerializeField]
  private Transform Menu;

  [SerializeField]
  private Button RestartButton;

  [SerializeField]
  private Button ReturnButton;

  private bool isMenuShowed = false;
  private float defaultTimeScale;
  void Start()
  {
    defaultTimeScale = Time.timeScale;

    togglePauseMenu();
    ReturnButton.onClick.AddListener(closePauseMenu);
    RestartButton.onClick.AddListener(loadScene);
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
    if (isMenuShowed)
    {
      Time.timeScale = 0;
    }
    else
    {
      Time.timeScale = defaultTimeScale;
    }
  }

  private void closePauseMenu()
  {
    isMenuShowed = false;
    togglePauseMenu();
  }

  private void loadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    closePauseMenu();
  }
}

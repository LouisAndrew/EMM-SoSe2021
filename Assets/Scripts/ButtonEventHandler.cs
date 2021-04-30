using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class ButtonEventHandlder : MonoBehaviour
{

  public GameObject vBtn;


  // Use this for initialization
  void Start()
  {
    vBtn = GameObject.Find("Btn");
    vBtn.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
    vBtn.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);


  }

  public void OnButtonPressed(VirtualButtonBehaviour vb)
  {

  }

  public void OnButtonReleased(VirtualButtonBehaviour vb)
  {

  }
}
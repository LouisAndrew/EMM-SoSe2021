using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton : MonoBehaviour
{
  [SerializeField] private Player player;

  // Start is called before the first frame update

  void Start()
  {
    VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
    for (int i = 0; i < vbs.Length; ++i)
    {
      Debug.Log(i);
      vbs[i].RegisterOnButtonPressed(this.OnButtonPressed);
      vbs[i].RegisterOnButtonReleased(this.OnButtonReleased);
    }
  }

  public void OnButtonPressed(VirtualButtonBehaviour vb)
  {
    switch (vb.VirtualButtonName)
    {
      case "FORWARD":
        Debug.Log("FORWARD");
        player.verticalMovement += player.arMovementStep;
        break;
      case "BACK":
        player.verticalMovement -= player.arMovementStep;
        break;
      case "RIGHT":
        player.horizontalMovement += player.arMovementStep;
        break;
      case "LEFT":
        player.horizontalMovement -= player.arMovementStep;
        break;
    }
  }

  public void OnButtonReleased(VirtualButtonBehaviour vb)
  {
    switch (vb.VirtualButtonName)
    {
      case "FORWARD":
      case "BACK":
        player.verticalMovement = 0;
        break;

      case "LEFT":
      case "RIGHT":
        player.horizontalMovement = 0;
        break;
    }

  }

  // Update is called once per frame
  void Update()
  {

  }
}

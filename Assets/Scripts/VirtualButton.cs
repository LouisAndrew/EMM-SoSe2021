using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
    for (int i = 0; i < vbs.Length; ++i)
    {
      Debug.Log(i);
      vbs[i].RegisterOnButtonPressed(this.OnButtonPressed);
    }
  }

  public void OnButtonPressed(VirtualButtonBehaviour vb)
  {
    switch (vb.VirtualButtonName)
    {
      case "FORWARD":
        Debug.Log("FORWARD");
        break;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Switch(int idx) {
        switch (idx) {
            case 0: SwitchCamera.instance.SwitchToGod(); break;
            case 1: SwitchCamera.instance.SwitchToMain(); break;
            case 2: SwitchCamera.instance.SwitchToRobot(); break;
        }
    }
}

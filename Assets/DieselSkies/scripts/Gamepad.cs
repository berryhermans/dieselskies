using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamepad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (string joystick in Input.GetJoystickNames())
        {
            Debug.Log(joystick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            Debug.Log("beepboop");
        }
    }
}

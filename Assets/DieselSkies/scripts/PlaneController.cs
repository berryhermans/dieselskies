using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : InputBroadcaster
{
    public InputBroadcaster PlayerInput;

    private void OnEnable()
    {
        PlayerInput.OnRewiredButtonEventBroadcast += (buttonEvent) =>
        {
            Debug.Log(buttonEvent.ActionName + " | " + buttonEvent.EventType);
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : InputBroadcaster
{
    public InputBroadcaster PlayerInput;

    private void OnEnable()
    {
        PlayerInput.Vector2Broadcasted += (vector2) =>
        {
            Debug.Log(vector2);
            BroadcastVector2(vector2);
        };
    }
}

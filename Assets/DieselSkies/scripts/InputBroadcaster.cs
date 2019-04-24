using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour {

    public delegate void Vector2Delegate(Vector2 vector2);
    public event Vector2Delegate Vector2Broadcasted;

	public delegate void Vector3Delegate(Vector3 vector3);
	public event Vector3Delegate Vector3Broadcasted;

	public delegate void GameObjectDelegate(GameObject gameobject);
	public event GameObjectDelegate GameObjectBroadcasted;

    public delegate void StringDelegate(string str);
    public event StringDelegate StringBroadcasted;

    public delegate void RewiredButtonEventDelegate(RewiredButtonEventModel buttonEvent);
    public event RewiredButtonEventDelegate RewiredButtonEventBroadcasted;

    protected void BroadcastVector2(Vector2 vector2)
    {
        if (Vector2Broadcasted != null) Vector2Broadcasted(vector2);
    }

    protected void BroadcastVector3(Vector3 vector3)
	{
		if (Vector3Broadcasted != null) Vector3Broadcasted(vector3);
	}

	protected void BroadcastGameObject(GameObject gameobject)
	{
		if (GameObjectBroadcasted != null) GameObjectBroadcasted(gameobject);
	}

    protected void BroadcastString(string str)
    {
        if (StringBroadcasted != null) StringBroadcasted(str);
    }

    protected void BroadcastRewiredButtonEvent(RewiredButtonEventModel buttonEvent)
    {
        if (RewiredButtonEventBroadcasted != null) RewiredButtonEventBroadcasted(buttonEvent);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour {

    public delegate void Vector2Delegate(Vector2 vector2);
    public event Vector2Delegate OnVector2Broadcast;

	public delegate void Vector3Delegate(Vector3 vector3);
	public event Vector3Delegate OnVector3Broadcast;

	public delegate void GameObjectDelegate(GameObject gameobject);
	public event GameObjectDelegate OnGameObjectBroadcast;

    public delegate void StringDelegate(string str);
    public event StringDelegate OnStringBroadcast;

    public delegate void RewiredButtonEventDelegate(RewiredButtonEventModel buttonEvent);
    public event RewiredButtonEventDelegate OnRewiredButtonEventBroadcast;

    protected void BroadcastVector2(Vector2 vector2)
    {
        if (OnVector2Broadcast != null) OnVector2Broadcast(vector2);
    }

    protected void BroadcastVector3(Vector3 vector3)
	{
		if (OnVector3Broadcast != null) OnVector3Broadcast(vector3);
	}

	protected void BroadcastGameObject(GameObject gameobject)
	{
		if (OnGameObjectBroadcast != null) OnGameObjectBroadcast(gameobject);
	}

    protected void StringBroadcast(string str)
    {
        if (OnStringBroadcast != null) OnStringBroadcast(str);
    }

    protected void BroadcastRewiredButtonEvent(RewiredButtonEventModel buttonEvent)
    {
        if (OnRewiredButtonEventBroadcast != null) OnRewiredButtonEventBroadcast(buttonEvent);
    }
}
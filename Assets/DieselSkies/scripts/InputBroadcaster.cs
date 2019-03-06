using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour {

	public delegate void Vector3Delegate(Vector3 vector3);
	public event Vector3Delegate OnVector3Broadcast;

	public delegate void GameObjectDelegate(GameObject gameobject);
	public event GameObjectDelegate OnGameObjectBroadcast;

	protected void BroadcastVector3(Vector3 vector3)
	{
		if (OnVector3Broadcast != null) OnVector3Broadcast(vector3);
	}

	protected void BroadcastGameObject(GameObject gameobject)
	{
		if (OnGameObjectBroadcast != null) OnGameObjectBroadcast(gameobject);
	}
}

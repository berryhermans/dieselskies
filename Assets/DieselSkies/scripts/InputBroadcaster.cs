using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour {

	public delegate void BroadcastAction(Vector3 vector3);
	public event BroadcastAction OnVector3Broadcast;

	protected void BroadcastVector3(Vector3 vector3)
	{
		if (OnVector3Broadcast != null) OnVector3Broadcast(vector3);
	}

}

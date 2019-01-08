using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BroadcastAction(Vector3 vector3);

public interface IVector3Broadcaster {
	event BroadcastAction OnVector3Broadcast;
}

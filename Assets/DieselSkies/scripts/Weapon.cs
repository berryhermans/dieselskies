using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public InputBroadcaster Input;
	public GameObject AttackSpawnpoint;

	private void Start()
	{
		Input.OnVector3Broadcast += Shoot;
	}

	public void Shoot(Vector3 target)
	{
		Debug.DrawLine(AttackSpawnpoint.transform.position, target, Color.yellow, .1f);
		Debug.Log("pewpewpew");
	}
}

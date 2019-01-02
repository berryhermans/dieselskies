using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Sensor's only job is to detect specific objects and announcing that these objects are entering, staying or leaving the sensor range
/// </summary>
public class Sensor : MonoBehaviour {

	public Collider SensorCollider;

	public bool DetectHostilePlanes;
	public bool DetectFriendlyPlanes;

	public bool BroadcastOnEnter;
	public bool BroadcastOnStay;
	public bool BroadcastOnExit;

	private void OnTriggerEnter(Collider other)
	{
		if (BroadcastOnEnter)
		{
			Debug.Log("enter"); 
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (BroadcastOnStay)
		{
			Debug.Log("stay");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (BroadcastOnExit)
		{
			Debug.Log("exit");
		}
	}
}

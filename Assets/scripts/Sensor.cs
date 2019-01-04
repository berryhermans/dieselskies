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

	public float DelayBetweenStayBroadcasts;

	private float _timeUntilNextStayBroadcast;
	private float _lastOnStayFrame;

	private void Start()
	{
		_timeUntilNextStayBroadcast = 0;
	}

	private void Update()
	{
		if (DelayBetweenStayBroadcasts > 0) _timeUntilNextStayBroadcast -= Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (BroadcastOnEnter)
		{
			Debug.Log("Entering sensor range: " + other.name);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (BroadcastOnStay && (_timeUntilNextStayBroadcast <= 0 || _lastOnStayFrame == Time.frameCount))
		{
			Debug.Log("Staying in sensor range: " + other.name);
			_timeUntilNextStayBroadcast = DelayBetweenStayBroadcasts;
			_lastOnStayFrame = Time.frameCount;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (BroadcastOnExit)
		{
			Debug.Log("Exiting sensor range: " + other.name);
		}
	}
}

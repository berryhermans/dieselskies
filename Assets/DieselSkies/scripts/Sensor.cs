﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Sensor's only job is to detect specific objects and announcing if these objects are entering, staying or leaving the sensor range
/// </summary>
public class Sensor : InputBroadcaster {

	public Collider SensorCollider;

	[Header("Broadcast data types")]
	public bool BroadcastVector3;
	public bool BroadcastGameObject;

	[Header("Broadcast events")]
	public bool BroadcastOnEnter;
	public bool BroadcastOnStay;
	public bool BroadcastOnExit;

    [Header("Other Settings")]
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
		if (!BroadcastOnEnter) return;
		if (other.GetComponent<SensorTarget>() == null) return;

		Debug.Log("Entering sensor range: " + other.name);

		Broadcast(other);
	}

	private void OnTriggerStay(Collider other)
	{
		if (!BroadcastOnStay) return;
		if (_timeUntilNextStayBroadcast > 0 && _lastOnStayFrame != Time.frameCount) return;
		if (other.GetComponent<SensorTarget>() == null) return; 

		Debug.Log("Staying in sensor range: " + other.name);
		_timeUntilNextStayBroadcast = DelayBetweenStayBroadcasts;
		_lastOnStayFrame = Time.frameCount;

		Broadcast(other);
	}

	private void OnTriggerExit(Collider other)
	{
		if (!BroadcastOnExit) return;
		if (other.GetComponent<SensorTarget>() == null) return;

		Debug.Log("Exiting sensor range: " + other.name);

		Broadcast(other);
	}

	private void Broadcast(Collider other)
	{
		if (BroadcastVector3) BroadcastVector3(other.transform.position);
		if (BroadcastGameObject) BroadcastGameObject(other.gameObject);
	}
}

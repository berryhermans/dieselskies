using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{

	public Rigidbody Body;
	public Transform Target;

	private Quaternion _targetDirection;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		_targetDirection = Quaternion.Euler(Target.position - Body.position);

		Debug.Log("mouse: " + _targetDirection);

		Body.rotation = _targetDirection;
	}
}

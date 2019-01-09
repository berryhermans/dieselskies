using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
	public Rigidbody Body;
    [Range(0,360)]
    public float TurnStrength;

	public InputBroadcaster Input;
	private Vector3 _target;

	// Use this for initialization
	void Start()
	{
		_target = Body.transform.forward.normalized;
		Input.OnVector3Broadcast += OnInputHandler;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion _targetRotation = Quaternion.LookRotation(_target - Body.position);
        Body.rotation = Quaternion.RotateTowards(Body.rotation, _targetRotation, TurnStrength * Time.deltaTime);
    }

	private void OnInputHandler(Vector3 input)
	{
		_target = input;
	}
}

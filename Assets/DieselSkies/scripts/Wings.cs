using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
	public Rigidbody Body;
    [Range(0,360)]
    public float TurnStrength;
	public InputBroadcaster Input;

	private WingState _currentState;
	private WingState _previousState;
    private float _targetRotationDegreesY;

	// Use this for initialization
	void Start()
	{
		Input.Vector2Broadcasted += OnVector2BroadcastedHandler;
		SetState(WingState.IDLE);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		HandleState();
    }

	private void OnVector2BroadcastedHandler(Vector2 input)
	{
		_targetRotationDegreesY = (Mathf.Atan2(input.y, input.x) / Mathf.PI) * 180f;
        if (_targetRotationDegreesY < 0) _targetRotationDegreesY += 360;
        Debug.Log(_targetRotationDegreesY);
		if (_currentState != WingState.TURNING) SetState(WingState.TURNING);
	}

	private void SetState(WingState newState)
	{
		_previousState = _currentState;
		_currentState = newState;
	}

	private void HandleState()
	{
		switch (_currentState)
		{
			case WingState.IDLE:
				// The plane is on target, so the wings don't have to do anything.
				break;
			case WingState.TURNING:
				HandleTurningState();
				break;
			default:
				Debug.LogError("Can't handle unknown state: " + _currentState.ToString());
				break;
		}
	}

	private void HandleTurningState()
	{
        Vector3 bla = new Vector3(Body.rotation.x, _targetRotationDegreesY, Body.rotation.z);
		Quaternion targetRotation = Quaternion.LookRotation(bla, Vector3.up);
		Body.rotation = Quaternion.RotateTowards(Body.rotation, targetRotation, TurnStrength * Time.deltaTime);

		// Are we on target yet?
		if (Body.rotation == targetRotation) SetState(WingState.IDLE);
	}
}

public enum WingState
{
	IDLE,
	TURNING
}

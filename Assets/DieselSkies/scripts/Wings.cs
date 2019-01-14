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
	private Vector3 _target;

	// Use this for initialization
	void Start()
	{
		Input.OnVector3Broadcast += OnInputHandler;
		SetState(WingState.IDLE);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		HandleState();
    }

	private void OnInputHandler(Vector3 input)
	{
		_target = input;
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
		Quaternion _targetRotation = Quaternion.LookRotation(_target - Body.position);
		Body.rotation = Quaternion.RotateTowards(Body.rotation, _targetRotation, TurnStrength * Time.deltaTime);

		// Are we on target yet?
		if (Body.rotation == _targetRotation) SetState(WingState.IDLE);
	}
}

public enum WingState
{
	IDLE,
	TURNING
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public InputBroadcaster Input;
	public GameObject AttackSpawnpoint;

	private WeaponState _currentState;
	private WeaponState _previousState;

	private void Start()
	{
		Input.OnGameObjectBroadcast += OnInputHandler;
	}

	private void FixedUpdate()
	{
		HandleState();
	}

	private void HandleState()
	{
		switch (_currentState)
		{
			case WeaponState.IDLE:

				break;
			case WeaponState.SHOOTING:
				HandleShootingState();
				break;
			default:
				break;
		}
	}

	private void HandleShootingState()
	{
		//Debug.DrawLine(AttackSpawnpoint.transform.position, target, Color.yellow, .1f);
		Debug.Log("pewpewpew");
	}

	private void SetState(WeaponState newState)
	{
		_previousState = _currentState;
		_currentState = newState;
	}

	private void OnInputHandler(GameObject go)
	{

	}

}

public enum WeaponState
{
	IDLE,
	SHOOTING
}

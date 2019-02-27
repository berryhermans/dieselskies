using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public InputBroadcaster Input;
	public GameObject AttackSpawnpoint;
	public GameObject ProjectilePrefab;
    [Range(0, 5)]
    public float TimeBetweenShots;

	private WeaponState _currentState;
	private WeaponState _previousState;

    private float _timeSinceLastShot;

	private void Start()
	{
		Input.OnGameObjectBroadcast += OnInputHandler;
	}

	private void FixedUpdate()
	{
        _timeSinceLastShot += Time.deltaTime;

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
        if (_timeSinceLastShot >= TimeBetweenShots)
        {
            Shoot();
        }
	}

	private void SetState(WeaponState newState)
	{
		_previousState = _currentState;
		_currentState = newState;
	}

	private void OnInputHandler(GameObject go)
	{
		// TODO: gotta keep track of all the objects within range and toggle fire modes based on that list
		SetState(WeaponState.SHOOTING);
	}

    private void Shoot()
    {
        Instantiate(ProjectilePrefab, AttackSpawnpoint.transform.position, AttackSpawnpoint.transform.rotation);
        _timeSinceLastShot = 0;
    }
}

public enum WeaponState
{
	IDLE,
	SHOOTING
}

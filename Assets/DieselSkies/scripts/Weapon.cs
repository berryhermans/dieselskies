using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public InputBroadcaster Input;
	public GameObject AttackSpawnpoint;
	public GameObject ProjectilePrefab;
    [Range(0, 5)]
    public float TimeBetweenShots;
    [Range(0, 5)]
    public float TimeBetweenLastInputAndLastShot;

    private float _timeSinceLastShot;
    private float _timeSinceLastInput;
    private bool _isShooting;

	private void Start()
	{
		Input.OnGameObjectBroadcast += OnInputHandler;
	}

	private void FixedUpdate()
	{
        _timeSinceLastShot += Time.deltaTime;
        _timeSinceLastInput += Time.deltaTime;

        if (_isShooting && _timeSinceLastShot >= TimeBetweenShots)
        {
            Shoot();
        }

        if (_timeSinceLastInput >= TimeBetweenLastInputAndLastShot)
        {
            _isShooting = false;
        }
	}

	private void OnInputHandler(GameObject go)
	{
        // TODO: gotta keep track of all the objects within range and toggle fire modes based on that list
        _isShooting = true;
        _timeSinceLastInput = 0;
	}

    private void Shoot()
    {
        Instantiate(ProjectilePrefab, AttackSpawnpoint.transform.position, AttackSpawnpoint.transform.rotation);
        _timeSinceLastShot = 0;
    }
}
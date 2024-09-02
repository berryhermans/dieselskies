using System;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private ScriptableListAirplaneController activeAirplanes;
    [SerializeField] private Flight flight;
    public int Owner { get; private set; }

    private bool isInitialized = false;
    private IWeapon[] weapons = new IWeapon[0];

    private void Awake() {
        weapons = GetComponentsInChildren<IWeapon>();
    }

    private void Start() {
        activeAirplanes.Add(this);
    }

    private void Update() {
        foreach (IWeapon weapon in weapons)
        {
            weapon.Fire();
        }
    }

    public void Init(int owner, Vector3 initialDirection)
    {
        if(isInitialized) throw new Exception("Init may only be called once.");
        Debug.Log("init plane");
        Owner = owner;
        flight.SetTargetDirection(initialDirection);

        isInitialized = true;
    }

    public void SetTarget(Vector3 target)
    {
        Debug.Log($"Set target to {target}, new direction = {target - transform.position}");
        flight.SetTargetDirection(target - transform.position);
    }
}

using System;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private ScriptableListAirplaneController activeAirplanes;
    [SerializeField] private Flight flight;
    public int Owner { get; private set; }

    private bool isInitialized = false;

    private void Start() {
        activeAirplanes.Add(this);
    }

    public void Init(int owner, Vector3 initialDirection)
    {
        if(isInitialized) throw new Exception("Init may only be called once.");

        Owner = owner;
        flight.SetTargetDirection(initialDirection);

        isInitialized = true;
    }

    public void SetTarget(Vector3 target)
    {
        flight.SetTargetDirection(target - transform.position);
    }
}

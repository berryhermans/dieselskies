using System;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour, IDamageable
{
    [SerializeField] private ScriptableListAirplaneController activeAirplanes;
    [SerializeField] private Flight flight;
    [SerializeField] private Health health;
    [SerializeField] private List<Sensor> sensors;
    public TeamVariable Team { get; private set; }

    private bool isInitialized = false;

    private void Start() {
        health.OnHealthZero += DestroyPlane;
    }

    private void OnDestroy() {
        health.OnHealthZero -= DestroyPlane;
    }

    public void Init(TeamVariable team, Vector3 initialDirection)
    {
        if(isInitialized) throw new Exception("Init may only be called once.");

        Team = team;
        flight.SetTargetDirection(initialDirection);
        foreach (Sensor sensor in sensors)
        {
            sensor.Init(Team);
        }

        isInitialized = true;
    }

    public void SetTarget(Vector3 target)
    {
        flight.SetTargetDirection(target - transform.position);
    }

    public void TakeDamage(int amount)
    {
        health.TakeDamage(amount);
    }

    public void DestroyPlane()
    {
        activeAirplanes.Remove(this);
        Destroy(gameObject);
    }
}

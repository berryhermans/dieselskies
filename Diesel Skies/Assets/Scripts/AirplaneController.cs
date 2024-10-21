using System;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class AirplaneController : NetworkBehaviour, IDamageable
{  
    [SerializeField] private Flight flight;
    [SerializeField] private Health health;
    [SerializeField] private List<Sensor> sensors;
    public PlayerController Player;

    private bool isInitialized = false;

    // private void Start() {
    //     health.OnHealthZero += DestroyPlane;
    // }

    // private void OnDestroy() {
    //     health.OnHealthZero -= DestroyPlane;
    // }

    public void Init(PlayerController player, Vector3 initialDirection)
    {
        if(isInitialized) throw new Exception("Init may only be called once.");

        Player = player;
        flight.SetTargetDirection(initialDirection);
        foreach (Sensor sensor in sensors)
        {
            sensor.Init(Player);
        }

        // foreach (TeamColor teamColor in GetComponentsInChildren<TeamColor>())
        // {
        //     teamColor.SetColor(owner.Value.Color);
        // }

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
        Destroy(gameObject);
    }
}

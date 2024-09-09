using System;
using UnityEngine;

public class AirplaneController : MonoBehaviour, IDamageable
{
    [SerializeField] private ScriptableListAirplaneController activeAirplanes;
    [SerializeField] private Flight flight;
    [SerializeField] private Health health;
    public int Owner { get; private set; }

    private bool isInitialized = false;
    private IWeapon[] weapons = new IWeapon[0];

    private void Awake() {
        weapons = GetComponentsInChildren<IWeapon>();
    }

    private void Start() {
        health.OnHealthZero += DestroyPlane;
    }

    private void Update() {
        foreach (IWeapon weapon in weapons)
        {
            weapon.Fire();
        }
    }

    private void OnDestroy() {
        health.OnHealthZero -= DestroyPlane;
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
        Debug.Log($"Set target to {target}, new direction = {target - transform.position}");
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

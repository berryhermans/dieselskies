using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private ScriptableListAirplaneController activeAirplanes;
    [SerializeField] private Flight flight;
    [field: SerializeField] public int Owner { get; private set; }

    private void Start() {
        activeAirplanes.Add(this);
    }

    public void SetTarget(Vector3 target)
    {
        flight.SetTargetDirection(target - transform.position);
    }
}

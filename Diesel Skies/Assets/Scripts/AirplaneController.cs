using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private Flight flight;
    [field: SerializeField] public int Owner { get; private set; }

    public void SetTarget(Vector3 target)
    {
        flight.SetTargetDirection(target - transform.position);
    }
}

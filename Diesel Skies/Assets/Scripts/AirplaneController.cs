using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private Flight flight;

    public void SetTarget(Vector3 target)
    {
        flight.SetTargetDirection(target - transform.position);
    }
}

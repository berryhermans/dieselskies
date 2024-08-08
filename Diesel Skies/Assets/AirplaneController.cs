using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private Flight flight;
    [SerializeField] private Transform target;

    private void Update() {
        flight.SetTargetDirection(target.position - transform.position);
    }
}

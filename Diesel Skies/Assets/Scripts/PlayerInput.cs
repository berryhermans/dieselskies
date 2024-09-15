using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    [field: SerializeField] public int Owner { get; private set; }
    [SerializeField] private ScriptableListAirplaneController activeAirplanes;

    public void SetNearestAirplaneTarget(Vector3 targetScreenPoint)
    {
        Vector3 inputWorldPos = Camera.main.ScreenToWorldPoint(targetScreenPoint);
        inputWorldPos.y = 0;

        AirplaneController nearestAirplane = null;
        foreach (AirplaneController airplane in activeAirplanes)
        {
            if (airplane.Team != Owner) continue;
            nearestAirplane = nearestAirplane != null ? nearestAirplane : airplane;
            
            if (Vector3.Distance(airplane.transform.position, inputWorldPos) < Vector3.Distance(nearestAirplane.transform.position, inputWorldPos))
            {
                nearestAirplane = airplane;
            }
        }

        if (!nearestAirplane) return;
        nearestAirplane.SetTarget(inputWorldPos);
    }

    
}

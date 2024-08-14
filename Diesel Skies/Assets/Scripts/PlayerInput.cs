using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [field: SerializeField] public int Owner { get; private set; }
    
    private void Update() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.y = 0;

        AirplaneController nearestAirplane = null;
        foreach (AirplaneController airplane in FindObjectsOfType<AirplaneController>())
        {
            nearestAirplane = nearestAirplane != null ? nearestAirplane : airplane;
            
            if (Vector3.Distance(airplane.transform.position, mouseWorldPos) < Vector3.Distance(nearestAirplane.transform.position, mouseWorldPos))
            {
                nearestAirplane = airplane;
            }
        }

        nearestAirplane.SetTarget(mouseWorldPos);
    }
}

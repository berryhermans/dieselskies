using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController Player;

    public void DetectInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button or single touch
        {
            SetNearestAirplaneTarget(Input.mousePosition);
        }
    }

    public void SetNearestAirplaneTarget(Vector3 targetScreenPoint)
    {
        Vector3 inputWorldPos = Camera.main.ScreenToWorldPoint(targetScreenPoint);
        inputWorldPos.y = 0;

        AirplaneController nearestAirplane = null;
        foreach (AirplaneController airplane in FindObjectsByType<AirplaneController>(FindObjectsSortMode.None))
        {
            if (airplane.Player != Player) continue;
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

using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> OnLeftMouseButton;
    [SerializeField] private UnityEvent<Vector3> OnMiddleMouseButton;
    [SerializeField] private UnityEvent<Vector3> OnRightMouseButton;
    
    private void Update() {
        DetectMouseInput();
    }

    public void DetectMouseInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            OnLeftMouseButton?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            OnRightMouseButton?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(2)) // Middle mouse button
        {
            OnMiddleMouseButton?.Invoke(Input.mousePosition);
        }
    }
}

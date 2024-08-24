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
            Debug.Log("Mouse click detected at position: " + Input.mousePosition);
            OnLeftMouseButton?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            Debug.Log("Right mouse click detected at position: " + Input.mousePosition);
            OnRightMouseButton?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(2)) // Middle mouse button
        {
            Debug.Log("Middle mouse click detected at position: " + Input.mousePosition);
            OnMiddleMouseButton?.Invoke(Input.mousePosition);
        }
    }
}

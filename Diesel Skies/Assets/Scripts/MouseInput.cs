using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<Vector3> OnLeftMouseButton { get; private set; }
    [field: SerializeField] public UnityEvent<Vector3> OnMiddleMouseButton { get; private set; }
    [field: SerializeField] public UnityEvent<Vector3> OnRightMouseButton { get; private set; }
    
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

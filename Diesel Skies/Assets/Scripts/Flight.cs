using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float moveSpeed = 10f;
    [SerializeField, Range(0, 360)] private  float turnSpeed = 5f;

    private Vector3 targetDirection;

    void Update()
    {
        // move
        transform.position += moveSpeed * Time.deltaTime * transform.forward;

        // turn
        if (turnSpeed > 0) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    public void SetTargetDirection(Vector3 direction)
    {
        targetDirection = direction.normalized;
    }
}

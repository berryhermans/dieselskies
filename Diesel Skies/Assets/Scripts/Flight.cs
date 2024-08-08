using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed = 10f;
    [SerializeField, Range(0, 360)] private  float turnSpeed = 5f;

    private Vector3 targetDirection;

    void Start()
    {
        SetTargetDirection(transform.forward);
    }

    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public void SetTargetDirection(Vector3 direction)
    {
        targetDirection = direction.normalized;
    }
}

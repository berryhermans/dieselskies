using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
	public Rigidbody Body;
	public Transform Target;
    [Range(0,360)]
    public float TurnStrength;

	// Use this for initialization
	void Start()
	{

	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion _targetRotation = Quaternion.LookRotation(Target.position - Body.position);
        Body.rotation = Quaternion.RotateTowards(Body.rotation, _targetRotation, TurnStrength * Time.deltaTime);
    }
}

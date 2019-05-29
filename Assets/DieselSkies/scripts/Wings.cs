using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
	//public Rigidbody Body;
    [Range(0,360)]
    public float YawRotateStrength;
	public InputBroadcaster Input;
    
    private float _targetYawRotation;

	void Start()
	{
		Input.Vector2Broadcasted += OnVector2BroadcastedHandler;
	}

    void Update()
    {
        Yaw();
		//Turn();
    }

	private void OnVector2BroadcastedHandler(Vector2 input)
	{
        // Set the target yaw by converting the given unit circle input to degrees
		_targetYawRotation = (Mathf.Atan2(input.y, input.x) / Mathf.PI) * 180f;

        Debug.Log(string.Format("input: {0} | degrees: {1}", input.ToString(), _targetYawRotation));
	}

    private void Yaw()
    {
        if (transform.rotation.y == _targetYawRotation) return;

        Quaternion targetRotation = Quaternion.Euler(transform.rotation.x, _targetYawRotation, transform.rotation.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, YawRotateStrength * Time.deltaTime);
    }
}
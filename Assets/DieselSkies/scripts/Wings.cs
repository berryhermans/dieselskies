using JuiceBox;
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
        Debug.Log(Utility.Vector2ToUnityDegrees(input));
        _targetYawRotation = Utility.Vector2ToUnityDegrees(input);
    }

    private void Yaw()
    {
        if (transform.rotation.y == _targetYawRotation) return;

        Quaternion targetRotation = Quaternion.Euler(transform.rotation.x, _targetYawRotation, transform.rotation.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, YawRotateStrength * Time.deltaTime);
    }
}
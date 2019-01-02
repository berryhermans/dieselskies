using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

	public Rigidbody body;
	[Range(0,1000)]
	public float Speed;

	// Update is called once per frame
	void FixedUpdate () {
		body.velocity = (body.rotation * Vector3.forward ) * (Speed * Time.deltaTime);
	}
}

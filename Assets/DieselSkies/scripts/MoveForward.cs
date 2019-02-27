using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveForward : MonoBehaviour {

	[Range(0,1000)]
	public float Speed;

    private Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
		_body.velocity = (_body.rotation * Vector3.forward ) * (Speed * Time.deltaTime);
	}
}

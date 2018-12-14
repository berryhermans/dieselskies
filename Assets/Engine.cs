using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

	public Transform BodyTrans;
	[Range(0,100)]
	public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		BodyTrans.Translate(Vector3.forward * Time.deltaTime * Speed);		
	}
}

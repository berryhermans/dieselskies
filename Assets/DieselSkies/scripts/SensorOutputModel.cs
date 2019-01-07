using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorOutputModel : MonoBehaviour {

	public GameObject Object { get; private set; }

	public SensorOutputModel(GameObject go)
	{
		Object = go;
	}
}

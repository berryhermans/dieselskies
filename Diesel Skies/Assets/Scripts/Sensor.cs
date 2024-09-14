using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    [SerializeField] private bool detectAirplanes;
    [SerializeField] private bool detectProjectiles;

    [field: SerializeField] public UnityEvent<List<GameObject>> OnDetect { get; private set; }
    private readonly List<GameObject> detectedGameObjects = new();

    private void OnTriggerEnter(Collider other) 
    {
        if(detectAirplanes && TryDetect(other, out AirplaneController _))
        {
            detectedGameObjects.Add(other.gameObject);
        }
        
        if(detectProjectiles && TryDetect(other, out Projectile _))
        {
            detectedGameObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(detectAirplanes && TryDetect(other, out AirplaneController _))
        {
            detectedGameObjects.Remove(other.gameObject);
        }
        
        if(detectProjectiles && TryDetect(other, out Projectile _))
        {
            detectedGameObjects.Remove(other.gameObject);
        }      
    }

    private void Update() 
    {
        if(detectedGameObjects.Count > 0)
        {
            OnDetect?.Invoke(detectedGameObjects);
        }
    }

    private bool TryDetect<T>(Collider other, out T detectedComponent)
    {
        detectedComponent = other.GetComponent<T>();
        detectedComponent ??= other.GetComponentInParent<T>();

        return detectedComponent != null;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    [SerializeField] private bool detectFriendlyAirplanes;
    [SerializeField] private bool detectEnemyAirplanes;
    [SerializeField] private bool detectProjectiles;
    [field: SerializeField] public UnityEvent<List<GameObject>> OnDetect { get; private set; }


    private readonly List<GameObject> detectedGameObjects = new();
    private int team;
    private bool isInitialized = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (!isInitialized) return;

        if((detectFriendlyAirplanes || detectEnemyAirplanes) && TryDetect(other, out AirplaneController airplane))
        {
            if (detectFriendlyAirplanes && airplane.Team == team) detectedGameObjects.Add(other.gameObject);
            if (detectEnemyAirplanes && airplane.Team != team) detectedGameObjects.Add(other.gameObject);
        }

        if(detectProjectiles && TryDetect(other, out Projectile _))
        {
            detectedGameObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (!isInitialized) return;

        // more efficient to just try to remove a gameObject than fetching components
        detectedGameObjects.Remove(other.gameObject);     
    }

    private void FixedUpdate() 
    {
        for (int i = detectedGameObjects.Count - 1; i >= 0 ; i--)
        {
            GameObject detected = detectedGameObjects[i];
            if (detected == null) detectedGameObjects.Remove(detected);
        }

        if(detectedGameObjects.Count > 0)
        {
            OnDetect?.Invoke(detectedGameObjects);
        }
    }

    public void Init(int team)
    {
        if(isInitialized) throw new Exception("Init may only be called once.");
        this.team = team;

        isInitialized = true;
    }

    private bool TryDetect<T>(Collider other, out T detectedComponent)
    {
        detectedComponent = other.GetComponent<T>();
        detectedComponent ??= other.GetComponentInParent<T>();

        return detectedComponent != null;
    }
}

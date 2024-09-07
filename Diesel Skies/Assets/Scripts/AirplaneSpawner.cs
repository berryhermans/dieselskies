using System.Collections;
using System.Linq;
using UnityEngine;

public class AirplaneSpawner : MonoBehaviour
{
    [SerializeField] private int owner;
    [SerializeField] private Vector3 initialFlightDirection;
    [SerializeField] private int maxActiveAirplanes;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private GameObject airplanePrefab;
    [SerializeField] private ScriptableListAirplaneController activeAirplanes;

    private float spawnTimer = 0;

    private void Start() {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        while(true)
        {
            if(spawnTimer >= spawnCooldown && activeAirplanes.Where(x => x.Owner == owner).ToArray().Length < maxActiveAirplanes)
            {
                Spawn();
                spawnTimer = 0;
            }
            else 
            {
                spawnTimer += Time.deltaTime;
            }
            yield return null;
        }
    }

    private void Spawn()
    {
        GameObject AirplaneObject = Instantiate(airplanePrefab, transform.position, Quaternion.LookRotation(initialFlightDirection));
        AirplaneController airplaneController = AirplaneObject.GetComponent<AirplaneController>();
        airplaneController.Init(owner, initialFlightDirection);
    }
}

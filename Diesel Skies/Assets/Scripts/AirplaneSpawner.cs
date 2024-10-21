using FishNet.Object;
using UnityEngine;

// TODO: does it **need** to be a networkbehaviour in order to spawn things?
public class AirplaneSpawner : NetworkBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Vector3 initialFlightDirection;
    [SerializeField] private int maxActiveAirplanes;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private GameObject airplanePrefab;

    private float nextSpawnTime = 0;

    public void TrySpawn()
    {
        if (nextSpawnTime > Time.time)
            return;

        ServerSpawn();
        nextSpawnTime = Time.time + spawnCooldown;
    }

    [ServerRpc]
    private void ServerSpawn()
    { 
        GameObject airplaneObject = Instantiate(airplanePrefab, transform.position, Quaternion.LookRotation(initialFlightDirection));
        ServerManager.Spawn(airplaneObject, player.Owner);
        InitAirplane(airplaneObject.GetComponent<AirplaneController>());
    }

    [ObserversRpc]
    private void InitAirplane(AirplaneController airplane)
    {
        airplane.Init(player, initialFlightDirection);
    }
}

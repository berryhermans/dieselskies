using FishNet.Object;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private AirplaneSpawner spawner;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner) 
        {
        } 
        else
        {
            enabled = false;
        }
    }

    private void Update() 
    {
        input.DetectInput();
        spawner.TrySpawn();
    }
}

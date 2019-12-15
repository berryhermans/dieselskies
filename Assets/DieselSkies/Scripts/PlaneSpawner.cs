using JuiceBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public int PlayerId;
    public float SpawnOffset;
    public SpawnEdge Edge;
    public MeshCollider PlayArea;
    public GameObject PlanePrefab;

    private void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }

    public void Spawn()
    {
        Bounds bounds = PlayArea.bounds;
        Vector3 min;
        Vector3 max;

        switch (Edge)
        {
            case SpawnEdge.TOP:
                min = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
                max = bounds.max;
                break;

            case SpawnEdge.RIGHT:
                min = bounds.max;
                max = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
                break;

            case SpawnEdge.BOTTOM:
                min = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
                max = bounds.min;
                break;

            case SpawnEdge.LEFT:
                min = bounds.min;
                max = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
                break;

            default:
                Debug.LogErrorFormat("Unknown SpawnEdge '{0}'", Edge);
                return;
        }
        // get a random point on the edge
        Vector3 spawnPosition = VectorUtility.RandomRange(min, max);
        // get the rotation looking at the center of the play area
        Quaternion spawnRotation = Quaternion.LookRotation((PlayArea.bounds.center - spawnPosition), Vector3.up);

        // spawn a plane on the edge, looking towards the center
        GameObject Plane = Instantiate(PlanePrefab, spawnPosition, spawnRotation);
    }

    public enum SpawnEdge
    {
        TOP,
        RIGHT,
        BOTTOM,
        LEFT
    }
}

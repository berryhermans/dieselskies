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
        Vector3 RandomPointOnEdge = VectorUtility.RandomRange(min, max);
    }

    public enum SpawnEdge
    {
        TOP,
        RIGHT,
        BOTTOM,
        LEFT
    }
}

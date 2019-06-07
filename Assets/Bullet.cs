using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (true)
        {
            // if hitting a hull, do damage and destroy self.
        }
    }
}

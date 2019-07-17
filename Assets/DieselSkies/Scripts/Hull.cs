using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour, IDamagable
{
    public float Health;

    void IDamagable.TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
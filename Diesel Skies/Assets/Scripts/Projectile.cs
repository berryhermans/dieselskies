using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float duration;

    private float selfDestructTime;

    private void Start()
    {
        selfDestructTime = Time.time + duration;
    }

    private void Update()
    {
        if (Time.time >= selfDestructTime) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>() ?? other.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

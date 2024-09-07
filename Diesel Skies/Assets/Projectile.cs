using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float duration;

    private float selfDestructTime;

    private void Start() {
        selfDestructTime = Time.time + duration;
    }   

    private void Update() {
        if (Time.time >= selfDestructTime) Destroy(gameObject);
    } 
}
